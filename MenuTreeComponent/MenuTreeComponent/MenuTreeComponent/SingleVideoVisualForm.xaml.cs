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
    /// Логика взаимодействия для SingleVideoVisualForm.xaml
    /// </summary>
    public partial class SingleVideoVisualForm : MetroWindow
    {
        SingleVideoCallback OnAccepted;

        public SingleVideoVisualForm(SingleVideoCallback callback, string projectKey, string src = null, bool? isCorrect = null)
        {
            InitializeComponent();
            OnAccepted = callback;
            if (!string.IsNullOrEmpty(src))
            {
                srcMediaElement.Src = System.IO.Path.Combine(Environment.CurrentDirectory, projectKey, src);
            }
            srcMediaElement.SetProjectKey(projectKey);
            if (isCorrect != null)
                isCorrectCheckBox.IsChecked = isCorrect;
        }

        private async void okBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(srcMediaElement.Src))
            {
                OnAccepted(srcMediaElement.Src, isCorrectCheckBox.IsChecked.HasValue ? isCorrectCheckBox.IsChecked.Value : false);
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
