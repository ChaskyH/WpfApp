/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:WpfApp.PL"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using CommonServiceLocator;
using System;

namespace WpfApp.PL.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<LogInViewModel>();
            SimpleIoc.Default.Register<CreateUserViewModel>();
            SimpleIoc.Default.Register<FoodBrowserViewModel>();
            SimpleIoc.Default.Register<AddMealViewModel>();
            SimpleIoc.Default.Register<MealsViewModel>();
            SimpleIoc.Default.Register<GoalsViewModel>();
            SimpleIoc.Default.Register<DashboardViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public LogInViewModel Login
        {
            get
            {
                var login = ServiceLocator.Current.GetInstance<LogInViewModel>();
                login.Login = Main;
                return login;
            }
        }

        public CreateUserViewModel CreateUser
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CreateUserViewModel>();
            }
        }

        public FoodBrowserViewModel FoodBrowser
        {
            get
            {
                return ServiceLocator.Current.GetInstance<FoodBrowserViewModel>(Guid.NewGuid().ToString());
            }
        }

        public AddMealViewModel MealAdder
        {
            get
            {
                var res = ServiceLocator.Current.GetInstance<AddMealViewModel>();
                res.User = Main.User;
                return res;
            }
        }

        public MealsViewModel Meals
        {
            get
            {
                var res = ServiceLocator.Current.GetInstance<MealsViewModel>();
                res.User = Main.User;
                return res;
            }
        }

        public GoalsViewModel Goals
        {
            get
            {
                var res = ServiceLocator.Current.GetInstance<GoalsViewModel>();
                res.User = Main.User;
                return res;
            }
        }

        public DashboardViewModel Dashboard
        {
            get
            {
                var res = ServiceLocator.Current.GetInstance<DashboardViewModel>();
                res.User = Main.User;
                return res;
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}