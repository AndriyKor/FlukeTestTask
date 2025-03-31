using Fluke.API.Configuration;
using Fluke.API.Repository;
using Fluke.API.Services;
using Fluke.Domain.Models.Options;

var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "_flukeAllowOrigins",
        corsPolicyBuilder =>
        {
            corsPolicyBuilder
                .WithOrigins("http://localhost:5000")
                .AllowAnyMethod()
                .AllowAnyHeader();
        }
    );
});

builder.Services.Configure<EONETConfiguration>(builder.Configuration.GetSection(EONETConfiguration.EONET));

builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors("_flukeAllowOrigins");

app.UseAuthorization();
app.MapControllers();

// Custom api mapper
app.MapApiEndpoints();

app.Run();