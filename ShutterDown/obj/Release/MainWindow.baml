   M S B A M L   `   `   `  ���� F  BShutterDown, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ShutterDownShutterDown      ShutterDown.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:ShutterDown       � Title$  ShutterDown��$��295.091��$��274.5��.��� $��0,0,2,5q� � ColumnDefinitions �� �� $��0* �.+��� $
��Left=�$��
10,137,0,0q�$	��Top=�$	��112��$��44��.���� -    ��Name$ 	_Shutdown��$��Shutdown��$	��104��$��38��$��20(�	� -    	�Name$	 _10��$��
10 Minutes��$
��Left=�$��	10,15,0,0q�$	��Top=� J� RenderTransformOrigin$ 0.5,0.5&� 	� 	GroupName$ Minutes��$��15��$��78��	� -   $	 _20��$��
20 Minutes��$
��Left=�$��	10,35,0,0q�$	��Top=�$ 0.5,0.5&�$ Minutes��$��15��$��78��	� -   $	 _30��$��
30 Minutes��$
��Left=�$��	10,55,0,0q�$	��Top=�$ 0.5,0.5&�$ Minutes��$��15��$��78��	� -   $	 _40��$��
40 Minutes��$
��Left=�$��
172,15,0,0q�$	��Top=�$ 0.5,0.5&�$ Minutes��$��15��$��78��	� -   $	 _50��$��
50 Minutes��$
��Left=�$��
172,35,0,0q�$	��Top=�$ 0.5,0.5&�$ Minutes��$��15��$��78��	� -   $	 _60��$��
60 Minutes��$
��Left=�$��
172,55,0,0q�$	��Top=�$ 0.5,0.5&�$ Minutes��$��15��$��78��	� -   $ Custom��$��Custom��$
��Left=�$��	10,84,0,0q�$	��Top=�$ 0.5,0.5&�$ Minutes��$��15��$��60���� -	    ��Name$ 
customText��$
��Left=�$��21��$��
159,82,0,0q� �� TextWrapping$
 Wrap=�$��45��$	��Top=�$��43�� �� TextAlignment$ Right=��� $��Minutes��$
��Left=�$	��Top=�$��
202,78,0,0q�$��25��$��52���� $
��Left=�$��138,137,0,0q�$	��Top=�$	��112��$��44��.���� -
   $ Cancel��$��Cancel��$	��104��$��38��$��20(�{�.  �� -   	 ��Name$	 Status��$��Center=�$
��Idle��$
��Left=�$��
10,212,0,0q�$	��244��$��22(��� -   
 ��Name$
 closeToTray��$��Close to Tray��$
��Left=�$��20��$��
86,112,0,0q�$	��Top=�$��87�� d� 	IsChecked$
 TrueY��� -   $ 
customHour��$
��Left=�$��21��$��	80,82,0,0q�$
 Wrap=�$��0��$	��Top=�$��26��$ Right=��� $��Hour(s)��$
��Left=�$	��Top=�$��
111,78,0,0q�$��25��$��52��	� -   $ ShutdownType��$��Shutdown��$
��Left=�$��	0,186,0,0q�$	��Top=�$ ShutdownType��	� -   $ 	SleepType��$��Sleep��$
��Left=�$��111,186,0,0q�$	��Top=�$ ShutdownType��	� -   $ RestartType��$��Restart��$
��Left=�$��198,186,0,0q�$	��Top=�$ ShutdownType��