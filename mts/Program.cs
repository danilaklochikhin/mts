using mts.Service;
using mts.Domain.Repositories.EntityFramework;
using mts.Domain.Repositories.Abstract;
using mts.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// поддержка контроллеров и представлений
builder.Services.AddControllersWithViews();
// подключение функционала БД как сервис
builder.Services.AddTransient<ITarifsBaseRepository,EFTarifsBaseRepository>();
builder.Services.AddTransient<ICitysBaseRepository, EFCitysBaseRepository>();
builder.Services.AddTransient<DataManager>();
//подключаем контекст БД
builder.Services.AddDbContext<DBContext>(x => x.UseSqlServer(Config.ConnectionString));
// Настраиваем Identity систему
builder.Services.AddIdentity<IdentityUser,IdentityRole>(opts =>
{
    opts.User.RequireUniqueEmail = true;
    opts.Password.RequiredLength = 6;
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireDigit = false;
    opts.Password.RequireLowercase = false;
    opts.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<DBContext>().AddDefaultTokenProviders();
// настраиваем authentication cookie
builder.Services.ConfigureApplicationCookie(opts =>
{
    opts.Cookie.Name = "mtsAuth";
    opts.Cookie.HttpOnly = true;
    opts.LoginPath = "/account/login";
    opts.AccessDeniedPath = "/account/accessdenied";
    opts.SlidingExpiration = true;
});

// Подключение конфига из appsetings.json
builder.Configuration.Bind("Project", new Config());



//Configuration.Bind("Project", new Config());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//Подключение авторизации и аутентификации
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

//app.MapRazorPages();
// Регистрация маршрутов
app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
    });

app.Run();
