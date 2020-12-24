using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using PongLibrary;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace PongGame
{
    public class BallSprite : DrawableGameComponent
    {
        //the business logic
        private Paddle paddle;
        private Ball ball;

        //to render
        private SpriteBatch spriteBatch;
        private Texture2D imageBall;
        private Game1 game;

        //ball movement
        //private KeyboardState oldState;
        //private int counter;
        //private int threshold;

        public void setPaddle(Paddle p)
        {
            paddle = p;
            this.ball = new Ball(imageBall.Width, imageBall.Height, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, 6, 5, paddle);
        }

        public BallSprite(Game1 game) : base(game)
        {
            // TODO: Construct any child components here
            this.game = game;
        }

        public override void Initialize()
        {
            //this.threshold = 3;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(GraphicsDevice);
            this.imageBall = game.Content.Load<Texture2D>("ballImg");

            
            
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            askMove();

            base.Update(gameTime);
        }

        private void askMove()
        {
            ball.Move();
            /*
            counter++;
            if (counter > threshold)
            {
                //ball.Move();
                counter = 0;
            }*/
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(imageBall, new Vector2(ball.getBall.x, ball.getBall.y), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
