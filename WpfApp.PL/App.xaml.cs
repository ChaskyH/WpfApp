using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.PL.Commands;

namespace WpfApp.PL
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public NavigationCommand NavigationCommand
        {
            get { return Resources["NavigationCommand"] as NavigationCommand; }
        }
    }
}
