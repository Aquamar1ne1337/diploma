   M S B A M L   `   `   `  ����B  >Diploma, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DiplomaDiploma  5          Diploma.TaskList   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Diploma     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5      � .+�5   
   �� .+�5      (  "MaterialDesignThemes.Wpf.ColorZone      Mode$  
PrimaryMid=�6'   $��16q�69   $��64��6F   .��5      ]� .+�5      ��  �� Orientation$ 
Horizontal=�6!   +  %MaterialDesignThemes.Wpf.RippleAssist   
IsCentered . .+�5      �� -   5         ��Name$ 	insertbtn��5   !   $	��100��6|   ��64   Z� ��6K   Z� .��6�   Добавить5        5      $  Standard=�5   !   $��8 4 8 4q�5   !      CornerRadius$ 2��5   !    K� ZIndex$ 1��5   !   $��16 0 0 0q�5    !   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth1=�5!   !   .��5"      �  � ColumnDefinitions 5#   "   �� 5$   &   $
��Auto �67   �� 5%   &   $��* �67   �� 5&   &   $
��Auto �67   .+�5(   "   ��    MaterialDesignToolButton#���   6)   $
��0,-4q�6\   .��5)   &   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Magnify=�5*   '   	 J� Opacity$		 .56Q�5+   '   5,   #   �� 5-   "   -   5        
 ��Name$
 SearchTB��5-   *   $��1��5/   -   $��8 0 0 0q�50   -   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Поиск��51   -   .  (MaterialDesignThemes.Wpf.TextFieldAssist   DecorationVisibility$ Hidden=�52   -   $��0q�53   -   $	��200��54   -   $��Center=�55   -   56      57      �� 58       & "MaterialDesignToolForegroundButton#���  59      $��8 0 0 0q�5:      $ 0��5;      d� 5<      -   5         d�Name$ 
ToggleSort��5<   '    * &MaterialDesignSwitchAccentToggleButton#��[ 5=      $��Center=�5>      $��	600,0,0,0q�5?      6   5@      5A      5B      5C      �� 5E   
   -   5         ��Name$ LilView��5E      $
��Left=�6$   $��Center=�6?   $
��1080��6c   $��Disabled=�6�   ��. $
��Auto=�6�   $��0,64,-280,-0.4q�6  ��6p   �� ��5F      �� 5G      .R�5H      �  � 	ItemWidth$	 220��6     � 
ItemHeight$	 160��60   $��Center=�6A   6`   5I      ��5K      �� 5L      .R�5M      � $��Center=�6   $	��200��68   $	��150��6E   $��Center=�6R   .+�5N      #  MaterialDesignThemes.Wpf.Card  $	��140��6.   ���#03a9f4 ! PrimaryHueDarkForegroundBrush#���  5P   '   $��0q�5Q   '   $	��200��5R   '   .��5S      �  � RowDefinitions 5T   "   �� 5U   &   $
��Auto �64   �� 5V   &   $
��Auto �64   �� 5W   &   $
��Auto �64   �� 5X   &   $
��Auto �64   .+�5Z   "   �� $��0��5[   '   $��
16 16 16 4q�5\   '    $  MaterialDesignHeadline5TextBlock#��[ 5]   '   $��16(�5_   '   ��5^   '   �� *Название+5`   #   �� 5a   "   $��1��5b   '      MaterialDesignLightSeparator#��[ 5c   '   �� 5d   "   $��2��5e   '   $��	16 0 16 8q�5f   '   $��Center=�5g   '   $
��Left=�5h   '      MaterialDesignBody2TextBlock#��[ 5i   '   ��5j   '   �� *Крайний_срок+ �� StringFormat$ 
dd/MM/yyyy��5k   #   �� 5l   "   $��2��5m   '   $��
16 40 16 8q�5n   '   $��Center=�5o   '   $
��Left=�5p   '   #��[ 5q   '   ��5r   '   �� *Состояние+5s   #   �� 5t   "   $��2��5u   '   $ 
Horizontal=�5v   '   $��	16 0 16 8q�5w   '   $��Right=�5x   '   .+�5y   &   '  !MaterialDesignThemes.Wpf.PopupBox  $��Right=�6>   $��2 0 2 0q�6Z      PopupContent. 5z   *   �� .+�5{   .   �� $ ReviewBT��65   -   5        $��
Обзор��5{   G   6W   5|   +   5}   '   5~   #   5      5�      5�      5�      5�      5�      5�      