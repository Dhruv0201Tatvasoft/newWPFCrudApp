   M S B A M L   `   `   `  ����H  DnewWPFCrudApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:newWPFCrudAppnewWPFCrudApp  5   	   A%clr-namespace:newWPFCrudApp.ViewModelnewWPFCrudApp.ViewModel  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       newWPFCrudApp.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:newWPFCrudApp     5   	   4vm%clr-namespace:newWPFCrudApp.ViewModel     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5
   	     � Title$  
MainWindow��5   	   $	��450��6   $
��1580��6)    � DataContext 5      -  'newWPFCrudApp.ViewModel.PersonViewModel  5   
    � 	Resources 5         MyViewModel��%   &	          5   
   6   5      .��5      � $��79,58,71,36q�6    6    ��  �� Source# [   � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5!   
   �� 5"      $
��Auto �6   $	��244��6,   �� 5#      .+�5&   
   �� $��0��6   $��First Name:��6!   $��Right=�64   $��Center=�6P   $��0,0,0,10q�6k   �� 5'   
   $��	10,5,10,5q�6   $��1��6&   $��0��66   $	��150��6C   $
��Left=�6O   ��6j   �� *	FirstName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5)   
   $��1��6   $��
Last Name:��6!   $��Right=�63   $��Center=�6O   $��0,0,0,10q�6j   �� 5*   
   $��	10,5,10,5q�6   $��1��6%   $��1��62   $	��150��6B   $
��Left=�6N   ��6i   �� *
LastName+$ TwoWay=��� 5,   
   $��2��6   $��User Id:��6!   $��Right=�61   $��Center=�6M   $��0,0,0,10q�6h   �� 5-   
   $��	10,5,10,5q�6   $��2��6%   $��1��62   $	��150��6B   $
��Left=�6N   ��6i   �� *UserId+$ TwoWay=��� 5/   
   $��3��6   $��
BirthDate:��6!   $��Right=�63   $��Center=�6O   $��0,0,0,10q�6j   (  "System.Windows.Controls.DatePicker  50   
      SelectedDateFormat$
 Long=�6   	   SelectedDate	 
01-01-19906/   
   DisplayDateStart
 
01-01-19906I      DisplayDateEnd 
12-31-20126g   $��	10,5,10,5q�6�      FirstDayOfWeek$ Monday=�51      $��3��6-   $��1��6:   $	��150��6J   $
��Left=�6V      Text 50   �   �� *	BirthDate+$ TwoWay=� �� StringFormat$ 
dd/MM/yyyy��51   V   �� 54   
   $��4��6   $��Gender:��6!   $��Right=�60   $��Bottom=�6L   $��0,0,0,13q�6g   �� 55   
   -   5         ��Name$ 	txtGender��55      $��4��6&   $��1��63   $��	10,5,10,5q�6C   $	��150��6W   $
��Left=�6c    �� Text 6~   �� *Gender+$ TwoWay=�.@�56      �� $
��Male��6   �� 57      $��Female��6   58      �� 5:   
   $��5��6   $��Title:��6"   $��Right=�60   $��Center=�6L   $��0,0,0,10q�6g   �� 5;   
    �� Orientation$ 
Horizontal=�6   $��5��6.   $��1��6;   .+�5<      	� $	��Mr.��6S   $��	10,5,10,5q�6c    d� 	IsChecked 6   ��  �� Path$ TitleRadioBox[0]�$ TwoWay=�6c   	� 5=      $
��Mrs.��6R   $��	10,5,10,5q�6b    6   �� $ TitleRadioBox[1]�$ TwoWay=�6b   	� 5>      $
��Miss��6R   $��	10,5,10,5q�6a    6   �� $ TitleRadioBox[2]�$ TwoWay=�6a   5?      �� 5B   
   $��6��6   $��	Interest:��6!   $��Right=�62   $	��Top=�6N   �� 5C   
   $��6��6   $��1��6"   $ 
Horizontal=�62   .+�5D      �� -   5         ��Name$ 
txtReading��5D   F   $��Reading��6Z   $��Center=�6l   $��Center=�6�   $��	10,5,10,5q�6�    6   �� $ InterestCheckBox[0]�6�   �� 5E      -   5        $ 
txtWriting��5E   F   $��Writing��6Z   $��Center=�6l   $��Center=�6�   $��	10,5,10,5q�6�    6   �� $ InterestCheckBox[1]�6�   �� 5F      -   5        $ txtSwimming��5F   F   $��Swimming��6[   $��Center=�6n   $��Center=�6�   $��	10,5,10,5q�6�    6   �� $ InterestCheckBox[2]�6�   5G      �� 5I   
   $ 
Horizontal=�6   $��7��6.   $��1��6;   $��10,5,0,5q�6K   .+�5J      �� -   5         ��Name$ 	btnSubmit��5J   7   $��Submit��6J   $��80��6[   $��0,0,10,0q�6f   ��6   �� *SubmitCommamd+6f   �� 5K      $��Delete��68   $��80��6I   $
��Left=�6T   ��6   �� *DeleteCommand+6T   5L      �� 5M   
   $ 
Horizontal=�6   $��8��6.   $��1��6;   .+�5N      &   System.Windows.Controls.DataGrid  -   5          Name$ 
MyDataGrid��5N         AutoGenerateColumns$ False��6-   $
��Left=�6J      CanUserAddRows$
 True��6f      SelectionMode$ Single=�6}   ��6�   �� *
DataTable2+ �� SelectedItem 6�   �� *SelectedItem+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5O      +  %Microsoft.Xaml.Behaviors.EventTrigger  5P         	EventName$ CellEditEnding��6%   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5Q      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     PassEventArgsToCommand$
 True��6Z      Command 60   �� *CellEditEndingCommand+6Z   5R          Columns  5T      0  *System.Windows.Controls.DataGridTextColumn  5V      ,	  &System.Windows.Controls.DataGridColumn! 	  Header$! UserID��6+   1
  +System.Windows.Controls.DataGridBoundColumn" 
  Binding" 6;   �� *UserId+4  .System.Windows.Controls.DataGridComboBoxColumn  5W      $! Title��6-   #   SelectedValueBinding# 6<   �� *Title+$   ElementStyle$ 5X      �� 5Y      % �� 
TargetType"% ��6$   .�5Z   "   �� & �� Property& � ��' �� Value' 6@   �� *DataContext.Titles+( �� RelativeSource( �� ) �� AncestorType
) Window5[      *   EditingElementStyle* 5]      �� 5^      "% ��6$   .�5_   "   �� & � ��' 6@   �� *DataContext.Titles+( �� 
) Window5`      5b        5c      $! 	Firstname��6*   -   5        
FirstNames��" 5c   >   �� *	Firstname+$ TwoWay=�5d        5e      $! Lastname��6)   -   5        	LastNames��" 5e   ;   �� *
Lastname+$ TwoWay=�6e   4  .System.Windows.Controls.DataGridTemplateColumn  5f      $! 	Birthdate��6-   +   CellTemplate+ 5g      �� 5h      .R�5i   "   �� ��6,   �� *	Birthdate+$ 
dd/MM/yyyy��6a   5j      ,   CellEditingTemplate, 5l      �� 5m      .R�5n   "     
 
