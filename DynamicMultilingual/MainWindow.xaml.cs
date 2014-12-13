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

namespace DynamicMultilingual
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Cbx_Languages.ItemsSource = new List<string> { "zh-CN", "en-US", "de-DE" };

            Utilities.ResourceHelper.LoadResource("en-US");
        }

        private void Cbx_Languages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var seleted = this.Cbx_Languages.SelectedItem as String;

            Utilities.ResourceHelper.LoadResource(seleted);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var msg = Utilities.ResourceHelper.GetValue("Info_CodeBehind");

            MessageBox.Show(msg);
        }
    }
}
