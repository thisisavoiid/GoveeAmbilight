using System;
using System.Collections.Generic;
using System.Text;

namespace GoveeAmbilight
{
    public static class GoveeDeviceScanner
    {
        public static async Task<GoveeDevice> Scan()
        {
            ScanRequestPackage request = new ScanRequestPackage();
            GoveePackageSender packageSender = new GoveePackageSender();

            ScanResponsePackage? response = await packageSender.SendAsync<ScanRequestPackage, ScanResponsePackage>(request, 5000);
            ScanResponseData? data = response.Message.Data;

            return new GoveeDevice(data?.Ip, data?.Device);
        }
    }
}
