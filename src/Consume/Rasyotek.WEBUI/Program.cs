using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rasyotek.Business.Abstract;
using Rasyotek.Business.Concrete;
using Rasyotek.Business.ValidationRules;
using Rasyotek.DataAccess.Concrete;
using Rasyotek.DataAccess.Repository;
using Rasyotek.Entity;
using Rasyotek.WEBUI.ApiCallsServices.Abstract;
using Rasyotek.WEBUI.ApiCallsServices.Concrete;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddFluentValidation();
//builder.Services.AddControllers()
//    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PersonelValidator>());

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PersonelContext>();


builder.Services.AddHttpClient<IUniversityService, UniversityService>();
builder.Services.AddScoped<IRepository<Personel>, Repository<Personel>>();
builder.Services.AddScoped<IPersonelService, PersonelService>();
builder.Services.AddAutoMapper(typeof(Rasyotek.Business.Map.AutoMapper));



// Add services to the container.






var app = builder.Build();


app.UseCors("AllowAll"); // CORS politikasýný kullanma






// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Personel}/{action=Index}/{id?}");

app.Run();
