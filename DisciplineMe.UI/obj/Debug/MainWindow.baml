   M S B A M L   `   `   `  ����J  FDisciplineMe.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:DisciplineMe.UIDisciplineMe.UI  5   	   G(clr-namespace:DisciplineMe.UI.viewModelsDisciplineMe.UI.viewModels  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	        DisciplineMe.UI.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:DisciplineMe.UI     5   	   <localVM(clr-namespace:DisciplineMe.UI.viewModels     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	     � Title$  
MainWindow��5
   	   $��414.8��6   $��674.8��6+    � 	Resources 5         ItemDataTeplate � ColumnDefinitions �� Orientation��%
  &	        �� 5   
   .R�5      �  5      �� 5      �� 5      $	��100 �6'   .+�5      �� $��0��6   .+�5      �� $��5q�6    $��16(�6+   ��69   �� *Title+�� 5      $��5q�6    ��6+   �� *NotificationInfo+5      �� 5      $��1��6   .+�5      �� $��Center=�6   $��Center=�67   $
��Bold"�6q   $��11,0,1,0q�6�   ��6T   �� *
Progress+6�   �� 5      $ 
Horizontal=�6!   .+�5      A� $��10��6"   $��10��6.   $��25 5 5 5q�69   ���	#FFD64F4F���	#FFD64F4F6^   A� 5      $��10��6"   $��10��6.   $��5q�69   ���	#FF4B4BD4���	#FF4B4BD46W   A� 5      $��10��6"   $��10��6.   $��5q�69   ���	#FF56BF56���	#FF56BF566W   5      5      5      5      5       .��5!      �  � RowDefinitions 5"   
   �� 5#      $��40 �6   �� 5$      $��* �6    5&   
   �� 5'      $	��200 �6   �� 5(      $��* �6   .+�5+   
   &   System.Windows.Controls.Calendar  -   5          Name$ calendar��5+      $��1��6%   $��Center=�62   $��Bottom=�6O   $��5q�6j      CalendarDayButtonStyle 5,      �� 5-       �� 
TargetType:  4System.Windows.Controls.Primitives.CalendarDayButton"  6    �� BasedOn# [B 67   .�5.      -   5        5/      51      �� 53   
   $��Discipline Me!��6   $��0��6)   $��2��66   $��Center=�6J   $��Center=�6g   $��14(�6�   $
��Bold"�6�   �� 55   
   -   5        	 ��Name$	 listBox��55      $��1��6#   $��1��63   $��Stretch=�6@   #��[  6�   �� 57   
   $��1��6   .+�58      �� -   5        $��Add new Habit��58      $
��Left=�6-   $��	10,10,0,0q�6H   $	��Top=�6[   $	��180��6s   $��40��6   ���	#FF56BF56$��16(�6�   6�   �� 59      -   5        $
��Edit��59      $
��Left=�6$   $��	10,10,0,0q�6?   $	��Top=�6R   $	��180��6j   $��24��6v   6�   �� 5:      -   5        $��RemoveButton��5:   &   $��Remove��6   $
��Left=�6:   $��	10,10,0,0q�6U   $	��Top=�6h   $	��180��6�   $��24��6�   6�   5;      5=      5>      