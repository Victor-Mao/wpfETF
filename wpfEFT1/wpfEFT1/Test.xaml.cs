using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace wpfEFT1
{
    /// <summary>
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Test : Window
    {
        public Test()
        {
            InitializeComponent();
        }

        private void ButtonAdd(object sender, RoutedEventArgs e)
        {
            if (this.TextEntry.Text != "")
            {
                ListBox.Items.Add(this.TextEntry.Text);
                this.TextEntry.Focus();
                this.TextEntry.Clear();

            }
            else
            {
                MessageBox.Show("Please enter your batch number.");
                this.TextEntry.Focus();
            }
        }

        private void ButtonRemove(object sender, RoutedEventArgs e)
        {

            ListBox.Items.Remove(ListBox.SelectedItem);
        }

        private void TextEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            int iValue = -1;

            if (Int32.TryParse(textBox.Text, out iValue) == false)
            {
                TextChange textChange = e.Changes.ElementAt<TextChange>(0);
                int iAddedLength = textChange.AddedLength;
                int iOffset = textChange.Offset;

                textBox.Text = textBox.Text.Remove(iOffset, iAddedLength);
            }


        }
  

        private void OKButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string data = string.Empty;

            foreach (string item in ListBox.Items)
                data = string.Concat(data, item.ToString(), ",");

           

            data = data.TrimEnd(',');

            MessageBox.Show(data);




        }


        private void CancelButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }




    }
}