   M S B A M L   `   `   `  ����B  >Diploma, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DiplomaDiploma  5          Diploma.TaskReview   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Diploma     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5      � .+�5   
   � $��	10 20 0 0q�6   $
��Auto=�6#   $	��470��6S   $	��300��6_   $	��Top=�6l   $
��Left=�6�   .+�5      �� -   5          ��Name$  listw��5      ��6&   �� *Задание+.@�5      �� .��5      � $	��450��6   .+�5      �� .+�5      �� -   5         ��Name$ Nametbx��5   "   
������ 
���   �)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Название��6`    %  !MaterialDesignFloatingHintTextBox#��[  5       �� 
IsReadOnly . ��5   �   �� *Название+5   i   5      5      5      �� 5      .��5      � $	��450��6   .+�5       �� .+�5!      �� -   5        $ DescriptionTB��5!   "   
������ 
���   � * &MaterialDesignOutlinedTextFieldTextBox#��[ 5"       . $��0,0,0,0q�5$      $	��100��5%      $	��450��5&       �� AcceptsReturn .  �� TextWrapping$
 Wrap=�5(      " �� VerticalScrollBarVisibility$
 Auto=�5)      $ Описание��5*      ��5!   f   �� *Описание+5*      5+      5,      5-      �� 5.      .��5/      � $	��450��6   .+�50      �� .+�51      �� -   5        $ 
CreationTB��51   "   
������ 
���   �$ Дата создания��6c   #��[  52       . ��51   �   �� *Дата_создания+ �� StringFormat$ 
dd/MM/yyyy��52   i   53      54      55      �� 56      .��57      � $	��450��6   .+�58      �� .+�59      �� -   5        $ 
DeadlineTB��59   "   
������ 
���   �$ Крайний срок��6c   #��[  5:       . ��59   �   �� *Крайний_срок+$ 
dd/MM/yyyy��5:   i   5;      5<      5=      5>      5?      � 5A   
   $	��300��6   $	��300��6   $	��Top=�6(   $��Right=�6@   $��	0 20 10 0q�6\   .+�5B      )  #MaterialDesignThemes.Wpf.DialogHost  -   5        $	��300��5B   (   $	��300��64   $��Center=�5C      $��Center=�5D         DialogContent 5E      �� 5F      $	��300��6!   $	��100��6-   $��16q�5G      .+�5H      �� Новая заметка.5J      �� 5K      -   5        $ NoteTextBox��5N   	   $��0 8 0 0q�5L   	   $��Stretch=�5M   	   5N   	   �� 5O      	 �� Orientation$	 
Horizontal=�5P   	   $��Right=�5Q   	   .+�5R      ��   MaterialDesignFlatButton#��[ 5S      
 �� 	IsDefault
 . $��0 8 8 0q�5U      $2��,materialDesign:DialogHost.CloseDialogCommand��5V      ��5W   "   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5X   5   ��6&   3system&clr-namespace:System;assembly=mscorlib  65   True��5Z   '   .��5[   ;   Добавить5]      �� 5^      #��[ 5_       �� IsCancel . $��0 8 8 0q�5a      $2��,materialDesign:DialogHost.CloseDialogCommand��5b      ��5c   "   1&clr-namespace:System;assembly=mscorlibSystem 5d   5   ��6&   3system&clr-namespace:System;assembly=mscorlib  65   	False��5f   '   .��5g   ;   
