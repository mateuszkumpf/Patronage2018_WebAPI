using Newtonsoft.Json;

namespace Patronage2018.WebAPI.Middleware.Models
{
    internal class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}