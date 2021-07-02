using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.vehicle.track.model.Contracts
{
    public abstract class ResponseBase
    {
        public ResponseBase()
        {
            Errors = new List<Error>();
        }
        public int StatusCode { get; set; }
        public string Status { get; set; }
        public List<Error> Errors { get; set; }
    }

    public class Error
    {
        public Error()
        {
            ErrorMessages = new List<string>();
        }
        public String ErrorType { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
