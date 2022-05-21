using FluentValidation.AspNetCore;
using JWT.Business.DependenciesContainers.MicrosoftIoc;
using JWT.Business.StringInfos;
using JWT.WebApi.CustomFilters;
using JWT.WebApi.Mapping.AutoMapperProfile;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;//HTTPS false
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = JwtInfo.Issuer,
        ValidAudience = JwtInfo.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(JwtInfo.SecurityKey)),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero //if server works another timeline it makes zero it
    };
});

builder.Services.AddControllers().AddFluentValidation();

builder.Services.AddDependencies();
builder.Services.AddScoped(typeof(ValidId<>));

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler("/Error");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
