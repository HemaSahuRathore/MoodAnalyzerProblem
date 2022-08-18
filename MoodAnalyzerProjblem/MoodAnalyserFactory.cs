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
   /// UC 4 : Use Reflection to Create MoodAnalyser with default Constructor 
   /// - Create MoodAnalyserFactory and specify static method to create MoodAnalyser Object
   /// </summary>
    public class MoodAnalyserFactory
    {   
        //method to create Mood Analyser using Reflection
        public static object CreateMoodAnalyser(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);

            if (result.Success)
            {
                try
                {
                    Assembly currentAsembly = Assembly.GetExecutingAssembly(); //to get the current assembly
                    Type moodAnalyser = currentAsembly.GetType(className);//storing the class name to moodAnalyzer
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
    }

}
