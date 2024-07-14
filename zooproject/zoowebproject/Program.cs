using Infrastructure.Email;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<IEmail, dbEmail>();

/*builder.Services.AddScoped<OrderManager>();
builder.Services.AddScoped<IOrderDAL, OrderRepo>();
builder.Services.AddScoped<ClothingManager>();
builder.Services.AddScoped<IClothingDAL, ClothingRepo>();
builder.Services.AddScoped<JewelryManager>();
builder.Services.AddScoped<IJewelryDAL, JewelryRepo>();
builder.Services.AddScoped<UserManager>();
builder.Services.AddScoped<IUserDAL, UserRepo>();
builder.Services.AddScoped<ContactManager>();
builder.Services.AddScoped<IContactDAL, ContactRepo>();
*/
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => {
    options.LoginPath = new PathString("/Login");
    options.AccessDeniedPath = new PathString("/AccessDenied");
}
);

/*builder.Services.AddDistributedMemoryCache();*/
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(15);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
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

app.UseSession();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
