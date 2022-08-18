using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerProjblem;
using System;

namespace MoodAnalyzerProblemsTest
{
    [TestClass]
    public class MoodAnalyzerTest
    {
        public MoodAnalyzer moodAnalyzerObj;

        [TestInitialize]
        public void SetUp()
        {
            moodAnalyzerObj = new MoodAnalyzer();
        }

        [DataRow("I am in Sad Mood", "SAD")] //TC1.1
        [DataRow("I am in Any Mood", "HAPPY")] //TC1.2
        [TestMethod]
        public void GivenMessageReturnMood(string message, string expected)
        {
            //Act
            string actual = moodAnalyzerObj.AnalyseMood(message);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
