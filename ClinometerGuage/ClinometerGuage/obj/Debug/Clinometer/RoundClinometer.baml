   M S B A M L   `   `   `  ����J  FClinometerGuage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ClinometerGuageClinometerGuage  5      %    ClinometerGuage.RoundClinometer   5      'localclr-namespace:ClinometerGuage  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      Hmc;http://schemas.openxmlformats.org/markup-compatibility/2006    5      -   5        $��roundClinometer��5      .��5
      � .+�5   
   A� -   5        $��	BackPlate��5      $	��230��6%   $	��230��63   $��Center=�6B   $��Center=�6]   ��5      �� 5        �� 
StartPoint$	  0,0&�6&    �� EndPoint$	 1,1&�67   .��5      �  � Color$ 	#FF5B5E66��6#    � Offset$ 1Q�65   � 5      $ #d7dde8��6#   $ 0Q�65   5       J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ 	#FF685656��6#      
BlurRadius$ 10Q�65      ShadowDepth$ 2Q�6E   5      A� 5   
   -   5        $��	MainPlate��5      $	��220��6%   $	��220��63   $��Center=�6C   $��Center=�6^   ��5      
� 5      .��5      � $ 	#FFB7FF00��6#   $
 0.02Q�65   � 5      $ 	#FFAAB92B��6#   $ 1Q�65   5      5      A� 5   
   -   5        $��CornerLight��5      $	��023��6%   $	��023��63   z�5      V� 5       .~�5!      T� -   5        CornerValue�� T� X$ 00Q�5!   >   	 T� Y$	 00Q�6E   5"      ��5$      
� 5%      .��5&      � $ Transparent��6#   $ 0Q�67   � 5'      $ 	#A9374D65��6#   $ 1Q�67   5(       5*        5+      $ 	#A8000000��6#   $ 10Q�65   $ 2Q�6E   5-      A� 5.   
   ��6%   �� 
 �� ElementName$
 	BackPlate�� �� Path$ Width���6[   �� $
 	BackPlate��$ Height���5/      
� 50       �� Opacity$	 0.3Q�6&   .��51      � $ Transparent��6#   $ 1Q�69   � 52      $ Silver��6#   $ 0Q�69   53      55      �� 56   
   -   5        $��VerticalLine��56      $��Center=�6B   
�������$��02��6�   ��6�   �� $ Height�$
 	MainPlate��6�   �� 57   
   -   5        $��HorizontalLine��57      $��Center=�6*   
�������$��02��6�   ��6�   �� $ Width�$
 	MainPlate��6�   A� 58   
   -   5        $��StrokeSmall��58   n   $��Center=�6   $��Center=�6/   $��2��6L   
�������$	��060��6�   $	��060��6�   A� 59   
   -	   5        $��StrokeMedium��59   n   $��Center=�6   $��Center=�6/   $��2��6L   
�������$	��120��6�   $	��120��6�   A� 5:   
   -
   5        $��StrokeLarge��5:   n   $��Center=�6   $��Center=�6/   $��2��6L   
�������$	��180��6�   $	��180��6�   5;      5<      