   M S B A M L   `   `   `  ����  
PacmanMVVM-    'PacmanGame.MVVM.Views.StartDialogWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  DialogWindow��5   	   $	��100��6   $	��300��6+   .��5      �� .+�5   
   �  � ColumnDefinitions 5      �� 5      �� 5	       � RowDefinitions 5      �� 5      $
��20px �6    �� 5      $
��20px �6    .+�5      �� $��Enter user name��6   �� 5      $��1��6   $	��100��6@   ��6&   �� *
UserName+6@   �� 5      $��1��6   $��Choose game mode��6%   �� 5      $��1��6   $��1��6$   $	��100��64   ��6@   �� *
LogicModes+ �� SelectedItem 5      �� *SelectedLogic+5      �� 5   
   $��2��6   $	��100��6   $��Start��6*   ��6:   �� *LoginCommand+�� 5   
   -   5         ��Name$ DialogPresenter��5      ��64   �� *.+5      5      