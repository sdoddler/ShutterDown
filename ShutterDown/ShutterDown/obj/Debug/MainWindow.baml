   M S B A M L   `   `   `  ����F  BShutterDown, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ShutterDownShutterDown  5   	       ShutterDown.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ShutterDown     5   	     � Title$  ShutterDown��5   	   $��295.091��6   $��274.5��6.   .��5	      � $��0,0,2,5q�6    � ColumnDefinitions 5
   
   �� 5      �� 5      $��0* �6   .+�5   
   �� $
��Left=�6   $��
10,137,0,0q�6,   $	��Top=�6@   $	��112��6X   $��44��6d   .��5      �� -   5         ��Name$ 	_Shutdown��5      $��Shutdown��6(   $	��104��6;   $��38��6G   $��20(�6S   6a   5      	� 5   
   -   5         	�Name$	 _10��5      $��
10 Minutes��6#   $
��Left=�68   $��	10,15,0,0q�6S   $	��Top=�6f    J� RenderTransformOrigin$ 0.5,0.5&�6~    	� 	GroupName$ Minutes��6�   $��15��6�   $��78��6�   	� 5   
   -   5        $	 _20��5      $��
20 Minutes��6#   $
��Left=�68   $��	10,35,0,0q�6S   $	��Top=�6f   $ 0.5,0.5&�6~   $ Minutes��6�   $��15��6�   $��78��6�   	� 5   
   -   5        $	 _30��5      $��
30 Minutes��6#   $
��Left=�68   $��	10,55,0,0q�6S   $	��Top=�6f   $ 0.5,0.5&�6~   $ Minutes��6�   $��15��6�   $��78��6�   	� 5   
   -   5        $	 _40��5      $��
40 Minutes��6#   $
��Left=�68   $��
172,15,0,0q�6S   $	��Top=�6g   $ 0.5,0.5&�6   $ Minutes��6�   $��15��6�   $��78��6�   	� 5   
   -   5        $	 _50��5      $��
50 Minutes��6#   $
��Left=�68   $��
172,35,0,0q�6S   $	��Top=�6g   $ 0.5,0.5&�6   $ Minutes��6�   $��15��6�   $��78��6�   	� 5   
   -   5        $	 _60��5      $��
60 Minutes��6#   $
��Left=�68   $��
172,55,0,0q�6S   $	��Top=�6g   $ 0.5,0.5&�6   $ Minutes��6�   $��15��6�   $��78��6�   	� 5   
   -   5        $ Custom��5      $��Custom��6&   $
��Left=�67   $��	10,84,0,0q�6R   $	��Top=�6e   $ 0.5,0.5&�6}   $ Minutes��6�   $��15��6�   $��60��6�   �� 5   
   -	   5         ��Name$ 
customText��5      $
��Left=�6&   $��21��6A   $��
159,82,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $��45��6u   $	��Top=�6   $��43��6�    �� TextAlignment$ Right=�6�   6�   �� 5   
   $��Minutes��6   $
��Left=�6"   $	��Top=�6=   $��
202,78,0,0q�6U   $��25��6i   $��52��6u   �� 5   
   $
��Left=�6   $��138,137,0,0q�6,   $	��Top=�6A   $	��112��6Y   $��44��6e   .��5      �� -
   5        $ Cancel��5      $��Cancel��6%   $	��104��66   $��38��6B   $��20(�6N   {�.  6q   5      �� 5   
   -   5        	 ��Name$	 Status��5      $��Center=�6    $
��Idle��6D   $
��Left=�6S   $��
10,212,0,0q�6n   $	��244��6�   $��22(�6�   �� 5   
   -   5        
 ��Name$
 closeToTray��5      $��Close to Tray��6(   $
��Left=�6@   $��20��6[   $��
86,112,0,0q�6g   $	��Top=�6{   $��87��6�    d� 	IsChecked$
 TrueY�6�   6�   �� 5   
   -   5        $ 
customHour��5      $
��Left=�6&   $��21��6A   $��	80,82,0,0q�6M   $
 Wrap=�6`   $��0��6t   $	��Top=�6}   $��26��6�   $ Right=�6�   6�   �� 5    
   $��Hour(s)��6   $
��Left=�6"   $	��Top=�6=   $��
111,78,0,0q�6U   $��25��6i   $��52��6u   	� 5!   
   -   5        $ ShutdownType��5!      $��Shutdown��6,   $
��Left=�6?   $��	0,186,0,0q�6Z   $	��Top=�6m   $ ShutdownType��6�   6�   	� 5"   
   -   5        $ 	SleepType��5"      $��Sleep��6)   $
��Left=�69   $��111,186,0,0q�6T   $	��Top=�6i   $ ShutdownType��6�   6�   	� 5#   
   -   5        $ RestartType��5#      $��Restart��6+   $
��Left=�6=   $��198,186,0,0q�6X   $	��Top=�6m   $ ShutdownType��6�   6�   5%      5'      