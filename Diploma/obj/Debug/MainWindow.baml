   M S B A M L   `   `   `  ����B  >Diploma, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DiplomaDiploma  5   	   E ADragablz, Version=0.0.3.203, Culture=neutral, PublicKeyToken=null5(clr-namespace:Dragablz;assembly=DragablzDragablz 5   	       Diploma.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Diploma     5   	   =dragablz(clr-namespace:Dragablz;assembly=Dragablz     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   $	��600��5
   	   $
��1080��6     � 
ResizeMode$  NoResize=�6#    � WindowStartupLocation$ CenterScreen=�69    � WindowStyle$
 None=�6^   .��5      � .+�5   
   � $��60��6   $	��Top=�6      PrimaryHueMidBrush#���   63   .+�5      �� $��Diploma��6   
�������$��Center=�6:   $��Center=�6W   $��22(�6r   $��Champagne & Limousines)�6�   �� 5      -   5        $��Right=�5      $��Center=�61   ��6L   Z� ��6b   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Power=�6*   5      �� 5      -   5         ��Name$ AdminBT��5      $
��Left=�6&   $��Center=�6A   $y�Hidden=�6�   ��6\   Z� ��6r   Z� .��5        $ AccountEditOutline=�6*   5      5      � 5   
   $��0 60 0 0q�6   .+�5        Dragablz.TabablzControl  -   5           InterTabController 5       !  Dragablz.InterTabController  5!      .@�5#      �� -   5         ��Name$ FirstTabItem��5#      $��Главная��60   .��5$      � .+�5%      �� -   5         ��Name$ hellotextblock��5%       $'��!Добро пожаловать, ��68   $��50(�6R   $
��Left=�6`   $	��Top=�6{   $��
20 100 0 0q�6�   �� 5&      $
��Left=�6%   $	��500��6@   $	��500��6L   $��
20 200 0 0q�6Y    � 	Resources 5'      	 �� 
TargetType
 �� Property �� Value��%�   '��       '�� r     �� 5(   "   "	 ��6(   .�5)   &   �� 
 � ��$ 0,10,0,0q�6?   �� 5*   &   
 � ��$ 24(�6A   5+   #   �� 5,   "   "	 ��6(   .�5-   &   �� 
 � ��$	 500��6>   5.   #   5/      .+�50      �� -   5        $ readytextblock��50   (   $G��AКоличество ваших выполненых задач: ��6@   6n   �� 51      6*   �� 52      -   5        $ inprocesstextblock��52   (   $F��@Количество ваших задач в процессе: ��6D   6r   �� 53      6*   �� 54      -   5        $ latetextblock��54   (   $K��EКоличество ваших просроченных задач: ��6?   6o   �� 55      6*   �� 56      -	   5        $ dropedtextblock��56   (   $N��HКоличество ваших не выполненных задач: ��6A   6r   57      58      59      �� 5:      $��Задания��6   .��5;      � -
   5         �Name$ TaskGrid��5;      5=      5>      �� 5?      $��Клиенты��6   .��5@      � -   5        $ 
ClientGrid��5@      5B      5C      5D      5E      5F      5G      