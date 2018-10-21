using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;
using System.Windows.Input;
using WpfApp.BLL;
using WpfApp.DataProtocol;

namespace WpfApp.PL.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase, LogInViewModel.ILogin
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            Title = "Nutrition Tracker";

            LogOutCommand = new RelayCommand(
                () => {
                    User = null;
                    Properties.Settings.Default["UserId"] = "";
                    Properties.Settings.Default.Save();
                }
             );

            ExitCommand = new RelayCommand(
                () => Application.Current.Shutdown()
            );

            // bring the user guid from default settings
            try
            {
                string userId = Properties.Settings.Default["UserId"] as string;
                UsersLogic usersLogic = new UsersLogic();
                User = usersLogic.GetUser(new Guid(userId));
            }
            catch (Exception ex)
            {

            }
        }
        
        private string _title = "";
        public string Title
        {
            get { return _title; }
            set 
            {
                if (_title == value)
                {
                    return;
                }
                _title = value;
                RaisePropertyChanged("Title");
            }
        }

        private User _user;
        public User User
        {
            get { return _user; }
            set
            {
                if (_user == value)
                    return;

                _user = value;

                RaisePropertyChanged("User");
                IsUserLoggedIn = _user != null;
            }
        }

        private bool _isUserLoggedIn = false;
        public bool IsUserLoggedIn
        {
            get
            {
                if (IsInDesignMode)
                    return true;

                return _isUserLoggedIn;
            }
            set
            {
                if (_isUserLoggedIn == value)
                    return;

                _isUserLoggedIn = value;
                RaisePropertyChanged("IsUserLoggedIn");
            }
        }

        public bool Login(Credentials credentials)
        {
            UsersLogic usersLogic = new UsersLogic();
            User = usersLogic.GetUser(credentials);

            if (IsUserLoggedIn && credentials.RememberMe)
            {
                Properties.Settings.Default["UserId"] = User.Id.ToString();
                Properties.Settings.Default.Save();
            }

            return User != null;
        }

        public ICommand LogOutCommand { get; set; }
        public ICommand ExitCommand { get; set; }
    }
}