   M S B A M L   `   `   `  ����U  QAssigment2_HotelManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:Assigment2_HotelManagement.CustomerView'Assigment2_HotelManagement.CustomerView  5      ]3clr-namespace:Assigment2_HotelManagement.ViewModels%Assigment2_HotelManagement.ViewModels  5      5    /Assigment2_HotelManagement.CustomerView.Profile   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Glocal5clr-namespace:Assigment2_HotelManagement.CustomerView     5      Bvm3clr-namespace:Assigment2_HotelManagement.ViewModels     5        N� Title$  Profile��5
       N� 
Background
 ����� � DataContext 5      <   6Assigment2_HotelManagement.ViewModels.ProfileViewModel  5   
   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��8* �6   .+�5    
   �� $��	Full Name��6   $��0��6%   $��0��65   $	��0,5q�6B   �� 5!   
   $��0��6   $��1��6   ��6/   �� *Customer.CustomerFullName+ �� Mode$ TwoWay=��� 5$   
   $��	Telephone��6   $��0��6%   $��1��65   $	��0,5q�6B   �� 5%   
   $��1��6   $��1��6   ��6/   �� *Customer.Telephone+$ TwoWay=��� 5'   
   $��Email Address��6   $��0��6)   $��2��69   $	��0,5q�6F   �� 5(   
   $��2��6   $��1��6    �� 
IsReadOnly$
 True��6c   ��6/   �� *Customer.EmailAddress+$ TwoWay=�6c   �� 5+   
   $��Birthday��6   $��0��6$   $��3��64   $	��0,5q�6A   (  "System.Windows.Controls.DatePicker  5,   
   $��3��6   $��1��6"      SelectedDate 62   �� *BirthdayToDateTime+$ TwoWay=�6m   �� 5/   
   $��Status��6   $��0��6"   $��4��62   $	��0,5q�6?   �� 50   
   $��4��6   $��1��6   ��6/   �� *Customer.CustomerStatus+$ TwoWay=��� 53   
   $��Update Profile��6   $��6��6*   $��2��67   $	��150��6K   $��40��6W   $��Center=�6c   $��Center=�6�   ��54      �� *UpdateProfileCommand+55      56      