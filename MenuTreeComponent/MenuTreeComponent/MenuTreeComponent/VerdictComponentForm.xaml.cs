using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для VerdictComponentForm.xaml
    /// </summary>
    public partial class VerdictComponentForm : MetroWindow
    {
        private VerdictComponentCallback OnAccepted;

        public VerdictComponentForm(VerdictComponentCallback vc, ConclusionComponent currentComponent = null)
        {
            InitializeComponent();
            OnAccepted = vc;
            if(currentComponent != null)
            {
                nameTextBox.Text = currentComponent.Name;
                isCorrectRadioBtn.IsChecked = currentComponent.IsCorrectSelection;
                (currentComponent.IsLast ? finalRadioBtn : branchRadioBtn).IsChecked = true;
            }
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void okBtn_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(nameTextBox.Text) && (finalRadioBtn.IsChecked.HasValue && finalRadioBtn.IsChecked.Value || branchRadioBtn.IsChecked.HasValue && branchRadioBtn.IsChecked.Value))
            {
                OnAccepted(
                    nameTextBox.Text,
                    finalRadioBtn.IsChecked.HasValue && finalRadioBtn.IsChecked.Value,
                    isCorrectRadioBtn.IsChecked.HasValue && isCorrectRadioBtn.IsChecked.Value
                );
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
    }
}
