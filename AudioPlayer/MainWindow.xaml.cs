using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using System.Threading;
using Microsoft.WindowsAPICodePack.Dialogs;


namespace AudioPlayer
{
    public partial class MainWindow : Window
    {
        private CancellationTokenSource cancellationTokenSource;
        private List<string> playlist;
        private int currentIndex;
        private bool isPlaying;
        private bool isRepeat;
        private bool isShuffle;

        public MainWindow()
        {
            InitializeComponent();

            playlist = new List<string>();
            cancellationTokenSource = new CancellationTokenSource();
        }

        private void ChooseFolderButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog()
            {
                IsFolderPicker = true
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                LoadPlaylist(dialog.FileName);
                Play();
            }
        }

        private void LoadPlaylist(object fileName)
        {
            throw new NotImplementedException();
        }

        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (isRepeat)
            {
                Play();
                return;
            }

            if (isShuffle)
            {
                NextRandom();
                Play();
                return;
            }

            Next();
        }

        private void PlayPauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaying)
            {
                Pause();
            }
            else
            {
                Play();
            }
        }

        private void Play()
        {
            if (playlist.Count > 0)
            {
                mediaElement.Source = new Uri(playlist[currentIndex]);
                mediaElement.Play();
                isPlaying = true;
                playPauseImage.Source = new BitmapImage(new Uri("pause.png", UriKind.Relative));
            }
        }

        private void Pause()
        {
            mediaElement.Pause();
            isPlaying = false;
            playPauseImage.Source = new BitmapImage(new Uri("play.png", UriKind.Relative));
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            Previous();
            Play();
        }

        private void Previous()
        {
            if (currentIndex > 0)
            {
                currentIndex--;
            }
            else
            {
                currentIndex = playlist.Count - 1;
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            Next();
            Play();
        }

        private void Next()
        {
            if (isShuffle)
            {
                NextRandom();
            }
            else
            {
                currentIndex = (currentIndex + 1) % playlist.Count;
            }

        }

        private void NextRandom()
        {
            throw new NotImplementedException();
        }

        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShuffleButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PositionSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}