   M S B A M L   `   `   `  ����B  >Diploma, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DiplomaDiploma  5          Diploma.UserControlLogin   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Diploma     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      �   � RowDefinitions  5   
   �� 5      $	��200 �6   �� 5      $��50 �6   �� 5      $��* �6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  $��0��6#      Mode$
 Dark=�60   $��Stretch=�6<   $��Stretch=�5   #   $��Stretch=�6A   $��	0,-26,0,0q�6d   .��5      �� $��Вход��6   $��50(�6$   $��80,67,80,51q�62   $��Center=�6G   $��82��6b   5      �� 5   
    &  "MaterialDesignFloatingActionButton#���   6   7  1MaterialDesignThemes.Wpf.Transitions.Transitioner   MoveNextCommand#��Z 5      $
��Left=�5      $��Bottom=�5      $��0��5      $��2��6   $��20q�6/   .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Plus=�6&   5      �� 5   
   $��2��6   $��30q�6    .@�5      �� .��5      � $	��300��6   .+�5      �� .+�5      �� -   5         ��Name$ LoginTB��5   "   
������ 
���   � % !MaterialDesignFloatingHintTextBox#��[ 6`   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Логин��6�   .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton . 5    >   5!      5"      5#      �� 5$      .��5%      � $	��300��6   .+�5&      �� .+�5'      G� -   5         G�Name$ 
pasentertb��5(      
������ 
���   �$ Пароль��5*       .  ) %MaterialDesignFloatingHintPasswordBox#��[ 5,      6R   5-      5.      5/      �� 50      .+�51      �� -   5         ��Name$ enterbt��51      $��5q�6*   $��Right=�52      $��Bottom=�61   {�.  .��6t   
Войти6{   53      54      �� 55   
   .+�56      �� -   5        $ Closebt��56      $��5q�6&   $��Right=�57      $��Bottom=�61   ��6b   Z� ��6x   Z� .��58        $ Power=�6*   59      5:      5;      5<      