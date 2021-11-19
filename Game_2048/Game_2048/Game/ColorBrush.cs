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


namespace Game_2048.Game
{
   
    class ColorBrush
    {
        private List<SolidColorBrush> brushes;
        TextBlock[,] array;
        public ColorBrush(TextBlock[,] arr)
        {
            array = new TextBlock[4, 4];
            array = arr;
            brushes = new List<SolidColorBrush>
            {


                Brushes.Yellow,//0            
                Brushes.Pink,//1
                 Brushes.YellowGreen,//2
                Brushes.Orange,//3
                Brushes.Olive,//4
                 Brushes.Violet,//5
                 Brushes.Red,//6
                 Brushes.Blue,//7
                  Brushes.Cyan,//8
                   Brushes.Gold,//9
                    Brushes.Gray,//10
                     Brushes.Red//11

            };
        }

        public void setColor(int value, TextBlock[,] arr)
        {
            this.array = arr;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {



                    if (this.array[i, j].Text != "")
                    {
                        array[i, j].Background = brushes[10];
                        value = int.Parse(array[i, j].Text);
                        switch (value)
                        {
                            case 0: array[i, j].Background = brushes[10]; break;
                            case 2: array[i, j].Background = brushes[0]; break;
                            case 4: array[i, j].Background = brushes[1]; break;
                            case 8: array[i, j].Background = brushes[3]; break;
                            case 16: array[i, j].Background = brushes[4]; break;
                            case 32: array[i, j].Background = brushes[5]; break;
                            case 64: array[i, j].Background = brushes[6]; break;
                            case 128: array[i, j].Background = brushes[7]; break;
                            case 256: array[i, j].Background = brushes[8]; break;
                            case 512: array[i, j].Background = brushes[8]; break;
                            case 1024: array[i, j].Background = brushes[9]; break;
                            case 2048: array[i, j].Background = brushes[11]; break;
                            default: array[i, j].Background = brushes[5]; break;
                        }
                    }
                }
            }


        }
        public void setColor(TextBlock[,] arr)
        {
            this.array = arr;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                    if (this.array[i, j].Text == "")
                    {
                        array[i, j].Background = brushes[10];
                       
                       
                    }
                }
            }


        }
     
    }
}
