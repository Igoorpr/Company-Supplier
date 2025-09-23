using COMPANY_SUPPLIER.APP.Config;
using COMPANY_SUPPLIER.MVC.ValidateFields.Config;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services 
builder.Services.AddCors(options =>
{
    options.AddPolicy("Cors", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()  
            .AllowAnyMethod(); 
    });
});
builder.Services.AddLocalization();
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();
builder.Services.AddAplication();
//Middleware
builder.Services.AddControllers(filters =>
{
    // Registro do filtro global (aplicado em todas as requisi��es)
    filters.Filters.Add<ConfigFilter>();
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen(c =>
{
    // Documenta��o do Swagger (Cabe�alho)
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SUPPLIER AND COMPANY APPLICATION",
        Description = "",
        Version = "v1"
    });

    var FileXML = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var PathXML = Path.Combine(AppContext.BaseDirectory, FileXML);
    c.IncludeXmlComments(PathXML);
    // Info Project .APP
    var PathXMLAux = Path.Combine(AppContext.BaseDirectory, "COMPANY_SUPPLIER.APP.xml");
    c.IncludeXmlComments(PathXMLAux);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
switch (app.Environment.EnvironmentName)
{
    case "Localhost":
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "COMPANY_SUPPLIER.MVC v1"));
        break;
    case "Development":
    case "Staging":
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/cs/swagger/v1/swagger.json", "COMPANY_SUPPLIER.MVC v1"));
        break;
    default:
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
        break;
}

app.UseCors("Cors");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
