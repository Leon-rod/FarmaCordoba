using FarmaceuticaBack.Data.Contracts;
using FarmaceuticaBack.Data.Repositories;
using FarmaceuticaBack.Models;
using FarmaceuticaBack.Services.Contracts;
using FarmaceuticaBack.Services.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<FarmaceuticaContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString
("DefaultConnection")));

builder.Services.AddScoped<IMedicamentoRepository, MedicamentoRepository>();
builder.Services.AddScoped<IMedicamentoService, MedicamentoService>();
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<IEstablecimientoRepository, EstablecimientoRepository>();
builder.Services.AddScoped<IEstablecimientoService, EstablecimientoService>();

builder.Services.AddScoped<IInventarioRepository, InventarioRepository>();
builder.Services.AddScoped<IInventarioService, InventarioService>();

builder.Services.AddScoped<IInventarioRepository, InventarioRepository>();
builder.Services.AddScoped<IInventarioService, InventarioService>();

builder.Services.AddScoped<IMonodrogaRepository, MonodrogaRepository>();
builder.Services.AddScoped<IMonodrogaService, MonodrogaService>();

builder.Services.AddScoped<ILaboratorioRepository, LaboratorioRepository>();
builder.Services.AddScoped<ILaboratorioService, LaboratorioService>();

builder.Services.AddScoped<IPresentacionRepository, PresentacionRepository>();
builder.Services.AddScoped<IPresentacionService, PresentacionService>();

builder.Services.AddScoped<IMarcaRepository, MarcaRepository>();
builder.Services.AddScoped<IMarcaService, MarcaService>();

builder.Services.AddScoped<IDispensacionRepository, DispensacionRepository>();
builder.Services.AddScoped<IDispensacionService, DispensacionService>();

builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IPedidoService, PedidoService>();

builder.Services.AddScoped<IDetallePedidoRepository, DetallePedidoRepository>();
builder.Services.AddScoped<IDetallePedidoService, DetallePedidoService>();

builder.Services.AddScoped<IFacturaRepository, FacturaRepository>();
builder.Services.AddScoped<IFacturaService, FacturaService>();

builder.Services.AddScoped<ITotalesFacturadosVendedoresRepository, TotalesFacturadosVendedoresRepository>();
builder.Services.AddScoped<ITotalesFacturadosVendedoresService, TotalesFacturadosVendedoresService>();

builder.Services.AddScoped<IReporteMensualObraSocialRepository, ReporteMensualObraSocialRepository>();
builder.Services.AddScoped<IReporteMensualObraSocialService, ReporteMensualObraSocialService>();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.AddScoped<IPersonalEstablecimientoRepository, PersonalEstablecimientoRepository>();
builder.Services.AddScoped<IPersonalEstablecimientoService, PersonalEstablecimientoService>();

builder.Services.AddScoped<ILogisticaRepository, LogisticaRepository>();
builder.Services.AddScoped<ILogisticaService, LogisticaService>();

builder.Services.AddScoped<ICoberturaRepository, CoberturaRepository>();
builder.Services.AddScoped<ICoberturaService, CoberturaService>();

builder.Services.AddScoped<IProveedorRepository, ProveedorRepository>();
builder.Services.AddScoped<IProveedorService, ProveedorService>();

builder.Services.AddScoped<IMedicamentoLoteRepository, MedicamentoLoteRepository>();
builder.Services.AddScoped<IMedicamentoLoteService, MedicamentoLoteService>();

builder.Services.AddScoped<IVTotalesFacturadosRepository, VTotalesFacturadosRepository>();
builder.Services.AddScoped<IVTotalesFacturadosService, VTotalesFacturadosService>();

builder.Services.AddScoped<IVReporteMensualOSRepository, VReporteMensualOSRepository>();
builder.Services.AddScoped<IVReporteMensualOSService, VReporteMensualOSService>();

builder.Services.AddScoped<IObraSocialRepository, ObraSocialRepository>();
builder.Services.AddScoped<IObraSocialService, ObraSocialService>();

builder.Services.AddScoped<ITipoPagoRepository, TipoPagoRepository>();
builder.Services.AddScoped<ITipoPagoService, TipoPagoService>();

builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<IGeneroService, GeneroService>();

builder.Services.AddScoped<ITipoDocumentoRepository, TipoDocumentoRepository>();
builder.Services.AddScoped<ITipoDocumentoService, TipoDocumentoService>();

builder.Services.AddScoped<IBarrioRepository, BarrioRepository>();
builder.Services.AddScoped<IBarrioService, BarrioService>();

builder.Services.AddScoped<ICargoRepository, CargoRepository>();
builder.Services.AddScoped<ICargoService, CargoService>();

builder.Services.AddScoped<IPersonalRepository, PersonalRepository>();
builder.Services.AddScoped<IPersonalService, PersonalService>();

builder.Services.AddScoped<ITipoProductoRepository, TipoProductoRepository>();
builder.Services.AddScoped<ITipoProductoService, TipoProductoService>();

builder.Services.AddScoped<IFacturaTipoPagoRepository, FacturaTipoPagoRepository>();
builder.Services.AddScoped<IFacturaTipoPagoService, FacturaTipoPagoService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowLocalhost");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
