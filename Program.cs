using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Duolingonator.Services;
using Duolingonator.Profiles;
using Duolingo.NET;

var odataEndpoint = "odata";
var version = "v2";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(version, new OpenApiInfo { Title = "Duolingonator", Version = version });

    c.DocInclusionPredicate((docName, apiDesc) =>
    {
        return apiDesc.RelativePath != null ? docName == odataEndpoint ?
            apiDesc.RelativePath.Contains(odataEndpoint) : !apiDesc.RelativePath.Contains(odataEndpoint) : false;
    });

    c.AddSecurityDefinition("API Key", new OpenApiSecurityScheme
    {
        Name = "x-api-key",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "API Key"
              },
              Name = "API Key",
              In = ParameterLocation.Header,
            },
            new List<string>()
          }
        });

});

builder.Services.AddHttpClient();
builder.Services.AddScoped<DuolingoService>();
builder.Services.AddScoped<DuolingoClient>();
builder.Services.AddAutoMapper(typeof(DuolingoProfile));

builder.Services.AddControllers()
    .AddOData(opt => opt.AddRouteComponents(odataEndpoint, GetGraphModel("Duolingo"))
            .Filter().Select().Expand().OrderBy().Count().SetMaxTop(999).SkipToken());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger(options =>
{
    options.SerializeAsV2 = true;
});

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint(
        string.Format("/swagger/{0}/swagger.json", version),
        "Duolingonator");
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();


static IEdmModel GetGraphModel(string name)
{
    ODataConventionModelBuilder builder = new();

    builder.EntitySet<Duolingonator.Models.Language>("Languages").EntityType.Namespace = name;

    builder.Namespace = name;

    return builder.GetEdmModel();
}

