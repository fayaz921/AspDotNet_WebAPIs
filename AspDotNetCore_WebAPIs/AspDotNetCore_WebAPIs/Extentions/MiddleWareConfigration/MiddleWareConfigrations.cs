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

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
            return app;
        }
    }
}
