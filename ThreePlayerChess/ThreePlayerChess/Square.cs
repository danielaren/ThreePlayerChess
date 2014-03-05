using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreePlayerChess
{
    public class Square
    {
        private int x;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        private int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private Color colorBackground;

        public Color ColorBackGround
        {
            get { return colorBackground; }
            set { colorBackground = value; }
        }


        public Square()
        {

        }

        public Square GetSquareByName(List<Square> board, string name)
        {
            Square square = new Square();
            foreach (var item in board)
            {
                if (item.Name.Equals(name))
                {
                    square = item;
                }
            }
            return square;
        }
    }
}

