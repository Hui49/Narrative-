   M S B A M L   `   `   `  ����  GettingStarted    GettingStarted.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   _ [Microsoft.Kinect.Toolkit, Version=1.7.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35h dMicrosoft.Kinect.Toolkit.Controls, Version=1.7.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e352k(http://schemas.microsoft.com/kinect/2013   6@     � Title$  
MainWindow��5   	   $	��850��6   $
��1500��6)    � Topmost .   � ShowInTaskbar .   � WindowState$ 	Maximized=�6\   ��5      �� 5   
    j� TileMode$ FlipXY=�6    �� ImageSource$ images/playground.png��6'   .��5      � .+�5	   
   4  .Microsoft.Kinect.Toolkit.KinectSensorChooserUI  -   5        $��sensorChooserUi��5	   W   $��Center=�6"   $	��Top=�6?   6W   8  2Microsoft.Kinect.Toolkit.Controls.KinectUserViewer  5
   
   $	��Top=�6   $��Center=�65   $	��100��6�      UserColoringMode$ Manual=�6�   4  .Microsoft.Kinect.Toolkit.Controls.KinectRegion   KinectRegion 6R   ��  �� ElementName$ kinectRegion��6�     5   
   -   5        $��kinectRegion��5      $��
0,10,0,-10q�6-   .��5      � .+�5      8  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton  -   5        	   Label$	       Brazil!��5   %   
   LabelBackground

 �2�2�$	��Top=�6o   $��100,267,0,0q�6�   $
��Left=�6�   $	��232��6�   ���	#FF58AB43$	��276��6�   .��5      �� $	��232��6   $	��276��6)   $��images/brazil.png��65   $	��Top=�6P   5      :  4Microsoft.Kinect.Toolkit.Controls.KinectCircleButton  5      -   5           Label$ press here!��5   (   $��Right=�6<   $	��254��6X   $	��Top=�6e   $��0,555,650.6,0q�6�   $	��223��6�    J� RenderTransformOrigin$ 0,1.351&�6�   .��5      �� $	��106��6   $	��143��6)   $��images/Untitled-1.png��65   5      :  4Microsoft.Kinect.Toolkit.Controls.KinectScrollViewer  5      $��Disabled=�6'   $
��Auto=�6N   $��Bottom=�6s   .��5      �� -   5        $��scrollContent��5   :    �� Orientation$ 
Horizontal=�6!   6:   5        5      -   5        $	        Italy!��5   %   
 �	#FF3CBCE7$	��Top=�6o   $��457,267,0,0q�6�   $
��Left=�6�   $	��232��6�   ���	#FF58AB43$	��267��6�   .��5      �� $	��234��6   $	��269��6)   $��images/italy.png��65   $	��Top=�6O   5        5      -   5        $	       Spain!��5   %   
 �	#FFE45454$	��Top=�6n   $��799,267,0,0q�6�   $
��Left=�6�   $	��232��6�   ���	#FFC74848$	��265��6�   .��5      �� $	��233��6   $	��267��6)   $��images/spain3.png��65   $	��Top=�6P   5      �� 5      $
��Left=�6   $	��216��63   $	��Top=�6@   $	��238��6X   $��images/logo.png��6d   $��
155,20,0,0q�6}   �� 5      $
��Left=�6   $	��122��63   $��
430,93,0,0q�6@   $	��Top=�6T   $	��855��6l   $��images/title.png��6x     5       -   5        $	       Spain!��5    %   
 �	#FFE45454$	��Top=�6n   $��1150,267,0,0q�6�   $
��Left=�6�   $	��232��6�   ���	#FFC74848$	��265��6�   .��5!      �� $	��233��6   $	��267��6)   $��images/spain3.png��65   $	��Top=�6P   5"      5$      5%      5&      5'      