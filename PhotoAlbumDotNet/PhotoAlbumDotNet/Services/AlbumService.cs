using System.Net.Http.Json;

namespace PhotoAlbumDotNet.Services;

public interface IAlbumService
{
    Task<Album[]> Get(int albumId);
}

public class AlbumService(HttpClient httpClient) : IAlbumService
{
    public async Task<Album[]> Get(int albumId)
    {
        var response = await httpClient.GetFromJsonAsync<Album[]>($"photos?albumId={albumId}");
        return response ?? throw new ArgumentNullException();
    }
}

public record Album(int AlbumId, int Id, string Title, string Url, string ThumbnailUrl);