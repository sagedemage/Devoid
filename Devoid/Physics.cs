using Devoid.Entities;
using Microsoft.Xna.Framework;

namespace Devoid
{
    public class Physics
    {
        public void PlayerBoundaries(ref Player player, GraphicsDeviceManager graphics)
        {
            /* Player Boundaries */
            if (player.Position.X > graphics.PreferredBackBufferWidth - player.getTextureWidth() / 2)
            {
                // Right Boundary
                player.Position.X = graphics.PreferredBackBufferWidth - player.getTextureWidth() / 2;
            }
            else if (player.Position.X < player.getTextureWidth() / 2)
            {
                // Left Boundary
                player.Position.X = player.getTextureWidth() / 2;
            }
            if (player.Position.Y > graphics.PreferredBackBufferHeight - player.getTextureHeight() / 2)
            {
                // Top Boundary
                player.Position.Y = graphics.PreferredBackBufferHeight - player.getTextureHeight() / 2;
            }
            else if (player.Position.Y < player.getTextureHeight() / 2)
            {
                // Botton Boundary
                player.Position.Y = player.getTextureHeight() / 2;
            }
        }

        public void PlayerWallCollision(ref Player player, Wall wall)
        {
            /* Player and Wall Collision */
            var vertex_gap = 2;

            /* Collision Detection */
            if (player.getBottomSideYPosition() > wall.getTopSideYPosition() + vertex_gap &&
                player.getTopSideYPosition() < wall.getBottomSideYPosition() - vertex_gap)
            {
                /* Wall's Vertical Position
                 * Does the player's y position within the wall's y position? 
                 */
                if (player.getRightSideXPosition() > wall.getLeftSideXPosition() &&
                player.getRightSideXPosition() < wall.getRightSideXPosition())
                {
                    /* Wall's Left Side 
                     * Is player's right side between wall's left side and wall's right side?
                     */
                    // player collides with wall's left side
                    player.Position.X = wall.Position.X - wall.getTextureWidth() / 2 - player.getTextureWidth() / 2;
                }
                else if (player.getLeftSideXPosition() < wall.getRightSideXPosition() &&
                player.getLeftSideXPosition() > wall.getLeftSideXPosition())
                {
                    /* Wall's Right Side 
                     * Is player's left side between wall's left side and wall's right side?
                     */
                    // player collides with wall's right side
                    player.Position.X = wall.Position.X + wall.getTextureWidth() / 2 + player.getTextureWidth() / 2;
                }
            }
            else if (player.getRightSideXPosition() > wall.getLeftSideXPosition() + vertex_gap &&
                player.getLeftSideXPosition() < wall.getRightSideXPosition() - vertex_gap)
            {
                /* Wall's Horizontal Position
                 * Does the player's x position is within the wall's x position? 
                 */
                if (player.getBottomSideYPosition() > wall.getTopSideYPosition() &&
                player.getBottomSideYPosition() < wall.getBottomSideYPosition())
                {
                    /* Wall's Top Side 
                     * Is player above wall's top side?
                     */
                    // player collides with wall's top side
                    player.Position.Y = wall.Position.Y - wall.getTextureHeight() / 2 - player.getTextureHeight() / 2;
                }
                else if (player.getTopSideYPosition() < wall.getBottomSideYPosition() &&
                player.getTopSideYPosition() > wall.getTopSideYPosition())
                {
                    /* Wall's Bottom Side 
                     * Is the player below the wall's bottom side?
                     */
                    // player collides with wall's bottom side
                    player.Position.Y = wall.Position.Y + wall.getTextureHeight() / 2 + player.getTextureHeight() / 2;
                }
            }
        }
    }
}
