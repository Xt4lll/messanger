   M S B A M L   `   `   `  ����@  <local, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:locallocal  5          local.serverPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:local     5        N� Title$  
serverPage��5	      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $
��0.2* �6   �� 5      �� 5      $
��0.2* �6    � RowDefinitions 5   
   �� 5      �� 5      $
��0.1* �6   .+�5   
   �� -   5         ��Name$ usersLbx��5      $��Stretch=�6$   $��Stretch=�6B   �� 5   
   -   5        $ messagesLbx��5      $��2��6'   $��1��6;   $��Stretch=�6K   $��Stretch=�6i   �� 5   
   -   5         ��Name$ 
messageTbx��5      $��1��6&   $��1��63   $��Stretch=�6C   $��Stretch=�6a   �� 5   
   -   5         ��Name$ sendBtn��5      $��1��6"   $��Stretch=�6/   $��Stretch=�6K   $
��send��6i   $��2��6x   6�   �� 5   
   -   5        $ quitBtn��5      $��1��6"   $��Stretch=�6/   $��Stretch=�6K   $
��quit��6i   6x    � 5   
   -   5          �Name$ serverFrame��5        � NavigationUIVisibility$ Hidden=�6%   $��2��6E   $��3��6V   5      5      