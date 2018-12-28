using MediatR;

namespace Patronage2018.Application.FizzBuzz.Queries
{
    public class GetFizzBuzzQuery : IRequest<GetFizzBuzzQueryResult>
    {
        public int Number { get; set; }
    }
}
