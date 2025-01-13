using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddControllersWithViews();
// Add services to the container
// builder.Services.AddControllers();

var app = builder.Build();
app.UseStaticFiles();  
app.UsePathBase("/");  
//  app.UseStaticFiles(new StaticFileOptions  
//  {   
//      RequestPath = "/"  
//  });  
 app.UsePathBase("/");
app.MapGet("/", () => "Hello World!");

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
