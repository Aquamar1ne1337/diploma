   M S B A M L   `   `   `  ����B  >Diploma, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DiplomaDiploma  5          Diploma.TaskControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Diploma     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        � Triggers  5
      :� 5   
    :� RoutedEvent$ Loaded��6   .[�5      �� .��5      ��  g� Duration$ 00:00:3D�6    �� TargetProperty$ Opacity�60   .��5      W�  W� From$ 0X�6&   	 W� To$ 1X�6/   5      5      5      .��5      � .+�5   
   �� $��Center=�6   $
��Left=�60    �� Orientation$ Vertical=�6K   $��10,121,0,23.6q�6b   $	��522��6y   $	��305��6�   .+�5      �� -   5         ��Name$ ClientCB��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Клиент��6)   $	��290��6Q   $
��Left=�6]   $��10,0,0,0q�6x      MaterialDesignComboBox#��[  6�   6�   �� 5      -   5        	 ��Name$	 NameTB��5      $ Название��6&   $	��290��6P   $
��Left=�6\   $��	10,10,0,0q�6w   6�   (  "System.Windows.Controls.DatePicker  5      -   5        
  Name$
 
DeadlineDP��5      $ Крайний срок��6-   $	��290��6[   $
��Left=�6g   $��
10,10,0,10q�6�   6�   �� 5      -   5        $	 descriptionTB��5      $
��Left=�6-    * &MaterialDesignOutlinedTextFieldTextBox#��[ 5      $��10,0,0,0q�5      $	��100��5      $	��490��5       �� AcceptsReturn .  �� TextWrapping$
 Wrap=�5      " �� VerticalScrollBarVisibility$
 Auto=�5      $ Описание��5       �� 5!      -   5         ��Name$ DoneBT��5!      $	��100��6%   $��Готово��61   $
��Left=�6B   $��	10,10,0,0q�6]   6�   �� 5"      -   5        $ BackBT��5"      $	��100��6%   $��
Назад��61   $
��Left=�6A   $��	10,10,0,0q�6\   6�   5#      5$      5%      