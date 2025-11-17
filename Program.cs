using ecommerce_api.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddNewtonsoftJson(options => 
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);


var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "C:\\home\\site\\wwwroot\\App_Data\\Ecommerce.db" };
builder.Services.AddDbContext<ECommerceDbContext>(
    options => options.UseSqlite(connectionStringBuilder.ConnectionString));


var MyAllowSpecificOrigins = "AllowAll";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                     builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});


var app = builder.Build();


app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ECommerceDbContext>();
    db.Database.EnsureCreated();
   

    if (!db.Categories.Any())
    {
        db.Categories.AddRange(
            new Category { Name = "Clothing" },
            new Category { Name = "Home & Garden" },
            new Category { Name = "Sports & Outdoors" },
            new Category { Name = "Toys & Games" },
            new Category { Name = "Health & Beauty" },
            new Category { Name = "Automotive" },
            new Category { Name = "Music & Instruments" },
            new Category { Name = "Books" }
        );
        db.SaveChanges();
    }
}

app.Run();

// Test comment
