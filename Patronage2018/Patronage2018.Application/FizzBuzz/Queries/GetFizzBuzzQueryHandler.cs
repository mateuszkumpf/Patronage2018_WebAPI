using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Patronage2018.Application.FizzBuzz.Queries
{
    public class GetFizzBuzzQueryHandler : IRequestHandler<GetFizzBuzzQuery, GetFizzBuzzQueryResult>
    {
        public GetFizzBuzzQueryHandler()
        {

        }

        public async Task<GetFizzBuzzQueryResult> Handle(GetFizzBuzzQuery request, CancellationToken cancellationToken)
        {
            if (request.Number < 0 || request.Number > 1000)
            {
                return new GetFizzBuzzQueryResult(400, "Out of range (0-1000).");
            }

            if (request.Number % 2 == 0)
            {
                if (request.Number % 3 == 0)
                {
                    return new GetFizzBuzzQueryResult(200, "FizzBuzz");
                }

                return new GetFizzBuzzQueryResult(200, "Fizz");
            }
            else if (request.Number % 3 == 0)
            {
                return new GetFizzBuzzQueryResult(200, "Buzz");
            }
            else
            {
                return new GetFizzBuzzQueryResult(201, "Number is not devide by 2, 3 or both.");
            }
        }
    }
}
