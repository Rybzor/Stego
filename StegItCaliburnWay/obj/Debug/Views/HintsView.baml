   M S B A M L   `   `   `  ����L  HStegItCaliburnWay, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:StegItCaliburnWay.Logic.Converters"StegItCaliburnWay.Logic.Converters  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      '    !StegItCaliburnWay.Views.HintsView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      G
converters0clr-namespace:StegItCaliburnWay.Logic.Converters     5      9system&clr-namespace:System;assembly=mscorlib     5      $	��820��5	      $	��820��6     � 	Resources  5
         StegItImage �� 	UriSource  
StegItText�� 5   
   %m  &	        &	 2     �� 5      $ /Resources/StegItPng.png?�6.   ��5      ��
                
Interfejs użytkownika został podzielony na cztery główne obszary robocze wyświetlające dane (1-4), zakładki umożliwiające przełączanie się między różnymi rodzajami nośników danych i rozwijana lista umożliwiająca wybranie konkretnego algorytmu dla zadanego nośnika (5-7) oraz przyciski do wykonywania operacji związanych z ukrywaniem lub odzyskiwaniem ukrytych informacji (8-13). 

Zgodnie z numeracją na rysunku 28, komponenty o zadanym numerze pełnią następujące funkcje: 
1. Obszar z kontenerem na dane. Przedstawia on kontener, w którym użytkownik programu może umieścić dane źródłowe. W zależności od wybranego typu danych może to być tekst, obrazek, lub informacje o załadowanym pliku dźwiękowym czy wideo. Treść kontenera wczytuje się wybierając przycisk (8). 
2. Wiadomość, która będzie ukrywana w załadowanym nośniku. Aby wczytać wiadomość należy wybrać przycisk (9).
3. Obszar prezentujący kontener wraz z ukrytą w nim wiadomością.
4. Obszar, który wyświetla ukrytą w kontenerze wiadomość. 
5. Zakładki z typami nośników, w których można ukryć dane.
6. Menu kontekstowe, które umożliwia wyświetlenie informacji o autorze aplikacji, czy wskazówek odnośnie korzystania z programu oraz zamknięcie aplikacji.
7. Rozwijana lista zawierająca dostępne metody steganograficzne dla wybranej kategorii nośnika danych.
8. Przycisk akcji umożliwiający wczytanie kontenera.
9. Przycisk akcji umożliwiający wczytanie wiadomości do ukrycia.
10. Przycisk akcji ukrywający wiadomość i wyświetlający ją lub informacje o niej w polu (3).
11. Przycisk akcji umożliwiający zapisanie ukrytej wiadomości do pliku.
12. Przycisk akcji umożliwiający kasację wyborów użytkownika, takich jak załadowana wiadomość do ukrycia, lub kontener na dane. 
13. Przycisk akcji odczytujący ukrytą wiadomość znajdującą się w kontenerze (1). Po odczytaniu wiadomości przycisk ten umożliwia skopiowanie jej do systemowego schowka. 
                
            ��5       5!      .��5#      �  � RowDefinitions 5$   
   �� 5%      $��* �6   6)   �� 5&      $
��Auto �6   6,    � ColumnDefinitions 5(   
   �� 5)      $��* �6   6+   .+�5,   
   �� $��0��6   .��5-      �� $	��812��6   $	��814��6    #��[  6-   5.      �� 50   
   $
��Wrap=�51      
�������$��1��52      $��Center=�6   $��Center=�67   $
��Bold"�53      $��0, 8, 0 , 0q�6    �� Padding$ 4, 0, 10, 0q�64   #��[ 6J   6o   55      56      