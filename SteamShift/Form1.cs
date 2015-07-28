using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;

using System.Globalization;

namespace SteamShift
{
	public partial class Form1 : Form
	{
		#region Varaible Declarations and P/Invoke stubs
		string steamPath = null;

		List<string> Libraries = new List<string>();

		// P/Invoke constants
		[DllImport( "kernel32.dll", SetLastError = true, CharSet = CharSet.Auto )]
		[return: MarshalAs( UnmanagedType.Bool )]
		static extern bool GetDiskFreeSpaceEx( string lpDirectoryName, out ulong lpFreeBytesAvailable, out ulong lpTotalNumberOfBytes, out ulong lpTotalNumberOfFreeBytes );

		#endregion

		protected class ItemData
		{
			public string name { get; set; }
			public string appdir { get; set; }
			public string vcf { get; set; }

			public override string ToString()
			{
				return name;
			}
		}

		#region Construction
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load( object sender, EventArgs e )
		{
			if( !GetSteamPath() )
				this.Close();

			ParseVDF();
			PopulateGUI();
		}
		#endregion

		// HKEY_CURRENT_USER\Software\Valve\Steam
		private bool GetSteamPath()
		{
			RegistryKey rk = Registry.CurrentUser;
			RegistryKey rkSteam = rk.OpenSubKey( "Software\\Valve\\Steam" );
			steamPath = ((string)rkSteam.GetValue( "SteamPath" ) ).Replace( "/", "\\" );

			if ( steamPath.CompareTo( String.Empty ) == 0 )
			{
				MessageBox.Show( "Failed to find your Steam installation" + Environment.NewLine + Environment.NewLine +
					"Steam is not installed correctly on this computer Reinstall Steam and try again.",
					"Cannot Locate Steam Folder", MessageBoxButtons.OK, MessageBoxIcon.Error );
				return false;
			}

			if ( !ParseVDF() )
			{
				MessageBox.Show( "Failed to determine the location of Steam libraries." + Environment.NewLine + Environment.NewLine +
					"This usually happens if the path to the Steam Installation folder is not set correctly, or your Steam installation " +
					"is not configured with multiple libraries.",
					"Cannot Locate Steam Libraries",
					MessageBoxButtons.OK, MessageBoxIcon.Error );
				return false;
			}

			return true;
		}

		private bool ParseVDF()
		{
			string sFile = Path.Combine( steamPath, "SteamApps\\libraryfolders.vdf" );
			if ( !File.Exists( sFile ) )
				return false;

			Libraries.Clear();
			Libraries.Add( ConvertTo_ProperCase( steamPath ) );

			int n = 0;
			bool bOK = true;
			foreach ( var line in File.ReadLines( sFile ) )
			{
				n++;
				switch ( line )
				{
					case "\"LibraryFolders\"":
						if ( n != 1 )
							bOK = false;
						break;

					case "{":
						if ( n != 2 )
							bOK = false;
						break;

					case "}":
						break;

					default:
						{
							string sLib = line.Substring( line.LastIndexOf( "\t" ) + 1 ).Replace( "\"", "" ).Replace( "\\\\", "\\" );
							Libraries.Add( sLib );
						}
						break;
				}

				if ( !bOK )
				{
					MessageBox.Show( "Unexpected characters on line " + n.ToString() + " in file " + sFile, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning );
					return false;					
				}
			}

			if ( Libraries.Count < 2 )
			{
				MessageBox.Show( "Your Steam installation does not appear to contain multiple libraries." + Environment.NewLine + Environment.NewLine +
					"To use this utility, you must first create a second library in Steam. You can do this do by clicking the \"Steam Library Folders\" button " +
					"under \"Settings\" | \"Downloads\" in Steam.", "Cannot Locate Additional Steam Libraries", MessageBoxButtons.OK, MessageBoxIcon.Information );
				return false;
			}

			return true;
		}

