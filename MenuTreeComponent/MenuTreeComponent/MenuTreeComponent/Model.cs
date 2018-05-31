using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Tools;

namespace MenuTreeComponent
{
    public delegate void StringCallback(string value);

    public delegate void ResolverCallback(string name, string content);

    public delegate void ResolverImageCallback(string name, string content, string fullSrc);

    public delegate void VideoPairCallback(string correctSrc, string incorrectSrc);

    public delegate void SingleVideoCallback(string src, bool isCorrect);

    public delegate void VerdictCallback(Conclusion verdict);

    public delegate void VerdictComponentCallback(string name, bool isLast, bool isCorrect);

    [DataContract(IsReference = true)]
    [KnownType(typeof(ConclusionComponent))]
    public class Node : INotifyPropertyChanged
    {
        [DataMember]
        public string ID { get; set; }

        [DataMember(Name = "Name")]
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public bool IsLast
        {
            get
            {
                return this.ChildNodes == null;
            }
        }

        public virtual Visual Icon
        {
            get
            {
                if (this.ChildNodes == null)
                    return App.Current.Resources["appbar_checkmark"] as Visual;
                else
                    return App.Current.Resources["appbar_folder_open"] as Visual;
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        [DataMember]
        public ObservableCollection<Node> ChildNodes { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual string Add(string name_, bool isLast, PropertyChangedEventHandler handler, object extraData = null)
        {
            Node n = new Node()
            {
                ID = Guid.NewGuid().ToString(),
                Name = name_,
                ChildNodes = isLast ? null : new ObservableCollection<Node>(),
            };
            n.PropertyChanged += handler;
            this.ChildNodes.Add(n);
            OnPropertyChanged("ChildNodes");
            return n.ID;
        }

        public virtual void Remove(string id)
        {
            Node nodeToDelete = null;
            if (this.ChildNodes != null)
            {
                foreach (var node in this.ChildNodes)
                {
                    if (string.Equals(node.ID, id))
                    {
                        nodeToDelete = node;
                        break;
                    }
                    node.Remove(id);
                }
            }
            if (nodeToDelete != null)
            {
                ObservableCollection<Node> remainingChildren =
                    nodeToDelete.ChildNodes != null ?
                    new ObservableCollection<Node>(nodeToDelete.ChildNodes.Where(node => !node.IsLast)) :
                    new ObservableCollection<Node>();
                this.ChildNodes.Remove(nodeToDelete);
                foreach(Node ch in remainingChildren)
                {
                    this.ChildNodes.Add(ch);
                }
                OnPropertyChanged("ChildNodes");
            }
        }
    }

    public class CheckingItem
    {
        public string Name { get; set; }

        public bool IsChecked { get; set; }
    }

    [DataContract]
    [KnownType(typeof(Question))]
    [KnownType(typeof(Conclusion))]
    public class Topic : INotifyPropertyChanged
    {
        [DataMember(Name = "Name")]
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        [DataMember(Name = "GeneralQuestion")]
        private string _generalQuestion;

        public string GeneralQuestion
        {
            get
            {
                return _generalQuestion;
            }
            set
            {
                _generalQuestion = value;
                OnPropertyChanged("GeneralQuestion");
            }
        }

        /// <summary>
        /// Item1 - node ID, Item2 - parent node ID
        /// </summary>
        [DataMember]
        public ObservableCollection<Tuple<string, string>> NodeIDs { get; set; }

        [DataMember]
        public ObservableCollection<Question> Questions { get; set; }

        [DataMember]
        public Conclusion Conclusion { get; set; }

        public Type VisualContentType
        {
            get
            {
                if (this.Conclusion != null)
                    return typeof(SingleVideo);
                if(this.Questions.Count > 0)
                {
                    foreach(Question q in this.Questions)
                    {
                        if(q.Resolvers.Count > 0)
                        {
                            foreach(Resolver r in q.Resolvers)
                            {
                                if(r.VisualContent != null)
                                {
                                    return r.VisualContent.GetType();
                                }
                            }
                        }
                    }
                }
                return typeof(VisualContent);
            }
        }

        public bool IsVisualContentAllowed<T>() where T : VisualContent
        {
            return this.VisualContentType == typeof(T) || this.VisualContentType == typeof(VisualContent);
        }

        public string VisualContentTypeMessage
        {
            get
            {
                string typeName = this.VisualContentType == typeof(VideoPair) ? "Видео-пара" :
                                  this.VisualContentType == typeof(SingleVideo) ? "Одиночное видео" :
                                  string.Empty;
                if (!string.IsNullOrEmpty(typeName))
                {
                    return $"В данном упражнении в качестве визуального контента используется {typeName}. Чтобы использовать другой визуальный контент в этом упражнении, нужно удалить все материалы, содержащие текущий визуальный контент.";
                }
                else
                {
                    return $"В данном упражнении пока можно использовать любой визуальный контент. После первого выбора можно будет использовать только такой контент для новых материалов. Чтобы после этого использовать другой визуальный контент в этом упражнении, нужно будет удалить все материалы, содержащие текущий визуальный контент.";
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    [DataContract]
    [KnownType(typeof(Resolver))]
    public class Question : INotifyPropertyChanged
    {
        [DataMember(Name = "Name")]
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }

        [DataMember]
        public ObservableCollection<Resolver> Resolvers { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    [DataContract]
    [KnownType(typeof(VisualContent))]
    [KnownType(typeof(TextResolver))]
    [KnownType(typeof(ImageResolver))]
    public abstract class Resolver : INotifyPropertyChanged
    {
        [DataMember(Name = "Name")]
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value;  OnPropertyChanged("Name"); }
        }

        [DataMember]
        public VisualContent VisualContent { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    [DataContract]
    public class TextResolver : Resolver
    {
        [DataMember(Name = "Content")]
        private string _content;

        public string Content
        {
            get { return _content; }
            set { _content = value; OnPropertyChanged("Content"); }
        }
    }

    [DataContract]
    public class ImageResolver : Resolver
    {
        [DataMember(Name = "ImageSrc")]
        private string _imageSrc;

        public string ImageSrc
        {
            get { return _imageSrc; }
            set { _imageSrc = value; OnPropertyChanged("ImageSrc"); }
        }

        [DataMember(Name = "FullImageSrc")]
        private string _fullImageSrc;

        public string FullImageSrc
        {
            get { return _fullImageSrc; }
            set { _fullImageSrc = value;  OnPropertyChanged("FullImageSrc"); OnPropertyChanged("Origin"); }
        }

        public ImageSource Origin
        {
            get
            {
                return new BitmapImage(new Uri(_fullImageSrc));
            }
        }
    }

    [DataContract]
    [KnownType(typeof(VideoPair))]
    [KnownType(typeof(SingleVideo))]
    [KnownType(typeof(VideoVerdict))]
    public abstract class VisualContent
    {
        public abstract bool Verify(object answer);
    }

    [DataContract]
    public class VideoPair : VisualContent
    {
        [DataMember]
        public string correctSrc { get; set; }
        [DataMember]
        public string incorrectSrc { get; set; }
        public override bool Verify(object answer)
        {
            return string.Equals(correctSrc, answer as string, StringComparison.OrdinalIgnoreCase);
        }
    }

    [DataContract]
    public class SingleVideo : VisualContent
    {
        [DataMember]
        public string Src { get; set; }
        [DataMember]
        public bool IsNormal { get; set; }
        public override bool Verify(object answer)
        {
            return IsNormal == (bool)answer;
        }
    }

    [DataContract(IsReference = true)]
    public class VerdictComponent : Node
    {

    }

    [DataContract(IsReference = true)]
    [KnownType(typeof(FinalComponent))]
    public class ConclusionComponent : Node
    {
        [DataMember]
        public bool IsCorrectSelection { get; set; }

        public override Visual Icon
        {
            get
            {
                if (this.IsLast)
                    return this.IsCorrectSelection ?
                        App.Current.Resources["appbar_checkmark"] as Visual :
                        App.Current.Resources["appbar_noentry"] as Visual;
                else
                    return App.Current.Resources["appbar_folder_open"] as Visual;
            }
        }

        public Brush Bg { get; set; }

        public override string Add(string name_, bool isLast, PropertyChangedEventHandler handler, object extraData = null)
        {
            string id = Guid.NewGuid().ToString();
            ConclusionComponent vc = new ConclusionComponent()
            {
                ID = id,
                Name = name_,
                ChildNodes = isLast ? null : new ObservableCollection<Node>(),
                IsCorrectSelection = extraData != null && ((bool?)extraData).HasValue && ((bool?)extraData).Value
            };
            vc.PropertyChanged += handler;
            this.ChildNodes.Add(vc);
            OnPropertyChanged("ChildNodes");
            return id;
        }
    }

    // В целях поддержки обратной совместимости со старыми проектами
    [DataContract(IsReference = true)]
    public class FinalComponent: ConclusionComponent { }

    [DataContract]
    [KnownType(typeof(VerdictComponent))]
    public class VideoVerdict : VisualContent
    {
        [DataMember]
        public string Caption { get; set; }
        [DataMember]
        public VerdictComponent Root;
        public override bool Verify(object answer)
        {
            throw new NotImplementedException();
        }
    }

    [DataContract]
    [KnownType(typeof(ConclusionComponent))]
    public class Conclusion
    {
        [DataMember]
        public string Caption { get; set; } // Заключение
        [DataMember]
        public ConclusionComponent Root;

        public Conclusion(string caption_, string name_)
        {
            this.Caption = caption_;
            Root = new ConclusionComponent()
            {
                ID = Guid.NewGuid().ToString(),
                Name = name_,
                ChildNodes = new ObservableCollection<Node>()
            };
        }
    }

    [DataContract]
    [KnownType(typeof(Node))]
    [KnownType(typeof(Topic))]
    public class Project : INotifyPropertyChanged
    {
        [DataMember]
        public Node Root { get; set; }

        private bool _isChanged;

        public bool IsChanged
        {
            get
            {
                return _isChanged;
            }
            set
            {
                _isChanged = value;
                OnPropertyChanged("Caption");
            }
        }

        [DataMember]
        public string ShortName { get; set; }

        [DataMember]
        public ObservableCollection<Topic> Topics { get; set; }

        [DataMember]
        public string ServerAddress { get; set; } = "localhost:8080";

        // не сериализуется
        public ObservableCollection<Publication> Publications { get; set; }

        public string ChangeMark
        {
            get
            {
                return this.IsChanged ? "*" : string.Empty;
            }
        }

        public string Caption
        {
            get
            {
                return $"Конфигуратор {VersionInfo.CurrentVersion}: {this.ShortName}{this.ChangeMark}";
            }
        }

        public string Name
        {
            get
            {
                return this.Root.Name;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void HandleChange(object sender, PropertyChangedEventArgs e)
        {
            this.IsChanged = true;
        }

        public void InitComponentModel(Node target)
        {
            if(target != null)
            {
                target.PropertyChanged += this.HandleChange;
            }
            if(target.ChildNodes != null)
            {
                foreach (Node child in target.ChildNodes)
                    InitComponentModel(child);
            }
        }

        public Project(string fileName_, string shortName_)
        {
            Root = new Node()
            {
                Name = fileName_,
                ChildNodes = new ObservableCollection<Node>(),
                ID = Guid.NewGuid().ToString()
            };
            ShortName = shortName_;
            IsChanged = true;
            Topics = new ObservableCollection<Topic>();
            Publications = new ObservableCollection<Publication>();
        }

        public bool Publish(string publicationName)
        {
            if(this.Publications == null)
            {
                this.Publications = new ObservableCollection<Publication>();
            }
            if(this.Publications.Any(p => string.Equals(p.ApiKey, Root.ID) && string.Equals(p.Name, publicationName)))
            {
                //отказ - такая публикация уже есть
                return false;
            }
            // файл конфига
            ObservableCollection<Command> commands = new ObservableCollection<Command>() { new Command(this.ShortName, (cmd) => {
                AppClient.UploadFile(ServerAddress, Root.ID, publicationName, cmd);
            })};
            foreach (string fileName in Directory.EnumerateFiles(this.Root.ID))
            {
                FileInfo fi = new FileInfo(fileName);
                commands.Add(new Command($"{fi.Name}", (cmd) =>
                {
                    AppClient.UploadFile(ServerAddress, Root.ID, publicationName, cmd);
                }));
            }
            
            Publication pub = new Publication(Root.ID, publicationName, commands);
            this.Publications.Add(pub);
            pub.Execute();
            return true;
        }

        public void UpdateFile(string fileName_)
        {
            this.Root.Name = fileName_;
            this.ShortName = new FileInfo(fileName_).Name;
        }
    }
}
