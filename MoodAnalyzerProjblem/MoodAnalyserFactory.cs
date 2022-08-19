using MoodAnalyzerProblem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyzerProblem
{  /// <summary>
   /// UC 5 : Use Reflection to Create MoodAnalyser with Parameter Constructor
   /// - Use MoodAnalyserFactory to create MoodAnalyser Object with Message Parameneter
   /// TC 5.1 : Given MoodAnalyser When Proper Return MoodAnalyser Object
   /// TC 5.2 : Given Class Name When Improper Should Throw MoodAnalysisException
   /// TC 5.3 : Given Class When Constructor Not Proper Should Throw MoodAnalysisException
   /// </summary>
    public class MoodAnalyserFactory
    {   
        //method to create Mood Analyser with non parameterized Constructor using Reflection
        public static object CreateMoodAnalyser(string className, string constructorName)
        {
            string pattern = "." + constructorName + "$";
            Match result = Regex.Match(className, pattern); //to check if class name & constructor we are passing are same or not

            if (result.Success)
            {
                try
                {
                    Assembly currentAsembly = Assembly.GetExecutingAssembly(); //to get the current assembly
                    Type moodAnalyser = currentAsembly.GetType(className);//trying to fetch whether the class name passed exist or not
                    return Activator.CreateInstance(moodAnalyser);

                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalysisException("Class not found", MoodAnalysisException.ExceptionTypes.CLASS_NOT_FOUND);
                }

            }
            else
            {
                throw new MoodAnalysisException("Constructor not found", MoodAnalysisException.ExceptionTypes.CONSTRUCTOR_NOT_FOUND);
            }
        }

        //method to create Mood Analyser with parameterized constructor using Reflection
        public static object CreateMoodAnalyserUsingParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyzer);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName)) //checking if class name equals to constructor
                {
                    ConstructorInfo constructor = type.GetConstructor(new[] { typeof(string) }); //fetching constructor information
                    object moodAnalyzerObj = constructor.Invoke(new object[] { message });
                    return moodAnalyzerObj;
                }

                else
                {
                    throw new MoodAnalysisException("Constructor not found", MoodAnalysisException.ExceptionTypes.CONSTRUCTOR_NOT_FOUND);
                }
            }
            else
            {
                throw new MoodAnalysisException("Class not found", MoodAnalysisException.ExceptionTypes.CLASS_NOT_FOUND);
            }
        }
    }

}
