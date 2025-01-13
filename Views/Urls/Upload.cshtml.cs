using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Threading.Tasks;

public class UrlProcessorModel : PageModel
{
    public void OnGet()
    {
        // This method is called when the page is loaded with a GET request
    }

    public async Task<IActionResult> OnPostAsync([FromForm] string url)
    {
        // Simulate processing time
        await Task.Delay(2000);

        // Simulated response data
        var responseData = new
        {
            message = "Musics download request completed!",
            success = true,
            filesDownloadedCount = 33,
            filesDownloaded = "juju - Wasted Summers (Official Music Video), Dominic Fike - Mama's Boy (Official Video), liana flores - rises the moon (official music video), dream, ivory - welcome and goodbye (TikTok ver alarm + slowed + reverb), Los Retros - Someone To Spend Time With, to build a home (a cover), Yaelokre - Harpy Hare 𓆱 (Illustrated Song), Liana Flores - Rises the moon  sub. español, Pinegrove - Need 2 (official lyric video), JAWNY - Honeypie (Official Video), Adore - Did I tell u that I miss u (Slowed) Anime MV w-lyrics, nimino - 'I Only Smoke When I Drink' (Official Music Video), dont get attached because it ends eventually right, Title Fight - Head In The Ceiling Fan, Riovaz- Prom Night (Official Music Video), SALES - renee, canciones que tal vez no sabías el nombre pero escuchaste #1 🎧, Laufey - From The Start (Official Music Video), Back To Strangers, ♡castle of dreams♡ - Portals (Oficial Audio), Ricky Montgomery - Mr Loverman (Official Lyric Video), Beach House - Myth ( cover by The Night Sun), Pavement- Harness Your Hopes (Official Music Video), The Walters - I Love You So [Official Video], Her, Vundabar - Alien Blues (Official Video), Beach Bunny - Prom Queen -- Traduccion al Español, Fly me to the moon 王OK, Current Joys - Blondie (Lyrics), A7S - Eyes On Me (Official Music Video), Cults - Always Forever, 13-year-old girl sentenced to maximum imprisonment for the beating death of Reggie Brown, RealestK - All You (Official Audio)",
            failedToDownload = ""
        };

        return new JsonResult(responseData);
    }
}

