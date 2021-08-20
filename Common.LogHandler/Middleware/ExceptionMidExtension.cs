using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.LogHandler.Middleware
{
	public static class ExceptionMidExtension
	{
		private static NLog.Logger nlogger = NLog.LogManager.LoadConfiguration("nlog.config").GetCurrentClassLogger();

		/// <summary>
		/// Every Exception must pass through here
		/// </summary>
		/// <param name="app"></param>
		public static void ConfigureExceptionHandler(this IApplicationBuilder app)
		{
			app.UseExceptionHandler(appError =>
			{
				appError.Run(async context =>
				{
					context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
					context.Response.ContentType = "application/json";

					var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
					if (contextFeature != null)
					{
						nlogger.Error(contextFeature.Error, contextFeature.Error.Message);
					}
				});
			});
		}
	}
}
