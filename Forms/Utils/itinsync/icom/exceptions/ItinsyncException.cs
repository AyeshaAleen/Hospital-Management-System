using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.itinsync.icom.constant.application;

namespace Utils.itinsync.icom.exceptions
{
    public class ItinsyncException : Exception
    {
        public Exception exception;
        public string errorMessage;
        public int code;
        public ItinsyncException()
        {
            this.errorMessage = "System.Problem.IT.Support";
            this.code = ApplicationCodes.ERROR;
        }
        public ItinsyncException(Exception exception)
        {
            this.exception = exception;
            this.errorMessage = "System.Problem.IT.Support";
            this.code = ApplicationCodes.ERROR;
        }
        public ItinsyncException(Exception exception, String message)
        {
            this.exception = exception;
            this.errorMessage = message;
            this.code = ApplicationCodes.ERROR;

        }
        public ItinsyncException(Exception exception, string message, int code)
        {
            this.exception = exception;
            this.errorMessage = message;
            this.code = code;

        }

        public ItinsyncException(String message)
        {
            this.errorMessage = message;
            this.code = ApplicationCodes.ERROR;
        }



    }
}
