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
using System.IO;
using System.IO.IsolatedStorage;

namespace ThreePlayerChess
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
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
        List<String> squareNames = new List<string>(){ "A1", "A2" };
        Square square = new Square();

        private void SetSquaresOnBoard(List<Square> board)
        {
            board.Add(new Square() { Name = "A1", X = 622, Y = 337, ColorBackGround = Color.Gray });
            board.Add(new Square() { Name = "A2", X = 590, Y = 350, ColorBackGround = Color.White });   
        }

        public Game()
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
            foreach (var name in squareNames)
            {
                spriteBatch.Draw(blackKing, new Vector2(square.GetSquareByName(board, name).X,
                square.GetSquareByName(board, name).Y), square.GetSquareByName(board, name).ColorBackGround);  
            }
            
            MouseState mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);
            //blackKingRect = new Rectangle(xCord, yCord, xCord + 33, yCord + 30);


            if (mouseState.LeftButton == ButtonState.Pressed)
            {
              
                IsolatedStorageFile myIsolatedStorage =
    IsolatedStorageFile.GetUserStoreForApplication();

                using (var writeFile = myIsolatedStorage.OpenFile("coordinates.txt", FileMode.Append))
                using (var writer = new StreamWriter(writeFile))
                {
                    writer.WriteLine(mousePosition.ToString());    
                }
                
                System.Diagnostics.Debug.WriteLine(mousePosition);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
