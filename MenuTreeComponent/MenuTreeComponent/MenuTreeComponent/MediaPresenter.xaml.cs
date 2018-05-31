using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tools;
using Microsoft.Win32;
using MahApps.Metro.Controls.Dialogs;

namespace MenuTreeComponent
{
    /// <summary>
    /// Логика взаимодействия для MediaPresenter.xaml
    /// </summary>
    public partial class MediaPresenter : UserControl, INotifyPropertyChanged
    {
        private string _projectKey;

        public MediaPresenter()
        {
            InitializeComponent();
            timer.Tick += Timer_Tick;
        }

        public void SetProjectKey(string projectKey)
        {
            Log($"SetProjectKey: {projectKey}");
            _projectKey = projectKey;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            progressBar.Value = mediaElement.Position.TotalMilliseconds;
        }

        private void Log(string message)
        {
            MainWindow.AppLogger.Log(message);
        }

        private DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromMilliseconds(100) };

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Src
        {
            get { Log($"Get Src from Uri={mediaElement.Source}"); return mediaElement.Source != null ? mediaElement.Source.Segments.LastOrDefault() : null; }
            set
            {
                Log($"Set Src: {value}");
                if (value != null)
                {
                    mediaElement.Source = new Uri(value); OnPropertyChanged("Src");
                }
                else
                {
                    mediaElement.Source = null;
                }
            }
        }

        public bool IsSearchEnabled
        {
            get
            {
                return uploadBtn.Visibility == Visibility.Visible;
            }
            set
            {
                uploadBtn.Visibility = value ? Visibility.Visible : Visibility.Hidden;
            }
        }

        public bool IsReady { get; private set; } = false;

        private void uploadBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Log("uploadBtn_Click");
                timer.Stop();
                Log("Timer stopped");
                System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
                dlg.Filter = "Video files (*.avi, *.mp4, *.mpeg) | *.avi; *.mp4; *.mpeg; *.swf";
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var fi = new FileInfo(dlg.FileName);
                    Log($"Selected file: {fi.Name}");
                    string mediaID = Guid.NewGuid().ToString();
                    Log($"Generated MediaID={mediaID}. Opening source file");
                    // Копируем в папку проекта
                    using (FileStream fs = File.OpenRead(dlg.FileName))
                    {
                        if (!Directory.Exists(_projectKey))
                            Directory.CreateDirectory(_projectKey);
                        Log($"Creating target file: {mediaID}{fi.Extension}");
                        using (FileStream ds = File.Open(System.IO.Path.Combine(_projectKey, $"{mediaID}{fi.Extension}"), FileMode.Create))
                        {
                            Log("Copying stream...");
                            fs.CopyTo(ds);
                        }
                    }
                    this.IsReady = false;
                    this.Src = System.IO.Path.Combine(Environment.CurrentDirectory, _projectKey, $"{mediaID}{fi.Extension}");
                    Play();
                }
            }
            catch(Exception ex)
            {
                Log($"uploadBtn_Click Exception: {ex}{Environment.NewLine} Trace: {ex.StackTrace}");
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void Play()
        {
            try
            {
                Log("Play");
                if (!this.IsReady)
                    loader.Visibility = Visibility.Visible;
                if (!timer.IsEnabled)
                {
                    Log("Timer Start");
                    timer.Start();
                }
                Log("Media.Play");
                mediaElement.Play();
            }
            catch(Exception ex)
            {
                Log($"Play Exception: {ex}{Environment.NewLine}Trace: {ex.StackTrace}");
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void Pause()
        {
            try
            {
                Log("Pause");
                Log("Timer Stop");
                timer.Stop();
                Log("Media.Pause");
                mediaElement.Pause();
            }
            catch (Exception ex)
            {
                Log($"Pause Exception: {ex}{Environment.NewLine}Trace: {ex.StackTrace}");
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void Stop()
        {
            try
            {
                Log("Stop");
                Log("Timer Stop");
                timer.Stop();
                Log("Media.Stop");
                mediaElement.Stop();
                progressBar.Value = 0;
            }
            catch (Exception ex)
            {
                Log($"Stop Exception: {ex}{Environment.NewLine}Trace: {ex.StackTrace}");
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void playBtn_Click(object sender, RoutedEventArgs e)
        {
            Log("playBtn_Click");
            Play();
        }

        private void pauseBtn_Click(object sender, RoutedEventArgs e)
        {
            Log("pauseBtn_Click");
            Pause();
        }

        private void stopBtn_Click(object sender, RoutedEventArgs e)
        {
            Log("stopBtn_Click");
            Stop();
        }

        private void muteBtn_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.IsMuted = !mediaElement.IsMuted;
        }

        private void volumeDecBtn_Click(object sender, RoutedEventArgs e)
        {
            if (mediaElement.IsMuted)
                mediaElement.IsMuted = false;
            if (mediaElement.Volume > 0)
                mediaElement.Volume -= 0.1;
        }

        private void soundIncBtn_Click(object sender, RoutedEventArgs e)
        {
            if (mediaElement.IsMuted)
                mediaElement.IsMuted = false;
            if (mediaElement.Volume < 1)
                mediaElement.Volume += 0.1;
        }

        private void mediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            try
            {
                Log("mediaElement_MediaOpened");
                progressBar.Maximum = mediaElement.NaturalDuration.TimeSpan.TotalMilliseconds;
                Log($"Set Duration={progressBar.Maximum} ms");
                loader.Visibility = Visibility.Hidden;
                this.IsReady = true;
            }
            catch(Exception ex)
            {
                Log($"mediaElement_MediaOpened Exception: {ex}{Environment.NewLine}Trace: {ex.StackTrace}");
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void mediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            Log("mediaElement_MediaEnded");
            Stop();
        }

        private void mediaElement_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            try
            {
                Log($"mediaElement_MediaFailed Details: {e.ErrorException}{Environment.NewLine}Trace: {e.ErrorException.StackTrace}");
                MessageBox.Show($"Не удалось открыть видео: {e.ErrorException.Message}");
                loader.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                Log($"mediaElement_MediaFailed Exception: {ex}{Environment.NewLine}Trace: {ex.StackTrace}");
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}
