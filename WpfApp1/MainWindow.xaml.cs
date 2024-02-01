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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button[] buttons;
        Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            buttons = new Button[9] {_1, _2, _3, _4, _5, _6, _7, _8, _9 };
        }

        int[,] winner_data = new int[8, 3]
        {
            { 0, 1, 2 }, 
            { 3, 4, 5 },
            { 6, 7, 8 },

            { 0, 4, 8 },
            { 2, 4, 6 },

            { 0, 3, 6 },
            { 1, 4, 7 },
            { 2, 5, 8 },
        }; 

        private void _1_Click(object sender, RoutedEventArgs e)
        {
            int flag = 0;

            int key = random.Next(0, 9);

            (sender as Button).Content = "X";
            (sender as Button).IsEnabled = false;
            for (int i = 0; i < 9; i++)
            {
                if (buttons[key].IsEnabled == false)
                {
                    key = random.Next(0, 9);
                    continue;
                }
                flag++;
                break;
            }
            if (flag < 9)
            {
                buttons[key].Content = "0";
                buttons[key].IsEnabled = false;
            }

            for (int i = 0; i < winner_data.GetLength(0);  i++)
            {
                for (int k = 0; k < winner_data.GetLength(1); k++)
                {
                    if (buttons[winner_data[i, k]].Content == "X" &&
                        buttons[winner_data[i, k + 1]].Content == "X" &&
                        buttons[winner_data[i, k + 2]].Content == "X")
                    {
                        MessageBox.Show("You win!");
                        this.Close();
                        return;
                    }
                    else if (buttons[winner_data[i, k]].Content == "0" &&
                        buttons[winner_data[i, k + 1]].Content == "0" &&
                        buttons[winner_data[i, k + 2]].Content == "0")
                    {
                        MessageBox.Show("You lose :(");
                        this.Close();
                        return;
                    }

                    break;
                }
            }
        }

    }
}
