   M S B A M L   `   `   `  ����E  APacmanMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:PacmanGame.MVVM.ViewModelsPacmanGame.MVVM.ViewModels  5   	   P LPacman.ComputerLogics, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullrMclr-namespace:PacmanGame.ComputerLogics.Models;assembly=Pacman.ComputerLogics PacmanGame.ComputerLogics.Models 5   	        PacmanGame.MVVM.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   >	ViewModel(clr-namespace:PacmanGame.MVVM.ViewModels     5   	   `modelsMclr-namespace:PacmanGame.ComputerLogics.Models;assembly=Pacman.ComputerLogics     5   	     � Title$  
MainWindow��5   	   $	��500��6   $	��600��6)    � DataContext 5      4   .PacmanGame.MVVM.ViewModels.PacmanGameViewModel  5   
    J� InputBindings 5
      �� 5   
   
 �� Key$
 Left��6    �� Command 6    �� *TurnLeftCommand+�� 5   
   $ Up��6    6   �� *TurnUpCommand+�� 5   
   $ Right��6    6!   �� *TurnRightCommand+�� 5   
   $
 Down��6    6    �� *TurnDownCommand+.��5      �� .+�5   
   �� $��ShowResults��6   ��6'   �� *ShowResultsCommand+�� 5   
    �� Orientation$ 
Horizontal=�6   .+�5      �� $��Score:��6   �� 5      ��6   �� *Score+5      �� 5   
   $��New game��6   ��6$   �� *RunGameCommand+�� 5   
   $��15q�5      
���   �._�5      �� $��Center=�6   $��Center=�66   ��6S   �� *FieldPoints+ � 	Resources 5       �� DataType.  (PacmanGame.ComputerLogics.Models.PointXY-  'PacmanGame.ComputerLogics.Models.Pacman �� ImageSource	 j� Stretch,  &PacmanGame.ComputerLogics.Models.Ghost*  $PacmanGame.ComputerLogics.Models.Yam
 J� Opacity��%�  (��       5   #   *, +)(�� ]     5    #   *, +)(��      5'   #   *, +)(�� �    5.   #   *, +)�� 5      "  6#   .R�5      �� 
���   �$
��40px��64   $
��40px��6A   5      �� 5       "  6#   .R�5!      �� $
��40px��6!   $
��40px��6.   ��5"      �� 5#   "   $ Images/pacman.png��6-   $
	 Fill=�6M   5%      5&      �� 5'      "  6#   .R�5(      �� $
��40px��6!   $
��40px��6.   ��5)      �� 5*   "   $ Images/ghost.png��6-   $
	 Fill=�6L   5,      5-      �� 5.      "  6#   .R�5/      �� $
��40px��6!   $
��40px��6.   $	
 0.3Q�6<   ��50      �� 51   "   $ Images/yam.png��6-   $
	 Fill=�6J   53      54      55      ��56      �� 57      .R�58      �� $	��280��6!   $	��480��6.   59      ��5;      �� 5<       �� 
TargetType" ��6   .�5=      ��  �� Property �@��Left �� Value 68   ��  �� Path$ X��� 5>       �@��Top 67   �� $ Y�5?      5A      5B      5C      5D      