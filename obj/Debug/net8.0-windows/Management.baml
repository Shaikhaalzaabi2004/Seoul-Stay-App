   M S B A M L   `   `   `  ����D  @SeoulStay, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:SeoulStay	SeoulStay  5   	       SeoulStay.Management   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:SeoulStay     5   	     � Title$  
Management��5   	    � WindowStartupLocation$ CenterScreen=�6   $	��500��6A   $	��800��6N   .��5	      �� -   5        $��parent��5	      .+�5
   
   �� $��20, 20, 20, 20q�6   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5      �� $��
./logo.png��6   $	��150��6,   5      �� 5      $��Right=�6   $ 
Horizontal=�65   $��0, 20, 0, 0q�6N   .+�5      �� -   5        $��	logOutBtn��5      $��Log Out��6*   $��80��6<   6^   �� 5      -   5        $��ExitBtn��5      $
��Exit��6(   $��80��67   $��20, 0, 0, 0q�6B   6o   5      �� 5      $ 
Horizontal=�6   $��0, 20, 0, 0q�62   .+�5      �� -   5        $��myTabControl��5      .@�5      �� -   5        $��travelerTab��5      $��I'm Traveler��61   .��5      �� $��10, 10, 10, 10q�6%   .+�5      �� $ 
Horizontal=�6)   .+�5   "   �� -   5        $��search��5   *   $	��400��68   6g   5      �� 5      $ 
Horizontal=�6)   $��0, 10, 0, 0q�6B   .+�5   "   &   System.Windows.Controls.DataGrid  -   5        $��
travelerDg��5   +      AutoGenerateColumns$ False��6=   $	��600��6Y   $	��200��6e      CanUserAddRows$ False��6r      Columns 5   &   0  *System.Windows.Controls.DataGridTextColumn  5   *   ,  &System.Windows.Controls.DataGridColumn   Header$ Title��6=      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6f   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6L   �� *Title+6r     5   *   $ Capacity��6=   $ * 6l    6O   �� *
Capacity+6x     5   *   $
 Area��6=   $ * 6i    6K   �� *	Area.Name+6u     5   *   $
 Type��6=   $ * 6m    6K   �� *ItemType.Name+6y   5"   #   5$      5%      5'      �� 5(      -   5        $��ownerTab��5(      $��I'm Owner/Manager��6.   .��5)      �� $��10, 10, 10, 10q�6%   .+�5*      �� $ 
Horizontal=�6)   .+�5+   "   �� -	   5        $��addBtn��5+   )   $��Add listing��67   $	��100��6M   6p   5,      �� 5-      $��0, 10, 0, 10q�6)   $ 
Horizontal=�6?   .+�5.   "     -
   5        $��ownerDg��5.   +   $ False��6:   $	��600��6V   $ False��6b   $	��200��6y    5/   &     50   *   $ Title��6=   $ * 6f    6L   �� *Title+6r     51   *   $ Capacity��6=   $ * 6l    6O   �� *
Capacity+6x     52   *   $
 Area��6=   $ * 6i    6K   �� *	Area.Name+6u     53   *   $
 Type��6=   $ * 6m    6K   �� *ItemType.Name+6y   4  .System.Windows.Controls.DataGridTemplateColumn  54   *   	   CellTemplate	 55   .   �� 56   2   .R�57   6   �� �� 58   :   
 �Name$
 editLink��6D   -   5        .�58   k   .�59   >   �� $��Edit Details��6H   5:   ;   5;   7   5<   3   5>   +   5@   #   5A      5B      5C      5D      5E      �� 5F      $ 
Horizontal=�6   .+�5G      �� -   5        $��itemsFoundLabel��5G      61   5H      5I      5K      5L      