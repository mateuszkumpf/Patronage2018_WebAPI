namespace Patronage2018.Application.FizzBuzz.Queries
{
    public class GetFizzBuzzQueryResult
    {
        public GetFizzBuzzQueryResult(int statusCode, string result)
        {
            StatusCode = statusCode;
            if (statusCode != 400)
            {
                Result = result;
            }
            else
            {
                Error = result;
            }
        }

        public int StatusCode { get; set; }

        public string Error { get; set; }

        public string Result { get; set; }
    }
}
