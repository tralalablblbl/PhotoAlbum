// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using PhotoAlbumDotNet.Services;

var firstArgument = args.FirstOrDefault();
if (!int.TryParse(firstArgument, out var albumId))
{
    Console.WriteLine("First argument should be valid album id(number)");
    return;
}

var services = new ServiceCollection();
services.AddHttpClient<IAlbumService, AlbumService>(client =>
{
    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
});
var serviceProvider = services.BuildServiceProvider();
var service = serviceProvider.GetRequiredService<IAlbumService>();
var albums = await service.Get(albumId);
if (albums.Length == 0)
{
    Console.WriteLine("No photos.");
}
else
{
    var result = string.Join(" ", albums.Select(a => $"[{a.Id}] {a.Title}"));
    Console.WriteLine(result);
}

public partial class Program { }