Назад5i      5j      5k      .��5m      �� $��1q�5n        PrimaryHueMidBrush#���  5o      $	��256��5p      $	��256��5q      }�. ._�5s      �  � RowDefinitions 5t      �� 5u      $��* �5v      �� 5w      $
��Auto �5x      .+�5z      �� -   5         ��Name$ NoteListBox��5{   	   $
��Auto=�66   ��6   ��  �� SelectedValuePath 6�   �� *id_заметки+��5|      �� 5}   "   .R�5~   &   �� $	 
Horizontal=�61   .+�5   *   �� $��10 0 0 0q�6P   $
��Left=�6b   $
��Auto��6}   $��Center=�6�   ��64   �� *Содержание+6�   5�   '   5�   #   5�      (  "MaterialDesignThemes.Wpf.ColorZone  5�         Mode$ 
PrimaryMid=�5�   	   $��1��5�   	     MaterialDesignShadowDepth5 J� Effect# �  5�   	   .��5�      �� $��16q�5�      Заметки5�      5�      �� 5�       0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 5�   	      OpenDialogCommand#��Z 5�   	   $��Bottom=�5�   	   $��Right=�5�   	   $��0��5�   	   $��
0 0 28 -20q�5�   	   .��5�      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Plus=�5�      $��22��5�      $��22��5�      5�      5�      5�      5�      5�      � 5�   
   $	��470��6   $	��167��6   $��Bottom=�6(   $
��Left=�6C   $��	10 0 0 40q�6^   .+�5�      &   System.Windows.Controls.DataGrid  -	   5          Name$ subtaskdatagrid��5�         AutoGenerateColumns .     CanUserAddRows .  ��6L   ��  6{   �� *id_позадачи+   Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ Описание��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *Описание+4	  .System.Windows.Controls.DataGridTemplateColumn	  5�      $ Статус��6-    	  CellTemplate 5�      �� 5�      .R�5�   "   �� -
   5         d� 	IsChecked 5�   +   �� *Статус+6�   5�      5�      5�      5�      �� 5�   
   -   5         ��Name$ UserComboBox��5�      $ Участники��6)   $	��300��6T   $��Right=�6`   $��Bottom=�6|   $��
0,0,10,120q�6�    �� 
IsReadOnly .  & "MaterialDesignFloatingHintComboBox#��[ 6�   6�   � 5�   
   -   5         �Name$	 pb1��5�      $��Bottom=�6#   $��0 0 0 5q�6>   $��15��6O   6]   �� 5�   
   -   5         ��Name$ 
backbutton��5�      $��Bottom=�6%   $	��100��6@   $��
Назад��6L   $��Right=�6\   $��	0 0 10 40q�6x   6�   �� 5�   
   -   5        $ endtaskbutton��5�      $��Bottom=�6(   $��Right=�6C   $	��120��6_   $��Завершить��6k   $��
0 0 180 40q�6   {�.  6�   �� 5�   
   -   5        $ ganttreportbutton��5�      $	��Top=�6,   $��Center=�6D   $	��150��6a   $��0 20 0 0q�6m   $#��Диаграмма Ганта��6   6�   '
  !MaterialDesignThemes.Wpf.PopupBox
  5�   
   $��40��6"   $��40��6-   $��Bottom=�69   $��Center=�6T   $��	0 0 90 30q�6q    
  	StaysOpen . {�5�      �� *	IsChecked+  �� ElementName$  PopupEnabled��! 
  PopupContent.! 5�      � $	��300��5�      $��8,8,8,8q�5�      " � 	Resources" 5�      # �� 
TargetType  MaterialDesignTextBox$ �� BasedOn% �� Property& �� Value��%�   '��       7  �� 5�      "# ��5�      8$   .�5�      �� % �@ 
IsFloating& . 5�      �� 5�      % � ��$& 8,8,8,8q�5�      5�      5�      ' � ColumnDefinitions' 5�      �� 5�      $��* �5�      �� 5�      $
��Auto �5�       5�      �� 5�      $��* �5�      �� 5�      $��* �5�      �� 5�      $��* �5�      �� 5�      $��* �5�      �� 5�      $��* �5�      �� 5�      $��* �5�      .+�5�      �� $��0��5�   	   $��0��5�   	    $  MaterialDesignHeadline6TextBlock#��[ 5�   	   $��8,8,8,16q�5�   	   Новая задача5�      �� 5�      -   5        $ 	subtasktb��5�      $��0��5�   	   $��1��5�   	   $ Описание��5�   	   �� 5�      $��5��5�   	   $��2��5�   	   $	 
Horizontal=�5�   	   $��Right=�5�   	   .+�5�      �� -   5        $ addsubtaskbutton��5�      $��_Добавить��5�      ( 
  ClosePopupCommand#��Z( 5�      �� 5�      -   5        $ refreshbutton��5�      $��_Обновить��5�      #��Z( 5�      6J   �� 5�      $��_Закрыть��5�      #��Z( 5�      5     5     5     5     5     5     