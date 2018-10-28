using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp.PL.Controls;

namespace WpfApp.PL.Commands
{
    public class NavigationCommand : ICommand
    {
        public enum Navigation
        {
            None, Back, FoodBrowser, Dashboard, AddMeal, AccountInfo, Meals
        }

        public NavigationCommand()
        {
            UserControls = new Stack<UserControl>();
        }

        public MainWindow MainWindow { get; set; }

        public Stack<UserControl> UserControls { get; set; }


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is string)
            {
                Navigation navigation = (Navigation)Enum.Parse(typeof(Navigation), parameter as string);

                UserControl uc = GetControl(navigation);

                if (uc != null)
                {
                    UserControls.Push(uc);
                    MainWindow.ShowControl(uc);
                }

            }
        }

        public UserControl GetControl(Navigation navigation)
        {
            UserControl res = null;

            switch (navigation)
            {
                case Navigation.None:
                    UserControls.Clear();
                    break;
                case Navigation.Back:
                    if (UserControls.Count() > 0)
                        res = UserControls.Pop();
                    if (UserControls.Count() > 0)
                        res = UserControls.Pop();
                    break;
                case Navigation.FoodBrowser:
                    res = new FoodBrowser();
                    break;
                case Navigation.Dashboard:
                    UserControls.Clear();
                    res = new DashboardControl();
                    break;
                case Navigation.AddMeal:
                    res = new AddMealControl();
                    break;
                case Navigation.AccountInfo:
                    res = new GoalsControl();
                    break;
                case Navigation.Meals:
                    res = new MealsControl();
                    break;
            }

            return res;
        }
    }
}
