   M S B A M L   `   `   `  ����G  CPerfume_Shop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Perfume_ShopPerfume_Shop  5   	       Perfume_Shop.mail_check   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Perfume_Shop     5   	     � Title$  Проверка��5      $	��400��6"   $	��400��6/    � WindowStartupLocation$ CenterScreen=�6;    � 
ResizeMode$ NoResize=�6`    � 	Resources 5	       �� 
TargetType   RoundedTextBoxStyle �� Property �� Value �� 
TargetType �� CornerRadius	 ��Name  RoundedButtonStyle��%�  &	        &	 �    �� 5   
   " ��6   .�5      ��  � �� �	#FFEEEEEE6+   �� 5       � �� �	#FFCCCCCC6,   �� 5       � ��$ 1q�60   �� 5       � ��$ 5q�6(   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      #��z��5      $ 20��5      ._�5      �� $	 PART_ContentHost��6+   5      5      5      5      �� 5   
   " ��6   .�5       ��  � �� �	#FF6200EE6+   �� 5!       � ��
 �����6+   �� 5"       � �� �	#FF6200EE6,   �� 5#       � ��$ 1q�60   �� 5$       � ��$
 10,5q�6(   �� 5%       � ��$ 16(�6)   �� 5&       � �� 5'      �� 5(      " ��6&   .R�5)      �� #��z��6!   #��z��5*      #��z��5+      $ 19��5,      ._�5-      �� $��Center=�6/   $��Center=�6L   5.      5/      51      52      53      .��54      � 
 � ColumnDefinitions
 55   
   �� 56      .+�59   
   �� -   5         ��Name$ LegitTextBox��59       �� 	MaxLength$ 5��6(   $��117,0,117,0q�66   #��[  6K   $��37��6x   $��Center=�6�   �� 5:   
   $+��%Введите код из почты��6   $��Bottom=�6/   $��30(�6J   $��
52,0,0,224q�6X   $��58��6l   ���	#FF6200EE$
��Left=�6�   $	��314��6�   �� 5;   
   -   5         ��Name$ legit��5;      $��Поддтвердить��6    $	��Top=�67   $��109,230,109,0q�6O   $��37��6z   #��[ 6�   5>      5@      