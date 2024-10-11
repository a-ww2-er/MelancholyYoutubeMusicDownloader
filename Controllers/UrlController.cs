using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using System;
using MelancholyYoutubeMusicDownloader.Models;

// [ApiController]
[Route("api/[controller]")]
public class UrlsController : ControllerBase
{
    public IActionResult Index()
    {
        return Ok("Hello World");
    }

    [HttpPost]
    public async Task<IActionResult> ProcessUserUrls([FromBody] UrlModel userUrls)
    {
         var youtube = new YoutubeClient();
        string[] allLinks = userUrls.Urls.Split(',');
        foreach (var url in allLinks)
        {
            var video = await youtube.Videos.GetAsync(url);
            var title = video.Title;
            var streamInfo = await youtube.Videos.Streams.GetManifestAsync(video.Id);
            var stream = streamInfo.GetAudioOnlyStreams().GetWithHighestBitrate();
            
         
           await youtube.Videos.Streams.DownloadAsync(stream, @"vids\" + title + ".mp3");
        }
        Console.WriteLine(allLinks);
        Console.WriteLine(userUrls.Urls);
        return Ok("videos downloaded"); // Return an HTTP 200 OK response
    }
}