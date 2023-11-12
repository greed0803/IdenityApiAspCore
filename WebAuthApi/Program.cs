using Data.Context;
using IdentityProviderApi.Utils;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repo;
using Repo.Base;
using Service.Base;
using Service.Impl;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("dev", policy =>
    {
        policy
            .WithOrigins("*")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//UserRepository userRepository = ;
builder.Services.AddSingleton(new UserRepository(IdentityProviderContext.GetContext()));
builder.Services.AddSingleton(new ClientRepository(IdentityProviderContext.GetContext()));
builder.Services.AddSingleton(new PolicyRepository(IdentityProviderContext.GetContext()));
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IClientService, ClientService>();
builder.Services.AddSingleton<IPolicyService, PolicyService>();

//Auth
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
        options => {
            builder.Configuration.Bind("JwtSettings", options);
            options.TokenValidationParameters = new TokenValidationParameters()
            {

                ClockSkew = TokenValidationParameters.DefaultClockSkew,
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                ValidAudience = "https://localhost:44396/",
                ValidIssuer = "https://localhost:44396/",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettings.Get("Jwt:Key")))
            };
        
        })
    //.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
    //    options => builder.Configuration.Bind("CookieSettings", options))
    ;


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("dev");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
