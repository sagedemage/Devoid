using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Pong
{
    public class Game1 : Game {
        /* Game */
        Texture2D playerTexture;
        Texture2D wallTexture;
        Vector2 wallPosition;
        Vector2 playerPosition;
        float playerSpeed;
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
            playerPosition = new Vector2(_graphics.PreferredBackBufferWidth / 4, _graphics.PreferredBackBufferHeight / 2);
            wallPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            playerSpeed = 100f;
            background_color = new Color(39, 79, 195);

            base.Initialize();
        }

        protected override void LoadContent() 
        {
            /* Load your game content */

            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load your game content here
            playerTexture = Content.Load<Texture2D>("player");

            // Load your game content here
            wallTexture = Content.Load<Texture2D>("wall");
        }

        protected override void Update(GameTime gameTime) 
        {
            /* Game Logic */
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            PlayerBoundaries();
            PlayerObjectCollision(wallPosition, wallTexture);
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
                playerTexture, playerPosition, null,
                Color.White, 0f,
                new Vector2(playerTexture.Width / 2, playerTexture.Height / 2),
                Vector2.One, SpriteEffects.None, 0f
            );

            // wall
            _spriteBatch.Draw(
                wallTexture, wallPosition, null,
                Color.White, 0f,
                new Vector2(wallTexture.Width / 2, wallTexture.Height / 2),
                Vector2.One, SpriteEffects.None, 0f
            );

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        protected void PlayerBoundaries() 
        {
            /* Player Boundaries */
            if (playerPosition.X > _graphics.PreferredBackBufferWidth - playerTexture.Width / 2) {
                // Right Boundary
                playerPosition.X = _graphics.PreferredBackBufferWidth - playerTexture.Width / 2;
            }
            else if (playerPosition.X < playerTexture.Width / 2) {
                // Left Boundary
                playerPosition.X = playerTexture.Width / 2;
            }
            if (playerPosition.Y > _graphics.PreferredBackBufferHeight - playerTexture.Height / 2) {
                // Top Boundary
                playerPosition.Y = _graphics.PreferredBackBufferHeight - playerTexture.Height / 2;
            }
            else if (playerPosition.Y < playerTexture.Height / 2) {
                // Botton Boundary
                playerPosition.Y = playerTexture.Height / 2;
            }
        }

        private void PlayerObjectCollision(Vector2 objectPosition, Texture2D objectTexture) 
        {
            /* Player Object Collision */

            // vertical side
            var verticalside = playerPosition.Y > (objectPosition.Y - objectTexture.Height / 2) && 
                playerPosition.Y < (objectPosition.Y + objectTexture.Height / 2);

            var leftsidex = playerPosition.X > (objectPosition.X - objectTexture.Width) &&
                playerPosition.X < (objectPosition.X + objectTexture.Width / 2);

            var rightsidex = playerPosition.X < (objectPosition.X + objectTexture.Width) &&
                playerPosition.X > (objectPosition.X - objectTexture.Width / 2);

            // horizontal side
            var horizontalside = playerPosition.X > (objectPosition.X - objectTexture.Width / 2) &&
                playerPosition.X < (objectPosition.X + objectTexture.Width / 2);

            var topsidey = playerPosition.Y > (objectPosition.Y - objectTexture.Height) &&
                playerPosition.Y < (objectPosition.Y + objectTexture.Height / 2);

            var bottomsidey = playerPosition.Y < (objectPosition.Y + objectTexture.Height) &&
                playerPosition.Y > (objectPosition.Y - objectTexture.Height / 2);

            if (leftsidex && verticalside) 
            {
                // left side collision
                playerPosition.X = objectPosition.X - objectTexture.Width / 2 - playerTexture.Width / 2;
            }

            if (rightsidex && verticalside)
            {
                // right side collision
                playerPosition.X = objectPosition.X + objectTexture.Width / 2 + playerTexture.Width / 2;
            }

            if (topsidey && horizontalside)
            {
                // top side collision
                playerPosition.Y = objectPosition.Y - objectTexture.Height / 2 - playerTexture.Height / 2;
            }

            if (bottomsidey && horizontalside)
            {
                // bottom side collision
                playerPosition.Y = objectPosition.Y + objectTexture.Height / 2 + playerTexture.Height / 2;
            }
        }

        private void Keybindings(GameTime gameTime) 
        {
            /* Player Movement */
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up))
            {
                // Move the player up
                playerPosition.Y -= playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.Down))
            {
                // Move the player down
                playerPosition.Y += playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.Left))
            {
                // Move the player left
                playerPosition.X -= playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.Right))
            {
                // Move the player right
                playerPosition.X += playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }
    }
}