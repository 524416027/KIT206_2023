   M S B A M L   `   `   `  ����H  DKIT206_A3_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:KIT206_A3_WPF.ViewsKIT206_A3_WPF.Views  5   	       KIT206_A3_WPF.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:KIT206_A3_WPF.Views     5   	     � Title$  
MainWindow��5   	   $	��600��6   $	��600��6)   $	��900��69   $	��900��6E   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��0��6   $��0,1,0,1q�6   
���   �68   �� 5   
   -   5        $��0��5      $!��Generate Performance Report��6M   
���   �$��1q�6�   $��4q�6�   $
��Left=�6�   $��4,4,0,4q�6�   $	��192��6�    �� 	IsDefault$
 True��6�   $
��Bold"�6�   � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $	��240��6#   $��2* �62   $	��240��6=   �� 5      $	��320��6#   $��3* �62   $	��320��6=   �� 5      $	��320��6#   $��3* �62   .+�5      ,   &KIT206_A3_WPF.Views.ResearcherListView  -   5          Name$ researcherListView��5   7   $��0��6'   67   �� 5      $��0��6   $��0,0,1,0q�6%   
���   �6?   /   )KIT206_A3_WPF.Views.ResearcherDetailsView  5!      -   5          Name$ researcherDetailsView��5!   :   $��1��6*   6:   �� 5"      $��1��6   $��0,0,1,0q�6%   
���   �6?   -   'KIT206_A3_WPF.Views.PublicationListView  5%      -   5          Name$ publicationListView��5%   8   $��2��6(   68   5&      5'      5(      