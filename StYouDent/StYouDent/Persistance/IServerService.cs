using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StYouDent.Persistance
{
    public interface IServerService
    {
        Task<string> SendLogin(string email, string pass);
        Task<string> SendRequest(string json, string adress);
        Task<string> GetRequest(string adress);
    }
}
