namespace CH11
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (!env.IsDevelopment())
      {
        app.UseHsts();
      }

      app.UseRouting();
      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapGet("/", () => "Hello world");
      });
    }
  }
}