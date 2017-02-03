using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Controls;
using System.IO.Ports;

namespace GettingStarted
{
   
    public partial class MainWindow : Window
    {
        private KinectSensorChooser sensorChooser;

        //Instantiate the Kinect runtime. Required to initialize the device.
        
        Skeleton[] skeletons;

        //record the max/min distance of left/right hands
        float maxLeft = 640f, minLeft = 0f;
        float maxRight = 0f, minRight = 640f;
        float prevLeft = 0f, prevRight = 0f;

        //create your serial port
        SerialPort myPort = new SerialPort();
        //initialize your data
        byte[] bData = new byte[1];

        public MainWindow()
        {
            InitializeComponent();

            
        

            Loaded += OnLoaded;

            
           

         

            bData[0] = 0;
            ////// set your port //////
            myPort.PortName = "COM3"; // depending on the port used
            myPort.BaudRate = 9600;
            myPort.Handshake = System.IO.Ports.Handshake.None;
            myPort.Parity = Parity.None;
            myPort.DataBits = 8;
            myPort.StopBits = StopBits.One;
            myPort.ReadTimeout = 50;
            myPort.WriteTimeout = 50;
            // Check here for Arduino program:  ////
            // http://arduino.cc/en/Tutorial/Dimmer
            // http://arduino.cc/en/Reference/Serial
            ////////////////////////////////////////
            if (!myPort.IsOpen)
            {
                try
                {
                    myPort.Open();
                }
                catch (Exception ex) { }
            }

        }

    

        

        void readData(object sender, SkeletonFrameReadyEventArgs e)
        {
            using (SkeletonFrame mySFrame = e.OpenSkeletonFrame())
            {
                if (mySFrame != null)
                {
                    skeletons = new Skeleton[mySFrame.SkeletonArrayLength];
                    mySFrame.CopySkeletonDataTo(skeletons);
                    Skeleton currSkeleton = (from s in skeletons
                                             where s.TrackingState == SkeletonTrackingState.Tracked
                                             select s).FirstOrDefault();

                    if (currSkeleton != null)
                    {
                        CalcDirection(currSkeleton);
                    }
                    
                }
            }
            
        }

          private void CalcDirection(Skeleton mySkeleton)
        {
            Joint lJoint = mySkeleton.Joints[JointType.HandLeft];
            Joint rJoint = mySkeleton.Joints[JointType.HandRight];
            Joint flJoint = mySkeleton.Joints[JointType.KneeLeft];
            Joint frJoint = mySkeleton.Joints[JointType.KneeRight];
            Joint hJoint = mySkeleton.Joints[JointType.Head];

            Microsoft.Kinect.SkeletonPoint lVector = new Microsoft.Kinect.SkeletonPoint();
            lVector.X = ScaleVector(640, lJoint.Position.X);
            lVector.Y = ScaleVector(480, -lJoint.Position.Y);
            lVector.Z = lJoint.Position.Z;

            Microsoft.Kinect.SkeletonPoint rVector = new Microsoft.Kinect.SkeletonPoint();
            rVector.X = ScaleVector(640, rJoint.Position.X);
            rVector.Y = ScaleVector(480, -rJoint.Position.Y);
            rVector.Z = rJoint.Position.Z;

            lJoint.TrackingState = JointTrackingState.Tracked;
            if (lVector.X > prevLeft)
            {
                maxLeft = lVector.X;
            }
            if (lVector.X < prevLeft)
            {
                minLeft = lVector.X;
                if (maxLeft > minLeft)
                {
                    bData[0] = 1;
                    
                  
                       
                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\lenovo\Desktop\brazil music.wav");
                        player.Play();
                        myPort.Write(bData, 0, 1);//output the siginal
                       
                       
                }
            }
            prevLeft = lVector.X;

            rJoint.TrackingState = JointTrackingState.Tracked;
            if (rVector.X < prevRight)
            {
                minRight = rVector.X;
            }
            if (rVector.X > prevRight)
            {
                maxRight = rVector.X;
                if (maxRight > minRight)
                {
                    bData[0] = 1;
                   
                 
                        
                        myPort.Write(bData, 0, 1);
                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\lenovo\Desktop\brazil music.wav");
                        player.Play();
                      

                }
            }
            prevRight = rVector.X;

            if (flJoint.Position.Y > frJoint.Position.Y+10)
            {
                bData[0] = 2;
                
                try
                {
                    myPort.Write(bData, 0, 1);//output the siginal
                }
                catch (Exception ex) { }
            }
            if (flJoint.Position.Y +10< frJoint.Position.Y)
            {
                bData[0] = 2;
                
                try
                {
                    myPort.Write(bData, 0, 1);//output the siginal
                }
                catch (Exception ex) { }
            }
            float rjointy = rJoint.Position.Y;
            float hjointy = hJoint.Position.Y;
            if (rjointy > hjointy)
            {
                bData[0] = 2;


                try
                {
                    myPort.Write(bData, 0, 1);//output the siginal
                }
                catch (Exception ex) {
                    hjointy = -1000;
                }
              

            }
            
             float ljointy = lJoint.Position.Y;

             if (ljointy > hjointy)  
             {
                 bData[0] = 3;


                 myPort.Write(bData, 0, 1);//output the siginal
                 hjointy = -1000;


             }

           
           
        }

