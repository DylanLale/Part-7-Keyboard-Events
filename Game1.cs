using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Part_7__Keyboard_Events
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D pacRightTexture;
        Texture2D pacLeftTexture;
        Texture2D pacUpTexture;
        Texture2D pacDownTexture;
        Texture2D pacTexture;
        Texture2D pacSleepTexture;
        KeyboardState keyboardState;
        Rectangle pacLocation;
        

        public Game1()
        
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            pacLocation = new Rectangle(10, 10, 75, 75);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            pacRightTexture = Content.Load<Texture2D>("PacRight");
            pacLeftTexture = Content.Load<Texture2D>("PacLeft");
            pacDownTexture = Content.Load<Texture2D>("PacDown");
            pacUpTexture = Content.Load<Texture2D>("PacUp");
            pacSleepTexture = Content.Load<Texture2D>("PacSleep");
            pacTexture = pacSleepTexture;


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                pacTexture = pacUpTexture;
                pacLocation.Y -= 2;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                pacTexture = pacDownTexture;
                pacLocation.Y += 2;
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                pacTexture = pacLeftTexture;
                pacLocation.X -= 2;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                pacTexture = pacRightTexture;
                pacLocation.X += 2;
            }

            if (!keyboardState.IsKeyDown(Keys.Up) && !keyboardState.IsKeyDown(Keys.Right) && !keyboardState.IsKeyDown(Keys.Left) && !keyboardState.IsKeyDown(Keys.Down))
            {
                pacTexture = pacSleepTexture;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            _spriteBatch.Draw(pacTexture, pacLocation, Color.White);

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}