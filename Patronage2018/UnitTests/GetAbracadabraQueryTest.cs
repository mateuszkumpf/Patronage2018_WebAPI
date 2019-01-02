using MediatR;
using Moq;
using NUnit.Framework;
using Patronage2018.Application.Abracadabra.Queries;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using UnitTests;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetAbracadabraTest()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(f => f.Send(It.IsAny<GetAbracadabraQuery>(), It.IsAny<CancellationToken>()))
                        .Returns((GetAbracadabraQuery getAbracadabraQuery, CancellationToken cancellationToken) => MockHandle(getAbracadabraQuery, cancellationToken));
            var result = await mockMediator.Object.Send(new GetAbracadabraQuery());

            Assert.AreEqual(result.Result, "Czary mary");
        }

        private async Task<GetAbracadabraResult> MockHandle(GetAbracadabraQuery request, CancellationToken cancellationToken)
        {
            var mockHttpClient = new MockHttpClient();
            try
            {
                var httpClient = mockHttpClient.GetMockClient();

                var response = await httpClient.GetAsync("http://test.com/mockio");

                return new GetAbracadabraResult(true, await response.Content.ReadAsStringAsync());
            }
            catch (HttpRequestException)
            {
                return new GetAbracadabraResult(false, "External service is unavailable.");
            }
        }
    }
}