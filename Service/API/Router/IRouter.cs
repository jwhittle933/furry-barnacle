using System.Net;

namespace BibleAPI.Service.API.Router
{
    public interface IRouter
    {
		public void Receive(HttpListenerContext c);
    }
}