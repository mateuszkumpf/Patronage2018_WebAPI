namespace Patronage2018.Application.Abracadabra.Queries
{
    public class GetAbracadabraResult
    {
        public GetAbracadabraResult(bool success, string result)
        {
            if (success)
            {
                IsSuccess = success;
                Result = result;
            }
            else
            {
                IsSuccess = success;
                Error = result;
            }
        }

        public bool IsSuccess { get; set; }

        public string Error { get; set; }

        public string Result { get; set; }
    }
}
