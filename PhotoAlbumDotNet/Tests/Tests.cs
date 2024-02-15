using PhotoAlbumDotNet.Services;

namespace Tests;

public class Tests
{
    [Test]
    public async Task HasPhotos()
    {
        var client = new HttpClient();
        client.BaseAddress = client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
        var service = new AlbumService(client);

        var results = await service.Get(1);
        Assert.That(results, Is.Not.Empty);
    }

    [Test]
    public async Task NoPhotos()
    {
        var client = new HttpClient();
        client.BaseAddress = client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
        var service = new AlbumService(client);

        var results = await service.Get(9999);
        Assert.That(results, Is.Empty);
    }
}