using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingSample;
using System.Linq;

namespace BowlingSampleUnitTests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            BowlingSample.DataLayer.Game g = new BowlingSample.DataLayer.Game("Lewis");
            Assert.IsNotNull(g);
            Assert.IsTrue(g.Frames.Count == 10);
        }

        [TestMethod]
        public void TestScoreFrame10()
        {
            BowlingSample.DataLayer.Game game = new BowlingSample.DataLayer.Game("Lewis");
            BowlingSample.DataLayer.Round round = game.Frames.Where(r => r.Frame == 10).FirstOrDefault();
            Assert.IsNotNull(round);
            round.Ball1 = 10;
            round.Ball3 = 10;
            round.Ball4 = 10;
            game.CalculateScore();
            Assert.IsTrue(game.TotalScore == 30);
            round.Ball1 = 5;
            round.Ball2 = 5;
            round.Ball3 = 10;
            round.Ball4 = 10;
            game.CalculateScore();
            Assert.IsTrue(game.TotalScore == 20);
            round.Ball1 = 5;
            round.Ball2 = 4;
            round.Ball3 = 10;
            round.Ball4 = 10;
            game.CalculateScore();
            Assert.IsTrue(game.TotalScore == 9);
        }

        [TestMethod]
        public void TestScorePerfectGame()
        {
            BowlingSample.DataLayer.Game game = new BowlingSample.DataLayer.Game("Lewis");
            foreach (var r in game.Frames)
            {
                r.Ball1 = 10;
                if (r.Frame == 10)
                {
                    r.Ball3 = 10;
                    r.Ball4 = 10;
                }
            }            
            game.CalculateScore();
            Assert.IsTrue(game.TotalScore == 300);
        }

        [TestMethod]
        public void TestScoreSpare()
        {
            BowlingSample.DataLayer.Game game = new BowlingSample.DataLayer.Game("Lewis");
            foreach (var r in game.Frames)
            {
                r.Ball1 = 5;
                r.Ball2 = 5;
                if (r.Frame == 10)
                {
                    r.Ball3 = 5;
                    r.Ball4 = 5;
                }

            }
            game.CalculateScore();
            Assert.IsTrue(game.TotalScore == 150);
        }

        [TestMethod]
        public void TestScoreNine()
        {
            BowlingSample.DataLayer.Game game = new BowlingSample.DataLayer.Game("Lewis");
            foreach (var r in game.Frames)
            {
                r.Ball1 = 5;
                r.Ball2 = 4;
            }
            game.CalculateScore();
            Assert.IsTrue(game.TotalScore == 90);
        }
    }
}
