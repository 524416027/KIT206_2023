   M S B A M L   `   `   `  ����H  DKIT206_A3_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:KIT206_A3_WPF.ViewsKIT206_A3_WPF.Views  5   	   =#clr-namespace:KIT206_A3.ControllersKIT206_A3.Controllers  5   	   -    'KIT206_A3_WPF.Views.CumulativeCountView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:KIT206_A3_WPF.Views     5   	   :
controller#clr-namespace:KIT206_A3.Controllers     5   	     � Title$  CumulativeCountView��5	   	   $	��450��6%   $	��450��62   $	��320��6B   $	��320��6N    � 	Resources 5      /   )KIT206_A3_WPF.Views.ResearcherDetailsView 	  local  cumulativeList S� ObjectInstance S� 
MethodName��%z   &	        &	      7     5   
   6&   S� 5   
   8   $) #GetSelectedResearcherCumulativeList��5      5      5      .��5      � $��4 4 4 4q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��0��6   $��Cumulative Count��6   $
��Bold"�68   $��16(�6J   �� 5   
   $��1��6   $�� Year       Count��6   $
��Bold"�69   �� 5"   
   -   5         ��Name$ cumulative_list��5"      $��3��6+   $��Disabled=�68     cumulativeCountTemplate#��[ 5$      ��5#      ��  �� Source# [ 5%      5&      5'      