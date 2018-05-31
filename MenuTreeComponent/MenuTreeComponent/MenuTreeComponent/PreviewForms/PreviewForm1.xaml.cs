using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace MenuTreeComponent.PreviewForms
{
    /// <summary>
    /// Логика взаимодействия для PreviewForm1.xaml
    /// </summary>
    public partial class PreviewForm1 : MetroWindow
    {
        private Topic _current;

        private string _pk;

        private Brush _defaultBg;

        public PreviewForm1(Topic target, string pk)
        {
            InitializeComponent();
            _current = target;
            _pk = pk;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            generalQuestionTxt.Text = _current.GeneralQuestion;
            questionsListBox.ItemsSource = _current.Questions;
            _defaultBg = leftBtn.Background;
        }

        private void questionsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (questionsListBox.SelectedItems.Count > 0)
            {
                resolversListBox.ItemsSource = _current.Questions[questionsListBox.SelectedIndex].Resolvers;
            }
            else resolversListBox.ItemsSource = null;
        }

        private async void resolversListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (questionsListBox.SelectedItems.Count > 0 && resolversListBox.SelectedItems.Count > 0)
            {
                VideoPair vp = _current.Questions[questionsListBox.SelectedIndex].Resolvers[resolversListBox.SelectedIndex].VisualContent as VideoPair;
                if (vp != null) {
                    int r = (new Random()).Next(0, 2);
                    leftMedia.Src = System.IO.Path.Combine(Environment.CurrentDirectory, _pk, r > 0 ? vp.correctSrc : vp.incorrectSrc);
                    rightMedia.Src = System.IO.Path.Combine(Environment.CurrentDirectory, _pk, r > 0 ? vp.incorrectSrc : vp.correctSrc);
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
                leftMedia.Src = null;
                rightMedia.Src = null;
            }
            refreshControls();
        }

        private void refreshControls()
        {
            leftBtn.IsEnabled = leftMedia.Src != null;
            leftBtn.Background = _defaultBg;
            rightBtn.IsEnabled = rightMedia.Src != null;
            rightBtn.Background = _defaultBg;
        }

        private void leftBtn_Click(object sender, RoutedEventArgs e)
        {
            VideoPair vp = _current.Questions[questionsListBox.SelectedIndex].Resolvers[resolversListBox.SelectedIndex].VisualContent as VideoPair;
            leftBtn.Background = new SolidColorBrush(leftMedia.Src == vp.correctSrc ? Colors.DarkGreen : Colors.DarkRed);
            rightBtn.IsEnabled = false;
        }

        private void rightBtn_Click(object sender, RoutedEventArgs e)
        {
            VideoPair vp = _current.Questions[questionsListBox.SelectedIndex].Resolvers[resolversListBox.SelectedIndex].VisualContent as VideoPair;
            rightBtn.Background = new SolidColorBrush(rightMedia.Src == vp.correctSrc ? Colors.DarkGreen : Colors.DarkRed);
            leftBtn.IsEnabled = false;
        }   
    }
}
