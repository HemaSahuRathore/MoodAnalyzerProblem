using MoodAnalyzerProblem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyzerProblem
{  
    public class MoodAnalyserFactory
    {   
        // UC 4 : method to create Mood Analyser with non parameterized Constructor using Reflection
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

        // UC 5 : method to create Mood Analyser with parameterized constructor using Reflection
        public static object CreateMoodAnalyserUsingParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyzer);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName)) //checking if class name equals to constructor
                {
                    ConstructorInfo constructor = type.GetConstructor(new[] { typeof(string) }); //new[] array to take param fetching constructor information
                    Object moodAnalyzerObj = constructor.Invoke(new object[] { message });
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

        //UC 6 : Use Reflection to invoke Method
        public static string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyzerProblem.MoodAnalyzer");
                object moodAnalyseObject = MoodAnalyserFactory.CreateMoodAnalyserUsingParameterizedConstructor("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer", "I am Happy");
                MethodInfo analyseMoodInfo = type.GetMethod(methodName);
                object mood = analyseMoodInfo.Invoke(moodAnalyseObject, null);
                return mood.ToString();

            }
            catch (NullReferenceException)
            {
                throw new MoodAnalysisException("Method not found", MoodAnalysisException.ExceptionTypes.METHOD_NOT_FOUND);

            }
        }

        // UC 7 : Use Reflection to change mood dynamically
        public static string SetField(string message, string fieldName)
        {
            try
            {
                MoodAnalyzer moodAnalyser = new MoodAnalyzer();
                Type type = typeof(MoodAnalyzer);
                FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    throw new MoodAnalysisException("Message cannot be null", MoodAnalysisException.ExceptionTypes.NO_SUCH_FIELD);
                }
                field.SetValue(moodAnalyser, message);
                return moodAnalyser.message;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalysisException("Field cannot found", MoodAnalysisException.ExceptionTypes.NO_SUCH_FIELD);
            }
        }
    }

}
