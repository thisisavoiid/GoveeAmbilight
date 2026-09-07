using GoveeAmbilight.Command_Packages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Text;
using System.Xml;

namespace GoveeAmbilight
{
    public record class GoveeDevice
    {
        private string _ip = "Unknown";
        public string IP => _ip;

        private string _mac = "Unknown";
        public string MAC => _mac;

        private GoveePackageSender _sender = new GoveePackageSender();

        public GoveeDevice(string ip, string mac)
        {
            _ip = ip;
            _mac = mac;
        }

        public async Task SetColor(GoveeColor color, int temperature = 0)
        {
            if (_sender == null)
                return;

            var data = new ColorWcRequestData(color, temperature);
            var message = new ColorWcMessage(data);
            var colorPackage = new ColorWcRequestPackage(message);

            if (colorPackage == null)
                return;

            await _sender.SendAsync<ColorWcRequestPackage, IGoveeResponsePackage>(colorPackage);
        }
    }
}
