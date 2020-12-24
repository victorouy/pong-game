using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongLibrary
{
    public class Ball
    {
        private Rectangle ball;
        private Rectangle screen;
        private Vector2 velocity;
        private Paddle paddle;

        public Rectangle getBall
        {
            get { return ball; }
        }

        public Ball(int ballWidth, int ballHeight, int screenWidth, int screenHeight, int velocityX, int velocityY, Paddle paddle)
        {
            int halfScreen = screenWidth / 2;
            int halfBall = ballWidth / 2;
            this.ball.x = halfScreen - halfBall;
            this.ball.y = 0;
            this.ball.width = ballWidth;
            this.ball.height = ballHeight;

            this.screen.width = screenWidth;
            this.screen.height = screenHeight;
            this.screen.x = 0;
            this.screen.y = 0;

            // ??? WHAT SHOULD I INITIALIZE THE SPEED WITH ??? maybe just 1
            this.velocity.X = velocityX;
            this.velocity.Y = velocityY;

            this.paddle = paddle;
        }

        private void Bounce() //change velocity direction 
        {
            // calculate how much was left of the velocity as it hits the edge
            // negate it(velocity of dimensions(x or y)) to get the bounce towards the opposite direction

            // if bounce from left, then just flip the x velocity
            if (ball.y <= 0)
            {
                this.velocity.Y = -1 * (velocity.Y);
            }
            else if ((ball.x <= 0) || (ball.x >= (screen.width - ball.width)))
            {
                this.velocity.X = -1 * (velocity.X);
            }
        }

        private void HitPaddle()
        {
            this.velocity.Y = -1 * (velocity.Y);
            ball.x = velocity.X + ball.x;
            ball.y = velocity.Y + ball.y;
        }

        public void Move()
        {
            // move depending on velocity and ball position
            int movePosX = velocity.X + ball.x;
            int movePosY = velocity.Y + ball.y;

            // 1. check if it hits the paddle -- loop to check entire width of paddle if it hit it
            // even if it hits side of paddle
            // 2.0 check if hits top -- ball.y == 0
            // or 
            // 2.1 check if hits left -- ball.x == 0
            // or
            // 2.2 check if hits right -- ball.x == screenWidth - ballWidth
            // then bounce
            if (ball.x == 0 || ball.y == 0)
            {
                if (((movePosX >= paddle.BoundingBox.x) && (movePosX <= paddle.BoundingBox.x + paddle.BoundingBox.width)) && ((movePosY >= paddle.BoundingBox.y) && (movePosY <= paddle.BoundingBox.y)))
                {
                    HitPaddle();
                }
                else if (movePosY <= 0)
                {
                    ball.y = 0;
                    ball.x = movePosX;
                    Bounce();
                    ball.y = velocity.Y + ball.y;
                }
                else if (movePosX <= 0)
                {
                    ball.x = 0;
                    ball.y = movePosY;
                    Bounce();
                    ball.x = velocity.X + ball.x;
                }
                else if (movePosX >= (screen.width - ball.width))
                {
                    ball.x = screen.width - ball.width;
                    ball.y = movePosY;
                    Bounce();
                    ball.x = velocity.X + ball.x;
                }
                // check if it hits the bottom, set velocity to (0,0) to end game -- as the ball stops moving(no speed)
                // WE'LL COME BACK TO THIS IN FUTURE
                else if (movePosY >= (screen.height - ball.height))
                {
                    velocity.X = 0;
                    velocity.Y = 0;
                }
                // if does not hit any edge, then move normally
                else
                {
                    ball.x = movePosX;
                    ball.y = movePosY;
                }
            }
            else
            {
                if (((movePosX >= paddle.BoundingBox.x) && (movePosX <= paddle.BoundingBox.x + paddle.BoundingBox.width)) && ((movePosY >= paddle.BoundingBox.y) && (movePosY <= paddle.BoundingBox.y + paddle.BoundingBox.height)))
                {
                    HitPaddle();
                }
                else if (movePosY <= 0)
                {
                    ball.y = 0;
                    ball.x = movePosX;
                    Bounce();
                }
                else if (movePosX <= 0)
                {
                    ball.x = 0;
                    ball.y = movePosY;
                    Bounce();
                }
                else if (movePosX >= (screen.width - ball.width))
                {
                    ball.x = screen.width - ball.width;
                    ball.y = movePosY;
                    Bounce();
                }
                // check if it hits the bottom, set velocity to (0,0) to end game -- as the ball stops moving(no speed)
                // WE'LL COME BACK TO THIS IN FUTURE
                else if (movePosY >= (screen.height - ball.height))
                {
                    velocity.X = 0;
                    velocity.Y = 0;
                }
                // if does not hit any edge, then move normally
                else
                {
                    ball.x = movePosX;
                    ball.y = movePosY;
                }
            }
        }
    }
}
