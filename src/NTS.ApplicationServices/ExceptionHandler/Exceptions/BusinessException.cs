namespace NTS.ApplicationServices.ExceptionHandler.Exceptions
{
    using System;

    public class BusinessException : Exception
    {
     //   private ILogger _logger = LogManager.GetLogger(typeof(object));

        public BusinessException(string message)
            : base(message)
        {
           // _logger.Error(message);
        }

        public BusinessException(string message, Exception inner)
            : base(message, inner)
        {
          //  _logger.Error(message + " : " + inner);
        }
    }

}
