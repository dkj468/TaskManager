using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
    public class AppException
    {
        public AppException(int statusCode, string error, string detail = null)
        {
            StatusCode = statusCode;
            Error = error; 
            Detail = detail;
        }
        public int StatusCode { get; set; }
        public string Error { get; set; }
        public string Detail { get; set; }
    }
}
