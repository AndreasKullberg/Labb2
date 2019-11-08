using System;
namespace Labb2
{
    public class Position
    {
        private int _x;
        private int _y;

        public int X {
            get => _x;
            set => _x = Math.Abs(value);          
            
        }

        public int Y
        {
            get => _y;
            set => _y = Math.Abs(value);

        }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public double Lenght() => Math.Sqrt(Square(X) + Square(Y));
        
        public static double Square(int number) => Math.Pow(number, 2);

        public bool Equals (Position p) => p.Y == this.Y && p.X == this.X;
       
        public Position Clone() => new Position(this.X, this.Y);
       
        public override string ToString()
        {
            return $"({this.X},{this.Y})";
        }

        public static bool operator >(Position p1, Position p2)
        {
            if (p1.Lenght() == p2.Lenght())
            {
                return p1.X > p2.X;
            }
            return p1.Lenght() > p2.Lenght();
        }

        public static bool operator <(Position p1, Position p2)
        {
            if (p1.Lenght() == p2.Lenght())
            {
                return p1.X < p2.X;
            }
            return p1.Lenght() < p2.Lenght();
        }

        public static Position operator +(Position p1, Position p2) => new Position(p1.X + p2.X, p1.Y + p2.Y);

        public static Position operator -(Position p1, Position p2) => new Position(p1.X - p2.X, p1.Y - p2.Y);

        public static double operator %(Position p1, Position p2) => Math.Sqrt(Square(p1.X - p2.X) + Square(p1.Y - p2.Y));
       
    }
}
