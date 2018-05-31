using System;
using System.Collections.Generic;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tools;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace MenuTreeComponent
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private Project _current;
        public Project Current
        {
            get
            {
                return _current;
            }
            private set
            {
                _current = value;
                _current.InitComponentModel(_current.Root);
                this.DataContext = _current;
                this.SetBinding(MainWindow.TitleProperty, new Binding()
                {
                    Path = new PropertyPath("Caption"),
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                });
                saveProjectMenuItem.Header = $"Сохранить {value.ShortName}";
                saveProjectMenuItem.Visibility = Visibility.Visible;
                saveAsProjectMenuItem.Header = $"Сохранить {value.ShortName} как...";
                saveAsProjectMenuItem.Visibility = Visibility.Visible;
                ConfigMenuTab.Visibility = Visibility.Visible;
                DataMenuTab.Visibility = Visibility.Visible;
                PublishMenuTab.Visibility = Visibility.Visible;
                treeView1.ItemsSource = _current.Root.ChildNodes;
            }
        }

        public static readonly Logger AppLogger = new Logger("logs", "Application");

        private Node _selectedNode;

        public MainWindow()
        {
            InitializeComponent();
            AppLogger.Log($"=== Application Started ===");
            Title = $"Конфигуратор {VersionInfo.CurrentVersion}";
        }

        private async void AddMenuItem_Click(object sender, RoutedEventArgs e)
        {
            string text = await this.ShowInputAsync("Добавление пункта меню", "Введите название для пункта меню", new MetroDialogSettings()
            {
                AnimateShow = true,
                AnimateHide = true,
                DefaultText = "Новый пункт меню"
            });
            if (!string.IsNullOrWhiteSpace(text))
            {
                if (_selectedNode != null)
                {
                    _selectedNode.Add(text, false, Current.HandleChange);
                }
                else
                {
                    Current.Root.Add(text, false, Current.HandleChange);
                }
            }
        }

        private async void AddTopics_Click(object sender, RoutedEventArgs e)
        {
            SelectTopicsWindow stw = new SelectTopicsWindow(Current.Topics);
            stw.Owner = this;
            stw.Closed += async (a, b) => { await this.HideOverlayAsync(); this.Activate(); };
            await this.ShowOverlayAsync();
            stw.Show();
        }

        public void InsertTopics(List<Topic> selected)
        {
            if (_selectedNode != null)
            {
                selected.ForAll(t =>
                {
                    string id = _selectedNode.Add(t.Name, true, Current.HandleChange);
                    if (t.NodeIDs != null)
                    {
                        t.NodeIDs.Add(new Tuple<string, string>(id, _selectedNode.ID));
                    }
                    else t.NodeIDs = new ObservableCollection<Tuple<string, string>>
                    { new Tuple<string, string>(id, _selectedNode.ID) };
                });
            }
        }

        private async void RenameMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedNode != null)
            {
                string text = await this.ShowInputAsync("Переименование пункта меню", "Введите название для пункта меню", new MetroDialogSettings()
                {
                    AnimateShow = true,
                    AnimateHide = true,
                    DefaultText = _selectedNode.Name
                });
                if (!string.IsNullOrWhiteSpace(text))
                {
                    _selectedNode.Name = text;
                }
            }
        }

        private async void RemoveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedNode != null)
            {
                MessageDialogResult mdr = await this.ShowMessageAsync("Удаление пункта меню", "Вы уверены, что хотите удалить этот пункт меню?", MessageDialogStyle.AffirmativeAndNegative, new MetroDialogSettings()
                {
                    AnimateShow = true,
                    AnimateHide = true,
                    DefaultButtonFocus = MessageDialogResult.Negative,
                    NegativeButtonText = "Отмена"
                });
                if (mdr == MessageDialogResult.Affirmative)
                {
                    Current.Topics.ForAll(t =>
                    {
                        if (t.NodeIDs != null)
                            t.NodeIDs = new ObservableCollection<Tuple<string, string>>(
                                t.NodeIDs.Where(x => _selectedNode.IsLast && x.Item1 != _selectedNode.ID
                            || !_selectedNode.IsLast && x.Item2 != _selectedNode.ID));
                    });
                    Current.Root.Remove(_selectedNode.ID);
                }
            }
        }

        private async void ManageDataMenuItem_Click(object sender, RoutedEventArgs e)
        {
            TopicForm tf = new TopicForm(this.Current, this._selectedNode);
            tf.Owner = this;
            tf.Closed += async (a, b) => { Save(); await this.HideOverlayAsync(); this.Activate(); };
            tf.Saved += (a, b) => { Save(); };
            await this.ShowOverlayAsync();
            tf.Show();
        }

        private string ToLiteral(string input)
        {
            using (var writer = new StringWriter())
            {
                using (var provider = CodeDomProvider.CreateProvider("CSharp"))
                {
                    provider.GenerateCodeFromExpression(new CodePrimitiveExpression(input), writer, null);
                    return writer.ToString();
                }
            }
        }

        private async void PublishConfigMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (Current != null && Current.IsChanged)
            {
                // Сохраняем изменения
                Save();
            }
            string name = await this.ShowInputAsync($"Публикация конфигурации - ключ {Current.Root.ID}", "Введите название для публикации", new MetroDialogSettings()
            {
                AnimateShow = true,
                AnimateHide = true,
                DefaultText = "Новая публикация"
            });
            if (!string.IsNullOrWhiteSpace(name))
            {
                if (Current.Publish(name))
                {
                    await this.ShowMessageAsync($"Публикация конфигурации - ключ {Current.Root.ID}", $"Публикация {name} успешно создана. Вы можете посмотреть ее состояние в разделе Публикации", MessageDialogStyle.Affirmative, new MetroDialogSettings()
                    {
                        AnimateShow = true,
                        AnimateHide = true
                    });
                }
                else
                {
                    await this.ShowMessageAsync($"Публикация конфигурации - ключ {Current.Root.ID}", $"Публикация с названием {name} уже существует для этого ключа. Пожалуйста, выберите другое название", MessageDialogStyle.Affirmative, new MetroDialogSettings()
                    {
                        AnimateShow = true,
                        AnimateHide = true
                    });
                }
            }
        }

        private async void AboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            await this.ShowMessageAsync("О программе", VersionInfo.Info, MessageDialogStyle.Affirmative, new MetroDialogSettings()
            {
                AnimateShow = true,
                AnimateHide = true
            });
        }

        private void createProjectMenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.SaveFileDialog dlg = new System.Windows.Forms.SaveFileDialog();
            dlg.Filter = "Файлы конфигурации (.cfg)|*.cfg";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Current = new Project(dlg.FileName, new FileInfo(dlg.FileName).Name);
                Save();
            }
        }

        private void openProjectMenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            dlg.Filter = "Файлы конфигурации (.cfg)|*.cfg";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (FileStream fs = File.OpenRead(dlg.FileName))
                {
                    try
                    {
                        DataContractSerializer formatter = new DataContractSerializer(typeof(Project));
                        Current = formatter.ReadObject(fs) as Project;
                        Current.UpdateFile(dlg.FileName);
                    }
                    catch (Exception ex)
                    {
                        AppLogger.Log($"Open Project Exception: {ex}{Environment.NewLine}Trace: {ex.StackTrace}");
                        MessageBox.Show("Ошибка открытия проекта. Возможно, файл проекта был поврежден или изменен извне.");
                    }
                }
            }
        }

        private void Save()
        {
            try
            {
                using (FileStream fs = File.Open(Current.Name, FileMode.Create))
                {
                    DataContractSerializer formatter = new DataContractSerializer(typeof(Project));
                    formatter.WriteObject(fs, Current);
                }
                Current.IsChanged = false;
                AppLogger.Log($"=== Project {Current.Caption} Saved ===");
            }
            catch (Exception ex)
            {
                AppLogger.Log($"Save Project {Current.ShortName} Exception: {ex}{Environment.NewLine}Trace: {ex.StackTrace}");
                MessageBox.Show("Ошибка сохранения проекта. Возможно, файл проекта был поврежден или изменен извне.");
            }
        }

        private void saveProjectMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void saveAsProjectMenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.SaveFileDialog dlg = new System.Windows.Forms.SaveFileDialog();
            dlg.Filter = "Файлы конфигурации (.cfg)|*.cfg";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    using (FileStream fs = File.Open(dlg.FileName, FileMode.Create))
                    {
                        Current.Root.Name = dlg.FileName;
                        Current.ShortName = new FileInfo(dlg.FileName).Name;
                        DataContractSerializer formatter = new DataContractSerializer(typeof(Project));
                        formatter.WriteObject(fs, Current);
                    }
                    Current.IsChanged = false;
                }
                catch (Exception ex)
                {
                    AppLogger.Log($"SaveAs Project as {dlg.FileName} Exception: {ex}{Environment.NewLine}Trace: {ex.StackTrace}");
                    MessageBox.Show("Ошибка сохранения проекта. Возможно, файл проекта был поврежден или изменен извне.");
                }
            }
        }

        private void exitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async Task<MessageDialogResult> SaveChanges()
        {
            MessageDialogResult mdr = await this.ShowMessageAsync("Выход", "Сохранить изменения?", MessageDialogStyle.AffirmativeAndNegativeAndSingleAuxiliary, new MetroDialogSettings()
            {
                AnimateShow = true,
                AnimateHide = true,
                AffirmativeButtonText = "Да",
                NegativeButtonText = "Нет",
                FirstAuxiliaryButtonText = "Отмена",
                DefaultButtonFocus = MessageDialogResult.Affirmative
            });
            if (mdr == MessageDialogResult.Affirmative)
            {
                Save();
            }
            return mdr;
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Current != null && Current.IsChanged)
            {
                e.Cancel = true;
                MessageDialogResult mdr = await SaveChanges();
                if (mdr != MessageDialogResult.FirstAuxiliary)
                {
                    Current.IsChanged = false;
                    this.Close();
                }
            }
            else
            {
                AppLogger.Log($"=== Application Closed ===");
            }
        }

        private void treeView1_SelectedItemChanged(object sender, RoutedEventArgs e)
        {
            _selectedNode = (sender as Button).DataContext as Node;
            AddMenuItem.IsEnabled = _selectedNode != null && _selectedNode.ChildNodes != null;
            AddTopics.IsEnabled = _selectedNode != null && _selectedNode.ChildNodes != null;
            ManageDataMenuItem.IsEnabled = _selectedNode != null && !_selectedNode.IsLast;
        }

        private async void ServerConfigMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageDialogResult mdr = await this.ShowMessageAsync("Настройка сервера", $"Адрес сервера: {Current.ServerAddress}", MessageDialogStyle.AffirmativeAndNegativeAndDoubleAuxiliary, new MetroDialogSettings()
            {
                AnimateShow = true,
                AnimateHide = true,
                NegativeButtonText = "Отмена",
                FirstAuxiliaryButtonText = "Изменить...",
                SecondAuxiliaryButtonText = "Проверить соединение"
            });
            switch (mdr)
            {
                // Изменить: тут надо показать инпут
                case MessageDialogResult.FirstAuxiliary:
                    string newAddress = await this.ShowInputAsync("Настройка сервера", "Укажите адрес сервера", new MetroDialogSettings()
                    {
                        AnimateShow = true,
                        AnimateHide = true,
                        DefaultText = Current.ServerAddress
                    });
                    if (!string.IsNullOrWhiteSpace(newAddress))
                    {
                        Current.ServerAddress = newAddress;
                        await this.ShowMessageAsync("Настройка сервера", $"Новый адрес {newAddress} успешно сохранен", MessageDialogStyle.Affirmative, new MetroDialogSettings()
                        {
                            AnimateShow = true,
                            AnimateHide = true
                        });
                    }
                    break;
                // Проверить соединение - вешаем лоадер и делаем запрос
                case MessageDialogResult.SecondAuxiliary:
                    await this.ShowOverlayAsync();
                    loader.Visibility = Visibility.Visible;
                    bool isOK = await AppClient.Ping(Current.ServerAddress);
                    loader.Visibility = Visibility.Hidden;
                    if (isOK)
                    {
                        await this.ShowMessageAsync("Запрос успешно выполнен", $"Сервер {Current.ServerAddress} работает", MessageDialogStyle.Affirmative, new MetroDialogSettings()
                        {
                            AnimateShow = true,
                            AnimateHide = true
                        });
                    }
                    else
                    {
                        await this.ShowMessageAsync("Ошибка запроса", $"В настоящее время сервер {Current.ServerAddress} недоступен, либо не является сервером для этой программы, попробуйте повторить запрос позднее или уточните адрес у Вашего системного администратора", MessageDialogStyle.Affirmative, new MetroDialogSettings()
                        {
                            AnimateShow = true,
                            AnimateHide = true
                        });
                    }
                    break;
                default:
                    break;
            }
        }

        private async void PublicationsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            PublicationsForm pf = new PublicationsForm(Current);
            pf.Owner = this;
            pf.Closed += async (a, b) => { await this.HideOverlayAsync(); this.Activate(); };
            await this.ShowOverlayAsync();
            pf.Show();
        }
    }
}
