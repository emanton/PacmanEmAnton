   M S B A M L   `   `   `  ����  
PacmanMVVM-    'PacmanGame.MVVM.Views.StartDialogWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  DialogWindow��5   	   $	��100��6   $	��300��6+   .��5      �� .+�5   
   �  � ColumnDefinitions 5      �� 5      �� 5	       � RowDefinitions 5      �� 5      $
��20px �6    �� 5      $
��20px �6    .+�5      �� -   5         ��Name$ userTextBlock��5      
���  ��$��Enter user name��6@   �� 5      -   5         ��Name$ nameTextBox��5      $��1��6+   $	��100��6U   ��6;   �� *
UserName+6a   �� 5      -   5        $ modeTextBlock��5      
���  ��$��1��6@   $��Choose game mode��6M   �� 5      -   5         ��Name$ modeComboBox��5      $��1��6-   $��1��6:   $	��100��6J   ��6V   �� *
LogicModes+ �� SelectedItem 5      �� *SelectedLogic+6>   5      �� 5   
   -   5         ��Name$ startButton��5      {�.  $��2��68   $	��100��6E   $��Start��6Q   ��6a   �� *LoginCommand+�� 5   
   -   5         ��Name$ DialogPresenter��5      ��64   �� *.+5      5      