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
    /// Логика взаимодействия для PublicationsForm.xaml
    /// </summary>
    public partial class PublicationsForm : MetroWindow
    {
        public PublicationsForm(Project current)
        {
            InitializeComponent();
            this.DataContext = current;
        }

        private void publicationsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (publicationsListView.SelectedItems.Count > 0)
            {
                commandsListView.ItemsSource = (publicationsListView.SelectedItem as Publication).Commands;
            }
        }

        private void repeatPublication_Click(object sender, RoutedEventArgs e)
        {
            ((sender as Button).DataContext as Publication).Restart();
        }

        private void repeatCommand_Click(object sender, RoutedEventArgs e)
        {
            (publicationsListView.SelectedItem as Publication).ExecutionStart();
            ((sender as Button).DataContext as Command).Restart();
        }
    }
}
