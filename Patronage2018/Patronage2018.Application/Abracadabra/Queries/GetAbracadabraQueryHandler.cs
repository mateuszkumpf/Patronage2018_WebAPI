using MediatR;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Patronage2018.Application.Abracadabra.Queries
{
    public class GetAbracadabraQueryHandler : IRequestHandler<GetAbracadabraQuery, GetAbracadabraResult>
    {
        public async Task<GetAbracadabraResult> Handle(GetAbracadabraQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync(@"http://www.mocky.io/v2/5c127054330000e133998f85");

                response.EnsureSuccessStatusCode();

                return new GetAbracadabraResult(true, await response.Content.ReadAsStringAsync());
            }
            catch (HttpRequestException)
            {
                return new GetAbracadabraResult(false, "Service is unavailable.");
            }
        }
    }
}
