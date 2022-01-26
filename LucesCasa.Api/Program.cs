using LucesCasa.Backend;
using LucesCasa.Common;
using LucesCasa.Models.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var appSettingsSection = builder.Configuration.GetSection("AppSettings");
ServiceConfiguration.Key = Encoding.ASCII.GetBytes(appSettingsSection.GetValue<string>("Key"));

// Add services to the container.
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
  {
      x.RequireHttpsMetadata = false;
      x.SaveToken = true;
      x.TokenValidationParameters = new TokenValidationParameters
      {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(ServiceConfiguration.Key),
          ValidateIssuer = false,
          ValidateAudience = false
      };
  });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LucesCasaContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("ProdConnection"));
});


// Configuration
ServiceConfiguration.ConnectionString = builder.Configuration.GetConnectionString("ProdConnection");
ServiceConfiguration.ModuleUser = builder.Configuration.GetSection("ModuleCredentials").GetValue<string>("ModuleUser");
ServiceConfiguration.ModulePassword = builder.Configuration.GetSection("ModuleCredentials").GetValue<string>("ModulePassword");

// DI
builder.Services.AddSingleton<IServiceConfiguration, ServiceConfiguration>();
builder.Services.AddTransient<BELuces>();
builder.Services.AddTransient<BEAuth>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
