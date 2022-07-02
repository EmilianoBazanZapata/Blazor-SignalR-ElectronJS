using BlazorApp1.Data;
using BlazorApp1.Hubs;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

//Comprimir el resultado de la ejecución de una acción puede ser una buena idea para acelerar la descarga y
//evitar un consumo innecesario de datos,
//y sobre todo en acciones donde se retorne una cantidad importante de información potencialmente comprimible,
//como texto plano, JSON o marcado HTML.
builder.Services.AddResponseCompression(options => {
    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/octect-stream"});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints => 
{
    endpoints.MapHub<ChatHub>("/chathub");
});

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
