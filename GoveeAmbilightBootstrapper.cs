using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Transactions;

namespace GoveeAmbilight
{
    public class GoveeAmbilightBootstrapper()
    {
        public static void Main(string[] args)
        {
            GoveeAmbilightCore applicationCore = new GoveeAmbilightCore();
            applicationCore.Execute();
        }
    }
}