		private void PopulateGUI()
		{
			cboLeft.Items.Clear();
			cboRight.Items.Clear();

			if ( Libraries.Count > 1 )
			{
				for ( int nIndex = 0; nIndex < Libraries.Count; nIndex++ )
				{
					if ( nIndex != 1 )
						cboLeft.Items.Add( Libraries[nIndex] );
	
					if (nIndex != 0 )
						cboRight.Items.Add( Libraries[nIndex] );
				}

				cboLeft.SelectedIndex = 0;
				cboRight.SelectedIndex = 0;

				PopulateList( cboLeft.SelectedItem.ToString(), listLeft );
				PopulateList( cboRight.SelectedItem.ToString(), listRight );

				UpdateFreeSpace( cboLeft.SelectedItem.ToString(), labelFreeSpaceLeft );
				UpdateFreeSpace( cboRight.SelectedItem.ToString(), labelFreeSpaceRight );

				this.cboLeft.SelectedIndexChanged += new System.EventHandler( this.cboLeft_SelectedIndexChanged );
				this.cboRight.SelectedIndexChanged += new System.EventHandler( this.cboRight_SelectedIndexChanged );
			}

			ResizeColumns();
		}

		private void cboLeft_SelectedIndexChanged( object sender, EventArgs e )
		{
			cboRight.Items.Remove( cboLeft.SelectedItem );

			foreach ( string lib in Libraries )
			{
				if ( lib != cboLeft.SelectedItem && !cboRight.Items.Contains( lib ) )
					cboRight.Items.Add( lib );
			}

			PopulateList( cboLeft.SelectedItem.ToString(),  listLeft );
			UpdateFreeSpace( cboLeft.SelectedItem.ToString(), labelFreeSpaceLeft );
		}

		private void cboRight_SelectedIndexChanged( object sender, EventArgs e )
		{
			cboLeft.Items.Remove( cboRight.SelectedItem );

			foreach ( string lib in Libraries )
			{
				if ( lib != cboRight.SelectedItem && !cboLeft.Items.Contains( lib ) )
					cboLeft.Items.Add( lib );
			}

			PopulateList( cboRight.SelectedItem.ToString(), listRight );
			UpdateFreeSpace( cboRight.SelectedItem.ToString(), labelFreeSpaceRight );
		}

		private void PopulateList( string sLib, ListView vw )
		{
			vw.Items.Clear();

			sLib = Path.Combine( sLib, "steamapps" );
			if ( !Directory.Exists( sLib ) )
				return;

			foreach( string sFile in Directory.EnumerateFiles( sLib, "appmanifest_*.acf", System.IO.SearchOption.TopDirectoryOnly ) )
			{
				double size = 0;
				string name = string.Empty;
				ItemData item = new ItemData();
				item.vcf = Path.GetFileName( sFile );

				foreach ( var line in File.ReadLines( sFile ) )
				{
					if ( line.Contains( "\t\"SizeOnDisk\"" ) )
					{
						size = Convert.ToDouble( line.Substring( line.LastIndexOf( "\t" ) + 1 ).Replace( "\"", "" ) );
						size /= 1073741824; // 1024 * 1024 * 1024

					}

					if ( line.Contains( "\t\"name\"" ) )
					{
						item.name = line.Substring( line.LastIndexOf( "\t" ) + 1 ).Replace( "\"", "" );
					}

					if ( line.Contains( "\t\"installdir\"" ) )
						item.appdir = line.Substring( line.LastIndexOf( "\t" ) + 1 ).Replace( "\"", "" );
				}

				ListViewItem lvItem = vw.Items.Add( item.name );
				lvItem.SubItems.AddRange( new string[] { size.ToString( "F01" ) } );
				lvItem.Tag = item;
			}
		}

		protected void UpdateFreeSpace( string sLib, Label label )
		{
			ulong FreeBytesAvailable, TotalNumberOfBytes, TotalNumberOfFreeBytes;
			bool success = GetDiskFreeSpaceEx( sLib, out FreeBytesAvailable, out TotalNumberOfBytes, out TotalNumberOfFreeBytes );

			label.Text = "Free Space (Gb): " + ( (double)FreeBytesAvailable / 1073741824 ).ToString("F01");
		}

		private void Form1_Resize( object sender, EventArgs e )
		{
			ResizeColumns();
		}

