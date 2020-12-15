using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace BibleAPI.Service.API.Router
{
    public class Router : IRouter
    {
    	private IDictionary<string, RequestHandler> _handlers = 
    		new Dictionary<string, RequestHandler>();

    	public Router(RouteMap[] handlers) {
    		foreach (RouteMap r in handlers) {
    			this._handlers.Add(r.Path, r.Handler);
    		}
    	}

		public void Receive(HttpListenerContext c) {
			Console.WriteLine($"{c.Request.HttpMethod} request to {c.Request.Url.AbsolutePath}");

			var buffer = Encoding.ASCII.GetBytes("200 OK\n");

			c.Response
				.OutputStream
				.Write(buffer, 0, buffer.Length);

			c.Response.StatusCode = (int)HttpStatusCode.OK;
			c.Response.OutputStream.Flush();
			c.Response.OutputStream.Close();
		}
    }
}