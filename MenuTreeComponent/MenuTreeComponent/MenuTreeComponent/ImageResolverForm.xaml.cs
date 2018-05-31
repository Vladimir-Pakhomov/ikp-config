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
using System.IO;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace MenuTreeComponent
{
    /// <summary>
    /// Логика взаимодействия для ImageResolverForm.xaml
    /// </summary>
    public partial class ImageResolverForm : MetroWindow
    {
        private ResolverImageCallback OnAccepted;

        private string _projectKey;

        public ImageResolverForm(ResolverImageCallback callback, string projectKey, string name = null, string src = null, string fullSrc = null)
        {
            InitializeComponent();
            OnAccepted = callback;
            _projectKey = projectKey;
            if (!string.IsNullOrEmpty(name))
                nameTextBox.Text = name;
            if (!string.IsNullOrEmpty(src))
                contentImage.Source = new BitmapImage(new Uri(fullSrc));
        }

        private async void okBtn_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(nameTextBox.Text) && contentImage.Source != null)
            {
                OnAccepted(nameTextBox.Text, (contentImage.Source as BitmapImage).UriSource.Segments.LastOrDefault(),
                    (contentImage.Source as BitmapImage).UriSource.OriginalString);
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

        private void selectImageBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            dlg.Filter = "Image files (*.jpg, *.jpeg, *.bmp, *.png) | *.jpg; *.jpeg; *.bmp; *.png";
            if(dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string shortName = new FileInfo(dlg.FileName).Name;
                // Копируем в папку приложения Media
                using (FileStream fs = File.OpenRead(dlg.FileName))
                {
                    if (!Directory.Exists(_projectKey))
                        Directory.CreateDirectory(_projectKey);
                    using(FileStream ds = File.Open(System.IO.Path.Combine(_projectKey, shortName), FileMode.Create))
                    {
                        fs.CopyTo(ds);
                    }
                }

                contentImage.Source = new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, _projectKey, shortName)));
            }
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
