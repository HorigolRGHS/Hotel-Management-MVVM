   M S B A M L   `   `   `  ����U  QAssigment2_HotelManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:Assigment2_HotelManagement.AdminView$Assigment2_HotelManagement.AdminView  5      ]3clr-namespace:Assigment2_HotelManagement.ViewModels%Assigment2_HotelManagement.ViewModels  5      9    3Assigment2_HotelManagement.AdminView.RoomManagement   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlocal2clr-namespace:Assigment2_HotelManagement.AdminView     5      Bvm3clr-namespace:Assigment2_HotelManagement.ViewModels     5        N� Title$  RoomManagement��5
       � DataContext 5      C   =Assigment2_HotelManagement.ViewModels.RoomManagementViewModel  5   
   .��5      � 
������ � RowDefinitions 5   
   �� 5      $��7* �6   �� 5      $��3* �6    � ColumnDefinitions 5   
   �� 5      $��6* �6   �� 5      $��4* �6   .+�5   
   &   System.Windows.Controls.DataGrid  $��0��6   $��0��6    $��2��60   $��10q�6A      AutoGenerateColumns$ False��6M   
�������
�������$��1q�6�      CanUserAddRows$ False��6�   ��5      �� *Rooms+ �� SelectedItem 5      �� *SelectedRoom+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Header$ RoomId��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6P   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 65   �� *RoomId+6P     5!      $ 
RoomNumber��6%   $	 * 6X   
 69   �� *
RoomNumber+6X     5"      $ 
RoomDetail��6%   $	 * 6c   
 69   �� *RoomDetailDescription+6c     5#      $ RoomMaxCapacity��6%   $	 * 6b   
 6>   �� *RoomMaxCapacity+6b     5$      $ RoomType��6%   $	 * 6a   
 67   �� *RoomType.RoomTypeName+6a     5%      $ RoomStat��6%   $	 * 6V   
 67   �� *
RoomStatus+6V     5&      $ RoomPrice/Day��6%   $	 * 6`   
 6<   �� *RoomPricePerDay+6`   5(      � 5+   
   $��0��6   $��1��6   $��10q�6,    5,      �� 5-      $
��Auto �6    �� 5.      $
��Auto �6    �� 5/      $
��Auto �6    �� 50      $
��Auto �6    �� 51      $
��Auto �6     53      �� 54      $
��Auto �6#   �� 55      $��2* �6#   �� 56      $
��Auto �6#   �� 57      $��2* �6#   .+�5;      �� $��0��6   $��0��6%   $	��Id:��65   $��Right=�6@   $��Center=�6\   $��14(�6w   $��5q�6�   �� 5<      $��1��6   $��0��6%   $��Number:��65   $��Right=�6D   $��Center=�6`   $��14(�6{   $��5q�6�   �� 5=      $��2��6   $��0��6%   $��Detail:��65   $��Right=�6D   $��Center=�6`   $��14(�6{   $��5q�6�   �� 5>      $��3��6   $��0��6%   $��MaxCap:��65   $��Right=�6D   $��Center=�6`   $��14(�6{   $��5q�6�   �� 5?      $��4��6   $��0��6%   $��Type:��65   $��Right=�6B   $��Center=�6^   $��14(�6y   $��5q�6�   �� 5A      $��0��6   $��2��6%   $��Status:��65   $��Right=�6D   $��Center=�6`   $��14(�6{   $��5q�6�   �� 5B      $��1��6   $��2��6%   $��Price:��65   $��Right=�6C   $��Center=�6_   $��14(�6z   $��5q�6�   �� 5E      $��0��6   $��1��6#   $��5q�63   $��5q�6>    �� 
IsReadOnly$
 True��6z   ��6J   �� *EditedRoom.RoomId+ �� Mode$ TwoWay=�6z   �� 5F      $��1��6   $��1��6#   $��5q�63   $��5q�6>   ��6J   �� *EditedRoom.RoomNumber+$ TwoWay=��� 5G      $��2��6   $��1��6#   $��5q�63   $��5q�6>   ��6J   �� *" EditedRoom.RoomDetailDescription+$ TwoWay=��� 5H      $��3��6   $��1��6#   $��5q�63   $��5q�6>   ��6J   �� *EditedRoom.RoomMaxCapacity+$ TwoWay=��� 5K      $��4��6   $��1��6$   $��5q�64   $��5q�6?    �� DisplayMemberPath$ RoomTypeName��5N       �� SelectedValuePath$ 
RoomTypeId��5O       �� SelectedValue 5L      �� *EditedRoom.RoomTypeId+$ TwoWay=���5M      �� *	RoomTypes+5O      �� 5R      $��0��6   $��3��6$   $��5q�64   $��5q�6?    d� 	IsChecked 5S      �� *EditedRoom.RoomStatus+$ TwoWay=�   ByteToBooleanConverter �� 	Converter# [  �� 5U      $��1��6   $��3��6#   $��5q�63   $��5q�6>   ��6J   �� *EditedRoom.RoomPricePerDay+$ TwoWay=�5V      � 5Y   
   $��1��6   $��1��6!   $��Center=�61   $��Center=�6N   $��10q�6i   .+�5Z      �� -   5         ��Name$	 Add��5Z      $	��ADD��6"   $��40��60   $	��100��6<   $��10q�6H   
������
�������$��14(�6   $
��Bold"�6�   ��5[      �� *AddRoomCommand+�� 5\      -   5        $ Update��5\      $��UPDATE��6%   $��40��66   $	��100��6B   $��10q�6N   
������
�������$��14(�6�   $
��Bold"�6�   ��5]      �� *UpdateRoomCommand+�� 5^      -   5        $ Delete��5^      $��DELETE��6%   $��40��66   $	��100��6B   $��10q�6N   
���Gc��
�������$��14(�6�   $
��Bold"�6�   ��5_      �� *DeleteRoomCommand+5`      5a      5b      