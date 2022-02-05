using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Shared.Models
{
    public class StoreException : Exception
    {
        public string errorType;
        public StoreException(string errorType, string message) : base(message)
        {
            this.errorType = errorType;
        }
    }



   



}
