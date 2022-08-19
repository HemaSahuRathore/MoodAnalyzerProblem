using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerProblem;
using MoodAnalyzerProjblem;
using System;

namespace MoodAnalyzerProblemsTest
{   

    [TestClass]
    public class MoodAnalyzerTest
    {
        [TestCategory("Respond Mood")]
        [DataRow("I am in Sad Mood", "SAD")] //TC1.1: Given “I am in Sad Mood” message should Return SAD
        [DataRow("I am in Any Mood", "HAPPY")] //TC1.2: Given “I am in Any Mood” message should Return HAPPY
        //[DataRow(null, "HAPPY")]//TC2.1: Given Null Mood should Return Happy
        [TestMethod]
        public void GivenMessageReturnMood(string message, string expected)
        {
            //Arrange 
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);
            //Act
            string actual = moodAnalyzer.AnalyseMood();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCategory("Exception")]
        [DataRow(null, "Message cannot be null", MoodAnalysisException.ExceptionTypes.NULL_MESSAGE)] //TC3.1
        [DataRow("", "Message cannot be Empty", MoodAnalysisException.ExceptionTypes.EMPTY_MESSAGE)] //TC3.2
        [TestMethod]
        public void GivenNullReturnCusException(string msg, string expectedMsg, MoodAnalysisException.ExceptionTypes expectedType)
        {
            //Arrange 
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer(msg);
            //Act
            try
            {
                string actual = moodAnalyzer.AnalyseMood();
            }
            catch (MoodAnalysisException ex)
            {
                //Assert
                Assert.AreEqual(expectedMsg, ex.Message);
                Assert.AreEqual(expectedType, ex.exceptionType);
            }
        }

        [TestCategory("Reflection - Create Obj using Non Parameterized Constructor")]
        [TestMethod]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer")]//TC4.1 : Given MoodAnalyser Class Name Should Return MoodAnalyser
        public void GivenClassInfoReturnObjectUsingDefaultConstructor(string className, string constructorName)
        {   
            Object expectedObj = new MoodAnalyzer();
            
            //Act
            Object actualObj = MoodAnalyserFactory.CreateMoodAnalyser(className, constructorName);
            
            expectedObj.Equals(actualObj);
                     
        }

        [TestCategory("Reflection - Create Obj using Non Parameterized Constructor")]
        [TestMethod]
        [DataRow("MoodAnalyzerProblem.Mood", "Mood")] //TC4.2 : Given Class Name When Improper Should Throw MoodAnalysisException
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer", "Mood")] //TC4.3 : Given Class When Constructor Not Proper Should Throw MoodAnalysisException 
        public void GivenImproperClassThrowMoodAnalysisException(string className, string constructorName)
        {
            string expectedmsg = "Class not found";
            try
            {
                object actualObj = MoodAnalyserFactory.CreateMoodAnalyser("MoodAnalyser.Mood", "Mood");
            }
            catch(MoodAnalysisException exception)
            {
                Assert.AreEqual(expectedmsg,exception.message);
            }
        }

        [TestCategory("Reflection - Create Obj using Parameterized Constructor")]
        [TestMethod]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer", "I am Happy")]//TC 5.1 : Given MoodAnalyser When Proper Return MoodAnalyser Object 
        public void GivenClassWithMessageReturnObjectUsingParameterizedConstructor(string className, string constructorName, string  message)
        {
            Object expectedObj = new MoodAnalyzer("HAPPY");
            //Act
            Object obj = MoodAnalyserFactory.CreateMoodAnalyserUsingParameterizedConstructor (className, constructorName, message);
            expectedObj.Equals(obj);

        }


        [TestMethod]
        [TestCategory("Reflection - Create Obj using Parameterized Constructor ")]
        [DataRow("MoodAnalyzerProblem.Mood", "MoodAnalyzer", "I am Happy")]//TC 5.2 : Given Class Name When Improper Should Throw MoodAnalysisException
        [DataRow("MoodAnalyzerProblem.Mood", "Mood", "I am Happy")]//TC 5.3 :  Given Class When Constructor Not Proper Should Throw MoodAnalysisException 

        public void GivenClassToCreateObjUsingParameterizedConstThrowsException(string className, string constructorName, string message)
        {
            string expected = "Class not found";
            try
            {
                object obj = MoodAnalyserFactory.CreateMoodAnalyserUsingParameterizedConstructor(className, constructorName, message);
            }
            catch (MoodAnalysisException exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }
    }
}
 