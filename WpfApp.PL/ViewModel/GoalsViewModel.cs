using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.BLL;
using WpfApp.DataProtocol;

namespace WpfApp.PL.ViewModel
{
    public class GoalsViewModel : ViewModelBase
    {
        public GoalsViewModel()
        {
            AddGoadCommand = new RelayCommand(AddGoal);
            Goals = new Goals()
            {
                GoalStartDate = DateTime.Today
            };
        }

        public RelayCommand AddGoadCommand { get; set; }

        void AddGoal()
        {
            GoalsLogic goalsLogic = new GoalsLogic();
            goalsLogic.AddGoal(User, Goals);

            (App.Current as App).NavigationCommand.Execute("Dashboard");
        }

        /// <summary>
        /// The <see cref="User" /> property.
        /// </summary>
        private User _User = null;
        public User User
        {
            get
            {
                return _User;
            }
            set
            {
                if (_User == value)
                {
                    return;
                }
                _User = value;
                RaisePropertyChanged("User");
            }
        }

        /// <summary>
        /// The <see cref="Goals" /> property.
        /// </summary>
        private Goals _Goals = new Goals();
        public Goals Goals
        {
            get
            {
                return _Goals;
            }
            set
            {
                if (_Goals == value)
                {
                    return;
                }
                _Goals = value;
                RaisePropertyChanged("Goals");
            }
        }
    }
}
