using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Python.Runtime;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI3Pythonnet
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow( )
        {
            this.InitializeComponent( );
        }

        private async Task TestPython( )
        {
            using ( Py.GIL( ) )
            {
                dynamic sys = Py.Import( "sys" );
            }
        }

        private void myButton_Click( object sender, RoutedEventArgs e )
        {
            myButton.Content = "Clicked";
            Runtime.PythonDLL = "C:\\python\\python310.dll";
            PythonEngine.Initialize( );

            using ( Py.GIL( ) )
            {
                dynamic sys = Py.Import( "sys" );
                string version = sys.version;
                System.Diagnostics.Debug.WriteLine( "Version: {0}", version, null );
            }

            //Task.Run( ( ) => this.TestPython( ) );
        }
    }
}
