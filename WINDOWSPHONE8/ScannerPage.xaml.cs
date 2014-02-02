using System;
using System.Windows.Threading;
using System.Windows.Navigation;
using System.Collections.ObjectModel;

using Microsoft.Devices;
using com.google.zxing;
using com.google.zxing.common;
using com.google.zxing.qrcode;
using Microsoft.Phone.Controls;

namespace WINDOWSPHONE8
{
    public partial class ScannerPage : PhoneApplicationPage
    {
        private readonly DispatcherTimer _timer;
        private readonly ObservableCollection<string> _matches;

        private PhotoCameraLuminanceSource _luminance;
        private QRCodeReader _reader;
        private PhotoCamera _photoCamera;
        
        public ScannerPage()
        {
            InitializeComponent();

            _matches = new ObservableCollection<string>();
            _matchesList.ItemsSource = _matches;

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(250);
            _timer.Tick += (o, arg) => ScanPreviewBuffer();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _photoCamera = new PhotoCamera();
            _photoCamera.Initialized += OnPhotoCameraInitialized;
            _previewVideo.SetSource(_photoCamera);

            CameraButtons.ShutterKeyHalfPressed += (o, arg) => _photoCamera.Focus();

            base.OnNavigatedTo(e);
        }
        protected override void OnNavigatingFrom
          (System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            if (_photoCamera != null)
            {
                _photoCamera.Dispose();
            }
        }
        private void OnPhotoCameraInitialized(object sender, CameraOperationCompletedEventArgs e)
        {
            int width = Convert.ToInt32(_photoCamera.PreviewResolution.Width);
            int height = Convert.ToInt32(_photoCamera.PreviewResolution.Height);

            _luminance = new PhotoCameraLuminanceSource(width, height);
            _reader = new QRCodeReader();

            Dispatcher.BeginInvoke(() =>
            {
                _previewTransform.Rotation = _photoCamera.Orientation;
                _timer.Start();
            });
        }

        private void ScanPreviewBuffer()
        {
            try
            {
                _photoCamera.GetPreviewBufferY(_luminance.PreviewBufferY);
                var binarizer = new HybridBinarizer(_luminance);
                var binBitmap = new BinaryBitmap(binarizer);
                var result = _reader.decode(binBitmap);
                Dispatcher.BeginInvoke(() => DisplayResult(result.Text));
                // katsotaan miten käy
                string kysymysID, kysymysString;
                string viesti = result.Text;
                int categoryIdIndex = viesti.IndexOf("kysymys") + 7;
                kysymysID = viesti.Substring(categoryIdIndex);
                
                switch (kysymysID)
                {
                    case "1":
                        kysymysString = "Kysymys 1. Mikä on aakkosten kolmas kirjain?";
                        break;
                    case "2":
                        kysymysString = "Kysymys 2. Mitä kuuluu?";
                        break;
                    case "3":
                        kysymysString = "Kysymys 3. Kissa vai koira?";
                        break;
                    case "4":
                        kysymysString = "Kysymys 4. Whats yo name?";
                        break;
                    case "5":
                        kysymysString = "Kysymys 5. ...?";
                        break;
                    default:
                        kysymysString = "Kysymystä ei voitu hakea.";
                        break;
                }
                Dispatcher.BeginInvoke(() => KysymysSaatu(kysymysString));
            }
            catch
            {
            }
        }

        private void DisplayResult(string text)
        {
            if (!_matches.Contains(text))
                _matches.Add(text);
        }
        private void KysymysSaatu(string kys)
        {// kokeillaan siirtyä kysymys-sivulle
            NavigationService.Navigate(new Uri("/QuestionPage.xaml?kysymys="+kys, UriKind.Relative));
        }
    }
}