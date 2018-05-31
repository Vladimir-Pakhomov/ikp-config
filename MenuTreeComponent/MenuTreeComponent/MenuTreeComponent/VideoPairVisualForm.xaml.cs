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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace MenuTreeComponent
{
    /// <summary>
    /// Логика взаимодействия для VideoPairVisualForm.xaml
    /// </summary>
    public partial class VideoPairVisualForm : MetroWindow
    {
        VideoPairCallback OnAccepted;

        public VideoPairVisualForm(VideoPairCallback callback, string projectKey, string correctSrc = null, string incorrectSrc = null)
        {
            InitializeComponent();
            OnAccepted = callback;
            if (!string.IsNullOrEmpty(correctSrc))
            {
                correctSrcMediaElement.Src = System.IO.Path.Combine(Environment.CurrentDirectory, projectKey, correctSrc);
            }
            correctSrcMediaElement.SetProjectKey(projectKey);
            if (!string.IsNullOrEmpty(incorrectSrc))
            {
                incorrectSrcMediaElement.Src = System.IO.Path.Combine(Environment.CurrentDirectory, projectKey, incorrectSrc);
            }
            incorrectSrcMediaElement.SetProjectKey(projectKey);
        }

        private async void okBtn_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(correctSrcMediaElement.Src) && !string.IsNullOrEmpty(incorrectSrcMediaElement.Src))
            {
                OnAccepted(correctSrcMediaElement.Src, incorrectSrcMediaElement.Src);
                this.Close();
            }
            else
            {
                await this.ShowMessageAsync("Ошибка конфигурации", "Пожалуйста, введите значения", MessageDialogStyle.Affirmative,
                    new MetroDialogSettings()
                    {
                        AnimateShow = true,
                        AnimateHide = true
                    });
            }
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
