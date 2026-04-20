using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PromartStore.API.Data;
using PromartStore.API.Services;

var builder = WebApplication.CreateBuilder(args);

// -- CORS ---------------------------------------------------------------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
        policy.WithOrigins(
                  "http://localhost:5173",
                  "http://localhost:5174",
                  "http://localhost:4173"   // vite preview
              )
              .AllowAnyHeader()
              .AllowAnyMethod());
});

// -- Database (InMemory) -------------------------------------------------------
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("PromartStoreDb"));

// -- JWT Authentication --------------------------------------------------------
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"]!;

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer           = true,
        ValidateAudience         = true,
        ValidateLifetime         = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer              = jwtSettings["Issuer"],
        ValidAudience            = jwtSettings["Audience"],
        IssuerSigningKey         = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});

builder.Services.AddAuthorization();
builder.Services.AddControllers();

// -- DI Services ---------------------------------------------------------------
builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();

// -- Seed Data -----------------------------------------------------------------
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    DbSeeder.Seed(db);
}

// -- Middleware Pipeline -------------------------------------------------------
app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
