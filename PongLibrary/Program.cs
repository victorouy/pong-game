using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            //(int paddleWidth, int paddleHeight, int screenWidth, int screenHeight, int speed)
            Paddle p = new Paddle(10, 2, 20, 18, 4);
            /*
            Console.WriteLine(p.BoundingBox.x);
            p.MoveLeft();
            Console.WriteLine(p.BoundingBox.x);
            p.MoveLeft();
            Console.WriteLine(p.BoundingBox.x);
            p.MoveLeft();
            Console.WriteLine("should still be 17:  " + p.BoundingBox.x);
            Console.ReadLine();*/
            //(int ballWidth, int ballHeight, int screenWidth, int screenHeight, int velocityX, int velocityY, Paddle paddle)
            Ball b = new Ball(1, 1, 20, 18, 1, -1, p);
            Console.WriteLine(b.getBall.x);
            Console.WriteLine(b.getBall.y);
            for (int i = 0; i < 40; i++)
            {
                b.Move();
                Console.WriteLine("x:  " + b.getBall.x);
                Console.WriteLine("y:  " + b.getBall.y);
                Console.WriteLine("");
            }
            Console.ReadLine();
        }
    }
}
