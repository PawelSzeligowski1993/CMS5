using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddScoped<IUserRepository, UserRepository>();




builder.Services.AddControllers(option => {
    //option.ReturnHttpNotAcceptable=true;
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//ApplicationDBContext
builder.Services.AddEntityFrameworkNpgsql()
            .AddDbContext<ApplicationDBContext>(opt =>
            opt.UseNpgsql(builder.Configuration.GetConnectionString("SampleDBConnection")));

var MyAlloweSpecificOrgins = "_myAllowSpecificOrgins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAlloweSpecificOrgins,
        policy =>
        {
            //policy.WithOrigins("https://localhost:7110/")
            policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();

        });
});






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAlloweSpecificOrgins);

app.UseAuthorization();

app.MapControllers();



app.Run();

