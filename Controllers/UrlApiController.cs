using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using System;
using System.Collections.Generic;
using MelancholyYoutubeMusicDownloader.Models;

[Route("api/[controller]")]
public class UrlApiController : ControllerBase
{
    // [HttpGet]
    // public IActionResult Index()
    // {
    // }

    [HttpPost("url-upload")]
    public async Task<IActionResult> ProcessUserUrls([FromBody] UrlModel userUrls)
    {
        var youtube = new YoutubeClient();
        string formattedString = userUrls.Urls.Replace("https", ",https");
        string[] allLinks = formattedString.Split(',', StringSplitOptions.RemoveEmptyEntries);
        List<string> downloadedFiles = new List<string>();
        List<string> failedFiles = new List<string>();

        foreach (var url in allLinks)
        {
            try
            {
                var video = await youtube.Videos.GetAsync(url);
                if (video != null)
                {
                    var title = video.Title;
                    var streamInfo = await youtube.Videos.Streams.GetManifestAsync(video.Id);
                    var stream = streamInfo.GetAudioOnlyStreams().GetWithHighestBitrate();

                    string cleanedFilename = CleanFileName(title);
                    await youtube.Videos.Streams.DownloadAsync(stream, $"musics/{cleanedFilename}.mp3");
                    downloadedFiles.Add(cleanedFilename);
                }
                else
                {
                    Console.WriteLine($"{url} is not a valid url");
                    failedFiles.Add(url);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{url} could not be saved: {ex.Message}");
                failedFiles.Add(url);
            }
        }

        string downloadedFilesString = string.Join(", ", downloadedFiles);
        string failedFilesString = string.Join(", ", failedFiles);
        int downloadedFilesCount = downloadedFiles.Count;

        var returnObj = new
        {
            message = "Musics download request completed!",
            success = true,
            filesDownloadedCount = downloadedFilesCount,
            filesDownloaded = downloadedFilesString,
            failedToDownload = failedFilesString
        };

        return Ok(returnObj);
    }

    private string CleanFileName(string fileName)
    {
        return fileName
            .Replace("\"", "")
            .Replace("/", "-")
            .Replace(":", "-")
            .Replace("*", "")
            .Replace("?", "")
            .Replace("<", "")
            .Replace(">", "")
            .Replace("|", "")
            .Replace("\\", "-")
            .Replace("@", "");
    }
}