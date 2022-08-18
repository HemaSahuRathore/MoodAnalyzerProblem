using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProjblem
{ /// <summary>
  /// UC 1 Refactor the code to take the mood message in Constructor 
  ///- Note:
  ///- MoodAnalyser will have a message Field
  ///- MoodAnalyser will have 2 Constructors – Default - MoodAnalyser() and with   Parameters – MoodAnalyser(message)
  ///- analyseMood method will change to support no parameters and use message Field defined for the Class
  /// </summary>
    public class MoodAnalyzer
    {
        public string message;

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

            if (message.ToUpper().Contains(sad))
                return sad;
            else
                return happy;
        }
    }
}