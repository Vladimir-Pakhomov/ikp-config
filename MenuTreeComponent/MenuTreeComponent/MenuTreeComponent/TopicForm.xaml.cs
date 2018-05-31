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
using System.IO;
using System.Runtime.Serialization;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace MenuTreeComponent
{
    /// <summary>
    /// Логика взаимодействия для TopicForm.xaml
    /// </summary>
    public partial class TopicForm : MetroWindow
    {
        private Project _current;

        private Node _selectedNode;

        public Topic SelectedTopic
        {
            get
            {
                return topicsListBox.SelectedItem as Topic;
            }
        }

        public Question SelectedQuestion
        {
            get
            {
                return questionsListBox.SelectedItem as Question;
            }
        }

        public Resolver SelectedResolver
        {
            get
            {
                return resolversListBox.SelectedItem as Resolver;
            }
        }

        public TopicForm(Project current, Node selectedNode)
        {
            _current = current;
            _selectedNode = selectedNode;
            InitializeComponent();
            this.Title = $"Управление упражнениями - {selectedNode.Name}";
            updateCollection();
        }

        public event EventHandler Saved;

        private void OnSaved(EventArgs e)
        {
            if (Saved != null)
                Saved(this, e);
        }

        private void topicsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            questionsListBox.ItemsSource = SelectedTopic != null ? SelectedTopic.Questions : null;
            editTopicNameBtn.IsEnabled = topicsListBox.SelectedItems.Count > 0;
            editTopicMainQuestionBtn.IsEnabled = topicsListBox.SelectedItems.Count > 0;
            questionAddBtn.IsEnabled = topicsListBox.SelectedItems.Count > 0;
            previewBtn.IsEnabled = topicsListBox.SelectedItems.Count > 0;
            mediaInfo.DataContext = SelectedTopic;
            topicNameTextBox.DataContext = SelectedTopic;
            topicMainQuestionTextBox.DataContext = SelectedTopic;
            RefreshConclusionControls();
        }

        private void RefreshConclusionControls()
        {
            conclusionAddBtn.IsEnabled = SelectedTopic.Conclusion == null && SelectedTopic.VisualContentType != typeof(VideoPair);
            conclusionEditBtn.IsEnabled = SelectedTopic.Conclusion != null;
            conclusionRemoveBtn.IsEnabled = SelectedTopic.Conclusion != null;
        }

        private async void editTopicNameBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = await this.ShowInputAsync("Изменение названия упражнения", "Введите название упражнения", new MetroDialogSettings()
            {
                AnimateShow = true,
                AnimateHide = true,
                DefaultText = SelectedTopic.Name
            });
            if (!string.IsNullOrWhiteSpace(name))
                SelectedTopic.Name = name;
        }

        private async void editTopicMainQuestionBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = await this.ShowInputAsync("Изменение названия упражнения", "Введите название упражнения", new MetroDialogSettings()
            {
                AnimateShow = true,
                AnimateHide = true,
                DefaultText = SelectedTopic.GeneralQuestion
            });
            if (!string.IsNullOrWhiteSpace(name))
                SelectedTopic.GeneralQuestion = name;
        }

        private void questionsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            questionEditBtn.IsEnabled = questionsListBox.SelectedItems.Count > 0;
            questionRemoveBtn.IsEnabled = questionsListBox.SelectedItems.Count > 0;
            resolversListBox.ItemsSource = SelectedQuestion != null ? SelectedQuestion.Resolvers : null;
            resolverAddBtn.IsEnabled = questionsListBox.SelectedItems.Count > 0;
        }

        private async void questionAddBtn_Click(object sender, RoutedEventArgs e)
        {
            string text = await this.ShowInputAsync("Добавление вопроса", "Введите название для вопроса", new MetroDialogSettings()
            {
                AnimateShow = true,
                AnimateHide = true,
                DefaultText = "Новый вопрос"
            });
            if (!string.IsNullOrWhiteSpace(text))
            {
                SelectedTopic.Questions.Add(new Question() { Name = text, Resolvers = new ObservableCollection<Resolver>() });
            }
        }

        private async void questionEditBtn_Click(object sender, RoutedEventArgs e)
        {
            string text = await this.ShowInputAsync("Редактирование вопроса", "Введите название для вопроса", new MetroDialogSettings()
            {
                AnimateShow = true,
                AnimateHide = true,
                DefaultText = SelectedQuestion.Name
            });
            if (!string.IsNullOrWhiteSpace(text))
            {
                SelectedQuestion.Name = text;
            }
        }

        private async void questionRemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageDialogResult mdr = await this.ShowMessageAsync("Удаление вопроса", "Вы уверены, что хотите удалить этот вопрос? Все связанные с этим вопросом объекты также будут удалены.", MessageDialogStyle.AffirmativeAndNegative, new MetroDialogSettings()
            {
                AnimateShow = true,
                AnimateHide = true,
                DefaultButtonFocus = MessageDialogResult.Negative,
                NegativeButtonText = "Отмена"
            });
            if (mdr == MessageDialogResult.Affirmative)
            {
                SelectedTopic.Questions.RemoveAt(questionsListBox.SelectedIndex);
            }
        }

        private void resolversListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            resolverEditBtn.IsEnabled = resolversListBox.SelectedItems.Count > 0;
            resolverRemoveBtn.IsEnabled = resolversListBox.SelectedItems.Count > 0;
            visualAddBtn.IsEnabled = resolversListBox.SelectedItems.Count > 0 && SelectedResolver.VisualContent == null;
            visualEditBtn.IsEnabled = resolversListBox.SelectedItems.Count > 0 && SelectedResolver.VisualContent != null;
            visualRemoveBtn.IsEnabled = resolversListBox.SelectedItems.Count > 0 && SelectedResolver.VisualContent != null;
        }

        private async void resolverTextAddBtn_Click(object sender, RoutedEventArgs e)
        {
            await this.ShowOverlayAsync();
            TextResolverForm trf = new TextResolverForm((name, content) =>
            {
                SelectedQuestion.Resolvers.Add(new TextResolver() { Name = name, Content = content });
            });
            trf.Closed += async (a, b) => { await this.HideOverlayAsync(); this.Activate(); };
            trf.Owner = this;
            trf.Show();
        }

        private async void resolverImageAddBtn_Click(object sender, RoutedEventArgs e)
        {
            await this.ShowOverlayAsync();
            ImageResolverForm irf = new ImageResolverForm((name, src, fullSrc) =>
            {
                SelectedQuestion.Resolvers.Add(new ImageResolver() { Name = name, ImageSrc = src, FullImageSrc = fullSrc });
            }, _current.Root.ID);
            irf.Closed += async (a, b) => { await this.HideOverlayAsync(); this.Activate(); };
            irf.Owner = this;
            irf.Show();
        }

        private async void visualVideoPairAddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTopic.IsVisualContentAllowed<VideoPair>())
            {
                await this.ShowOverlayAsync();
                VideoPairVisualForm vpvf = new VideoPairVisualForm((correct, incorrect) =>
                {
                    SelectedResolver.VisualContent = new VideoPair() { correctSrc = correct, incorrectSrc = incorrect };
                    visualAddBtn.IsEnabled = false;
                    visualEditBtn.IsEnabled = true;
                    visualRemoveBtn.IsEnabled = true;
                }, _current.Root.ID);
                vpvf.Closed += async (a, b) => { await this.HideOverlayAsync(); this.Activate(); };
                vpvf.Owner = this;
                vpvf.Show();
            }
            else
            {
                await this.ShowMessageAsync(this.Title, SelectedTopic.VisualContentTypeMessage, MessageDialogStyle.Affirmative,
                    new MetroDialogSettings()
                    {
                        AnimateShow = true,
                        AnimateHide = true
                    });
            }
        }

        private async void visualSingleVideoAddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTopic.IsVisualContentAllowed<SingleVideo>())
            {
                await this.ShowOverlayAsync();
                SingleVideoVisualForm svvf = new SingleVideoVisualForm((src, isCorrect) =>
                {
                    SelectedResolver.VisualContent = new SingleVideo() { Src = src, IsNormal = isCorrect };
                    visualAddBtn.IsEnabled = false;
                    visualEditBtn.IsEnabled = true;
                    visualRemoveBtn.IsEnabled = true;
                }, _current.Root.ID);
                svvf.Closed += async (a, b) => { await this.HideOverlayAsync(); this.Activate(); };
                svvf.Owner = this;
                svvf.Show();
            }
            else
            {
                await this.ShowMessageAsync(this.Title, SelectedTopic.VisualContentTypeMessage, MessageDialogStyle.Affirmative,
                    new MetroDialogSettings()
                    {
                        AnimateShow = true,
                        AnimateHide = true
                    });
            }
        }

        private async void resolverEditBtn_Click(object sender, RoutedEventArgs e)
        {
            await this.ShowOverlayAsync();
            if (SelectedResolver is TextResolver)
            {
                TextResolverForm trf = new TextResolverForm((name, content) =>
                {
                    SelectedResolver.Name = name;
                    (SelectedResolver as TextResolver).Content = content;
                }, SelectedResolver.Name, (SelectedResolver as TextResolver).Content);
                trf.Closed += async (a, b) => { await this.HideOverlayAsync(); this.Activate(); };
                trf.Owner = this;
                trf.Show();
            }
            else if(SelectedResolver is ImageResolver)
            {
                ImageResolverForm irf = new ImageResolverForm((name, src, fullSrc) =>
                {
                    SelectedResolver.Name = name;
                    (SelectedResolver as ImageResolver).ImageSrc = src;
                    (SelectedResolver as ImageResolver).FullImageSrc = fullSrc;
                }, _current.Root.ID, SelectedResolver.Name, (SelectedResolver as ImageResolver).ImageSrc, (SelectedResolver as ImageResolver).FullImageSrc);
                irf.Closed += async (a, b) => { await this.HideOverlayAsync(); this.Activate(); };
                irf.Owner = this;
                irf.Show();
            }
        }

        private async void resolverRemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageDialogResult mdr = await this.ShowMessageAsync("Удаление материала", "Вы уверены, что хотите удалить этот материал? Все связанные с этим материалом объекты также будут удалены.", MessageDialogStyle.AffirmativeAndNegative, new MetroDialogSettings()
            {
                AnimateShow = true,
                AnimateHide = true,
                DefaultButtonFocus = MessageDialogResult.Negative,
                NegativeButtonText = "Отмена"
            });
            if (mdr == MessageDialogResult.Affirmative)
            {
                SelectedQuestion.Resolvers.RemoveAt(resolversListBox.SelectedIndex);
            }
        }

        private async void visualEditBtn_Click(object sender, RoutedEventArgs e)
        {
            await this.ShowOverlayAsync();
            if(SelectedResolver.VisualContent is VideoPair)
            {
                VideoPairVisualForm vpvf = new VideoPairVisualForm((correct, incorrect) => {
                    (SelectedResolver.VisualContent as VideoPair).correctSrc = correct;
                    (SelectedResolver.VisualContent as VideoPair).incorrectSrc = incorrect;
                }, _current.Root.ID, (SelectedResolver.VisualContent as VideoPair).correctSrc, (SelectedResolver.VisualContent as VideoPair).incorrectSrc);
                vpvf.Closed += async (a, b) => { await this.HideOverlayAsync(); this.Activate(); };
                vpvf.Owner = this;
                vpvf.Show();
            }
            else if(SelectedResolver.VisualContent is SingleVideo)
            {
                SingleVideoVisualForm svvf = new SingleVideoVisualForm((src, isCorrect) =>
                {
                    (SelectedResolver.VisualContent as SingleVideo).Src = src;
                    (SelectedResolver.VisualContent as SingleVideo).IsNormal = isCorrect;
                }, _current.Root.ID, (SelectedResolver.VisualContent as SingleVideo).Src, (SelectedResolver.VisualContent as SingleVideo).IsNormal);
                svvf.Closed += async (a, b) => { await this.HideOverlayAsync(); this.Activate(); };
                svvf.Owner = this;
                svvf.Show();
            }
        }

        private async void visualRemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageDialogResult mdr = await this.ShowMessageAsync(this.Title, "Вы действительно хотите очистить визуальный контент?", MessageDialogStyle.AffirmativeAndNegative,
                    new MetroDialogSettings()
                    {
                        AnimateShow = true,
                        AnimateHide = true,
                        DefaultButtonFocus = MessageDialogResult.Negative,
                        NegativeButtonText = "Отмена"
                    });
            if(mdr == MessageDialogResult.Affirmative)
            {
                SelectedResolver.VisualContent = null;
                visualAddBtn.IsEnabled = true;
                visualEditBtn.IsEnabled = false;
                visualRemoveBtn.IsEnabled = false;
            }
        }

        private async void previewBtn_Click(object sender, RoutedEventArgs e)
        {
            await this.ShowOverlayAsync();
            if (SelectedTopic.Conclusion != null)
            {
                PreviewForms.PreviewForm3 pf3 = new PreviewForms.PreviewForm3(this.SelectedTopic, _current.Root.ID);
                pf3.Owner = this;
                pf3.Show();
                pf3.Closed += async (a, b) => { await this.HideOverlayAsync(); this.Activate(); };
            }
            else if (SelectedTopic.VisualContentType == typeof(VideoPair))
            {
                PreviewForms.PreviewForm1 pf1 = new PreviewForms.PreviewForm1(this.SelectedTopic, _current.Root.ID);
                pf1.Owner = this;
                pf1.Show();
                pf1.Closed += async(a, b) => { await this.HideOverlayAsync(); this.Activate(); };
            }
            else if(SelectedTopic.VisualContentType == typeof(SingleVideo))
            {
                PreviewForms.PreviewForm2 pf2 = new PreviewForms.PreviewForm2(this.SelectedTopic, _current.Root.ID);
                pf2.Owner = this;
                pf2.Show();
                pf2.Closed += async (a, b) => { await this.HideOverlayAsync(); this.Activate(); };
            }
        }

        private async void topicAddBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = await this.ShowInputAsync("Добавление нового упражнения", "Введите название упражнения", new MetroDialogSettings()
            {
                AnimateShow = true,
                AnimateHide = true,
                DefaultText = "Новое упражнение"
            });
            if (!string.IsNullOrWhiteSpace(name))
            {
                string generalQuestion = await this.ShowInputAsync("Добавление нового упражнения", "Введите главный вопрос упражнения", new MetroDialogSettings()
                {
                    AnimateShow = true,
                    AnimateHide = true,
                    DefaultText = "Новый главный вопрос"
                });
                if (!string.IsNullOrWhiteSpace(generalQuestion))
                {
                    string id = _selectedNode.Add(name, true, _current.HandleChange);
                    _current.Topics.Add(new Topic() { Name = name, GeneralQuestion = generalQuestion,
                        NodeIDs = new ObservableCollection<Tuple<string, string>>
                        { new Tuple<string, string>(id, _selectedNode.ID) },
                        Questions = new ObservableCollection<Question>() });
                    updateCollection();
                }
            }
        }

        private void updateCollection()
        {
            topicsListBox.ItemsSource = _current.Topics.Where(t => t.NodeIDs != null && 
            t.NodeIDs.Any(n => n.Item2 == _selectedNode.ID));
        }

        private async void topicsSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            OnSaved(new EventArgs());
            await this.ShowMessageAsync("Сохранить проект", "Проект успешно сохранен");
        }

        private async void conclusionAddBtn_Click(object sender, RoutedEventArgs e)
        {
            await this.ShowOverlayAsync();
            VideoVerdictVisualForm vvvf = new VideoVerdictVisualForm((v) =>
            {
                SelectedTopic.Conclusion = v;
                RefreshConclusionControls();
            });
            vvvf.Closed += async (a, b) => { await this.HideOverlayAsync(); this.Activate(); };
            vvvf.Owner = this;
            vvvf.Show();
        }

        private async void conclusionEditBtn_Click(object sender, RoutedEventArgs e)
        {
            await this.ShowOverlayAsync();
            VideoVerdictVisualForm vvvf = new VideoVerdictVisualForm((v) =>
            {
                SelectedTopic.Conclusion = v;
                RefreshConclusionControls();
            }, SelectedTopic.Conclusion);
            vvvf.Closed += async (a, b) => { await this.HideOverlayAsync(); this.Activate(); };
            vvvf.Owner = this;
            vvvf.Show();
        }

        private async void conclusionRemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageDialogResult mdr = await this.ShowMessageAsync(this.Title, "Вы действительно хотите очистить удалить заключение?", MessageDialogStyle.AffirmativeAndNegative,
                new MetroDialogSettings()
                    {
                        AnimateShow = true,
                        AnimateHide = true,
                        DefaultButtonFocus = MessageDialogResult.Negative,
                        NegativeButtonText = "Отмена"
                    });
            if (mdr == MessageDialogResult.Affirmative)
            {
                SelectedTopic.Conclusion = null;
                RefreshConclusionControls();
            }
        }

        private async void topicRemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            // Удаление упражнения аналогично удалению нода из иерархии, поэтому достаточно дернуть удаление по ID
            Tuple<string, string> target = ((sender as Button).DataContext as Topic).NodeIDs.FirstOrDefault(x => x.Item2 == _selectedNode.ID);
            if (target != null)
            {
                MessageDialogResult mdr = await this.ShowMessageAsync(this.Title,
                    $"Вы действительно хотите удалить упражнение {((sender as Button).DataContext as Topic).Name} из {_selectedNode.Name}?", MessageDialogStyle.AffirmativeAndNegative,
                    new MetroDialogSettings()
                    {
                        AnimateShow = true,
                        AnimateHide = true,
                        DefaultButtonFocus = MessageDialogResult.Negative,
                        NegativeButtonText = "Отмена"
                    });
                if (mdr == MessageDialogResult.Affirmative)
                {
                    ((sender as Button).DataContext as Topic).NodeIDs.Remove(target);
                    _current.Root.Remove(target.Item1);
                    updateCollection();
                }   
            }
        }
    }
}
