using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Pong
{
    public class Game1 : Game {
        /* Game */

        // player object
        Player player;

        // wall object
        Wall wall;
        
        // background color
        Color background_color;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1(){
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
            var wallPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            wall = new Wall(wallPosition);

            background_color = new Color(39, 79, 195);

            base.Initialize();
        }

        protected override void LoadContent() 
        {
            /* Load your game content */

            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load your game content here
            var playerTexture = Content.Load<Texture2D>("player");
            player.setTexture(playerTexture);

            // Load your game content here
            var wallTexture = Content.Load<Texture2D>("wall");
            wall.setTexture(wallTexture);
        }

        protected override void Update(GameTime gameTime) 
        {
            /* Game Logic */
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            PlayerBoundaries();
            PlayerObjectCollision(wall.Position, wall.getTexture());
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
                new Vector2(player.getTextureWidth() / 2, player.getTextureHeight() / 2),
                Vector2.One, SpriteEffects.None, 0f
            );

            // wall
            _spriteBatch.Draw(
                wall.getTexture(), wall.Position, null,
                Color.White, 0f,
                new Vector2(wall.getTextureWidth() / 2, wall.getTextureHeight() / 2),
                Vector2.One, SpriteEffects.None, 0f
            );

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        protected void PlayerBoundaries() 
        {
            /* Player Boundaries */
            if (player.Position.X > _graphics.PreferredBackBufferWidth - player.getTextureWidth() / 2) {
                // Right Boundary
                player.Position.X = _graphics.PreferredBackBufferWidth -  player.getTextureWidth() / 2;
            }
            else if (player.Position.X < player.getTextureWidth() / 2) {
                // Left Boundary
                player.Position.X = player.getTextureWidth() / 2;
            }
            if (player.Position.Y > _graphics.PreferredBackBufferHeight - player.getTextureHeight() / 2) {
                // Top Boundary
                player.Position.Y = _graphics.PreferredBackBufferHeight - player.getTextureHeight() / 2;
            }
            else if (player.Position.Y < player.getTextureHeight() / 2) {
                // Botton Boundary
                player.Position.Y = player.getTextureHeight() / 2;
            }
        }

        private void PlayerObjectCollision(Vector2 objectPosition, Texture2D objectTexture) 
        {
            /* Player Object Collision */

            // vertical side
            var verticalside = player.Position.Y > (objectPosition.Y - 9 * objectTexture.Height / 10) && 
                player.Position.Y < (objectPosition.Y + 9 * objectTexture.Height / 10);

            var leftsidex = player.Position.X + player.getTextureWidth() / 2 > (objectPosition.X - objectTexture.Width / 2) &&
                player.Position.X + player.getTextureWidth() / 2 < (objectPosition.X + objectTexture.Width / 2);

            var rightsidex = player.Position.X - player.getTextureWidth() / 2  < (objectPosition.X + objectTexture.Width / 2) &&
                player.Position.X - player.getTextureWidth() / 2 > (objectPosition.X - objectTexture.Width / 2);

            // horizontal side
            var horizontalside = player.Position.X > (objectPosition.X - 9 * objectTexture.Width / 10) &&
                player.Position.X < (objectPosition.X + 9 * objectTexture.Width / 10);

            var topsidey = player.Position.Y + player.getTextureHeight() / 2 > (objectPosition.Y - objectTexture.Height / 2) &&
                player.Position.Y + player.getTextureHeight() / 2 < (objectPosition.Y + objectTexture.Height / 2);

            var bottomsidey = player.Position.Y - player.getTextureHeight() / 2 < (objectPosition.Y + objectTexture.Height / 2) &&
                player.Position.Y - player.getTextureHeight() / 2 > (objectPosition.Y - objectTexture.Height / 2);

            if (leftsidex && verticalside) 
            {
                // left side collision
                player.Position.X = objectPosition.X - objectTexture.Width / 2 -  player.getTextureWidth() / 2;
            }

            if (rightsidex && verticalside)
            {
                // right side collision
                player.Position.X = objectPosition.X + objectTexture.Width / 2 + player.getTextureWidth() / 2;
            }

            if (topsidey && horizontalside)
            {
                // top side collision
                player.Position.Y = objectPosition.Y - objectTexture.Height / 2 - player.getTextureHeight() / 2;
            }

            if (bottomsidey && horizontalside)
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
                player.Position.X +=  player.getSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }
    }
}