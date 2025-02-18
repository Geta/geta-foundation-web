<div align="center">
  <h1>Geta Packages Foundation Sample</h1>
  <p>A sample project which demonstrates how to use Geta Packages Foundation Sandbox as a submodule</p>
</div>

## 🏁 Getting Started

### Cloning the repo

```bash
    git clone https://github.com/Geta/geta-packages-foundation-sample.git
    cd geta-packages-foundation-sample
    git submodule update --init
```

### 🧪 Quick Start with Aspire (Recommended)
```bash
    cd sandbox/geta-packages-foundation-sandbox/src/Foundation.AppHost
    dotnet run 
```

### 🖥️ Standalone Setup
```bash
   cd sandbox/geta-packages-foundation-sandbox

   # Windows
   ./setup.cmd

   # Linux/macOS
   chmod +x setup.sh
   ./setup.sh

   cd ../../src/Sandbox.Web

   dotnet run
```

## ❓ How to Use as a Submodule
1. **Add submodule to your project:**
   ```bash
   cd yourProjectDirectory
   mkdir sandbox
   cd sandbox
   git submodule add https://github.com/Geta/geta-packages-foundation-sandbox.git
   ```
2. **Create web project (.net 9):**
   ```bash
   cd yourProjectDirectory
   mkdir src
   dotnet new web --name yourProjectName.Web --output src/yourProjectName.Web
   ```
3. **Add Foundation reference and modules importer**
   ```xml
    <!-- yourProjectName.Web.csproj -->
    <ItemGroup>
      <ProjectReference Include="..\..\sandbox\src\Foundation\Foundation.csproj" />
    </ItemGroup>
   
    <Import Project="..\..\sandbox\geta-packages-foundation-sandbox\src\Foundation\modules\ModulesInclude.proj"/>
   ```
4. **Create startup.cs file**
    ```cs
    public class Startup(IWebHostEnvironment webHostingEnvironment, IConfiguration configuration)
    {
        private readonly Foundation.Startup _foundationStartup = new(webHostingEnvironment, configuration);
    
        public void ConfigureServices(IServiceCollection services)
        {
            _foundationStartup.ConfigureServices(services);
        }
    
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            _foundationStartup.Configure(app, env);
        }
    }
    ```
5. **Adjust program.cs file**
    ```cs
    using yourProjectNameWebNamespace;
    
    Host.CreateDefaultBuilder(args)
    .ConfigureCmsDefaults()
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>();
        webBuilder.UseContentRoot(Path.GetFullPath("../../sandbox/geta-packages-foundation-sandbox/src/Foundation"));
    })
    .Build()
    .Run();

    ```

6. **Add AppHostConfiguration to appsettings.json**
    ```json
    "AppHost": {
      "SqlServerName": "yourSqlServerName",
      "SqlServerPort": 1433,
      "CmsDatabaseName": "yourProjectName-cms",
      "CommerceDatabaseName": "yourProjectName-commerce",
      "WebName": "yourProjectName"
    }

    ```
7. **Run Foundation.AppHost**   
