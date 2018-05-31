using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace MenuTreeComponent.PreviewForms
{
    /// <summary>
    /// Логика взаимодействия для PreviewForm2.xaml
    /// </summary>
    public partial class PreviewForm2 : MetroWindow
    {
        private Topic _current;

        private string _pk;

        private Brush _defaultBg;

        public PreviewForm2(Topic target, string pk)
        {
            InitializeComponent();
            _current = target;
            _pk = pk;
            _defaultBg = normalBtn.Background;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            generalQuestionTxt.Text = _current.GeneralQuestion;
            questionsListBox.ItemsSource = _current.Questions;
        }

        private void normalBtn_Click(object sender, RoutedEventArgs e)
        {
            SingleVideo sv = _current.Questions[questionsListBox.SelectedIndex].Resolvers[resolversListBox.SelectedIndex].VisualContent as SingleVideo;
            normalBtn.Background = new SolidColorBrush(sv.IsNormal ? Colors.DarkGreen : Colors.DarkRed);
            problemBtn.IsEnabled = false;
        }

        private void problemBtn_Click(object sender, RoutedEventArgs e)
        {
            SingleVideo sv = _current.Questions[questionsListBox.SelectedIndex].Resolvers[resolversListBox.SelectedIndex].VisualContent as SingleVideo;
            problemBtn.Background = new SolidColorBrush(!sv.IsNormal ? Colors.DarkGreen : Colors.DarkRed);
            normalBtn.IsEnabled = false;
        }

        private void questionsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(questionsListBox.SelectedIndex > -1)
            {
                resolversListBox.ItemsSource = _current.Questions[questionsListBox.SelectedIndex].Resolvers;
            }
            else
            {
                resolversListBox.ItemsSource = null;
            }
        }

        private async void resolversListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(questionsListBox.SelectedIndex > -1 && resolversListBox.SelectedIndex > -1)
            {
                SingleVideo sv = _current.Questions[questionsListBox.SelectedIndex].Resolvers[resolversListBox.SelectedIndex].VisualContent as SingleVideo;
                if (sv != null)
                {
                    media.Src = System.IO.Path.Combine(Environment.CurrentDirectory, _pk, sv.Src);
                }
                else
                {
                    await this.ShowMessageAsync("Ошибка", "Для данного материала еще не назначен медиа-контент", MessageDialogStyle.Affirmative, new MetroDialogSettings()
                    {
                        AnimateShow = true,
                        AnimateHide = true
                    });
                }
            }
            else
            {
                media.Src = null;
            }
            refreshControls();
        }

        private void refreshControls()
        {
            normalBtn.IsEnabled = media.Src != null;
            normalBtn.Background = _defaultBg;
            problemBtn.IsEnabled = media.Src != null;
            problemBtn.Background = _defaultBg;
        }
    }
}
