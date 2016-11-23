using System;



namespace LinkedInChecker.View
{
    /// <summary>
    /// Represents internet Services progress Exceptions
    /// </summary>
    
    public class ServiceException : Exception
    {
        public ServiceException()
        {
            new ExceptionDisplay(this.Message);
        }
        public override string Message
        {
            get
            {
                return "We are sorry, there is a problem with the service . Check your internet connection and please, try again";
            }
        } 
    }
}
