using Corbae.BLL.Implementations;
using Corbae.BLL.Interfaces;
using Corbae.DAL;
using Corbae.Mappings;
using Corbae.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ApiDbContext>(options => options.UseNpgsql(connection));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AppMappingProfile));

builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ICartService, CartService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IProductService, ProductService>();

var app = builder.Build();

app.UseDBInitialize();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCustomExceptionHandler();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();


