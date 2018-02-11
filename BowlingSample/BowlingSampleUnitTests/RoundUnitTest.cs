using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingSample;

namespace BowlingSampleUnitTests
{
    [TestClass]
    public class RoundTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            BowlingSample.DataLayer.Round r = new BowlingSample.DataLayer.Round();
            Assert.IsNotNull(r);
            Assert.IsTrue(r.Ball1 == 0);
            Assert.IsTrue(r.Ball2 == 0);
            Assert.IsTrue(r.Ball3 == 0);
            Assert.IsTrue(r.Ball4 == 0);
            Assert.IsTrue(r.RoundScore == 0);
            Assert.IsTrue(r.Frame == 0);
        }

        [TestMethod]
        public void TestAssignment()
        {
            BowlingSample.DataLayer.Round r = new BowlingSample.DataLayer.Round();
            r.Frame = 1;
            r.Ball1 = 1;
            r.Ball2 = 1;
            r.Ball3 = 1;
            r.Ball4 = 1;
            Assert.IsTrue(r.Ball1 == 1);
            Assert.IsTrue(r.Ball2 == 1);
            Assert.IsTrue(r.Ball3 == 1);
            Assert.IsTrue(r.Ball4 == 1);
            Assert.IsTrue(r.Frame == 1);
        }

        [TestMethod]
        public void TestStrikeSpare()
        {
            BowlingSample.DataLayer.Round r = new BowlingSample.DataLayer.Round();
            r.Frame = 10;
            r.Ball1 = 10;
            Assert.IsTrue(r.Ball1 == 10);
            Assert.IsTrue(r.IsSpare);
            r.Ball1 = 9;
            Assert.IsFalse(r.IsSpare);
            r.Ball2 = 1;
            Assert.IsTrue(r.IsSpare);
        }

        [TestMethod]
        public void TestBall2Available()
        {
            BowlingSample.DataLayer.Round r = new BowlingSample.DataLayer.Round();
            r.Frame = 1;
            r.Ball1 = 5;
            Assert.IsTrue(r.IsBall2Enabled);
            r.Ball1 = 10;
            Assert.IsFalse(r.IsBall2Enabled);
            Assert.IsFalse(r.IsBall3Enabled);
            Assert.IsFalse(r.IsBall4Enabled);
        }

        [TestMethod]
        public void TestBall2AvailableFrame10()
        {
            BowlingSample.DataLayer.Round r = new BowlingSample.DataLayer.Round();
            r.Frame = 10;
            r.Ball1 = 5;
            Assert.IsTrue(r.IsBall2Enabled);
            Assert.IsFalse(r.IsBall3Enabled);
            Assert.IsFalse(r.IsBall4Enabled);
            r.Ball1 = 10;
            Assert.IsFalse(r.IsBall2Enabled);
            Assert.IsTrue(r.IsBall3Enabled);
            Assert.IsTrue(r.IsBall4Enabled);
        }

        [TestMethod]
        public void TestBall2Value()
        {
            BowlingSample.DataLayer.Round r = new BowlingSample.DataLayer.Round();
            r.Frame = 1;
            r.Ball1 = 10;
            r.Ball2 = 10;
            Assert.IsTrue(r.Ball2 == 0);
            r.Ball1 = 5;
            r.Ball2 = 5;
            Assert.IsTrue(r.Ball2 == 5);
        }

        [TestMethod]
        public void TestBadAssignment()
        {
            BowlingSample.DataLayer.Round r = new BowlingSample.DataLayer.Round();
            r.Frame = 1;
            r.Ball1 = 11;
            r.Ball2 = 11;
            r.Ball3 = 11;
            r.Ball4 = 11;
            Assert.IsTrue(r.Ball1 == 0);
            Assert.IsTrue(r.Ball2 == 0);
            Assert.IsTrue(r.Ball3 == 0);
            Assert.IsTrue(r.Ball4 == 0);
            r.Frame = 1;
            r.Ball1 = -1;
            r.Ball2 = -1;
            r.Ball3 = -1;
            r.Ball4 = -1;
            Assert.IsTrue(r.Ball1 == 0);
            Assert.IsTrue(r.Ball2 == 0);
            Assert.IsTrue(r.Ball3 == 0);
            Assert.IsTrue(r.Ball4 == 0);

        }
    }
}
