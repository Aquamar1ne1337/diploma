   M S B A M L   `   `   `  ����B  >Diploma, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DiplomaDiploma  5      !    Diploma.InsertClientControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Diploma     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        � Triggers  5
      :� 5   
    :� RoutedEvent$ Loaded��6   .[�5      �� .��5      ��  g� Duration$ 00:00:3D�6    �� TargetProperty$ Opacity�60   .��5      W�  W� From$ 0X�6&   	 W� To$ 1X�6/   5      5      5      .��5      � .+�5   
   �� -   5         ��Name$ listw��5      $��2��6"   $��10q�6/   $��Center=�6;   $��Center=�6X   .@�5      �� .��5      � $	��300��6   .+�5      �� .+�5      �� -   5         ��Name$ Nametbx��5   "   
������ 
���   �)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Имя��6`    %  !MaterialDesignFloatingHintTextBox#��[  5      6W   5      5      5      �� 5      .��5      � $	��300��6   .+�5      �� .+�5       �� -   5        $ Emailtbx��5    "   
������ 
���   �$' !Электронная почта��6a   #��[  5!      6W   5"      5#      5$      �� 5%      .��5&      � $	��300��6   .+�5'      �� .+�5(      (  "System.Windows.Controls.DatePicker  -   5        	  Name$	 
Registerdp��5)      $% Дата регистрации��5*       ( $MaterialDesignFloatingHintDatePicker#��[ 5+      5-      5.      5/      �� 50      .��51      � $	��300��6   .+�52      �� .+�53      �� -   5        $ Phonetbx��53   "   
������ 
���   �$ Телефон��6a   #��[  54      6W   55      56      57      �� 58      .��59      � $	��300��6   .+�5:      �� .+�5;      �� -   5        $ Towntbx��5;   "   
������ 
���   �$ 
Город��6`   #��[  5<      6W   5=      5>      5?      �� 5@      .��5A      � $	��300��6   .+�5B      �� 
 �� Orientation$
 Vertical=�6!   .+�5C      �� -   5         ��Name$ Readybtn��5C   !   $��Готово��63   $	��100��6D   6i   �� 5D      -   5        $ Backbtn��5E      $��	5,5,5,4.6q�5D   !   $��
Назад��5E   '   $	��100��67   6C   5F      5G      5H      5I      5J      5K      