using CH11;
Host.CreateDefaultBuilder(args)
  .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
  .Build().Run();