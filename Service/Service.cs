using System;
using System.Net;
using System.Text;
using BibleAPI.Service.API.Router;

namespace BibleAPI.Service
{
    public class BibleService : IRouter
    {
		
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