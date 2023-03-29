using POC.GoldenRaspberryAwards.API.Domain.Entities;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace POC.GoldenRaspberryAwards.IntegrationTests
{
    public class GoldenRaspberryAwardsIntegrationTests
    {
        [Fact]
        public async Task GetMovies_ReturnsOkStatusCode()
        {
            await using var application = new GoldenRaspberryAwardsApplication();

            var url = "api/movies";

            var client = application.CreateClient();

            var response = await client.GetAsync(url);
            var movies = await client.GetFromJsonAsync<List<Movie>>(url);

            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType!.ToString());
        }

        [Fact]
        public async Task GetAwardIntervals_ReturnsOkStatusCode()
        {
            await using var application = new GoldenRaspberryAwardsApplication();

            var url = "api/awardintervals";

            var client = application.CreateClient();

            var response = await client.GetAsync(url);
            var awardIntervals = await client.GetFromJsonAsync<AwardIntervals>(url);

            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType!.ToString());
        }


        [Fact]
        public async Task UploadCsv_WhenValidFile_ReturnsOkStatusCodeAndMoviesList()
        {
            var response = await UploadCsv();

            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType!.ToString());
        }

        private async Task<HttpResponseMessage> UploadCsv()
        {
            await using var application = new GoldenRaspberryAwardsApplication();

            var url = "api/movies";

            var client = application.CreateClient();

            var fileContent = @"year;title;studios;producers;winner
                                2001;Movie 1;Studio 1;Producer 1;yes
                                2010;Movie 2;Studio 2;Producer 2;no";

            var content = new MultipartFormDataContent();

            var fileContentBytes = Encoding.UTF8.GetBytes(fileContent);

            var file = new ByteArrayContent(fileContentBytes);
            file.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "file",
                FileName = "movies.csv"
            };
            content.Add(file);

            var response = await client.PostAsync(url, content);

            return response;
        }
    }
}