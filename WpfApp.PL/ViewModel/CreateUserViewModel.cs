using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp.BLL;
using WpfApp.DataProtocol;
using WpfApp.PL.Validators;
using WpfApp.BLL.Validation;

namespace WpfApp.PL.ViewModel
{
    public class CreateUserViewModel : ViewModelBase
    {

        public CreateUserViewModel()
        {
            CreateUserCommand = new RelayCommand(
                () => CreateUser(),
                () => CanCreateUser()
                );

            SnackbarMessageQueue = new SnackbarMessageQueue(TimeSpan.FromSeconds(2));
        }
        
        // Commands
        public RelayCommand CreateUserCommand { get; set; }

        public SnackbarMessageQueue SnackbarMessageQueue { get; set; }

        
        public override void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.RaisePropertyChanged(propertyName);
            CreateUserCommand.RaiseCanExecuteChanged();
        }

        /// <summary>
        /// The <see cref="FirstName" /> property.
        /// </summary>
        private String _FirstName = "";
        public String FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                if (_FirstName == value)
                {
                    return;
                }
                _FirstName = value;
                RaisePropertyChanged("FirstName");
            }
        }

        /// <summary>
        /// The <see cref="LastName" /> property.
        /// </summary>
        private String _LastName = "";
        public String LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                if (_LastName == value)
                {
                    return;
                }
                _LastName = value;
                RaisePropertyChanged("LastName");
            }
        }

        /// <summary>
        /// The <see cref="BirthDay" /> property.
        /// </summary>
        private DateTime _BirthDay = DateTime.Now;
        public DateTime BirthDay
        {
            get
            {
                return _BirthDay;
            }
            set
            {
                if (_BirthDay == value)
                {
                    return;
                }
                _BirthDay = value;
                RaisePropertyChanged("BirthDay");
            }
        }

        /// <summary>
        /// The <see cref="Email" /> property.
        /// </summary>
        private String _Email = "";
        public String Email
        {
            get
            {
                return _Email;
            }
            set
            {
                if (_Email == value)
                {
                    return;
                }
                _Email = value;
                RaisePropertyChanged("Email");
            }
        }

        /// <summary>
        /// The <see cref="Password" /> property.
        /// </summary>
        private String _Password = "";
        public String Password
        {
            get
            {
                return _Password;
            }
            set
            {
                if (_Password == value)
                {
                    return;
                }
                _Password = value;
                RaisePropertyChanged("Password");
            }
        }

        /// <summary>
        /// The <see cref="PasswordValidation" /> property.
        /// </summary>
        private String _PasswordValidation = "";
        public String PasswordValidation
        {
            get
            {
                return _PasswordValidation;
            }
            set
            {
                if (_PasswordValidation == value)
                {
                    return;
                }
                _PasswordValidation = value;
                RaisePropertyChanged("PasswordValidation");
            }
        }

        private bool CanCreateUser()
        {
            return true;
        }

        private void CreateUser()
        {
            UsersLogic usersLogic = new UsersLogic();

            if (FirstName.Length == 0)
            {
                SnackbarMessageQueue.Enqueue("First Name Required");
            }
            else if (LastName.Length == 0)
            {
                SnackbarMessageQueue.Enqueue("Last Name Required");
            }
            else if (!usersLogic.BirthDayValidator.Validate(BirthDay))
            {
                SnackbarMessageQueue.Enqueue("Invalid BirthDay");
            }
            else if (!usersLogic.EmailValidator.Validate(Email))
            {
                SnackbarMessageQueue.Enqueue("Invalid Email");
            }
            else if (!usersLogic.PasswordStrengthValidator.Validate(Password))
            {
                SnackbarMessageQueue.Enqueue("Password is not strong enough. Min 6 charaters required.");
            }
            else if (Password != PasswordValidation)
            {
                SnackbarMessageQueue.Enqueue("Passwords Don't Match");
            }
            else
            {
                var res = usersLogic.CreateUser(FirstName, LastName, BirthDay, Email, Password);

                switch (res)
                {
                    case UsersLogic.CreationStatus.Created:
                        SnackbarMessageQueue.Enqueue("Successfull created user!", 
                                                     "Sign In", 
                                                     // TODO: BAD MVVM
                                                     () => { Flipper.FlipCommand.Execute(null, null); });
                        break;
                    case UsersLogic.CreationStatus.UserWithThisEmailAlreadyExists:
                        SnackbarMessageQueue.Enqueue("There already exists a user with this email.");
                        break;
                }
            }
        }

    }
}
