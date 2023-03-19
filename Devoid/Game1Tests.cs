using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Devoid
{
    [TestClass]
    public class Game1Tests
    {
        [TestMethod]
        public void TestPlayerLeftBoundary()
        {
            // Arrange
            Game1 game1 = new Game1();

            game1.RunOneFrame();

            // Act
            game1.player.Position.X = 30;

            game1.PlayerBoundaries();

            // Assert
            Assert.AreEqual(game1.player.Position.X, 32);
        }

        [TestMethod]
        public void TestPlayerRightBoundary()
        {
            // Arrange
            Game1 game1 = new Game1();

            game1.RunOneFrame();

            // Act
            game1.player.Position.X = 780;

            game1.PlayerBoundaries();

            // Assert
            Assert.AreEqual(game1.player.Position.X, 768);
        }

        [TestMethod]
        public void TestPlayerTopBoundary()
        {
            // Arrange
            Game1 game1 = new Game1();

            game1.RunOneFrame();

            // Act
            game1.player.Position.Y = 30;

            game1.PlayerBoundaries();

            // Assert
            Assert.AreEqual(game1.player.Position.Y, 32);
        }

        [TestMethod]
        public void TestPlayerBottomBoundary()
        {
            // Arrange
            Game1 game1 = new Game1();

            game1.RunOneFrame();

            // Act
            game1.player.Position.Y = 460;

            game1.PlayerBoundaries();

            // Assert
            Assert.AreEqual(game1.player.Position.Y, 448);
        }

    }
}
