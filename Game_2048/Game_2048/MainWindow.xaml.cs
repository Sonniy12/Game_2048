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
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Game_2048.Game;
namespace Game_2048
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        char symbol;
        ClassGame game;
     
         TextBlock [,]  array;
        public MainWindow()
        {
            InitializeComponent();
          
            array = new TextBlock[4, 4];
         
            array[0, 0] = block1;
            array[0, 1] = block2;
            array[0, 2] = block3;
            array[0, 3] = block4;
            //==========================
            array[1, 0] = block5;
            array[1, 1] = block6;
            array[1, 2] = block7;
            array[1, 3] = block8;
            //===================================
            array[2, 0] = block9;
            array[2, 1] = block10;
            array[2, 2] = block11;
            array[2, 3] = block12;
            //=================================
            array[3, 0] = block13;
            array[3, 1] = block14;
            array[3, 2] = block15;
            array[3, 3] = block16;

         
            game = new ClassGame(array, symbol);
            Show_score.Text = "";


        }
     
        private void Left_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!game.FillingTable(array))
            {
                Clear();
                //MessageBox.Show("Нет свободных ячеек");
            }
            else
            {
                symbol = 'L';
                game.WaitKey(symbol);
                Show_score.Text = game.Score.ToString();
            }

        }

        private void Right_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!game.FillingTable(array))
            {
                Clear();
               
            }
            else
            {
                symbol = 'R';
                game.WaitKey(symbol);
                Show_score.Text = game.Score.ToString();
            }

        }

   

        private void Up_Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (!game.FillingTable(array))
            {
                Clear();
               
            }
            else
            {
                symbol = 'T';
                game.WaitKey(symbol);
                Show_score.Text = game.Score.ToString();
            }
        }

        private void Down_Button_Click(object sender, RoutedEventArgs e)
        {
          
           
                if(!game.FillingTable(array))
                {
                Clear();
               
                }
            else
            {
                symbol = 'B';
                game.WaitKey(symbol);
                Show_score.Text = game.Score.ToString();
            }

                

            
           
        }
        private void Clear()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    array[i, j].Text = "";
                }
            }
            game.Score = 0;
            ColorBrush color_ = new ColorBrush(array);
            color_.setColor(array);

        }

     
    }
}