		private void ResizeColumns()
		{
			listLeft.Columns[ 0 ].Width = listLeft.Width - ( listLeft.Columns[ 1 ].Width + 5 );
			listRight.Columns[ 0 ].Width = listRight.Width - ( listRight.Columns[ 1 ].Width + 5 );
		}

		private void listLeft_ItemSelectionChanged( object sender, ListViewItemSelectionChangedEventArgs e )
		{
			if ( listLeft.SelectedItems.Count > 0 )
			{
				btnMove.Enabled = true;
				btnMove.Text = "-->";
			}
			else
				btnMove.Enabled = false;
		}

		private void listRight_ItemSelectionChanged( object sender, ListViewItemSelectionChangedEventArgs e )
		{
			if ( listRight.SelectedItems.Count > 0 )
			{
				btnMove.Enabled = true;
				btnMove.Text = "<--";
			}
			else
				btnMove.Enabled = false;
		}

		private void btnMove_Click( object sender, EventArgs e )
		{
			using ( Cursor.Current = Cursors.WaitCursor )
			{
				// Move left to right
				if ( btnMove.Text.Contains( ">" ) )
				{
					foreach ( ListViewItem lvi in listLeft.SelectedItems )
					{
						ItemData item = lvi.Tag as ItemData;

						string srcDir = Path.Combine( cboLeft.SelectedItem.ToString(), "steamapps\\common", item.appdir );
						string destDir = Path.Combine( cboRight.SelectedItem.ToString(), "steamapps\\common", item.appdir );

						string srcVCF = Path.Combine( cboLeft.SelectedItem.ToString(), "steamapps", item.vcf );
						string destVCF = Path.Combine( cboRight.SelectedItem.ToString(), "steamapps", item.vcf );

						if ( MoveDirectory( srcDir, destDir ) )
							File.Move( srcVCF, destVCF );
					}
				}
				// Move right to left
				else
				{
					foreach ( ListViewItem lvi in listRight.SelectedItems )
					{
						ItemData item = lvi.Tag as ItemData;

						string srcDir = Path.Combine( cboRight.SelectedItem.ToString(), "steamapps\\common", item.appdir );
						string destDir = Path.Combine( cboLeft.SelectedItem.ToString(), "steamapps\\common", item.appdir );

						string srcVCF = Path.Combine( cboRight.SelectedItem.ToString(), "steamapps", item.vcf );
						string destVCF = Path.Combine( cboLeft.SelectedItem.ToString(), "steamapps", item.vcf );

						if ( MoveDirectory( srcDir, destDir ) )
							File.Move( srcVCF, destVCF );
					}
				}

				string sLeft = cboLeft.SelectedItem.ToString();
				string sRight = cboRight.SelectedItem.ToString();

				PopulateGUI();

				cboLeft.SelectedItem = sLeft;
				cboRight.SelectedItem = sRight;
			}
		}

		protected bool MoveDirectory( string src, string dest )
		{
			bool bSuccess = true;
			try
			{
				if ( Path.GetPathRoot( src ).ToLower() == Path.GetPathRoot( dest ).ToLower() )
					FileSystem.MoveDirectory( src, dest, UIOption.AllDialogs );
				else
				{
					FileSystem.CopyDirectory( src, dest, UIOption.AllDialogs );
					try
					{
						FileSystem.DeleteDirectory( src, DeleteDirectoryOption.DeleteAllContents );
					}
					catch ( Exception ex )
					{
						MessageBox.Show( "Unable to remove contents of original folder." + Environment.NewLine + Environment.NewLine +
							"The data was successfully copied to the new location, but an error occurred trying to remove the files from the old location. " +
							"You can manually delete the contents of the following folder:" + Environment.NewLine + Environment.NewLine + dest,
							"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning );
					}
				}
			}
			catch ( Exception e )
			{
				FileSystem.DeleteDirectory( dest, DeleteDirectoryOption.DeleteAllContents );
				MessageBox.Show( e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error ); 
				bSuccess = false;
			}
			return bSuccess;
		}

		public static string ConvertTo_ProperCase( string text )
		{
			TextInfo myTI = new CultureInfo( "en-US", false ).TextInfo;
			return myTI.ToTitleCase( text.ToLower() );
		}
	}
}
