   M S B A M L   `   `   `  ����J  FEditCoordonates, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:WpfDisplayTransportMessageWpfDisplayTransportMessage  5   	   [2clr-namespace:WpfDisplayTransportMessage.ViewModel$WpfDisplayTransportMessage.ViewModel  5   	   +    %WpfDisplayTransportMessage.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:WpfDisplayTransportMessage     5   	   H	ViewModel2clr-namespace:WpfDisplayTransportMessage.ViewModel     5   	     � Title$  
MainWindow��5	   	   $	��900��6   $	��800��6)    � DataContext 5
      ?   9WpfDisplayTransportMessage.ViewModel.CoordonatesViewModel  5   
   .��5      � ��6   Z�  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��22(�6   $��0��6"   $��2��6/   $��10, 30, 10, 10q�6C   $��Center=�6[   $
��Bold"�6x   $��Comic Sans MS)�6�   Liste des transports5      �� 5   
   $��15(�6   $��1��6"   $��2��6/   $��4,4,4,15q�6C   $��Center=�6U   $
��Bold"�6r   31En fonction d'un point et d'un rayon de recherche5      �� 5!   
   $��2��6   $��0,20,0,3q�6    $��Center=�62   $��Online��6O   ���	#FF1A75E2$��SemiBold"�6�   $��Segoe UI Semibold)�6�    d� 	IsChecked 6`   �� *
IsOnline+6�   �� 5#   
   $��3��6    �� Orientation$ Vertical=�6"   $	��Top=�5$      $��200, 20, 200, 20q�5%      $��Center=�6'   .+�5'      �� $ 
Horizontal=�6   $��5q�62   .+�5(      �� $��70��6   $��Latitude��6#   �� 5)      $	��130��6   $��5q�6&   ��62   �� *
Latitude+5*      �� 5+      $ 
Horizontal=�6   $��5q�62   .+�5,      �� $��70��6   $��	Longitude��6#   �� 5-      $	��130��6   $��5q�6&   ��62   �� *	Longitude+5.      �� 5/      $ 
Horizontal=�6   $��5q�62   .+�50      �� $��70��6   $��Distance��6#   �� 51      $	��130��6   $��5q�6&   ��62   �� *
Distance+52      �� 53      �� 54      $��Center=�6   $��	10,5,10,5q�62   $��Afficher��6F   ���	#FFE2EAF3��55      �� * DisplayTransportMessageCommand+6@   56      �� 57   
   $��4��6   $��2��6?   $��10q�6S   $��Center=�6_   $
��Bold"�6|   ��6!   �� *Data.Message+6|   �� 58   
   $
��auto=�6   $��6��6:   $	��400��6G   $	��600��6T   ��59      �� 5:       �� ImageSource$ 	fond4.jpg��6   .��5<      �� $��Center=�6B   ��6   �� *LinesToDisplay+��5=      �� 5>      .R�5?      �� 
����  �$	��0.1q�64   $��10q�6J    �� Padding$ 10q�6V   
�������._�5@      �� $ Vertical=�6)   .+�5A   "   �� ��6,   �� *Name+�� 5B   "   ��6/   �� *Lines+��5C   &   �� 5D   *   .R�5E   .   �� $ 
Horizontal=�69   .+�5F   2   ��  �� CornerRadius$ 50��5G   9   $��30��5H   9   $��30��5I   9   $��10q�5J   9   $ 0,0,0,0q�5K   9   
��� ���
���   �$��1q�5N   9   ._�5P   6   �� $��Center=�6@   $��Center=�6[   ��5Q   @   �� *Number+5R   3   �� 5S   2   $��	0,10,10,0q�6=   $ Vertical=�6P   .+�5T   6   �� 2  ,System.Windows.Markup.XmlAttributeProperties  XmlSpace preserve6h   $
��Bold"�6V   ��6@   �� *Mode+6h   �� 5U   6   ��6@   �� *Name+5V   3   5W   /   5X   +   5Z   #   5[      5\      5]      5_      5`      �� 5a   
   $��7��6   $��	10,5,10,5q�6   $��	0,20,0,20q�62   $��Refresh��6E   $��Center=�6W   ���	#FFD6D6D3��5b      �� *RefreshCommand+60   5c      5d      