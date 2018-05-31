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
using Tools;

namespace MenuTreeComponent.PreviewForms
{
    /// <summary>
    /// Логика взаимодействия для PreviewForm3.xaml
    /// </summary>
    public partial class PreviewForm3 : MetroWindow
    {
        private Topic _current;

        private string _pk;

        private int _clicks = 0;

        private int _checkedCount = 0;

        private int _totalCorrectAnswersCount = 0;

        private int _matchCount = 0;

        public PreviewForm3(Topic target, string pk)
        {
            InitializeComponent();
            _current = target;
            _pk = pk;
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
            if(resolversListBox.SelectedIndex > -1 && questionsListBox.SelectedIndex > -1)
            {
                SingleVideo sv = _current.Questions[questionsListBox.SelectedIndex].Resolvers[resolversListBox.SelectedIndex].VisualContent as SingleVideo;
                if (sv != null)
                {
                    processClick();
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
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            generalQuestionTxt.Text = _current.GeneralQuestion;
            questionsListBox.ItemsSource = _current.Questions;
            ClearNode(_current.Conclusion.Root);
            updateCollection();
        }

        private void verdictTree_SelectedItemChanged(object sender, RoutedEventArgs e)
        {
            var cc = (sender as Button).DataContext as ConclusionComponent;
            bool? result = Verify(cc);
            if (result.HasValue && result.Value)
            {
                // И: если среди братьев все ноды с Bg=null неверные, скрыть все неверные
                var target = ((sender as Button).TemplatedParent as ContentPresenter).TemplatedParent as TreeViewItem;
                var daddy = VisualTreeHelper.GetParent(target);
                if (daddy != null)
                {
                    var bros = daddy.FindChildren<TreeViewItem>(true);
                    bool collapse = bros.All(bro => (bro.DataContext as ConclusionComponent).Bg != null
                    || !(bro.DataContext as ConclusionComponent).IsCorrectSelection);
                    if (collapse)
                    {
                        bros.ForAll(bro =>
                        {
                            if (!(bro.DataContext as ConclusionComponent).IsCorrectSelection)
                                bro.Visibility = Visibility.Collapsed;
                        });
                    }
                }
                // Если правильно, открываем дочерние ноды
                target.IsExpanded = true;
            }
        }

        private bool? Verify(ConclusionComponent cc)
        {
            // Не проверять, если уже проходили
            if (cc.Bg != null)
                return null;
            cc.Bg = cc.IsCorrectSelection ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.DarkRed);
            cc.OnPropertyChanged("Bg");
            _checkedCount++;
            if (cc.IsCorrectSelection)
            {
                _matchCount++;
                _totalCorrectAnswersCount++;
            }
            correctnessTxt.Text = $"Правильность: {(int)(100 * _matchCount / Math.Max(_checkedCount, _totalCorrectAnswersCount))} %";
            updateCollection();
            return cc.IsCorrectSelection;
        }

        private void ClearNode(Node node)
        {
            ConclusionComponent cc = node as ConclusionComponent;
            cc.Bg = null;
            cc.OnPropertyChanged("Bg");
            if (!node.IsLast)
            {
                node.ChildNodes.ForAll(ClearNode);
            }
        }

        private void processClick()
        {
            _clicks++;
            rationalityTxt.Text = $"Рациональность: {(int)(100 * Math.Pow(0.9, Math.Max(0, _clicks - 1)))} %";
        }

        private void updateCollection()
        {
            verdictTree.ItemsSource = _current.Conclusion.Root.ChildNodes;
        }
    }
}
