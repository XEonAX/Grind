   M S B A M L   `   `   `  ����K  GGrind.WPF.CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Grind.WPF.CSharpGrind.WPF.CSharp  5      -    'Grind.WPF.CSharp.UserMaintenanceControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:Grind.WPF.CSharp     5      .��5      �   � RowDefinitions  5	   
   �� 5
      $��* �6   �� 5      $��25 �6   �� 5      $	��140 �6   �� 5      $��25 �6   .+�5   
   � $��2��6   $��5q�6     5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� $
��Name��6   $
��Left=�6$   $��Center=�6?   $��0��6Z   �� 5      $��Trigram��6   $
��Left=�6'   $��Center=�6B   $��1��6]   �� 5      $��Internal Object ID��6   $
��Left=�62   $��Center=�6M   $��2��6h   �� 5      $��Password��6   $
��Left=�6(   $��Center=�6C   $��3��6^   �� 5      -   5        $��	chkActive��5   Q   $��Active��6   $��4��6(   $
��Left=�65   $��Center=�6b   $��5,0,0,0q�6}   �� 5       -   5        $��txtName��5    6   $��1��6   $��0��6'   $��Center=�6E   6`   �� 5!      -   5        $��
txtTrigram��5!   6   $��1��6   $��1��6'   $��Center=�6H   6c   �� 5"      -   5        $��txtIntObjId��5"   6   $��1��6   $��2��6'   $��Center=�6I   6d   �� 5#      -   5        $��txtPassword��5#   6   $��1��6   $��3��6'   $��Center=�6I   6d   �� 5$      -   5        $��cbLevel��5$   &   $��4��6   $��Center=�65   $��1��6Q   .@�5%      �� $��Master��6   �� 5&      $��Admin��6   �� 5'      $
��User��6   �� 5(      $��Viewer��6   5*      5+      � 5,   
   $��3��6    5-      �� 5.      �� 5/      �� 50      .+�52      �� -   5        $��btnAdd��52   3   $	��Add��6   $��0��6#   6A   �� 53      -   5        $��	btnUpdate��53   6   $��Update��6   $��1��6&   6G   �� 54      -	   5        $��	btnDelete��54   6   $��Delete��6   $��2��6&   6G   55      �� 56   
   -
   5        $��
btnRefresh��56   0   $��Refresh��6   $��1��6#   6B   �� 57   
   -   5        $��lbPeople��57      6"   58      59      