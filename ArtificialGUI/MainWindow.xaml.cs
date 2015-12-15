using Artificial.Parsers.Character;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace ArtificialGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Menu_FileOpen_Click(object sender, RoutedEventArgs e)
        {
            FileStream f = File.Open(@"C:\illusion\Artificial Academy 2\AA2Edit\data\save\Female\cirno.png", FileMode.Open);
            Character c = CharacterParser.TryRead(f);
            MessageBox.Show("Nothing blew up. Somehow.");
        }
        private void Menu_FileSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Save file");
        }
        private void Menu_FileClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
