using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerProblem;
using MoodAnalyzerProjblem;
using System;

namespace MoodAnalyzerProblemsTest
{   

    [TestClass]
    public class MoodAnalyzerTest
    {
       
        [DataRow("I am in Sad Mood", "SAD")] //TC1.1: Given “I am in Sad Mood” message should Return SAD
        [DataRow("I am in Any Mood", "HAPPY")] //TC1.2: Given “I am in Any Mood” message should Return HAPPY
        //[DataRow(null, "HAPPY")]//TC2.1: Given Null Mood should Return Happy
        [TestMethod]
        [TestCategory("Respond Mood")]
        public void GivenMessageReturnMood(string message, string expected)
        {
            //Arrange 
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);
            //Act
            string actual = moodAnalyzer.AnalyseMood();
            //Assert
            Assert.AreEqual(expected, actual);
        }

       
        [DataRow(null, "Message cannot be null", MoodAnalysisException.ExceptionTypes.NULL_MESSAGE)] //TC3.1
        [DataRow("", "Message cannot be Empty", MoodAnalysisException.ExceptionTypes.EMPTY_MESSAGE)] //TC3.2
        [TestMethod]
        [TestCategory("Exception")]
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

        [DataRow("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer")]//TC4.1 : Given MoodAnalyser Class Name Should Return MoodAnalyser
        [TestMethod]
        [TestCategory("Reflection - Create Obj using Non Parameterized Constructor")]
        public void GivenClassInfoReturnObjectUsingDefaultConstructor(string className, string constructorName)
        {   
            Object expectedObj = new MoodAnalyzer();
            
            //Act
            Object actualObj = MoodAnalyserFactory.CreateMoodAnalyser(className, constructorName);
            
            expectedObj.Equals(actualObj);
                     
        }

        [TestMethod]
        [TestCategory("Reflection - Create Obj using Non Parameterized Constructor")]
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

        [DataRow("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer", "I am Happy")]//TC 5.1 : Given MoodAnalyser When Proper Return MoodAnalyser Object 
        [TestMethod]
        [TestCategory("Reflection - Create Obj using Parameterized Constructor")]        
        public void GivenClassWithMessageReturnObjectUsingParameterizedConstructor(string className, string constructorName, string  message)
        {
            Object expectedObj = new MoodAnalyzer("HAPPY");
            //Act
            Object obj = MoodAnalyserFactory.CreateMoodAnalyserUsingParameterizedConstructor (className, constructorName, message);
            expectedObj.Equals(obj);

        }

        [DataRow("MoodAnalyzerProblem.Mood", "MoodAnalyzer", "I am Happy")]//TC 5.2 : Given Class Name When Improper Should Throw MoodAnalysisException
        [DataRow("MoodAnalyzerProblem.Mood", "Mood", "I am Happy")]//TC 5.3 :  Given Class When Constructor Not Proper Should Throw MoodAnalysisException 
        [TestMethod]
        [TestCategory("Reflection - Create Obj using Parameterized Constructor ")]
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

        
        [TestMethod]  // TC 6.1 : Given Happy Message Using Reflection When Proper Should Return HAPPY Mood
        [TestCategory("Reflection - Invoke Method")]
        public void GivenMethodNameShouldInvokeMethod()
        {
                string expected = "HAPPY";
                string mood = MoodAnalyserFactory.InvokeAnalyseMood("HAPPY", "AnalyseMood");
                Assert.AreEqual(expected, mood);
            
        }
       
        [TestMethod] // TC 6.2 : Given Happy Message When Improper Method Should Throw MoodAnalysisException
        [TestCategory("Reflection - Invoke Method")]
        public void GivenImProperMethodThrowException()
        {   
            //Arrange
            string expected = "Method not found";
            try
            {   
                //Act
                string mood = MoodAnalyserFactory.InvokeAnalyseMood("HAPPY", "Analyser");
            }
            catch (MoodAnalysisException exception)
            {
                //Assert
                Assert.AreEqual(expected, exception.Message);
            }
        }

        
        [TestMethod] // TC 7.1 : Set Happy Message with Reflector Should Return HAPPY
        [TestCategory("Reflection - Set Field")]
        public void GivenHAPPYMessageWithReflectorShouldReturnHAPPY()
        {
            string result = MoodAnalyserFactory.SetField("HAPPY", "message");
            Assert.AreEqual("HAPPY", result);
        }

    
        [TestMethod]  // TC 7.2 : Set Field When Improper Should Throw Exception with No Such Field
        [TestCategory("Reflection - Set Field")]
        public void SetFieldImproperShouldThrowException()
        {
            try
            {
                string result = MoodAnalyserFactory.SetField("HAPPY", "me");
            }
            catch (MoodAnalysisException exception)
            {
                Assert.AreEqual("Field cannot found", exception.Message);
            }
        }
       
        [TestMethod] // TC 7.3 : Set Null Messge  Should Throw Exception 
        [TestCategory("Reflection - Set Field")]
        public void SettingNullMessgeShouldThrowException()
        {
            try
            {
                string result = MoodAnalyserFactory.SetField(null, "message");//we are passing null for message
            }
            catch (MoodAnalysisException exception)
            {
                Assert.AreEqual("Message cannot be null", exception.Message);
            }
        }
    }
}
 