using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using WpfApp.DataProtocol;

namespace WpfApp.PL.ViewModel
{
    public class LogInViewModel : ViewModelBase
    {
        public interface ILogin
        {
            bool Login(Credentials credentials);
        }

        public LogInViewModel()
        {
            Credentials = new Credentials();

            LogInCommand = new RelayCommand(
                () => { Login.Login(Credentials); },
                () => { return Email.Length > 0 && Password.Length > 0; },
                true
                );
        }

        public Credentials Credentials { get; set; }

        public ILogin Login { get; set; }
        
        public String Email
        {
            get
            {
                 return Credentials.Email;
            }
            set
            {
                if (Credentials.Email == value)
                {
                    return;
                }
                Credentials.Email = value;
                RaisePropertyChanged("Email");
                LogInCommand.RaiseCanExecuteChanged();
            }
        }
        
        public String Password
        {
            get
            {
                return Credentials.Password;
            }
            set
            {
                if (Credentials.Password == value)
                {
                    return;
                }
                Credentials.Password = value;
                RaisePropertyChanged("Password");
                LogInCommand.RaiseCanExecuteChanged();
            }
        }

        public bool RememberMe
        {
            get
            {
                return Credentials.RememberMe;
            }
            set
            {
                if (Credentials.RememberMe == value)
                {
                    return;
                }
                Credentials.RememberMe = value;
                RaisePropertyChanged("RememberMe");
            }
        }

        public RelayCommand LogInCommand { get; set; }
    }
}