        //vector scaling was imported from the Coding4Fun Kinect Toolkit http://c4fkinect.codeplex.com/
        private float ScaleVector(int length, float position)
        {
            float value = (((float)length / 2f) * position) + (length / 2);
            if (value > length)
                return (float)length;
            if (value < 0f)
                return 0f;
            return value;
        }

        

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {

            this.sensorChooser = new KinectSensorChooser();
            this.sensorChooser.KinectChanged += SensorChooserOnKinectChanged;
            this.sensorChooserUi.KinectSensorChooser = this.sensorChooser;
            this.sensorChooser.Start();

            //fill scroll content
           
        }

       
        

        private void SensorChooserOnKinectChanged(object sender, KinectChangedEventArgs args)
        {
            bool error = false;
            if (args.OldSensor != null)
            {
                try
                {
                    args.OldSensor.DepthStream.Range = DepthRange.Default;
                    args.OldSensor.SkeletonStream.EnableTrackingInNearRange = false;
                    args.OldSensor.DepthStream.Disable();
                    args.OldSensor.SkeletonStream.Disable();
                }
                catch (InvalidOperationException)
                {
                    // KinectSensor might enter an invalid state while enabling/disabling streams or stream features.
                    // E.g.: sensor might be abruptly unplugged.
                    error = true;
                }
            }

            if (args.NewSensor != null)
            {
                try
                {
                    args.NewSensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
                    
                    args.NewSensor.SkeletonFrameReady += readData;

                    args.NewSensor.Start();
                    args.NewSensor.SkeletonStream.Enable(); // Enable skeletal tracking
                    try
                    {
                        args.NewSensor.DepthStream.Range = DepthRange.Near;
                        args.NewSensor.SkeletonStream.EnableTrackingInNearRange = true;
                        args.NewSensor.SkeletonStream.TrackingMode = SkeletonTrackingMode.Seated;
                        args.NewSensor.SkeletonFrameReady += readData;

                        args.NewSensor.Start();
                        args.NewSensor.SkeletonStream.Enable(); // Enable skeletal tracking
                    }
                    catch (InvalidOperationException)
                    {
                        // Non Kinect for Windows devices do not support Near mode, so reset back to default mode.
                        args.NewSensor.DepthStream.Range = DepthRange.Default;
                        args.NewSensor.SkeletonStream.EnableTrackingInNearRange = false;
                        error = true;
                    }
                }
                catch (InvalidOperationException)
                {
                    error = true;
                    // KinectSensor might enter an invalid state while enabling/disabling streams or stream features.
                    // E.g.: sensor might be abruptly unplugged.
                }
            }

            if (!error)
                kinectRegion.KinectSensor = args.NewSensor;
        }

       

        private void ButtonOnClick1(object sender, RoutedEventArgs e)
        {
            var brazil = new brazil();
            this.sensorChooser.Stop();
            this.Close();
            brazil.ShowDialog();
           
        }

        private void ButtonOnClick2(object sender, RoutedEventArgs e)
        {
            var italy = new italy();
            this.sensorChooser.Stop();
            this.Close();
            italy.ShowDialog();
        }

        private void ButtonOnClick3(object sender, RoutedEventArgs e)
        {
            var spain = new spain();
            this.sensorChooser.Stop();
            this.Close();
            spain.ShowDialog();
        }

        private void ButtonOnClick4(object sender, RoutedEventArgs e)
        {
            var kean = new kean();
            this.sensorChooser.Stop();
            this.Close();
            kean.ShowDialog();
        }

        private void ButtonOnClick5(object sender, RoutedEventArgs e)
        {
            var Face = new Face();
            this.sensorChooser.Stop();
            this.Close();
            Face.ShowDialog();
        }

                
    }
}
//http://dotneteers.net/blogs/vbandi/archive/2013/03/25/kinect-interactions-with-wpf-part-i-getting-started.aspx