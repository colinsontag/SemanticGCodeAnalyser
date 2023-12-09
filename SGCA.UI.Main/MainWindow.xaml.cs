﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace SGCA.UI.Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
        private ObservableCollection<LineItem> lineItems = new ObservableCollection<LineItem>();
        private int currentIndex = -1;
        string filepath = @"C:\Users\Colin\Documents\Studium\IWA\Flaschenverschluss_0.1_Fehler_Z1346.txt";
        public MainWindow()
        {
            InitializeComponent();

            // Sample text for demonstration
            
            string fileContent = File.ReadAllText(filepath);

            // Split the text into lines and add each line to the collection
            string[] lines = fileContent.Split('\n');
            foreach (string line in lines)
            {
                lineItems.Add(new LineItem { Text = line, LineColor = Brushes.Black });
            }

            // Specify the line number to make red (e.g., line 2)
            int lineNumberToRed = 3;

            // Set the color of the specified line to red
            if (lineNumberToRed >= 1 && lineNumberToRed <= lineItems.Count)
            {
                lineItems[lineNumberToRed - 1].LineColor = Brushes.Red;
            }

            // Set the collection as the ItemsSource for the ListBox
            lineListBox.ItemsSource = lineItems;
        }
        private void NextRedLineButton_Click(object sender, RoutedEventArgs e)
        {
            // Find the next red line
            int nextRedLineIndex = FindNextRedLine(currentIndex + 1);

            if (nextRedLineIndex != -1)
            {
                // Scroll to the next red line
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
            return -1; // No more red lines
        }
        

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Update the edited line in the ListBox
            if (currentIndex != -1)
            {
                lineItems[currentIndex].Text = lineTextBox.Text;
                // Reset the color to black after editing
                lineItems[currentIndex].LineColor = Brushes.Black;
                lineListBox.ItemsSource= "";
                lineListBox.ItemsSource= lineItems;
            }
        }
        private void SaveToFileButton_Click(object sender, RoutedEventArgs e)
        {
            

            // Extract the filename (without extension) from the input file path
            string inputFileNameWithoutExtension = Path.GetFileNameWithoutExtension(filepath);

            // Generate the timestamp in the format YYMMDDHHMM
            string timestamp = DateTime.Now.ToString("yyMMddHHmm");

            // Construct the output file name by combining the input file name and timestamp
            string outputFileName = $"{inputFileNameWithoutExtension}_{timestamp}.txt";

            // Specify the path to save the file
            string filePathToSave = Path.Combine(Path.GetDirectoryName(filepath), outputFileName);

            // Write the lines to the file
            File.WriteAllLines(filePathToSave, lineItems.Select(item => item.Text), Encoding.UTF8);

            MessageBox.Show($"File saved successfully as {outputFileName}!");
        }

        private void lineListBox_SelectionChanged_1(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Update the index when the selection changes
            currentIndex = lineListBox.SelectedIndex;

            // Display the selected text in the TextBox for editing
            lineTextBox.Text = currentIndex != -1 ? lineItems[currentIndex].Text : string.Empty;
        }
    }
}
