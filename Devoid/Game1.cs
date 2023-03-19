using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

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
            // Player Boundary
            PlayerBoundaries();

            // Player and Object Collision
            PlayerObjectCollision(wall1.Position, wall1.getTexture());
            PlayerObjectCollision(wall2.Position, wall2.getTexture());
            PlayerObjectCollision(wall3.Position, wall3.getTexture());
            PlayerObjectCollision(wall4.Position, wall4.getTexture());
            PlayerObjectCollision(wall5.Position, wall5.getTexture());
            PlayerObjectCollision(wall6.Position, wall6.getTexture());

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

        public void PlayerBoundaries()
        {
            /* Player Boundaries */
            if (player.Position.X > _graphics.PreferredBackBufferWidth - player.getTextureWidth() / 2)
            {
                // Right Boundary
                player.Position.X = _graphics.PreferredBackBufferWidth - player.getTextureWidth() / 2;
            }
            else if (player.Position.X < player.getTextureWidth() / 2)
            {
                // Left Boundary
                player.Position.X = player.getTextureWidth() / 2;
            }
            if (player.Position.Y > _graphics.PreferredBackBufferHeight - player.getTextureHeight() / 2)
            {
                // Top Boundary
                player.Position.Y = _graphics.PreferredBackBufferHeight - player.getTextureHeight() / 2;
            }
            else if (player.Position.Y < player.getTextureHeight() / 2)
            {
                // Botton Boundary
                player.Position.Y = player.getTextureHeight() / 2;
            }
        }

        private void PlayerObjectCollision(Vector2 objectPosition, Texture2D objectTexture)
        {
            /* Player Object Collision */
            var vertex_gap = 2;

            /* Top and Bottom Sides */
            // player horizontal sides
            var player_top_side = player.Position.Y - player.getTextureHeight() / 2;
            var player_bottom_side = player.Position.Y + player.getTextureHeight() / 2;

            // object horizontal sides
            var object_top_side = objectPosition.Y - objectTexture.Height / 2;
            var object_bottom_side = objectPosition.Y + objectTexture.Height / 2;

            // vertical side
            var verticalside = player_bottom_side > object_top_side + vertex_gap && player_top_side < object_bottom_side - vertex_gap;

            /* Right and Left Sides */
            // player vertical sides
            var player_left_side = player.Position.X - player.getTextureWidth() / 2;
            var player_right_side = player.Position.X + player.getTextureWidth() / 2;

            // object vertical sides
            var object_left_side = objectPosition.X - objectTexture.Width / 2;
            var object_right_side = objectPosition.X + objectTexture.Width / 2;

            // horizontal side
            var horizontalside = player_right_side > object_left_side + vertex_gap && player_left_side < object_right_side - vertex_gap;

            /* Collision Detection */
            // does player collide with object's right or left side
            var leftsidex = player_right_side > object_left_side && player_right_side < object_right_side;
            var rightsidex = player_left_side < object_right_side && player_left_side > object_left_side;

            // does player collisde with object's top or left side
            var topsidey = player_bottom_side > object_top_side && player_bottom_side < object_bottom_side;
            var bottomsidey = player_top_side < object_bottom_side && player_top_side > object_top_side;

            if (leftsidex && verticalside)
            {
                // left side collision
                player.Position.X = objectPosition.X - objectTexture.Width / 2 - player.getTextureWidth() / 2;
            }

            else if (rightsidex && verticalside)
            {
                // right side collision
                player.Position.X = objectPosition.X + objectTexture.Width / 2 + player.getTextureWidth() / 2;
            }

            else if (topsidey && horizontalside)
            {
                // top side collision
                player.Position.Y = objectPosition.Y - objectTexture.Height / 2 - player.getTextureHeight() / 2;
            }

            else if (bottomsidey && horizontalside)
            {
                // bottom side collision
                player.Position.Y = objectPosition.Y + objectTexture.Height / 2 + player.getTextureHeight() / 2;
            }
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
    }
}