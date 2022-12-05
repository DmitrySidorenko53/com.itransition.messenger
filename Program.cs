using com.itransition.messenger.Models.Data;
using com.itransition.messenger.Services;
using com.itransition.messenger.Services.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("LocalConnection");
builder.Services.AddDbContext<MessengerContext>(
    options => options.UseSqlServer(connection));
builder.Services.AddSession();
builder.Services.AddTransient<IUserService, UserServiceImpl>();
builder.Services.AddTransient<IMessageService, MessageServiceImpl>();
builder.Services.AddTransient<IMessageToUsersService, MessageToUsersServiceImpl>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => {
    endpoints.MapControllerRoute(
        name: "home",
        pattern: "{controller=Messenger}/{action=Home}");
});

app.UseEndpoints(endpoints => {
    endpoints.MapControllerRoute(
        name: "login",
        pattern: "{controller=Welcome}/{action=Login}");
});
app.Run();