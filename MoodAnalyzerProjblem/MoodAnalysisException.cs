using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProblem
{
    public class MoodAnalysisException : Exception
    {
        public string message;
        public ExceptionTypes exceptionType;

        public enum ExceptionTypes
        {
            NULL_MESSAGE,
            EMPTY_MESSAGE,
            CLASS_NOT_FOUND,
            CONSTRUCTOR_NOT_FOUND
        }
        public MoodAnalysisException(string msg, ExceptionTypes exceptionType) : base(msg) //overriding the base constructor
        {
            this.message = msg;
            this.exceptionType = exceptionType;
        }
    }
}
