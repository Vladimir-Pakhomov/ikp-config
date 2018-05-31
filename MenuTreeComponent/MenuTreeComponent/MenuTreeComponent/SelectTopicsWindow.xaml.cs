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

namespace MenuTreeComponent
{
    /// <summary>
    /// Логика взаимодействия для SelectTopicsWindow.xaml
    /// </summary>
    public partial class SelectTopicsWindow : MetroWindow
    {
        ObservableCollection<CheckingItem> ci = new ObservableCollection<CheckingItem>();
        ObservableCollection<Topic> _source;

        public SelectTopicsWindow(ObservableCollection<Topic> source)
        {
            InitializeComponent();
            _source = source;
            foreach(Topic t in source)
            {
                ci.Add(new CheckingItem() { Name = t.Name, IsChecked = false });
            }
            listBox1.ItemsSource = ci;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            List<Topic> selected = new List<Topic>();
            for(int i=0; i<ci.Count; i++)
            {
                if (ci[i].IsChecked)
                    selected.Add(_source[i]);
            }
            (this.Owner as MainWindow).InsertTopics(selected);
            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
