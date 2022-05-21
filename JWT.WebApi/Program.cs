using FluentValidation.AspNetCore;
using JWT.Business.DependenciesContainers.MicrosoftIoc;
using JWT.WebApi.CustomFilters;
using JWT.WebApi.Mapping.AutoMapperProfile;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

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

app.UseAuthorization();

app.MapControllers();

app.Run();
