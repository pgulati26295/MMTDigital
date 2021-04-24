using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMT.CustomerOrder.SharedKernel.Api
{
   public class ApiResponse<T>
    {
        public ApiResponse() => ErrorMessages = new List<ErrorMessage>();

        public bool WasSuccessful { get; set; }

        public string ResponseCode{ get; set; }

        public int StatusCode { get; set; }

        public string ResponseReason { get; set; }

        public List<ErrorMessage> ErrorMessages { get; set; }

        public T Data { get; set; }

        public string GetErrorMessages()
        {
            List<string> errors = ErrorMessages.Select(x => x.Description).ToList();
            return string.Join(". ", errors);
                
          }
    }
}
