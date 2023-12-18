using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Navigation;

namespace SGCA.UI.Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<LineItem> lineItems = new ObservableCollection<LineItem>();
        private int currentIndex = -1;
        
        private List<int> _linesToColor = new List<int>();


        public class LineItem : INotifyPropertyChanged
        {
            private string text;
            public string Text
            {
                get { return text; }
                set
                {
                    if (text != value)
                    {
                        text = value;
                        OnPropertyChanged(nameof(Text));
                    }
                }
            }

            private Brush lineColor;
            public Brush LineColor
            {
                get { return lineColor; }
                set
                {
                    if (lineColor != value)
                    {
                        lineColor = value;
                        OnPropertyChanged(nameof(LineColor));
                    }
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            public override string ToString()
            {
                return Text;
            }
        }


        public MainWindow(List<int> linesToColor, string filepath)
        {
            InitializeComponent();
            _linesToColor = linesToColor;
            _filepath = filepath;

            doColuring();
        }

        private void NextRedLineButton_Click(object sender, RoutedEventArgs e)
        {
           
            int nextRedLineIndex = FindNextRedLine(currentIndex + 1);

            if (nextRedLineIndex == -1)
            {
                MessageBox.Show("No more errors found");
                Console.WriteLine("No more errors found");
            }
            else
            {
                lineListBox.SelectedIndex = nextRedLineIndex;
                lineListBox.ScrollIntoView(lineListBox.SelectedItem);
                currentIndex = nextRedLineIndex;
            }
        }

        private int FindNextRedLine(int startIndex)
        {
            for (int i = startIndex; i < lineItems.Count; i++)
            {
                if (lineItems[i].LineColor == Brushes.Red)
                {
                    return i;
                }

            }
            if (currentIndex != -1) return currentIndex;
            return -1; 
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (currentIndex != -1)
            {
                lineItems[currentIndex].Text = lineTextBox.Text;
               
                lineItems[currentIndex].LineColor = Brushes.Green;
                lineListBox.ItemsSource = "";
                lineListBox.ItemsSource = lineItems;
            }
        }
        private void SaveToFileButton_Click(object sender, RoutedEventArgs e)
        {
            string inputFileNameWithoutExtension = Path.GetFileNameWithoutExtension(_filepath);            
            string timestamp = DateTime.Now.ToString("yyMMddHHmm");            
            string outputFileName = $"{inputFileNameWithoutExtension}_{timestamp}.gcode";            
            string filePathToSave = Path.Combine(Path.GetDirectoryName(_filepath), outputFileName);
            var nonEmptyLines = lineItems.Select(item => item.Text.Trim()).Where(line => !string.IsNullOrEmpty(line));
            File.WriteAllLines(filePathToSave, nonEmptyLines, Encoding.UTF8);
            MessageBox.Show($"File saved successfully as {outputFileName}!");
        }

        private void lineListBox_SelectionChanged_1(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {           
            currentIndex = lineListBox.SelectedIndex;            
            lineTextBox.Text = currentIndex != -1 ? lineItems[currentIndex].Text : string.Empty;
        }
        
        private string _filepath = "";
        private void doColuring()         
        {       
            string fileContent = File.ReadAllText(_filepath);
            string[] lines = fileContent.Split('\n');
            foreach (string line in lines)
            {
                lineItems.Add(new LineItem { Text = line, LineColor = Brushes.Black });
            }

            foreach (var lineNumberToRed in _linesToColor)
            {
                if (lineNumberToRed <= lineItems.Count)
                {
                    lineItems[lineNumberToRed - 1].LineColor = Brushes.Red;
                }
            }
            lineListBox.ItemsSource = lineItems;            
        }
    }
}

