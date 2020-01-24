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
        //Setup ability to use a screen
        GraphicsDeviceManager graphics;
        
        //Setup ability to draw objects (sprites)
        SpriteBatch spriteBatch;
       // Texture2D image = Content.Load<Texture2D>("snake image 1");

        // add 2D grid map with variable called texture
        public Texture2D player;
        public Texture2D enemy;
        public Texture2D enemy2;

        // Add a 2D vector that can store X and Y location in variable called position
        public Vector2 playerposition;
        public Vector2 enemyposition;
        public Vector2 enemy2position;
        

        public Rectangle playerrect;
        public Rectangle enemyrect;
        public Rectangle enemy2rect;

        //Create the game
        public Game1()
        {
            //Use screen code and call it rgraphics
            graphics = new GraphicsDeviceManager(this);
            //Seup folder for graphics (sprites)
            Content.RootDirectory = "Content";
            
            //Set window title
            this.Window.Title = "Square";

            //Set vector2 X and Y location for position variable
            playerposition = new Vector2(20, 20);
            enemyposition = new Vector2(20, 20);
            enemy2position = new Vector2(20, 20);


            //Display mouse on screen
            this.IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Create initialize empty texture (this is the square)
            player = new Texture2D(this.GraphicsDevice, 70,20);
            playerrect = new Rectangle((int)playerposition.X, (int)playerposition.Y, player.Width, player.Height);
            enemy = new Texture2D(this.GraphicsDevice, 30, 30);
            enemyrect = new Rectangle((int)enemyposition.X, (int)enemyposition.Y, enemy.Width, enemy.Height);
            enemy2 = new Texture2D(this.GraphicsDevice, 30, 30);
            enemy2rect = new Rectangle((int)enemy2position.X, (int)enemy2position.Y, enemy2.Width, enemy2.Height);


            // create array to store colour of each texel in the square called texture
            Color[] colourofplayer = new Color[70 * 20];
            Color[] colourofenemy = new Color[30 * 30];
            Color[] colourofenemy2 = new Color[30 * 30];

            //Loop through array to set the colour for each texel in texture
            for (int i = 0; i < (70*20); i++)
            {
                colourofplayer[i] = Color.AntiqueWhite;
            }
            for (int i = 0; i < (30*30); i++)
            {
                colourofenemy[i] = Color.DarkRed;
            }
            for (int i = 0; i < (30 * 30); i++)
            {
                colourofenemy2[i] = Color.DarkRed;
            }

            //Apply colour for the texture
            player.SetData<Color>(colourofplayer);
            enemy.SetData<Color>(colourofenemy);
            enemy2.SetData<Color>(colourofenemy2);

            //Always last in the sequence
            base.Initialize();

        }

        
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which is used to draw all graphics.
            spriteBatch = new SpriteBatch(GraphicsDevice);
                       
        }

        
        protected override void UnloadContent()
        {
            
        }


        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            // set up random   
            Random rand = new Random();

            //elapsed time can be used in the game
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            
            //Update game logic
            //Any game obejcts need to be updated here 
            playerposition.X += 1;
            enemyposition.X += 3;
            enemy2position.X += 3;

            //Move the texture each loop, update vector2 
            //add 1 to X position
            playerposition.Y += 1;
            enemyposition.Y += 3;
            enemy2position.Y += 3;

            //Check to see if at the edge of the screen and respawn at a random position
            if (playerposition.X >= this.GraphicsDevice.Viewport.Height || playerposition.X < 0)
            {
                //reset vector2 to position 0
                playerposition.X = rand.Next(0, GraphicsDevice.Viewport.Width);                
            }

            if (enemyposition.X >= this.GraphicsDevice.Viewport.Height || enemyposition.X < 0)
            {
                enemyposition.X = rand.Next(0, GraphicsDevice.Viewport.Width);
            }

            if (enemy2position.X >= this.GraphicsDevice.Viewport.Height || enemyposition.X < 0)
            {
                enemy2position.X = rand.Next(0, GraphicsDevice.Viewport.Width);
            }


            //Check to see if at bottom of screeen and reset
            if (enemyposition.Y >= this.GraphicsDevice.Viewport.Height || enemyposition.Y < 0)
            {              
                
                enemyposition.Y = rand.Next(0, GraphicsDevice.Viewport.Height);
            }
            if (enemy2position.Y >= this.GraphicsDevice.Viewport.Height || enemyposition.Y < 0)
            {

                enemy2position.Y = rand.Next(0, GraphicsDevice.Viewport.Height);
            }

            if (playerposition.Y >= this.GraphicsDevice.Viewport.Height || playerposition.Y < 0)
            {
                //reset vector2 to position 0
                playerposition.Y = rand.Next(0, GraphicsDevice.Viewport.Height);
            }

            //check to see if the 2 items are colliding - 
            if (enemyposition.Y == playerposition.Y || enemyposition.X == playerposition.X)
            {
                enemyposition.Y = rand.Next(0, GraphicsDevice.Viewport.Height);
                enemyposition.X = rand.Next(0, GraphicsDevice.Viewport.Width);

                playerposition.X = 0;
                playerposition.Y = 0;
                Console.WriteLine("COLLISION");
            }

            if (enemy2position.Y == playerposition.Y || enemy2position.X == playerposition.X)
            {
                enemy2position.Y = rand.Next(0, GraphicsDevice.Viewport.Height);
                enemy2position.X = rand.Next(0, GraphicsDevice.Viewport.Width);

                playerposition.X = 0;
                playerposition.Y = 0;

                Console.WriteLine("COLLISON!!!!");
            }


            // check the status of current keyboard state - 
            KeyboardState state = Keyboard.GetState();

            // check to see if s key is pressed to end game - if this is down the shape will move down
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                //add 10 to last y position
                playerposition.Y += 10;
            }

            // check to see if w is down  - if yes this will move the shape up
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                playerposition.Y -= 10;
            }

            // if d is down move right
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                playerposition.X +=10 ; 
            }

            //if a is down move left
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                playerposition.X -= 10;
            }

            //Check to see if escape pressed to end game
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Setup mouse, so state can be checked
            MouseState mouse = Mouse.GetState();

            //Check if left mouse button pressed
            if (mouse.LeftButton == ButtonState.Pressed)
            {
                playerposition.X = mouse.X;
                playerposition.Y = mouse.Y;
            }

            playerrect.X = (int)playerposition.X;
            playerrect.Y = (int)playerposition.Y;
            enemyrect.X = (int)enemyposition.X;
            enemyrect.Y = (int)enemyposition.Y;
            enemy2rect.X = (int)enemy2position.X;
            enemy2rect.Y = (int)enemy2position.Y;

           

            //Always last in the sequence
            base.Update(gameTime);
        }

        
        //Draw, redraws the graphics to the screen
        protected override void Draw(GameTime gameTime)
        {
            // Drawing code
            GraphicsDevice.Clear(Color.Black);

            //Start of updating game and objects
            spriteBatch.Begin();

            //Any game objects need to be updated here 
            //Objects are re-drawn each game loop

            spriteBatch.Draw(player, playerposition, Color.White);
            spriteBatch.Draw(player, enemyposition, Color.Red);
            spriteBatch.Draw(player, enemy2position, Color.Red);
                       

            //End of updating gamegame and objects
            spriteBatch.End();

            base.Draw(gameTime);
        }
        /*protected bool IsTouchingLeft(SpriteBatch sprite)
        {
            return this.playerposition.Right + this.playerposition.X > sprite.enemyposition.Left &&
                this.playerposition.Left < sprite.playerposition.Left && this.player.Bottom > sprite.enemyposition.Top &&
                this.playerposition.Top < sprite.playerposition.bottom;
        }*/
    }
}
