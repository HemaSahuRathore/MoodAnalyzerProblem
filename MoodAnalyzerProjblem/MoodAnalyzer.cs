using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProjblem
{ /// <summary>
  ///UC 2 : Handle Exception if User Provides Invalid Mood
  /// - Like NULL
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

            try 
            {
                if (message.ToUpper().Contains(sad))
                    return sad;
                else
                    return happy;
            }
            catch (NullReferenceException) //handling NullReferenceException
            {
                return happy;
            }
            
        }
    }
}