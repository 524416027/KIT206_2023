   M S B A M L   `   `   `  ����H  DKIT206_A3_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:KIT206_A3_WPF.ViewsKIT206_A3_WPF.Views  5      =#clr-namespace:KIT206_A3.ControllersKIT206_A3.Controllers  5      ,    &KIT206_A3_WPF.Views.ResearcherListView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:KIT206_A3_WPF.Views     5      :
controller#clr-namespace:KIT206_A3.Controllers     5        � 	Resources  5      0  *KIT206_A3.Controllers.ResearcherController   
controller  researcherList S� ObjectInstance S� 
MethodName��%i   &	        &	      7     5   
   6*   S� 5   
   8   $ LoadResearcherList��5      5      5      .��5      � -   5         �Name$ researcher_list_view��5      $��4,4,4,4q�6)    � RowDefinitions 5   
   �� 5      $��48 �6   �� 5      .+�5   
   �� $��Name Filter:��6   $
��Left=�6'   $	��Top=�6B   $��24��6Z   $��76��6f   $
��Left=�6q   $	��Top=�6�   $��	-4,-4,0,0q�6�   �� 5   
   -   5         ��Name$ textBoxNameFilter��5      $
��Left=�6R    �� TextWrapping$
 Wrap=�6m   $	��Top=�6�   $	��156��6�   $��72,0,0,0q�6�   $��20��6�   �� 5   
   $��Level Filter:��6   $
��Left=�6(   $	��Top=�6C   $��24��6[   $��76��6g   $
��Left=�6r   $	��Top=�6�   $��	-4,20,0,0q�6�   �� 5   
   -   5         ��Name$ comboBoxLevelFilter��5      $
��Left=�6_   $	��Top=�6z   $	��128��6�   $��	72,24,0,0q�6�   $��20��6�   .@�5       �� $�� ��6   �� 5!      $��Student��6   �� 5"      $��A��6   �� 5#      $��B��6   �� 5$      $��C��6   �� 5%      $��D��6   �� 5&      $��E��6   5'      �� 5*   
   -   5         ��Name$ researcher_list��5*      $��1��6+     researcherListTemplate#��[ 5,      ��5+      �� 	 �� Source#	 [ 5,      5-      5.      