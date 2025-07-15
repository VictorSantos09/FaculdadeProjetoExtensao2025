using Evento.Core.Configuration;
using Evento.UI.Components;
using Evento.UI.Generator;
using Microsoft.AspNetCore.Mvc;
using Radzen;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRadzenComponents();

// Add services to the container.
builder.Services.AddRazorComponents(options =>
    options.DetailedErrors = builder.Environment.IsDevelopment())
    .AddInteractiveServerComponents();


builder.Services.AddEventoCore(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapPost("/export/csv", (ExportRequest exportRequest) =>
{
    var csvData = CsvGenerator.Generate(exportRequest.Data, exportRequest.Columns);
    return Results.File(new UTF8Encoding().GetBytes(csvData), "text/csv", $"{exportRequest.FileName}.csv");
});

app.MapPost("/export/excel", (ExportRequest exportRequest) =>
{
    var result = ExcelGenerator.Generate(exportRequest.Data, exportRequest.Columns);
    return Results.File(result, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{exportRequest.FileName}.xlsx");
});

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
