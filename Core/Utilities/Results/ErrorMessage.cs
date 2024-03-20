using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorMessage : Result
    {
        public ErrorMessage(string message) : base(true, message)
        {

        }
        public ErrorMessage() : base(true)
        {

        }
    }
}
