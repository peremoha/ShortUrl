using FakeItEasy;
using Inforce.Interfaces;
using Inforce.Models;
using Inforce.Services;

namespace Inforce.Test
{
    public class Tests
    {
        private IUrlService _urlService;
        private List<ShortUrl> urls;

        [SetUp]
        public void Setup()
        {
            urls = new List<ShortUrl>();
            var repository = new Fake<IUrlRepository>();
            repository.CallsTo(x => x.AddShortUrl(A<ShortUrl>._)).Invokes((ShortUrl url) => urls.Add(url));
            _urlService = new ShortUrlService(repository.FakedObject);
        }

        [Test]
        public async Task Test1()
        {
            var url = "http//Created";
            var createdBy = "some user";

            await _urlService.AddShortUrl(url, createdBy);
            var testUrl = urls.FirstOrDefault(x => x.CreatedBy == createdBy);

            Assert.NotNull(testUrl);
            Assert.That(testUrl.CreatedBy, Is.EqualTo(createdBy));
        }
    }
}