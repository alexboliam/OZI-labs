   M S B A M L   `   `   `  ����B  >Lab1OZI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:Lab1OZILab1OZI  5   	   "    Lab1OZI.ChangePasswordWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Lab1OZI     5   	     � Title$!  Змінити пароль��5   	    � SizeToContent$ WidthAndHeight=�6     � WindowStartupLocation$ CenterScreen=�6?   .��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      $��20 �6   �� 5      $��20 �6   �� 5      $��30 �6   �� 5      $��20 �6   �� 5      $��30 �6   �� 5      $��20 �6   �� 5      $��20 �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   +)Введіть старий пароль:69   �� 5   
   -   5        $��oldPasswordBox��5      $��1��6(   $	��250��65   .��6�   Старий пароль6�   �� 5   
   $��2��6    �� Padding$ 0px 10px 0px 0pxq�6!   )'Введіть новий пароль:6S   �� 5   
   -   5        $��newPasswordBox��5      $��3��6(   $	��250��65   .��6�   Новий пароль6�   �� 5   
   $��4��6   $ 0px 10px 0px 0pxq�6!   1/Підтвердіть новий пароль:6W   �� 5   
   -   5        $��confirmPasswordBox��5      $��5��6,   $	��250��69   .��6�   %#Підтвердіть пароль6�   �� 5   
   -   5         ��Name$ 
InputError��5      $��asdasd��5      $��6��5      $
��Wrap=�5      $y�Hidden=�5      $��12(�5       
���  ��$��Arial)�5"      $��	0 5px 0 0q�5#      � 5$   
   $��7��6   $��Right=�6!   $��0,15,0,0q�6=   .+�5%      �� -   5         �� 	IsDefault$
 True��5%      $��60��6;   $��0,0,10,0q�6I   .��6[   Змінити6d   �� 5&       �� IsCancel$
 True��6   $��60��6%   .��63   Повернутися6@   5'      5)      5*      