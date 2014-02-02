using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WINDOWSPHONE8.Resources;
using Microsoft.Devices;
using Windows.Phone.Media.Capture; // For advanced capture APIs
using Microsoft.Xna.Framework.Media;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows.Media;
using System.Windows.Input;

namespace WINDOWSPHONE8
{
    public partial class CameraPage : PhoneApplicationPage
    {

        // Kentät
        private int photoCounter = 0;
        PhotoCamera cam;
        MediaLibrary library = new MediaLibrary();
        // Constructor
        public CameraPage()
        {
            InitializeComponent();

        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (PhotoCamera.IsCameraTypeSupported(CameraType.Primary) == true)
            {
                cam = new PhotoCamera(CameraType.Primary);

                cam.CaptureImageAvailable += new EventHandler<ContentReadyEventArgs>(cam_CaptureImageAvailable);
                cam.AutoFocusCompleted += new EventHandler<CameraOperationCompletedEventArgs>(cam_AutoFocusCompleted);

                viewfinderCanvas.Tap += new EventHandler<GestureEventArgs>(focus_Tapped);

                viewfinderBrush.SetSource(cam);
            }
            else
            {
                txtMessage.Text = "A Camera is not available on this device.";
            }
        }
        protected override void OnNavigatingFrom
          (System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            if (cam != null)
            {
                cam.Dispose();
                cam.CaptureImageAvailable -= cam_CaptureImageAvailable;
                cam.AutoFocusCompleted -= cam_AutoFocusCompleted;
            }
        }

        private void viewfinder_Tapped(object sender, GestureEventArgs e)
        {
            if (cam != null)
            {
                try
                {
                    cam.CaptureImage();
                }
                catch(Exception ex)
                {
                    this.Dispatcher.BeginInvoke(delegate()
                    {
                        txtMessage.Text = ex.Message;
                    });
                }
            }
        }

        void cam_CaptureImageAvailable(object sender, ContentReadyEventArgs e)
        {
            photoCounter++;
            string fileName = photoCounter + ".jpg";
            Deployment.Current.Dispatcher.BeginInvoke(delegate()
            {
                txtMessage.Text = "Captured image available, saving picture.";
            });
            library.SavePictureToCameraRoll(fileName, e.ImageStream);
            Deployment.Current.Dispatcher.BeginInvoke(delegate()
            {
                txtMessage.Text = "Picture has been saved to camera roll.";
            });
        }

        protected override void OnOrientationChanged(OrientationChangedEventArgs e)
        {
            if (cam != null)
            {
                Dispatcher.BeginInvoke(() =>
                {
                    double rotation = cam.Orientation;
                    switch (this.Orientation)
                    {
                        case PageOrientation.LandscapeLeft:
                            rotation = cam.Orientation - 90;
                            break;
                        case PageOrientation.LandscapeRight:
                            rotation = cam.Orientation + 90;
                            break;
                    }
                    viewfinderTransform.Rotation = rotation;
                });
            }
            base.OnOrientationChanged(e);
        }
        void cam_AutoFocusCompleted(object sender, CameraOperationCompletedEventArgs e)
        {
            Deployment.Current.Dispatcher.BeginInvoke(delegate()
            {
                // Write message to UI.
                txtMessage.Text = "Autofocus has completed.";

            });
        }

        private void focus_Clicked(object sender, RoutedEventArgs e)
        {
            if (cam.IsFocusSupported == true)
            {
                //Focus when a capture is not in progress.
                try
                {
                    cam.Focus();
                }
                catch (Exception focusError)
                {
                    // Cannot focus when a capture is in progress.
                    this.Dispatcher.BeginInvoke(delegate()
                    {
                        txtMessage.Text = focusError.Message;
                    });
                }
            }
            else
            {
                // Write message to UI.
                this.Dispatcher.BeginInvoke(delegate()
                {
                    txtMessage.Text = "Camera does not support programmable autofocus.";
                });
            }
        }

        void focus_Tapped(object sender, GestureEventArgs e)
        {
            if (cam != null)
            {
                if (cam.IsFocusAtPointSupported == true)
                {
                    try
                    {
                        // Determine the location of the tap.
                        Point tapLocation = e.GetPosition(viewfinderCanvas);

                        // Position the focus brackets with the estimated offsets.
                        focusBrackets.SetValue(Canvas.LeftProperty, tapLocation.X - 30);
                        focusBrackets.SetValue(Canvas.TopProperty, tapLocation.Y - 28);

                        // Determine the focus point.
                        double focusXPercentage = tapLocation.X / viewfinderCanvas.Width;
                        double focusYPercentage = tapLocation.Y / viewfinderCanvas.Height;

                        // Show the focus brackets and focus at point.
                        focusBrackets.Visibility = Visibility.Visible;
                        cam.FocusAtPoint(focusXPercentage, focusYPercentage);

                        // Write a message to the UI.
                        this.Dispatcher.BeginInvoke(delegate()
                        {
                            txtMessage.Text = String.Format("Camera focusing at point: {0:N2} , {1:N2}", focusXPercentage, focusYPercentage);
                        });
                    }
                    catch (Exception focusError)
                    {
                        // Cannot focus when a capture is in progress.
                        this.Dispatcher.BeginInvoke(delegate()
                        {
                            // Write a message to the UI.
                            txtMessage.Text = focusError.Message;
                            // Hide focus brackets.
                            focusBrackets.Visibility = Visibility.Collapsed;
                        });
                    }
                }
                else
                {
                    // Write a message to the UI.
                    this.Dispatcher.BeginInvoke(delegate()
                    {
                        txtMessage.Text = "Camera does not support FocusAtPoint().";
                    });
                }
            }
        }


    }
}