01-01-19906p    
12-31-20126�   	 6-   �� *	Birthdate+$ 	LostFocus=�6�   5o      5q        5r      $! Gender��6-   # 6=   �� *Gender+$ 5s      �� 5t      "% ��6$   .�5u   "   �� & � ��' 6@   �� *DataContext.Genders+( �� 
) Window5v      * 5x      �� 5y      "% ��6$   .�5z   "   �� & � ��' 6@   �� *DataContext.Genders+( �� 
) Window5{      5}        5~      $! 	Interests��6)   " 6<   �� *	Interests+$ TwoWay=�  5      - 	  Width5  /System.Windows.Controls.DataGridLengthConverter$- 60 6-   + 5�      �� 5�      .R�5�   "   �� $��Submit��6p   ��6)   �� *DataContext.CreatePerson+. �� ElementName$. 
MyDataGrid��6�   5�      5�        5�      $- 60 6-   + 5�      �� 5�      .R�5�   "   �� $��Delete��6n   ��6)   �� *DataContext.DeletePerson+$. 
MyDataGrid��6�   5�      5�      5�        5�      $��	30 0 0 0 q�6   $ False��6w   $ False��6�   $ Single=�6�   ��6*   �� *	DataTable+ 6M   �� *SelectedObject+  5�        5�      $	- 100 6)   $! Userid��65   " 6E   �� *UserId+  5�      $	- 100 6)   $! Title��65   " 6D   �� *Title+  5�      $	- 100 6)   $! Firstame��65   " 6G   �� *	Firstname+  5�      $	- 100 6)   $! Lastname��65   " 6G   �� *
Lastname+  5�      $	- 100 6)   $! 	Birthdate��65   " 6H   �� *	Birthdate+$ 
dd/MM/yyyy��  5�      $	- 100 6)   $! Gender��65   " 6E   �� *Gender+  5�      $	- 100 6)   $! 	Interests��65   " 6H   �� *	Interests+5�      5�      5�      5�      