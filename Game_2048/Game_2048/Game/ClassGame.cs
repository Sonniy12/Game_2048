
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
   
    class ClassGame
    {
         private TextBlock[,] array;
        private ColorBrush color_;
        private Random randNumber;
        private bool _isDone;
        private bool _isMoved;
        public bool IsBlocked { get; set; }
        public int Score { get; set; }      
        public int Number { get; set; }        
        public int pos_X { get; set; }
        public int pos_Y { get; set; }
        public int Value { get; set; }
        public int Value2 { get; set; }
        public char Key_symbol { get; set; }     
    
   
        public ClassGame(TextBlock[,] array_,char symbol)
        {
           
            color_ = new ColorBrush(array);
        randNumber = new Random();
           
            array = new TextBlock[4, 4];
            array = array_;

            Key_symbol = symbol;
            _isDone = false;
            
            _isMoved = true;
           
            IsBlocked = false;
            StartGame(array, symbol);

        }
       
        public void StartGame(TextBlock[,] _arr, char s)
        {
            array = _arr;
            RandNumberField(array);
            RandNumberField(array);
            Key_symbol = s;
            while (true)
            {


                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (array[i, j].Text != "")
                        {
                            int value = Int32.Parse(array[i, j].Text);
                            color_.setColor(value, array);

                        }
                        color_.setColor(array);

                    }
                }
                if (_isMoved)
                {
                    RandNumberField(array);
                                             
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (array[i, j].Text != "")
                            {
                                int value = Int32.Parse(array[i, j].Text);
                                color_.setColor(value, array);

                            }
                            color_.setColor(array);//

                        }
                    }
                }


                
                if (_isDone)
                {
                     break;
                }


                WaitKey(Key_symbol);


                if (MaxNumber() >= 2048) { WineGame();
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            array[i, j].Text = "";
                        }
                    }
                    return; }
                if (FillingTable(array))
                {
                  
                     break;
                   // return;
                }
               

            }


        }



        private  int MaxNumber()
        {
            int value = 0;
            
            for (int i = 0; i < 4; i++)
            {
                
                for (int j = 0; j < 4; j++)
                {
                    
                    if (array[i, j].Text != "")
                    {
                        
                        try
                        {
                            value = Int32.Parse(array[i, j].Text);
                            

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error!");

                        }
                        if (value > Number)
                        {
                            Number = value;
                        }
                    }

                }
            }
            return Number;
        }//max number

        public void RandNumberField(TextBlock[,] array_)
        {
            array = array_;
            int number = randNumber.Next(0, 10);
            int x = 0;
            int y = 0;

            do
            {
                x = randNumber.Next(0, 4);
                y = randNumber.Next(0, 4);

                pos_X = x;
                pos_Y = y;


            } while (array[pos_X, pos_Y].Text != "");


            if (number >= 8)
            {
                array[x, y].Text = 4.ToString();
            }
            else
            {
                array[x, y].Text = 2.ToString();
            }
         //   MessageBox.Show("row= " + pos_X + " col= " + pos_Y);
            if (CanMove())
            {
                return;
            }
            _isDone = true;

        } //random number in field

        private bool CanMove()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (array[j, i].Text=="")
                    {

                        return true;
                    }
                }
            }


            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (CheckingLimit(j + 1, i, array)
                        || CheckingLimit(j - 1, i, array)
                        || CheckingLimit(j, i + 1, array)
                        || CheckingLimit(j, i - 1, array))
                    {
                        return true;
                    }
                }
            }


            return false;
        }

        private bool CheckingLimit(int x, int y, TextBlock[,] arr)
        {
           
            if (x < 0 || x > 3 || y < 0 || y > 3)
            {
                return false;
            }


            return array[x, y].Text == arr[x, y].Text;
        }

        public bool FillingTable( TextBlock[,] arr)
        { array = arr;
            
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                    if ( array[i, j ].Text == "")
                    {
                       
                        return true;
                    }


                }
            }
            // array = arr;
            MessageBox.Show("Нет свободных ячеек");

            return false;
        }

        public void WaitKey( char s)
        {
            _isMoved = false;
          
            char input = s;
           
            switch (input)
            {
                case 'T':
                    Move(Movement.Up);  RandNumberField(array);
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (array[i, j].Text != "")
                            {
                                int value = Int32.Parse(array[i, j].Text);
                                color_.setColor(value, array);

                            }
                            color_.setColor(array);//

                        }
                    }
                    break;
                case 'L':
                    Move(Movement.Left);  RandNumberField(array);
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (array[i, j].Text != "")
                            {
                                int value = Int32.Parse(array[i, j].Text);
                                color_.setColor(value, array);

                            }
                            color_.setColor(array);//

                        }
                    }
                    break;
                case 'B':
                    Move(Movement.Down);  RandNumberField(array);
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (array[i, j].Text != "")
                            {
                                int value = Int32.Parse(array[i, j].Text);
                                color_.setColor(value, array);

                            }
                            color_.setColor(array);//

                        }
                    }
                    break;
                case 'R':
                    Move(Movement.Right); RandNumberField(array);
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (array[i, j].Text != "")
                            {
                                int value = Int32.Parse(array[i, j].Text);
                                color_.setColor(value, array);

                            }
                            color_.setColor(array);//

                        }
                    }
                    break;
            }


                    IsBlocked = false;
                
            
        }

        private void MoveVertically(int x, int y, int d)
        {
             Value = 0;
             Value2 = 0;
            
            if (array[x, y + d].Text !=""
                && (Value2 = Int32.Parse(array[x, y + d].Text)) == (Value = Int32.Parse(array[x, y].Text))
             )

            {
                Value = 0;
                array[x, y].Text = "";
                Value2 *= 2;
                array[x, y+d].Text = Value2.ToString();
               // MessageBox.Show("Value2" + Value2);
                Score += Value2;
                IsBlocked = true;
                _isMoved = true;
                color_.setColor(Value2, array);//
                color_.setColor( array);//
            }
            else if (array[x , y+d].Text == ""
                     && array[x, y].Text != "")
            {

                //value2 = Int32.Parse(array[x + d, y].Text);
                Value = 0;

                Value2 = Int32.Parse(array[x, y].Text);
                array[x , y+d].Text = array[x, y].Text;
                array[x, y].Text = "";

                _isMoved = true;
                color_.setColor(Value2, array);//
                color_.setColor(array);//
            }


            if (d > 0)
            {
                if (y + d < 3)
                {
                    MoveVertically(x, y + d, 1);
                }
            }
            else
            {
                if (y + d > 0)
                {
                    MoveVertically(x, y + d, -1);
                }
            }
        }


        private void MoveHorizontally(int x, int y, int d)
        {
             Value = 0;
             Value2 = 0;
            if (array[x + d, y].Text != ""
                && (Value2 = Int32.Parse(array[x+d,y].Text)) == (Value = Int32.Parse(array[x, y].Text)))
              
            {
                Value = 0;

                array[x, y].Text = "";
                Value2 *= 2;
                array[x + d, y].Text =Value2.ToString();
              
                Score +=Value2;

                IsBlocked = true;
                _isMoved = true;
                color_.setColor(Value2, array);//
                color_.setColor(array);//
            }
            else if (array[x + d, y].Text == ""
                     && array[x, y].Text != "")
            {

               
                Value = 0;

                Value2 = Int32.Parse(array[x, y].Text);
                array[x + d, y].Text = array[x, y].Text;
                array[x, y].Text = "";
               
                _isMoved = true;
                color_.setColor(Value2, array);//
                color_.setColor(array);//
            }


            if (d > 0)
            {
                if (x + d < 3)
                {
                    MoveHorizontally(x + d, y, 1);
                }
            }
            else
            {
                if (x + d > 0)
                {
                    MoveHorizontally(x + d, y, -1);
                }
            }
        }


        private void Move(Movement direction)
        {
            switch (direction)
            {
                case Movement.Left:
                    for (int x = 0; x < 4; x++)
                    {
                        int y = 1;
                        while (y < 4)
                        {
                            if (array[x , y].Text!="")
                            {
                                MoveVertically(x, y, -1);
                            }


                            y++;
                        }
                    }


                    break;
                case Movement.Right:
                    for (int x = 0; x < 4; x++)
                    {
                        int y = 2;
                        while (y >= 0)
                        {
                            if (array[x, y].Text != "")
                            {
                                MoveVertically(x, y, 1);
                            }


                            y--;
                        }
                    }


                    break;
                case Movement.Up:
                    for (int y = 0; y < 4; y++)
                    {
                        int x = 1;
                        while (x < 4)
                        {
                            if (array[x, y].Text != "")
                            {
                                MoveHorizontally(x, y, -1);
                            }


                            x++;
                        }
                    }


                    break;
                case Movement.Down:
                    for (int y = 0; y < 4; y++)
                    {
                        int x = 2;
                        while (x >= 0)
                        {
                            if (array[x, y].Text != "")
                            {
                                MoveHorizontally(x, y, 1);
                            }


                            x--;
                        }
                    }


                    break;
            }
        }






        private void WineGame()
        {
            MessageBox.Show("You Wine!");
        }
        public void LoseGame()
        {
            MessageBox.Show("Game again!");
        }
      
   

        internal enum Movement
        {
            Up,
            Down,
            Left,
            Right
        }
    }

}
