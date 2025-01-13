using Microsoft.AspNetCore.Mvc;
using System;
using MelancholyYoutubeMusicDownloader.Models;

public class HomeController : Controller
{
    public IActionResult Index()
    {
    
        return View();
    }


}