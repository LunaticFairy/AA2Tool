using Artificial.Parsers.Character;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private List<Character> characters = new List<Character>();
        public MainWindow()
        {
            InitializeComponent();
            listBox.ItemsSource = Characters;
        }

        public ObservableCollection<CharacterEntry> Characters
        {
            get
            {
                var results = new ObservableCollection<CharacterEntry>();
                foreach (var ch in characters)
                {
                    results.Add(new CharacterEntry(ch, ch.portrait));
                }
                return results;
            }
        }

        private void Menu_FileOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = @"C:\illusion\AA2Edit\data\save";
            openFileDialog.Filter = "AA2 Character File (*.png)|*.png";

            if (openFileDialog.ShowDialog() == true)
            {
                FileStream f = File.Open(openFileDialog.FileName, FileMode.Open);
                Character c = CharacterParser.TryRead(f);
                MessageBox.Show(c.data.profile.firstName);
                characters.Add(c);
                listBox.ItemsSource = Characters;
                f.Close();
            }
        }
        private void Menu_FileSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Save file");
        }
        private void Menu_FileClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //image.Source = ((CharacterEntry)listBox.SelectedItem).Char.thumbnail;
        }
    }
}
