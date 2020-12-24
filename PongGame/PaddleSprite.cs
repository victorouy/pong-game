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
    public class PaddleSprite : DrawableGameComponent
    {
        //the business logic
        private Paddle paddle;

        //to render
        private SpriteBatch spriteBatch;
        private Texture2D imagePaddle;
        private Game1 game;

        //keyboard input
        private KeyboardState oldState;
        private int counter;
        private int threshold;

        public Paddle getPaddle
        {
            get { return paddle; }
        }

        public PaddleSprite(Game1 game) : base(game)
        {
            // TODO: Construct any child components here
            this.game = game;
        }

        public override void Initialize()
        {
            this.oldState = Keyboard.GetState();
            this.threshold = 6;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(GraphicsDevice);
            this.imagePaddle = game.Content.Load<Texture2D>("paddleImg");

            this.paddle = new Paddle(imagePaddle.Width, imagePaddle.Height, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, 5);

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            checkInput();

            base.Update(gameTime);
        }

        private void checkInput()
        {
            KeyboardState newState = Keyboard.GetState();
            if (newState.IsKeyDown(Keys.Right))
            {
                // If not down last update, key has just been pressed.
                if (!oldState.IsKeyDown(Keys.Right))
                {
                    paddle.MoveRight();
                    counter = 0; //reset counter with every new keystroke
                }
                else
                {
                    counter++;
                    if (counter > threshold)
                        paddle.MoveRight();
                }
            }
            else if (newState.IsKeyDown(Keys.Left))
            {
                // If not down last update, key has just been pressed.
                if (!oldState.IsKeyDown(Keys.Left))
                {
                    paddle.MoveLeft();
                    counter = 0; //reset counter with every new keystroke
                }
                else
                {
                    counter++;
                    if (counter > threshold)
                        paddle.MoveLeft();
                }
            }
            // Improve/change the code above to also check forKeys.Left
            // Once finished checking all keys, update old state.
            this.oldState = newState;

        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(imagePaddle, new Vector2(paddle.BoundingBox.x, paddle.BoundingBox.y), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
