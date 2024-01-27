using SignalR_IHubContext_Example.Business;
using SignalR_IHubContext_Example.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt => opt.AddDefaultPolicy(policy =>
          policy.AllowAnyMethod()
          .AllowAnyHeader()
          .AllowCredentials()
          .SetIsOriginAllowed(origin => true)
          ));

builder.Services.AddTransient<MessageBusinnes>();
builder.Services.AddSingleton<MessageHub>();

builder.Services.AddSignalR();

builder.Services.AddControllersWithViews();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
   
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapHub<MessageHub>("/messagehub");


app.Run();
