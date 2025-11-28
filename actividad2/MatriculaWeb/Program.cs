using WebMatricula.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios DI
builder.Services.AddControllersWithViews();  // Soporte para MVC
builder.Services.AddSingleton<JsonFileService>();  // Servicio JSON como singleton

var app = builder.Build();

// Configuración del pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");  // Manejo de errores en producción
    app.UseHsts();  // HTTP Strict Transport Security
}

app.UseHttpsRedirection();    // Redirección HTTPS
app.UseStaticFiles();         // Archivos estáticos (CSS, JS, imágenes)
app.UseRouting();             // Sistema de rutas
app.UseAuthorization();       // Autorización (si se usa)

// Configuración de ruta por defecto
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Matricula}/{action=Index}/{id?}");  // Matricula/Index como home

app.Run();  // Inicia la aplicación