   M S B A M L   `   `   `  ����D  @WpfApp.PL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WpfApp.PL	WpfApp.PL  5   	   7 clr-namespace:WpfApp.PL.ControlsWpfApp.PL.Controls  5   	   9!clr-namespace:WpfApp.PL.ViewModelWpfApp.PL.ViewModel  5   	       WpfApp.PL.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:WpfApp.PL     5   	   5controls clr-namespace:WpfApp.PL.Controls     5   	   1vms!clr-namespace:WpfApp.PL.ViewModel     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
   	   b ^GalaSoft.MvvmLight.Platform, Version=5.4.1.0, Culture=neutral, PublicKeyToken=5f873c45e98af8a1*cmd http://www.galasoft.ch/mvvmlight  5   	     � WindowStartupLocation$  CenterScreen=�5   	    � WindowStyle$
 None=�5   	   $	��680��5   	   $
��1200��5   	    � DataContext 5   	   ��    ViewModelLocator �� Source# [   �� Path$
 Main� � 	Resources 5        OpenMenu �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime	 O� Value  	CloseMenu��%�  &	       &	 �     �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5        $ 0��6'   $	 70Q�63     5      $ 0:0:0.5��6'   $		 200Q�69   5      5      �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5        $ 0��6'   $		 200Q�63     5      $ 0:0:0.5��6'   $	 70Q�69   5      5      5      .��5       )  #MaterialDesignThemes.Wpf.DialogHost  -   5        
  Name$
 
RootDialog��5           
Identifier$ 
RootDialog��64   $��0,6,0,-6q�6�      IsOpen 6L   �� *IsUserLoggedIn+ �� Mode$ OneWay=�   InverseBooleanValueConverter �� 	Converter# [    DialogContent 5"   
   � 5#      .+�5$      &   MaterialDesignThemes.Wpf.Flipper    MaterialDesignCardFlipper#��[ 5%         FrontContent 5&      %   WpfApp.PL.Controls.LogInControl  5'         BackContent 5)      *   $WpfApp.PL.Controls.CreateUserControl  5*      5,      5-      .��50   
   �  � RowDefinitions 51      �� 52      $
��auto �6    �� 53      $��* �6     � ColumnDefinitions 55      �� 56      $
��auto �6#   �� 57      $��* �6#   .+�59      � $��2��6   $��60��6'   $	��Top=�63     AccentBrush#��[ 6K    J� Effect 5:      3  -System.Windows.Media.Effects.DropShadowEffect  5;         
BlurRadius$ 1Q�6'      ShadowDepth$ 1Q�66      Color$ 	#FFACACAC��6F   .+�5=      ��  �� Orientation$ 
Horizontal=�6   $��Right=�66   .+�5>      #  MaterialDesignThemes.Wpf.Chip  {�.  
���������6<   �� *User.FullName+   Icon 6^   �� $ User.Initials�6�   '  !MaterialDesignThemes.Wpf.PopupBox  5?         PlacementMode$ BottomAndAlignRightEdges=�6.      	StaysOpen .  $��10q�6i   
�������   PopupContent. 5@      �� $	��150��6%   .+�5A      �� $��Settings��6%   �� 5B      $��Goals��6%     NavigationCommand#��[ 65   $��AccountInfo��6b   �� 5C      $��About��6%   �� 5D      �� 5E      $��Logout��6%   ��66   �� *LogOutCommand+�� 5F      $
��Exit��6%   ��64   �� *ExitCommand+5G      5H      5I      �� 5J      $��Center=�6   $��Center=�69   $��22(�6T   
���������6b   �� *Title+6y   5K      � 5L      -   5         �Name$ GridMenu��5L   $   $��2��6   $��70��66   $
��Left=�6A     PrimaryBrush#��[ 6\   .+�5M      �� .+�5N      � $��60��6   #��[ 6'   .+�5O      d�  ' #MaterialDesignHamburgerToggleButton#��[ 6'   
�������$��25��5Q   '   $��25��63   $��Right=�5R   %   $��10 10 25 10q�6A    � Triggers 5S      :� 5T   "    :� RoutedEvent$ ToggleButton.Checked��6/   .[�5U   &   �� #��[ 66   5V   #   :� 5W   "   $ ToggleButton.Unchecked��6/   .[�5X   &   �� #��[ 66   5Y   #   5[      5\      �� 5]      -   5          ��Name$  ListViewMenu��5]      
�������$��Disabled=�6H   .@�5^      �� $��60��6'   .	  (System.Windows.Interactivity.Interaction! 	  Triggers! 5_      /
  )System.Windows.Interactivity.EventTrigger
  5`   "   " 
  	EventName$" MouseLeftButtonUp��61   .  (System.Windows.Interactivity.TriggerBase#   Actions.# 5a   &   /  )GalaSoft.MvvmLight.Command.EventToCommand  $   Command#$ [ 69   %   CommandParameter$
% Back��6f   5b   #   .��5d      �� $ 
Horizontal=�6)   .+�5e   "   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=null]]&   Kind$& ArrowLeftBold=�6:   $��25��6O   $��25��6[   $��10q�6f   �� 5f   "   $
��Back��6,   $��Center=�68   $��20 10q�6S   5g      5h      �� 5i      -   5        ' ��Name$' ItemHome��5i   '   $��60��69   ! 5j      
  5k   "   $" MouseLeftButtonUp��61   .# 5l   &     #$ [ 69   $% 	Dashboard��6f   5m   #   .��5o      �� $ 
Horizontal=�6)   .+�5p   "     $& ViewDashboard=�6:   $��25��6O   $��25��6[   $��10q�6f   �� 5q   "   $
��Home��6,   $��Center=�68   $��20 10q�6S   5r      5s      �� 5t      $��60��6'   ! 5u      
  5v   "   $" MouseLeftButtonUp��61   .# 5w   &     #$ [ 69   $% FoodBrowser��6f   5x   #   .��5z      �� $ 
Horizontal=�6)   .+�5{   "     $& Magnify=�6:   $��25��6I   $��25��6U   $��10q�6`   �� 5|   "   $��Browse Foods��6,   $��Center=�6@   $��20 10q�6[   5}      5~      �� 5      $��60��6'   ! 5�      
  5�   "   $" MouseLeftButtonUp��61   .# 5�   &     #$ [ 69   $% AddMeal��6f   5�   #   .��5�      �� $ 
Horizontal=�6)   .+�5�   "     $
& Plus=�6:   $��25��6F   $��25��6R   $��10q�6]   �� 5�   "   $��Add Meal��6,   $��Center=�6<   $��20 10q�6X   5�      5�      �� 5�      $��60��6'   ! 5�      
  5�   "   $" MouseLeftButtonUp��61   .# 5�   &     #$ [ 69   $% Meals��6f   5�   #   .��5�      �� $ 
Horizontal=�6)   .+�5�   "     $& FoodVariant=�6:   $��25��6M   $��25��6Y   $��10q�6d   �� 5�   "   $��Messages��6,   $��Center=�6<   $��20 10q�6X   5�      5�      5�      5�      5�      � 5�      -   5        $��ControlPlaceHolder��5�      $��1��6-   $��1��6=   $��20 20 20 20q�6J   5�      5�      5�      5�      