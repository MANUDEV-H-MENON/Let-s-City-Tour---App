using CityInfo.API.DbContexts;
using CityInfo.API.Responses;
using CityInfo.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;   // Content negotiation: return Not acceptable if asks in xml, or another not supported addition format
}).AddNewtonsoftJson()  // To patch - partially update resource - Josn patch and NewtonsoftJson
  .AddXmlDataContractSerializerFormatters(); // Content negotiation: supports additional formatter like xml

// Add Problem details to modify error information - could not do in.Net 6 , suppports with .Net 8
//builder.Services.AddProblemDetails(
//    options =>
//    {
//        options.CustomizeProblemDetails = ctx =>
//        {
//            ctx.Problemdetails.Extesnions.Add("additionalInfo", "AdditionalInfo example")
//        };
//    });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#if DEBUG
builder.Services.AddTransient<IMailService, LocalMailService>();  // registering local service
#else
builder.Services.AddTransient<IMailService, CloudMailService>();  // registering cloud service
#endif

builder.Services.AddSingleton<CitiesDataStore>();

//builder.Services.AddDbContext<CityInfoContext>(dbContextOptions
//    => dbContextOptions.UseSqlite(builder.Configuration["ConnectionString:CityInfoDBConnectionString"]));  // sqllite

builder.Services.AddDbContext<CityInfoContext>(dbContextOptions
    => dbContextOptions.UseSqlServer(builder.Configuration["ConnectionString:CityInfoDBConnectionString"]));  //sql server

builder.Services.AddScoped<ICityInfoRepository, CityInfoRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(option => option.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Authentication:Issuer"],
        ValidAudience = builder.Configuration["Authentication:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(builder.Configuration["Authentication:SecretForKey"])),
    });

builder.Services.AddAuthorization(options =>
options.AddPolicy("MustBeFromThrissur", policy =>
{
    policy.RequireAuthenticatedUser();
    policy.RequireClaim("city", "Thrissur");

}));

var app = builder.Build();


// Exception handler for production environment where stack trace are not displayed.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler();
//}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();   // Attributr based routing - use this inline middle wire


//Sample to use one line Run command - Inline middle wire
//app.Run(async (context) => { await context.Response.WriteAsync("Hello World! "); });

app.Run();
