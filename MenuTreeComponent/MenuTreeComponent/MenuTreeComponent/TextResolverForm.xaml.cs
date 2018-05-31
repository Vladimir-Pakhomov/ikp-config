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
    /// Логика взаимодействия для TextResolverForm.xaml
    /// </summary>
    public partial class TextResolverForm : MetroWindow
    {
        ResolverCallback OnAccepted;

        public TextResolverForm(ResolverCallback callback, string name = null, string content = null)
        {
            InitializeComponent();
            OnAccepted = callback;
            if (!string.IsNullOrEmpty(name))
                nameTextBox.Text = name;
            if (!string.IsNullOrEmpty(content))
                contentTextBox.Text = content;
        }

        private async void okBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(nameTextBox.Text) && !string.IsNullOrEmpty(contentTextBox.Text))
            {
                OnAccepted(nameTextBox.Text, contentTextBox.Text);
                this.Close();
            }
            else {
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
