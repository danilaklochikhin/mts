using mts.Service;
using mts.Domain.Repositories.EntityFramework;
using mts.Domain.Repositories.Abstract;
using mts.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ��������� ������������ � �������������
builder.Services.AddControllersWithViews();
// ����������� ����������� �� ��� ������
builder.Services.AddTransient<ITarifsBaseRepository,EFTarifsBaseRepository>();
builder.Services.AddTransient<ICitysBaseRepository, EFCitysBaseRepository>();
builder.Services.AddTransient<DataManager>();
//���������� �������� ��
builder.Services.AddDbContext<DBContext>(x => x.UseSqlServer(Config.ConnectionString));
// ����������� Identity �������
builder.Services.AddIdentity<IdentityUser,IdentityRole>(opts =>
{
    opts.User.RequireUniqueEmail = true;
    opts.Password.RequiredLength = 6;
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireDigit = false;
    opts.Password.RequireLowercase = false;
    opts.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<DBContext>().AddDefaultTokenProviders();
// ����������� authentication cookie
builder.Services.ConfigureApplicationCookie(opts =>
{
    opts.Cookie.Name = "mtsAuth";
    opts.Cookie.HttpOnly = true;
    opts.LoginPath = "/account/login";
    opts.AccessDeniedPath = "/account/accessdenied";
    opts.SlidingExpiration = true;
});

// ����������� ������� �� appsetings.json
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

//����������� ����������� � ��������������
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

//app.MapRazorPages();
// ����������� ���������
app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
    });

app.Run();
