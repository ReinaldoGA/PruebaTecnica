using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core.Base
{
    [Serializable]
    public class RequestBaseException<T> : Exception
    {
#pragma warning disable CS0114
        public T? Data { get; set; }
        public System.Net.HttpStatusCode StatusCode { get; set; }
        public RequestBaseException() { }

        public RequestBaseException(
            System.Net.HttpStatusCode code,
            string? message,
            JsonSerializerSettings? settings) : base(message)
        {
            this.StatusCode = code;
            if (!string.IsNullOrEmpty(message))
            {
                this.Data = JsonConvert.DeserializeObject<T>(message, settings);
            }
        }
    }
}
