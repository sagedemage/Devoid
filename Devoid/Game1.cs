using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using NUnit.Framework.Constraints;

namespace Devoid
{
    public class Game1 : Game
    {
        /* Game */

        // player object
        public Player player;

        // wall object
        Wall wall1;
        Wall wall2;
        Wall wall3;
        Wall wall4;
        Wall wall5;
        Wall wall6;

        // background color
        Color background_color;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Song _song;

        public Game1()
        {
            /* Create Game Object */
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            /* Initialize the game */
            // initialize player
            var playerPosition = new Vector2(_graphics.PreferredBackBufferWidth / 4, _graphics.PreferredBackBufferHeight / 2);
            player = new Player(playerPosition, 100f);

            // initialize wall
            var wallPosition = new Vector2(_graphics.PreferredBackBufferWidth / 4, _graphics.PreferredBackBufferHeight / 4);
            wall1 = new Wall(wallPosition);

            wallPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 4);
            wall2 = new Wall(wallPosition);

            wallPosition = new Vector2(_graphics.PreferredBackBufferWidth * 3 / 4, _graphics.PreferredBackBufferHeight / 4);
            wall3 = new Wall(wallPosition);

            wallPosition = new Vector2(_graphics.PreferredBackBufferWidth / 4, _graphics.PreferredBackBufferHeight * 3 / 4);
            wall4 = new Wall(wallPosition);

            wallPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight * 3 / 4);
            wall5 = new Wall(wallPosition);

            wallPosition = new Vector2(_graphics.PreferredBackBufferWidth * 3 / 4, _graphics.PreferredBackBufferHeight * 3 / 4);
            wall6 = new Wall(wallPosition);

            background_color = new Color(39, 79, 195);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            /* Load your game content */

            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load player content here
            var playerTexture = Content.Load<Texture2D>("player");
            player.setTexture(playerTexture);

            // Load wall content here
            var wallTexture = Content.Load<Texture2D>("wall");
            wall1.setTexture(wallTexture);
            wall2.setTexture(wallTexture);
            wall3.setTexture(wallTexture);
            wall4.setTexture(wallTexture);
            wall5.setTexture(wallTexture);
            wall6.setTexture(wallTexture);

            // Music
            _song = Content.Load<Song>("nature");
            MediaPlayer.Play(_song);
            MediaPlayer.Volume = 0.5f;
            MediaPlayer.IsRepeating = true;
        }

        protected override void Update(GameTime gameTime)
        {
            /* Game Logic */
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var physics = new Physics();

            // Player Boundary
            player.Position = physics.PlayerBoundaries(player, _graphics);

            // Player and Object Collision
            player.Position = physics.PlayerWallCollision(player, wall1);
            player.Position = physics.PlayerWallCollision(player, wall2);
            player.Position = physics.PlayerWallCollision(player, wall3);
            player.Position = physics.PlayerWallCollision(player, wall4);
            player.Position = physics.PlayerWallCollision(player, wall5);
            player.Position = physics.PlayerWallCollision(player, wall6);

            // set player keybindings
            Keybindings(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            /* Draw your content here */
            GraphicsDevice.Clear(background_color);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            // player
            _spriteBatch.Draw(
                player.getTexture(), player.Position, null,
                Color.White, 0f,
                player.getScale(),
                Vector2.One, SpriteEffects.None, 0f
            );

            // wall 1
            _spriteBatch.Draw(
                wall1.getTexture(), wall1.Position, null,
                Color.White, 0f,
                wall1.getScale(),
                Vector2.One, SpriteEffects.None, 0f
            );

            // wall 2
            _spriteBatch.Draw(
                wall2.getTexture(), wall2.Position, null,
                Color.White, 0f,
                wall2.getScale(),
                Vector2.One, SpriteEffects.None, 0f
            );

            // wall 3
            _spriteBatch.Draw(
                wall3.getTexture(), wall3.Position, null,
                Color.White, 0f,
                wall3.getScale(),
                Vector2.One, SpriteEffects.None, 0f
            );

            // wall 4
            _spriteBatch.Draw(
                wall4.getTexture(), wall4.Position, null,
                Color.White, 0f,
                wall4.getScale(),
                Vector2.One, SpriteEffects.None, 0f
            );

            // wall 5
            _spriteBatch.Draw(
                wall5.getTexture(), wall5.Position, null,
                Color.White, 0f,
                wall5.getScale(),
                Vector2.One, SpriteEffects.None, 0f
            );

            // wall 6
            _spriteBatch.Draw(
                wall6.getTexture(), wall6.Position, null,
                Color.White, 0f,
                wall6.getScale(),
                Vector2.One, SpriteEffects.None, 0f
            );

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void Keybindings(GameTime gameTime)
        {
            /* Player Movement */
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up))
            {
                // Move the player up
                player.Position.Y -= player.getSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (kstate.IsKeyDown(Keys.Down))
            {
                // Move the player down
                player.Position.Y += player.getSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (kstate.IsKeyDown(Keys.Left))
            {
                // Move the player left
                player.Position.X -= player.getSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (kstate.IsKeyDown(Keys.Right))
            {
                // Move the player right
                player.Position.X += player.getSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        public GraphicsDeviceManager GetGraphics()
        {
            return _graphics;
        }
    }
}