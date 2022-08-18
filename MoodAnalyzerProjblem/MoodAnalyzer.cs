using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProjblem
{ /// <summary>
  /// UC 1: Given a Message, ability to analyse and respond Happy or Sad Mood, 
  ///       - Create MoodAnalyser Object 
  ///       - Call analyseMood function with message as parameter and return Happy or Sad Mood
  /// TC1.1 : Given “I am in Sad Mood” message should Return SAD
  /// TC1.2 : Given “I am in Any Mood” message should Return HAPPY
  /// </summary>
    public class MoodAnalyzer
    {
        //Method to Analyse Mood
        public string AnalyseMood(string message)
        {
            string SAD = "SAD";
            string HAPPY = "HAPPY";

            if (message.ToUpper().Contains(SAD))
                return SAD;
            else
                return HAPPY;

        }
    }
}