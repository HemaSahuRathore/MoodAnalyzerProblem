using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProjblem
{ /// <summary>
  /// UC 3: Inform user if entered Invalid Mood
  /// - In case of NULL or Empty Mood throw Custom Exception MoodAnalysisException
  /// - Use Enum to differentiate the Mood
  /// </summary>
    public class MoodAnalyzer
    {
        string message;

        //default constructor
        public MoodAnalyzer()
        {
            this.message = null;
        }

        //Parameterized constructor
        public MoodAnalyzer(string message)
        {
            this.message = message;
        }

        //Method to Analyse Mood
        public string AnalyseMood()
        {

            string sad = "SAD";
            string happy = "HAPPY";

            try
            {
                if (message.Equals(string.Empty))
                    throw new MoodAnalysisException("Message cannot be Empty", MoodAnalysisException.ExceptionTypes.EMPTY_MESSAGE);
                else if (message.ToUpper().Contains(sad))
                    return sad;
                else
                    return happy;
            }
            catch (NullReferenceException nreObj)
            {
                Console.WriteLine(nreObj.Message);
                throw new MoodAnalysisException("Message cannot be null", MoodAnalysisException.ExceptionTypes.NULL_MESSAGE);
            }
        }
    }
}