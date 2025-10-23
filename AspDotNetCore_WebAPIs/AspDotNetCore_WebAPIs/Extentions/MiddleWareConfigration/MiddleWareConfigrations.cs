using AspDotNetCore_WebAPIs.MiddleWare;

namespace AspDotNetCore_WebAPIs.Extentions.MiddleWareConfigration
{
    public static class MiddleWareConfigrations
    {
        public static WebApplication AddMiddleWareConfigrations(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<GlobalExceptionHandlingMiddleWare>()
               .UseHttpsRedirection()
               .UseAuthorization();

            app.MapControllers();
            return app;
        }
    }
}
