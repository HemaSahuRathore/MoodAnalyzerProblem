using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerProjblem;
using System;

namespace MoodAnalyzerProblemsTest
{
    [TestClass]
    public class MoodAnalyzerTest
    {
        [DataRow("I am in Sad Mood", "SAD")] //TC1.1: Given “I am in Sad Mood” message should Return SAD
        [DataRow("I am in Any Mood", "HAPPY")] //TC1.2: Given “I am in Any Mood” message should Return HAPPY
        [DataRow(null, "HAPPY")]//TC2.1: Given Null Mood should Return Happy
        [TestMethod]
        public void GivenMessageReturnMood(string message, string expected)
        {
            //Arramge 
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);
            //Act
            string actual = moodAnalyzer.AnalyseMood();
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
