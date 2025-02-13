using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core.Model.BaseModel
{
    public class BaseModel
    {
        public bool Sucess { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public string ExceptionMessage { get; set; } = string.Empty;
    }
}
