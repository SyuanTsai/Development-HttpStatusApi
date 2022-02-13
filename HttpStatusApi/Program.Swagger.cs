using System.Reflection;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

public partial class Program
{
    #region Swagger 的服務配置

    /// <summary>
    ///     要啟用的Swagger服務。
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static void AddSwaggerSetting(IServiceCollection services)
    {
        //  建立Swagger請求回應的服務 - Add Nuget [Swashbuckle.AspNetCore.Filters]
        services.AddSwaggerExamplesFromAssemblyOf(typeof(Program));


        services.AddSwaggerGen
        (
            uiAnnotation =>
            {
                XmlFileSetting(uiAnnotation);
                //  建立Swagger請求回應的服務 - Add Nuget [Swashbuckle.AspNetCore.Filters]
                uiAnnotation.ExampleFilters();
            }
        );
    }

    #endregion Swagger 的服務配置

    #region UI介面的Xml檔案建立

    /// <summary>
    ///     讀取[Assembly]自動產生Xml檔案
    ///     提供Swagger產生UI介面
    /// </summary>
    private static void XmlFileSetting(SwaggerGenOptions uiAnnotation)
    {
        /*
         *  Controller專案的Xml File
         *  透過Assembly取得本專案的XML檔案
         *  拼裝路徑
         *  載入
         */
        var apiXmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var apiXml = Path.Combine(AppContext.BaseDirectory, apiXmlFile);
        uiAnnotation.IncludeXmlComments(apiXml);

        /*
         *  由於DomainModel會有不同專案，所以會有多個Xml File
         *  透過Assembly取得本專案的XML檔案
         *  拼裝路徑
         *  載入
         */
        // 如果要加入其他專案的xml
        var modelXmlFile = "BasicDomain.xml";
        var modelXml = Path.Combine(AppContext.BaseDirectory, modelXmlFile);
        uiAnnotation.IncludeXmlComments(modelXml);
    }

    #endregion
}