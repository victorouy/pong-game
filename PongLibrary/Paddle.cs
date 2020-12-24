using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongLibrary
{
    public class Paddle
    {
        private int speed { get; }
        private int screenWidth;
        private Rectangle boundingBox;

        public Rectangle BoundingBox
        {
            get
            {
                return boundingBox;
            }
        }

        public Paddle(int paddleWidth, int paddleHeight, int screenWidth, int screenHeight, int speed)
        {
            this.speed = speed;
            this.screenWidth = screenWidth;
            this.boundingBox.width = paddleWidth;
            this.boundingBox.height = paddleHeight;

            // y coordinate (y of top-left location of paddle) 
            this.boundingBox.y = screenHeight - paddleHeight;

            // x coordinate (x of top-left location of paddle) 
            int halfScreen = screenWidth / 2;
            int halfPaddle = paddleWidth / 2;
            this.boundingBox.x = halfScreen - halfPaddle;
        }
        public void MoveLeft()
        {
            int newX = this.boundingBox.x - speed;

            if (newX >= 0)
            {
                this.boundingBox.x = newX;
            }
        }

        public void MoveRight()
        {
            int newX = this.boundingBox.x + speed;

            if (newX <= screenWidth - boundingBox.width)
            {
                this.boundingBox.x = newX;
            }
        }
    }
}
