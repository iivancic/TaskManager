using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using NLog;
using TaskManager.Context;
using TaskManager.Extensions;
using TaskManager.Repository;
using TaskManager.Service;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<AssignmentService>();

builder.Services.AddDbContext<AssignmentContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}
);

builder.Services.AddScoped<AssignmentRepository>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
    //will add middleware for using HSTS which adds the Strict-Transport-Security header
    app.UseHsts();

app.UseHttpsRedirection();

//Enables using static files for the request
app.UseStaticFiles();
app.UseRouting();

//UseForwardedHeaders will forward proxy headers to the current request. 
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");
app.UseAuthorization();

//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Logic before executing the next deleagete in the Use method");
//    await next.Invoke();
//    Console.WriteLine("Logic after executing the next deleagete in the Use method");
//});

//app.Map("/usingmapbranch", builder =>
//{
//    builder.Use(async (context, next) =>
//    {
//        Console.WriteLine("Map branch logic in the Use method before the next delegate");
//        await next.Invoke();
//        Console.WriteLine("Map branch logic in the Use method after the next delegate");
//    });
//    builder.Run(async context =>
//    {
//        Console.WriteLine("Map branch response to the client in the Run method");
//        await context.Response.WriteAsync("Hello from the map branch");
//    });
//});

//app.Run(async context =>
//{
//    Console.WriteLine("Writing the response to the client in the Run method");
//    await context.Response.WriteAsync("Hello from the middleware component.");
//});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
