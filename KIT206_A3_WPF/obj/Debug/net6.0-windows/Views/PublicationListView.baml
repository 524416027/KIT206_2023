   M S B A M L   `   `   `  ����H  DKIT206_A3_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:KIT206_A3_WPF.ViewsKIT206_A3_WPF.Views  5      =#clr-namespace:KIT206_A3.ControllersKIT206_A3.Controllers  5      -    'KIT206_A3_WPF.Views.PublicationListView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:KIT206_A3_WPF.Views     5      :
controller#clr-namespace:KIT206_A3.Controllers     5        � 	Resources  5      1  +KIT206_A3.Controllers.PublicationController   
controller  publicationList S� ObjectInstance S� 
MethodName��%j   &	        &	      7     5   
   6+   S� 5   
   8   $ LoadPublicationList��5      5      5      .��5      � -   5         �Name$ publication_list_view��5      $��4,4,4,4q�6*    � RowDefinitions 5   
   �� 5      $��32 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��0��6   $��Publications��6   $
��Bold"�64   $��16(�6F   � 5    
   $��1��6    � ColumnDefinitions 5!      �� 5"      $
��Auto �6#   �� 5#      $
��Auto �6#   .+�5'      �� -   5        $��0��5'      $��0,4,16,4q�6%   $��Invert Order��67   $��80��6j   $
��Left=�6u   $��26��6�   � 5*      $��1��6    5+      �� 5,      $
��Auto �6'   �� 5-      $
��Auto �6'   �� 5.      $
��Auto �6'   �� 5/      $
��Auto �6'   .+�52      �� $��0��6   $��
Year from ��6,   $��Center=�6>   �� 53      -   5         ��Name$ textBoxYearFrom��53   *   $��1��6    �� TextWrapping$
 Wrap=�6a   $��48��6u   $��16��6�   �� 54      $��2��6   $
�� to ��6,   $��Center=�68   �� 55      -   5        $ textBoxYearTo��55   *   $��3��6   $
 Wrap=�6]   $��48��6q   $��16��6|   56      57      �� 5:   
   $��2��6   $�� Year       Title��6   $
��Bold"�69   �� 5=   
   -   5         ��Name$ publication_list��5=      $��3��6,   $��Disabled=�69     publicationListTemplate#��[ 5?      ��5>      �� 	 �� Source#	 [ 5A      5B      5C      