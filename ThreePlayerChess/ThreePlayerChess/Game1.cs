using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

namespace ThreePlayerChess
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background;
        Texture2D blackKing;
        Rectangle blackKingRect;
        Rectangle mainFrame;
        int xCord = 610;
        int yCord = 241;
        List<Square> board = new List<Square>();
        Square square = new Square();

        private void SetSquaresOnBoard(List<Square> board)
        {
            board.Add(new Square() { Name = "A1", X = 612, Y = 300 });
        }

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


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Frame rate is 30 fps by default for Windows Phone.
            TargetElapsedTime = TimeSpan.FromTicks(333333);

            // Extend battery life under lock.
            InactiveSleepTime = TimeSpan.FromSeconds(1);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        ///     and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            SetSquaresOnBoard(board);

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // load the background content
            background = Content.Load<Texture2D>("Textures\\BackgroundVersion1");

            blackKing = Content.Load<Texture2D>("Textures\\BlackKing");


            // set the rectangle parameters
            mainFrame = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            blackKingRect = new Rectangle(square.GetSquareByName(board, "A1").X, square.GetSquareByName(board, "A1").Y, 30, 33);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

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
            spriteBatch.Draw(background, mainFrame, Color.White);
            spriteBatch.Draw(blackKing, new Vector2(square.GetSquareByName(board, "A1").X, 
                square.GetSquareByName(board, "A1").Y), Color.White);

            MouseState mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);
            blackKingRect = new Rectangle(xCord, yCord, xCord + 33, yCord + 30);

            if (mouseState.LeftButton == ButtonState.Pressed)
                    if (blackKingRect.Contains(mousePosition))
                    {
                        xCord = mouseState.Y;
                        yCord = mouseState.X;
                    }

            spriteBatch.End();

            base.Draw(gameTime);
        }



    }
}
