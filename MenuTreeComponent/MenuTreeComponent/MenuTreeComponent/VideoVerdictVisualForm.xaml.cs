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
    /// Логика взаимодействия для VideoVerdictVisualForm.xaml
    /// </summary>
    public partial class VideoVerdictVisualForm : MetroWindow
    {
        VerdictCallback OnAccepted;

        private Conclusion _verdict;

        private ConclusionComponent _currentNode;

        public VideoVerdictVisualForm(VerdictCallback callback, Conclusion verdict = null)
        {
            InitializeComponent();
            OnAccepted = callback;
            _verdict = verdict ?? new Conclusion(string.Empty, string.Empty);
            verdictTreeView.ItemsSource = _verdict.Root.ChildNodes;
        }

        private async void okBtn_Click(object sender, RoutedEventArgs e)
        {
            if(_verdict != null)
            {
                OnAccepted(_verdict);
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

        private async void verdictAddBtn_Click(object sender, RoutedEventArgs e)
        {
            await this.ShowOverlayAsync();
            VerdictComponentForm vcf = new VerdictComponentForm((name, last, correct) =>
            {
                if (_currentNode != null)
                    _currentNode.Add(name, last, (s, args) => { }, correct);
                else
                    _verdict.Root.Add(name, last, (s, args) => { }, correct);
            });
            vcf.Closed += async (a, b) => { await this.HideOverlayAsync(); };
            vcf.Owner = this;
            vcf.Show();
        }

        private async void verdictEditBtn_Click(object sender, RoutedEventArgs e)
        {
            if(_currentNode != null)
            {
                string text = await this.ShowInputAsync("Редактирование компонента заключения", "Введите название для компонента", new MetroDialogSettings()
                {
                    AnimateShow = true,
                    AnimateHide = true,
                    DefaultText = _currentNode.Name
                });
                if (!string.IsNullOrWhiteSpace(text))
                {
                    _currentNode.Name = text;
                }
            }
        }

        private async void verdictRemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            if(_currentNode != null)
            {
                MessageDialogResult mdr = await this.ShowMessageAsync("Удаление компонента заключения", "Вы уверены, что хотите удалить этот компонент?", MessageDialogStyle.AffirmativeAndNegative, new MetroDialogSettings()
                {
                    AnimateShow = true,
                    AnimateHide = true,
                    DefaultButtonFocus = MessageDialogResult.Negative,
                    NegativeButtonText = "Отмена"
                });
                if (mdr == MessageDialogResult.Affirmative)
                {
                    _verdict.Root.Remove(_currentNode.ID);
                }
            }
        }

        private void verdictTreeView_SelectedItemChanged(object sender, RoutedEventArgs e)
        {
            _currentNode = (sender as Button).DataContext as ConclusionComponent;
            verdictAddBtn.IsEnabled = _currentNode != null && !_currentNode.IsLast;
            verdictEditBtn.IsEnabled = _currentNode != null;
            verdictRemoveBtn.IsEnabled = _currentNode != null;
        }
    }
}
