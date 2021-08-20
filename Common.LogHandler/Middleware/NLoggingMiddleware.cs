using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Common.LogHandler.Middleware
{
	public class NLoggingMiddleware
	{
		private readonly RequestDelegate _next;

		private static NLog.Logger nlogger = NLog.LogManager.LoadConfiguration("nlog.config").GetCurrentClassLogger();

		public NLoggingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			await _next(context);
			nlogger.Trace($"Request: {context.Request.Path} | Response Status Code: {context.Response.StatusCode}");
		}
	}
}
