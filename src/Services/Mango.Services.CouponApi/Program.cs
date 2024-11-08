using Mango.Framework.Service.Middleware;
using Mango.Services.CouponApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Base Services

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion
#region Advance Services

builder.Services.AddDbContext<CouponDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionString:DefaultConnection"));
    option.EnableSensitiveDataLogging(true);
});



#endregion


var app = builder.Build();


#region Base App
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
#endregion
#region Advance App

ApplyMigration();
app.UseMiddleware<ErrorHandlingMiddleware>();

#endregion

app.Run();



void ApplyMigration()
{
    using (var serviceScope = app.Services.CreateScope())
    {
        var dbContext = serviceScope.ServiceProvider.GetRequiredService<CouponDbContext>();
       if(dbContext.Database.GetPendingMigrations().Any())
           dbContext.Database.Migrate();
    }
}