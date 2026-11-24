namespace PracticeProject
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine($"request : {context.Request.Path}");
            await _next(context);
            Console.WriteLine($"Response : {context.Response.StatusCode}");
        }
    }
}
