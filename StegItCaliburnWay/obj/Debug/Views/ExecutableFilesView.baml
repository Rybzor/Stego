   M S B A M L   `   `   `  ����L  HStegItCaliburnWay, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:StegItCaliburnWay.ViewsStegItCaliburnWay.Views  5      W0clr-namespace:StegItCaliburnWay.Logic.Converters"StegItCaliburnWay.Logic.Converters  5      1    +StegItCaliburnWay.Views.ExecutableFilesView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:StegItCaliburnWay.Views     5      ^ ZCaliburn.Micro.Platform, Version=3.0.1.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  5      A
converters0clr-namespace:StegItCaliburnWay.Logic.Converters  5        � 	Resources  5      >  8StegItCaliburnWay.Logic.Converters.ByteToStringConverter   ByteToStringConverter��%   &	          5   
   6+   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $	��90* �6   6+    � ColumnDefinitions 5   
   �� 5      $	��45* �6   6-   �� 5      $	��10* �6   6-   �� 5      $	��45* �6   6-   .+�5   
   � $��0��6    5      �� 5      $
��Auto �6#   62   �� 5      $��* �6#   6/   .+�5!      �� $��0��6   $��Center=�6(   $
��Bold"�6C    �� Padding$ 4, 0, 10, 0q�6U   $��Wybierz algorytm:��6k   6�   �� 5#      -   5         ��Name$ ExecutableFilesMethods��5#      $��1��67    �� DisplayMemberPath$
 Name��5$       �� SelectedItem 5%      �� *SelectedExecutableFilesMethod+5&      5'      �� 5)   
   $
��Auto=�6   $��1��6:   $��0��6G   .��5*      ��  �� TextAlignment$ Center=�6   $��Center=�6/   $��Center=�6L   $
��Wrap=�6g   $ 
2, 2, 2, 2q�6{   ��6�   �� *ContainerFileInfo+5+      �� 5-   
   $��0��6   $��1��6   $��2��6-   6@   �� 5/   
   $��0��6   $��2��6!   $
��Bold"�61   $��Center=�6C   $ 0, 0, 10, 0q�6^   $��Tekst do ukrycia:��6t   6�   �� 51   
   $
��Auto=�6   $��1��6:   $��2��6G   .��52      �� $
��Wrap=�6   $ 
2, 2, 2, 2q�6,   ��6A   �� *MessageToHide+ �� 	Converter# [  53      54      55      