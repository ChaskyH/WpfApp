   M S B A M L   `   `   `  ����D  @WpfApp.PL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WpfApp.PL.ControlsWpfApp.PL.Controls  5      9!clr-namespace:WpfApp.PL.ViewModelWpfApp.PL.ViewModel  5      ;"clr-namespace:WpfApp.PL.AssistantsWpfApp.PL.Assistants  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5
      $    WpfApp.PL.Controls.FoodBrowser   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:WpfApp.PL.Controls     5      1vms!clr-namespace:WpfApp.PL.ViewModel     5      5assist"clr-namespace:WpfApp.PL.Assistants     5      V RMaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5
        � DataContext  5      ��    ViewModelLocator �� Source# [   �� Path$ FoodBrowser� � 	Resources 5        ThumbnailCellTemplate  ViewButtonTemplate . *MaterialDesignFloatingActionMiniDarkButton �� RelativeSource �� Mode �� AncestorType'  !MaterialDesignThemes.Wpf.PackIcon�  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=null]]   Kind  NameTextBoxTemplate��%�  &	       &	 U     7  &	 U    �� 5   
   .R�5      �� $��35��62   ��6   �� $ Photo�62   5      �� 5   
   .R�5      �� 8��  $��25��6Y   $��25��6e   ��5      ��  �� $ FindAncestor=�" >�$' !DataContext.ViewNutritionsCommand���6�   �� *Name+.��5        $	 Eye=�6*   $��18��65   $��18��6A   5      5      �� 5   
   .R�5      �� 
���   ���6   �� *Name+6,   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   	 � ColumnDefinitions	 5!   
   �� 5"      $��2* �6   �� 5#      .+�5%   
   (  "MaterialDesignThemes.Wpf.ColorZone  
   Mode$
 Standard=�6#   $��2��63   $��16q�5&   #   .��5'      ]� .+�5(        $
 Standard=�6-   $��8 4 8 4q�5)   1      CornerRadius$ 2��5*   1    K� ZIndex$ 1��5+   1   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�5,   1   .��5-      � 	 5.      �� 5/      $
��Auto �6/   �� 50      $��* �6/   �� 51      $
��Auto �6/   .+�53      ��   MaterialDesignToolButton#���  6!   ��6T   �� *SearchCommand+.��54        $ Magnify=�66    J� Opacity$	 .56Q�6E   55      �� 56      $��1��6"   $��8 0 0 0q�58   %   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$" Search your favorite foods..��59   %   .  (MaterialDesignThemes.Wpf.TextFieldAssist   DecorationVisibility$ Hidden=�5:   %   $��0q�5;   %   $	��200��5<   %   $��Center=�5=   %   ��57   "   �� *
SearchText+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��5=   A    J� InputBindings 5>      �� 5?   "   
 �� Key$ Enter��6T    �� Command 6-   �� $ SearchCommand�6T   .��5@   5   5A      5B      5C      5D      5E      �� 5F   
   $��1��6    �� Orientation$ Vertical=�6#   .+�5G      &   System.Windows.Controls.DataGrid     CanUserSortColumns .    
IsReadOnly .    SelectionMode$ Single=�5J         SelectionUnit$ FullRow=�6*      AlternatingRowBackground
 �����   CanUserAddRows .     AutoGenerateColumns .  ��5G      �� *Foods+   Columns 5M      4  .System.Windows.Controls.DataGridTemplateColumn  5N      ,	  &System.Windows.Controls.DataGridColumn 	  Header$
 View��6-       CellTemplate#  [ 6;     5O      ! 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$! 80
 6-   $ Photo��68   #  [ 6G   0  *System.Windows.Controls.DataGridTextColumn  5P      $	! 150
 6)   $
 Name��65   " �� TextAlignment$" Center=�6\   1  +System.Windows.Controls.DataGridBoundColumn#   Binding# 6C   �� *Name+6\   9  3MaterialDesignThemes.Wpf.MaterialDataGridTextColumn  5Q      $	! 120
 6@   $ Serving��6L   $" Center=�6~   # 6]   �� *ServingUnits+6~   5T      5U      �� 5W   
   $��1��6   $��1��6#   $��5q�60   $��10q�6;     MaterialDesignCardGroupBox#���  5X      ��5Y      �� 5Z      $ 
Horizontal=�6   $��Stretch=�66   .+�5[        $
 Food=�6.   
�������$��32��5\   2   $��32��6>   $��Center=�5]   2   �� 5^      $��8,0,0,0q�6    
�������$��Center=�5_        % !MaterialDesignSubheadingTextBlock#��[ 5`       ��5_   ;   �� *FoodNutritions.FoodName+5`       5b      .��5d      �  5e      �� 5f      �� 5g      $��2* �6$   	 5i      �� 5j      �� 5k      $
��1.2* �6(   .+�5m      �� $��0��6   $��0��6-   $ Vertical=�6:   .+�5n      �� $ 
Horizontal=�6!   .+�5o      �� $ �� Padding$$ 2,2,2,2q�6$   $��15(�6f   ��66   �� * FoodNutritions.ServingQuantity+6f   �� 5p      $$ 0,5,2,2q�6$   $��12(�6b   $��Italic$�6p   ��66   �� *FoodNutritions.ServingUnit+6p   5q      �� 5r      $ 
Horizontal=�6!   .+�5s      �� $$ 2,2,2,2q�6$   $��15(�6d   ��66   �� *FoodNutritions.ServingWeight+6d   �� 5t      $$ 0,5,2,2q�6$   $��g��66   $��12(�6?   $��Italic$�6M   5u      5v      �� 5w      $��1��6   
���   �$��1q�5x      % �� CornerRadius$% 3��5y      $��Stretch=�5z      $��
-2,0,-3,-1q�5{      ._�5|      �� $��Center=�6E   $��Center=�6`   ��6   �� *FoodNutritions.Photo+6`   5}      /   )WpfApp.PL.Controls.NutritionsGraphControl  5~      $��1��6/   $��2��6<     6P   �� *FoodNutritions+6y   5      5�      5�      5�      