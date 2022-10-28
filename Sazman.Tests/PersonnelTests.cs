using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Sazman.Tests.TestEntities;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Sazman.Tests
{
    public class PersonnelTests
    {
        private readonly HttpClient _httpClient;

        public PersonnelTests()
        {
            _httpClient = new TestClientProvider().Client;
        }

        [Fact]
        public async Task GivenARequest_WhenCallingGetAllPersonnel_ThenTheAPIReturnsExpectedREsponse()
        {
            var expectedStatusCode = HttpStatusCode.OK;
            var expectedContent = new[]
            {
                new Personnel
                {
                    Id = new Guid("7D9A3581-FAC0-4CF8-AE72-9A82DA0BAA82"),
                    Nam = "Rocky",
                    NameXanevadegi = "Balboa"
                },
                new Personnel
                {
                    Id = new Guid("8DDA7930-C5AE-42BF-8B4A-ECBB6726767B"),
                    Nam = "Sherlock",
                    NameXanevadegi = "Holmes"
                },
                new Personnel
                {
                    Id = new Guid("9A1C650E-DF1F-4A5B-856D-FB963E0E9D6C"),
                    Nam = "Harry",
                    NameXanevadegi = "Potter"
                }
        };

            var response = await _httpClient.GetAsync("personnel");
            await TestHelpers.AssertResponseWithContentAsync(response, expectedStatusCode, expectedContent);
        }

        [Fact]
        public async Task GivenARequest_WhenCallingGetPersonnelById_ThenTheAPIReturnsExpectedResponse()
        {
            var expectedStatusCode = HttpStatusCode.OK;
            var expectedContent = new Personnel
            {
                Id = new Guid("7D9A3581-FAC0-4CF8-AE72-9A82DA0BAA82"),
                Nam = "Rocky",
                NameXanevadegi = "Balboa"
            };

            var response = await _httpClient.GetAsync($"personnel/{expectedContent.Id}");
            await TestHelpers.AssertResponseWithContentAsync(response, expectedStatusCode, expectedContent);
        }

        [Fact]
        public async Task GivenARequest_WhenCallingCreatePersonnel_ThenTheAPIReturnsExpectedResponseAndAddsPersonnel()
        {
            var expectedStatusCode = HttpStatusCode.Created;
            var personnelToCreate = new Personnel
            {
                Id = new Guid("7D9A3581-FAC0-4CF8-AE72-9A82DA0BAA82"),
                Nam = "Rocky",
                NameXanevadegi = "Balboa"
            };

            var response = await _httpClient.PostAsync("personnel",
                TestHelpers.GetJsonStringContent(personnelToCreate));
            await TestHelpers.AssertResponseWithContentAsync(response, expectedStatusCode, personnelToCreate);
        }

        [Fact]
        public async Task GivenARequest_WhenCallingUpdatePersonnel_ThenTheAPIReturnsExpectedResponseAndUpdatesPersonnel()
        {
            var expectedStatusCode = HttpStatusCode.OK;
            var personnelToUpdate = new Personnel
            {
                Id = new Guid("9A1C650E-DF1F-4A5B-856D-FB963E0E9D6C"),
                Nam = "Harry - Updated",
                NameXanevadegi = "Potter - Updated"
            };

            var response = await _httpClient.PutAsync($"personnel/{personnelToUpdate.Id}", TestHelpers.GetJsonStringContent(personnelToUpdate));
            await TestHelpers.AssertCommonResponsePart(response, expectedStatusCode);
        }

        [Fact]
        public async Task GivenARequest_WhenCallingDeletePersonnel_ThenTheAPIReturnsExpectedResponseAdnDeletesPersonnel()
        {
            var expectedStatusCode = HttpStatusCode.OK;
            var response = await _httpClient.DeleteAsync("personnel/87520BF0-974B-44D4-8837-D7C35DB41813");
            await TestHelpers.AssertCommonResponsePart(response, expectedStatusCode);
        }
    }
}