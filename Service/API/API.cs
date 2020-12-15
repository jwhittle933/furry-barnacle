using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using System.Diagnostics;	 

namespace BibleAPI.Service.API
{
	public delegate void RequestHandler(HttpListenerContext r);

    public class API
    {
    	public int Port { get; private set; } = 8080;
    	private Thread _thread;
    	private HttpListener _listener;
    	private RequestHandler handleRequest = defaultHandler;

		public API() {
			this._thread = new Thread(this.Listen);
			this._thread.Start();
		}

		public API(int port, RequestHandler handler) {
			this.handleRequest = handler;
			this.Port = port;
			this._thread = new Thread(this.Listen);
			this._thread.Start();
		}

		public void Stop() {
			this._thread.Abort();
			this._listener.Stop();
		}

		private void Listen() {
			this._listener = new HttpListener();
			this._listener
				.Prefixes
				.Add("http://*:" + this.Port.ToString() + "/");
			this._listener.Start();

			while(true) {
				try {
					HttpListenerContext context = this._listener.GetContext();
					this.handleRequest(context);
				} catch (Exception e) {
					Console.WriteLine(e);
				}
			}
		}

		private static void defaultHandler(HttpListenerContext r) {
			Console.WriteLine($"{r.Request.HttpMethod} request to {r.Request.Url.AbsolutePath}");

			var buffer = Encoding.ASCII.GetBytes("200 OK\n");

			r.Response
				.OutputStream
				.Write(buffer, 0, buffer.Length);
			r.Response.StatusCode = (int)HttpStatusCode.OK;
			r.Response.OutputStream.Flush();
			r.Response.OutputStream.Close();
		}
    }
}