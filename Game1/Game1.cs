using Game1.Classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static int ScreenWidth;
        public static int ScreenHeight;

        Player player1;
        Player player2;
        Ball ball;

        const int PADDLE_OFFSET = 70;
        const float BALL_START_SPEED = 8f;
        const float KEYBOARD_PADDLE_SPEED = 10f;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            ScreenWidth = GraphicsDevice.Viewport.Width;
            ScreenHeight = GraphicsDevice.Viewport.Height;

            player1 = new Player();
            player2 = new Player();
            ball = new Ball();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            player1.Texture = Content.Load<Texture2D>("Paddle");
            player2.Texture = Content.Load<Texture2D>("Paddle");

            player1.Position = new Vector2(PADDLE_OFFSET, ScreenHeight / 2 - player1.Texture.Height / 2);
            player2.Position = new Vector2(ScreenWidth - player2.Texture.Width - PADDLE_OFFSET, ScreenHeight / 2 - player2.Texture.Height / 2);

            ball.Texture = Content.Load<Texture2D>("Ball");
            ball.Launch(BALL_START_SPEED);
       }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent(){}

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ScreenWidth = GraphicsDevice.Viewport.Width;
            ScreenHeight = GraphicsDevice.Viewport.Height;
            ball.Move(ball.Velocity);

            Vector2 player1Velocity = Input.GetKeyboardInputDirection(PlayerIndex.One) * KEYBOARD_PADDLE_SPEED;
            Vector2 player2Velocity = Input.GetKeyboardInputDirection(PlayerIndex.Two) * KEYBOARD_PADDLE_SPEED;

            player1.Move(player1Velocity);
            player2.Move(player2Velocity);


            if (ball.Position.X + ball.Texture.Width < 0)
            {
                ball.Launch(BALL_START_SPEED);
            }

            if (ball.Position.X > ScreenWidth)
            {
                ball.Launch(BALL_START_SPEED);
            }

            if (GameObject.CheckPaddleBallCollision(player1, ball))
            {
                ball.Velocity.X = Math.Abs(ball.Velocity.X);
            }

            if (GameObject.CheckPaddleBallCollision(player2, ball))
            {
                ball.Velocity.X = -Math.Abs(ball.Velocity.X);
            }
            
            base.Update(gameTime);
        }
            
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            player1.Draw(spriteBatch);
            player2.Draw(spriteBatch);
            ball.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
