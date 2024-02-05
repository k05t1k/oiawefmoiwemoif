using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
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
        Label[] label;
        Random random = new Random();

        public int winlose = 0;

        public MainWindow()
        {
            InitializeComponent();
            buttons = new Button[9] { _1, _2, _3, _4, _5, _6, _7, _8, _9 };
            label = new Label[1] { _1337 };

            for (int i = 0; i < 9; i++)
                buttons[i].IsEnabled = false;
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

        public int round = 1;

        public int win = 0;
        public int tie = 0;
        public int lose = 0;

        public string player = "X";
        public string enemy = "0";

        public bool WinLose()
        {
            int flag = 0;
            for (int i = 0; i < winner_data.GetLength(0); i++)
            {
                for (int k = 0; k < winner_data.GetLength(1); k++)
                {
                    if (buttons[winner_data[i, k]].Content == player &&
                        buttons[winner_data[i, k + 1]].Content == player &&
                        buttons[winner_data[i, k + 2]].Content == player)
                    {
                        win++;
                        label[winlose].Content = "Вы выиграли!";
                        return true;
                    }
                    else if (buttons[winner_data[i, k]].Content == enemy &&
                        buttons[winner_data[i, k + 1]].Content == enemy &&
                        buttons[winner_data[i, k + 2]].Content == enemy)
                    {
                        lose++;
                        label[winlose].Content = "Вы проиграли!";
                        return true;
                    }

                    break;
                }
            }

            for (int i = 0; i < 9; i++)
            {
                if (buttons[i].IsEnabled == false)
                    flag++;

                if (flag == 9)
                {
                    tie++;
                    label[winlose].Content = "Ничья!";
                    return true;
                }
            }

            return false;
        }

        int key_value = 0;

        private void _1_Click(object sender, RoutedEventArgs e)
        {
            int key = random.Next(0, 9);

            (sender as Button).Content = player;
            (sender as Button).IsEnabled = false;

            for (int i = 0; i < 9; i++)
            {
                if (buttons[key].IsEnabled == false)
                {
                    key = random.Next(0, 9);
                    continue;
                }

                buttons[key].Content = enemy;
                buttons[key].IsEnabled = false;
                // label[0].Content = $"set on {i}";
                break;
            }

            if (WinLose())
            {
                Start.IsEnabled = true;

                key = random.Next(0, 9);

                for (int j = 0; j < 9; j++)
                {
                    if (buttons[key].Content == "X" && round % 2 != 0)
                    {
                        key_value = key;
                        key = 0;
                        buttons[j].IsEnabled = false;
                        continue;
                    }

                    key = random.Next(0, 9);
                    buttons[j].IsEnabled = false;
                }

                round++;

                if (round % 2 != 0)
                {
                    player = "X";
                    enemy = "0";
                }
                else
                {
                    player = "0";
                    enemy = "X";
                }
            }
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            label[winlose].Content = " ";
            for (int i = 0; i < 9; i++) 
            {
                if (i == key_value && round % 2 == 0)
                    continue;

                buttons[i].Content = " ";
                buttons[i].IsEnabled = true; 
            }
            (sender as Button).IsEnabled = false;
        }
    }
}
