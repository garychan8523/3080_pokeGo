   M S B A M L   `   `   `  ����
  pokego    pokego.catchview   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Poke Go: Catch��5   	   $	��800��6    $
��1000��6-    � 
ResizeMode$ CanMinimize=�6:    � WindowStartupLocation$ CenterScreen=�6S    � Icon$ Resources/logo.png��6�   ��5      �� 5   
    �� EndPoint$ 0.5,1&�6    � MappingMode$ RelativeToBoundingBox=�6/    �� 
StartPoint$ 0.5,0&�6S   .��5      �  � Color$ 	#FFD8F0D8��6    � Offset$ 0.368Q�6-   � 5      $ 	#FFB8D8F0��6   5	      .��5      � .+�5   
   �� -   5        	 ��Name$	 cvpokeworldDrawing��5      $��Center=�6-   $	��457��6J   $	��980��6W   $��	0,0,0,200q�6c   $��Center=�6v   ��5      �� 5      
 �� ImageSource$
 Resources/battlebg.png��6   .+�5      �� -   5        $	 cvdialogDrawing��5      $��Center=�6.   $	��251��6K   $	��980��6X   $��0,0,0,0q�6d   $��Center=�6u   
 �� Top$	 464��6�   ��5      �� 5      $
 Resources/dialogbg.png��6!   .+�5      �� -   5         ��Name$ txtDescriptionIntro��5       �� Left$ 61��69   $ 50��6J   $	��859��6Z   
�������$��30(�6y   $��Global Monospace)�6�   �� 5      -   5        $ txtOptionCatch��5      $ 61��64   $ 90��6E   $	��859��6U   
�������$��30(�6t   $��Global Monospace)�6�   $��[Catch]��6�   6�   �� 5      -   5        $ txtOptionRun��5      $ 61��62   $	 130��6C   $	��859��6T   
�������$��30(�6s   $��Global Monospace)�6�   $��[Run]��6�   6�   �� 5      -   5        $ txtTPGinput��5      $	 238��61   $	 130��6C   $	��500��6T   
�������$��30(�6s   $��Global Monospace)�6�   $��
TYPE NOW !��6�   $��Center=�6�    �� TextAlignment$ Center=�6�   $y�	Collapsed=�6�   �� 5      -   5        $ txtTPGreturn��5      $	 238��62   $	 130��6D   $	��500��6U   
�������$��30(�6t   $��Global Monospace)�6�   $��
TYPE NOW !��6�   $��Center=�6�   $ Center=�6�   $y�	Collapsed=�6  �� 5      -	   5        $ txtTPGtimer��5      $	 686��61   $	 180��6C   $	��250��6T   
�������$��25(�6s   $��Global Monospace)�6�   $��5 seconds left��6�   $��Center=�6�   $ Right=�6  $y�	Collapsed=�6!  5      5      �� 5   
   -
   5        $	 cvcatchtarget��5       K� ZIndex$ 90��6(   $��Center=�64   $��64��6Q   $��64��6]   $��460,0,0,220q�6h   $��Center=�6}    J� Opacity$
 0.88Q�6�   5      5      5       