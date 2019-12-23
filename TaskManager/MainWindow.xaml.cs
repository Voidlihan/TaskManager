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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace TaskManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Process process = new Process();
        public MainWindow()
        {
            InitializeComponent();
            var processes = Process.GetProcesses();
            foreach (var a in processes.OrderBy(x => x.ProcessName))
            {
                listBoxProcesses.Items.Add($"{a.ProcessName}");
            }
        }

        private void Killing(object sender, RoutedEventArgs e)
        {
            Process.GetProcesses()[listBoxProcesses.SelectedIndex].Kill();
        }

        private void Select(object sender, MouseButtonEventArgs e)
        {
            var res = ItemsControl.ContainerFromElement(sender as ListBox, e.OriginalSource as DependencyObject) as ListBox;
        }
    }
}
