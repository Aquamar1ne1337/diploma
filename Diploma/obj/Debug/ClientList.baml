   M S B A M L   `   `   `  ����B  >Diploma, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DiplomaDiploma  5          Diploma.ClientList   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Diploma     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5      � .+�5   
   �� .+�5      (  "MaterialDesignThemes.Wpf.ColorZone      Mode$  
PrimaryMid=�6'   $��16q�69   $��64��6F   .��5      ]� .+�5      ��  �� Orientation$ 
Horizontal=�6!   +  %MaterialDesignThemes.Wpf.RippleAssist   
IsCentered . .+�5      �� -   5         ��Name$ 	insertbtn��5   !   $	��100��6|   ��64   Z� ��6K   Z� .��6�   Добавить5        5      $  Standard=�5   !   $��8 4 8 4q�5   !      CornerRadius$ 2��5   !    K� ZIndex$ 1��5    !   $��16 0 0 0q�5!   !   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth1=�5"   !   .��5#      �  � ColumnDefinitions 5$   "   �� 5%   &   $
��Auto �67   �� 5&   &   $��* �67   �� 5'   &   $
��Auto �67   .+�5)   "   ��    MaterialDesignToolButton#���   6)   $
��0,-4q�6\   .��5*   &   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Magnify=�6>   	 J� Opacity$		 .56Q�6M   5+   #   �� 5,   "   -   5        
 ��Name$
 SearchTB��5,   *   $��1��5.   )   $��8 0 0 0q�5/   )   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Поиск��50   )   .  (MaterialDesignThemes.Wpf.TextFieldAssist   DecorationVisibility$ Hidden=�51   )   $��0q�52   )   $	��200��53   )   $��Center=�54   )   55      57      �� 59       & "MaterialDesignToolForegroundButton#���  5:   	   $��8 0 0 0q�5;   	   $ 0��5<   	   d� 5=      -   5         d�Name$ 
ToggleSort��5=   '    * &MaterialDesignSwitchAccentToggleButton#��[ 5>      $��Center=�5?      $��	600,0,0,0q�5@      6   5A      5B      5C      5E      �� 5F   
   -   5         ��Name$ LilView��5F      $
��Left=�6$   $��Center=�6?   $
��1080��6c   $��Disabled=�6�   ��. $
��Auto=�6�   $��0,64,0,-0.4q�6  ��6p   �� ��5G      �� 5H      .R�5I      �  � 	ItemWidth$	 240��6     � 
ItemHeight$	 350��60   $��Center=�6A   5J      5K      ��5M      �� 5N      .R�5O      � $��Center=�6   $	��230��68   $	��330��6E   $��Center=�6R   .+�5P      ��   MaterialDesignBackground#���  5Q   !   ._�5R      �� $��Клиент номер: ��5S   !     MaterialDesignCardGroupBox#���  5T   !   $��15q�5U   !    � UseLayoutRounding .  J� SnapsToDevicePixels . .��5X   "   �� .+�5Y   &   �� $
��Bold"�60   	Имя:6H   �� 5Z   &    ��Name$ nametb��60   ��6@   �� *Имя+�� 5[   &   $
��Bold"�60   $"Электронная почта:6V   �� 5\   &   $ emailtb��60   $
��Wrap=�6d   ��6A   �� *#!Электронная_почта+6d   �� 5]   &   $
��Bold"�60   " Дата регистрации:6U   �� 5^   &   $ datatb��60   ��6@   �� *!Дата_регистрации+ �� StringFormat$ 
dd/MM/yyyy���� 5_   &   $
��Bold"�60   Телефон:6L   �� 5`   &   $ phonetb��60   ��6A   �� *Телефон+�� 5a   &   $
��Bold"�60   Город:6J   �� 5b   &   $ towntb��60   ��6@   �� *
Город+5c   #   5d      5e      �� 5f      $��115,24,20,245q�6$   $	��100��6;   
���������6G   �� *id_клиента+6x   �� 5g      $ 	updatebtn��6!   -   5          PrimaryHueMidBrush#��[ 5h   !   #��[ 5i   !    0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 5j   !   $��Bottom=�5k   !   $��Right=�5l   !   $��0��5m   !   $��0 0 80 5q�5n   !   .��5o        $ FileEditOutline=�5p   !   $��22��5q   !   $��22��5r   !   5s      �� 5t      $ 	deletebtn��6!   -   5        
���  ��
���  ��#��[ 5w   !   $��Bottom=�5x   !   $��Right=�5y   !   $��0��5z   !   $��0 0 28 5q�5{   !   .��5|        $ DeleteForeverOutline=�66   $��22��6R   $��22��6^   5}      5~      5      5�      5�      5�      