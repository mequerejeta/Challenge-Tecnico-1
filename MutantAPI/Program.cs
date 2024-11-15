using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MutantDetection.Data;
using MutantDetection.Models;
using MutantDetection.Seeders;
using MutantDetection.Services;
using MutantDetection.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MutantDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IMutantService, MutantService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MutantDbContext>();
    dbContext.Database.Migrate();
    DataSeeder.SeedInitialData(dbContext);
}
app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/mutant", async (IMutantService service, MutantDbContext dbContext, [FromBody] string[] dna) =>
{
    if (service.IsMutant(dna))
    {
        dbContext.DnaRecords.Add(new DnaRecord { Dna = string.Join(",", dna), IsMutant = true });
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }

    dbContext.DnaRecords.Add(new DnaRecord { Dna = string.Join(",", dna), IsMutant = false });
    await dbContext.SaveChangesAsync();
    return Results.StatusCode(403);
});

app.MapGet("/stats", async (MutantDbContext dbContext) =>
{
    var mutantCount = await dbContext.DnaRecords.CountAsync(d => d.IsMutant);
    var humanCount = await dbContext.DnaRecords.CountAsync();
    var ratio = humanCount > 0 ? (double)mutantCount / humanCount : 0;

    return Results.Json(new
    {
        count_mutant_dna = mutantCount,
        count_human_dna = humanCount,
        ratio
    });
});

app.Run();
