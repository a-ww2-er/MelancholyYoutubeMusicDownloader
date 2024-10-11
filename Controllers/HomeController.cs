using Microsoft.AspNetCore.Mvc;
using System;
using MelancholyYoutubeMusicDownloader.Models;

public class HomeController : Controller
{
    public IActionResult Index()
    {
         UrlModel model = new UrlModel();
         model.Urls = "dewferf";
        Console.WriteLine(model.Urls);
        return View();
    }
//   public IActionResult OnPost(UrlModel model)
// {
//     Console.Write("calling");
//     Console.WriteLine(model.Urls);
    // [HttpPost]
//     // Process the URLs here
//     return Content("hello"); // Return a response
// }

    [HttpPost]
    public IActionResult ProcessUrls(UrlModel model)
    {
        Console.WriteLine(model);
        ViewData["res"]=model.Urls;
        return View();
    
        // return RedirectToAction("Index"); 
    }
}