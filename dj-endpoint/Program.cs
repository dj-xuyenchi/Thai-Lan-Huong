using dj_actionlayer.DAO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

var secretKeyBytes = Encoding.UTF8.GetBytes(Settings.SecretKey());
// Tạo xác thực
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        //Tu Cap Token
        ValidateIssuer = false,
        ValidateAudience = false,

        //Ky vao Token
        ValidateIssuerSigningKey = false,
        IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),
        ClockSkew = TimeSpan.Zero
    };
});
// Tạo phân quyền cho API
builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("ADMINANDMEMBER", policy =>
        policy.RequireClaim(
             ClaimTypes.Role, new string[] { "ADMIN", "MEMBER","MAINTAIN" }
            )
    );
    option.AddPolicy("MEMBER", policy => policy.RequireClaim(
        ClaimTypes.Role, "MEMBER"
        ));
    option.AddPolicy("ADMINMAINTAIN", policy => policy.RequireClaim(
       ClaimTypes.Role, new string[] { "ADMIN", "MAINTAIN" }
        ));
    option.AddPolicy("ADMIN", policy => policy.RequireClaim(
     ClaimTypes.Role, "ADMIN"
     ));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://dj-xuyenchi.edu.vn", "https://api.dj-xuyenchi.edu.vn").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                      });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(MyAllowSpecificOrigins);
}
app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
