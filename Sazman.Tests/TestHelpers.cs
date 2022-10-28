using FluentAssertions;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Sazman.Tests
{
    public static class TestHelpers
    {
        private const string _jsonMediaType = "application/json";
        private static readonly JsonSerializerOptions _jsonSerializerOptions = new()
        {
            PropertyNameCaseInsensitive = true,
        };

        public static async Task AssertResponseWithContentAsync<T>(
            HttpResponseMessage response, HttpStatusCode expectedStatusCode,
            T expectedContent)
        {
            await AssertCommonResponsePart(response, expectedStatusCode);
            Assert.Equal(_jsonMediaType, response.Content.Headers.ContentType?.MediaType);
            //Assert.Equal<T?>(expectedContent, await JsonSerializer.DeserializeAsync<T?>(
            //    await response.Content.ReadAsStreamAsync(), _jsonSerializerOptions));
            expectedContent.Should().BeEquivalentTo(await JsonSerializer.DeserializeAsync<T?>(
                await response.Content.ReadAsStreamAsync(), _jsonSerializerOptions));
        }

        public static async Task AssertCommonResponsePart(
            HttpResponseMessage response, HttpStatusCode expectedStatusCode)
        {
            response.StatusCode.Should().Be(expectedStatusCode);
        }

        public static StringContent GetJsonStringContent<T>(T model) =>
            new(JsonSerializer.Serialize(model), Encoding.UTF8, _jsonMediaType);
    }
}
