   M S B A M L   `   `   `  ����H  DKIT206_A3_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:KIT206_A3_WPF.ViewsKIT206_A3_WPF.Views  5   	   /    )KIT206_A3_WPF.Views.PerformanceReportView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:KIT206_A3_WPF.Views     5   	     � Title$  PerformanceReportView��5   	   $	��450��6'   $	��450��64   $	��320��6D   $	��320��6P   .��5
      � $��4 4 4 4q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� $��0��6   $��Performance Report��6$   $
��Bold"�6A   $��16(�6S   �� 5      -   5        $��1��5      $��Copy Emails��6D   
���   �$��1q�6n   $��4q�6�   $��Right=�6�   $��4,0,0,4q�6�   $��96��6�    �� 	IsDefault$
 True��6�   $
��Bold"�6�   5       �� 5!   
   $��0��6   
���   �$��0,0,0,1q�62   �� 5$   
   $��1��6   $
��Poor��6   $
��Bold"�6,   $��12(�6>   �� 5%   
   $��1��6   
���   �$��0,0,0,1q�62   �� 5&   
   -   5         ��Name$ performance_poor_list��5&      $��2��61   $��Disabled=�6>      performanceReportTemplate#��[  5'      5(      �� 5+   
   $��3��6   $��Below Expectations��6   $
��Bold"�6:   $��12(�6L   �� 5,   
   $��3��6   
���   �$��0,0,0,1q�62   �� 5-   
   -   5        $( "performance_belowExpectations_list��5-      $��4��6>   $��Disabled=�6K   #��[  5.      5/      �� 52   
   $��5��6   $��Meeting Minimum��6   $
��Bold"�67   $��12(�6I   �� 53   
   $��5��6   
���   �$��0,0,0,1q�62   �� 54   
   -   5        $% performance_meetingMinimum_list��54      $��6��6;   $��Disabled=�6H   #��[  55      56      �� 59   
   $��7��6   $��Star Performers��6   $
��Bold"�67   $��12(�6I   �� 5:   
   $��7��6   
���   �$��0,0,0,1q�62   �� 5;   
   -   5        $% performance_starPerformers_list��5;      $��8��6;   $��Disabled=�6H   #��[  5<      5=      5>      5?      