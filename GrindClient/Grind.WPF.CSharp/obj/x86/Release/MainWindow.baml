   M S B A M L   `   `   `  ���� K  GGrind.WPF.CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Grind.WPF.CSharpGrind.WPF.CSharp  !    Grind.WPF.CSharp.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:Grind.WPF.CSharp     -     � Title$  
MainWindow��$	��Top=�$	��553��$	��757��$
��Left=�.���  � RowDefinitions �� �� $��20 �.+��� $��20��$��Bottom=�$��1��.@��� -    ��Name$ 
sbiMessage��$��Message��$
��Left=� � ToolTip ��  �� ElementName$ 
sbiMessage�� �� Path$ Content��� -   $ sbiState��$��State��$��Right=� �� $ sbiState��$ Content��� .@��� -    ��Name$ tbTasks��$��Tasks��.���� $��1q����	#FF688BAE._�� -    �Name$ MainGrid�� �� $��28 ��� ���� *Height+$ MainGrid���� $��6 ��� �� $��20 �.+��� $��0��$��Center=� �� Orientation$ 
Horizontal=�$��2,0,0,0q�.+��� -   	 ��Name$	 
btnRefresh��$��Refresh��$	��2,0q��� -   $	 btnDownloadTasks��$��Get and Store All Tasks��$	��2,0q��� -   $	 btnNew��$	��New��$	��2,0q��� -	   $	 	btnUpdate��$��Update��$	��2,0q��� -
   
 ��Name$
 
chkOffline��$��Work Offline��$��16��$��Right=� d� 	IsChecked$
 TrueY�&   System.Windows.Controls.DataGrid  -     Name$ 
dGridTasks��$��1��   
IsReadOnly .    CanUserResizeRows .  ��Z�    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 	Task Name��   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
taskName+  $ Task Status�� . $ 70  �� *task_status+4  .System.Windows.Controls.DataGridCheckBoxColumn  $ Is Bug�� . $ 40  �� *is_bug+  $ Bug Type�� . $ 60  �� *
bug_type+  $ Approved�� . $ 60  �� *
approved+  $ Target Date�� . $ 1*  �� *target_date+ �� StringFormat$ {0:dd - MMM - yyyy}��  $ Executor�� . $ 1*  �� *DeveloperName+  $ Reviewer�� . $ 1*  �� *ReviewerName+  $ Created�� . $ 1*  �� *
created_at+$ {0:d}��  $ Modified�� . $ 1*  �� *
updated_at+$ {0:d}���� $��Stretch=�$��2�� �� ResizeDirection$
 Rows=� �� ResizeBehavior$ PreviousAndNext=�
���   ����	#FF688CAF'   !Grind.WPF.CSharp.TaskTrackingForm  -     Name$ ttfrmControl��$��3���� -   $ tbUsers��$��Users��.��-   'Grind.WPF.CSharp.UserMaintenanceControl  -     Name$ userMaintenanceControl1���� -   $ tbChat��$
��Chat��.��!	   Grind.WPF.CSharp.ChatClient	  -    	 Name$ ChatClientControl��