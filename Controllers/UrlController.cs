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
         string formattedString = userUrls.Urls.Replace("https",",https");
        string[] allLinks = formattedString.Split(',');
      List<string> downloadedFiles = new List<string>(); 
      List<string> failedFiles = new List<string>(); 
        foreach (var url in allLinks)
        {
            if(url != ""){
            try
            {
                
        
            var video = await youtube.Videos.GetAsync(url);
            if(video != null){
            var title = video.Title;
            var streamInfo = await youtube.Videos.Streams.GetManifestAsync(video.Id);
            var stream = streamInfo.GetAudioOnlyStreams().GetWithHighestBitrate();
            
          string cleanedFilename = title.Replace("\"", "").Replace("/", "-").Replace(":", "-").Replace("*", "").Replace("?", "").Replace("<", "").Replace(">", "").Replace("|", "").Replace("\\", "-").Replace("@", "");
           await youtube.Videos.Streams.DownloadAsync(stream, @"musics\" + cleanedFilename + ".mp3");
             downloadedFiles.Add(cleanedFilename);
            }else{
                Console.WriteLine(url + " " + "is not a valid url");
                failedFiles.Add(url);
              }
            }
            catch (System.Exception)
            {
                
                Console.WriteLine(url + " " + "could not be saved");
                 failedFiles.Add(url);
            }
            
            }}
       string downloadedFilesString = string.Join(", ", downloadedFiles); 
       string failedFilesString = string.Join(", ", failedFiles); 
int downloadedFilesCount = downloadedFiles.Count; 

 var returnObj = new { 
    message="Musics download request completed!",
    success = true, 
    filesDownloadedCount = downloadedFilesCount, 
    filesDownloaded = downloadedFilesString ,
    failedToDownload =failedFilesString
};

return Ok(returnObj);
    }
}