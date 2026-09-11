using System.Text.Encodings.Web;

namespace GoveeAmbilight
{
    public class GoveeAmbilightCore
    {
        private GoveeDevice _device;
        public async void Execute()
        {
            TimeSpan timePerRequest = TimeSpan.FromMilliseconds(500);
            DateTime lastRequestSentAt = DateTime.Now;

            using ScreenCapture screenshotTaker = new ScreenCapture();

            //GoveeColor avgColor = screenshotTaker.GetAverageScreenColor();

            //Console.WriteLine(avgColor);
            while (true)
            {
                DateTime timeNow = DateTime.Now;
                TimeSpan difference = timeNow - lastRequestSentAt;

                if (difference < timePerRequest)
                    continue;

                lastRequestSentAt = timeNow;

                GoveeColor color = screenshotTaker.GetAverageScreenColor();
                Console.WriteLine($"\u001b[38;2;{color.Red};{color.Green};{color.Blue}m{color}");
            }

            return;
            _device = await GoveeDeviceScanner.Scan();
            Console.WriteLine(_device);

            if (_device is null)
            {
                Console.WriteLine("No device found!");
                return;
            }

            Random random = new Random();

            while (true)
            {
                int randomR = random.Next(0, 255);
                int randomG = random.Next(0, 255);
                int randomB = random.Next(0, 255);
                GoveeColor randomColor = new GoveeColor(randomR, randomG, randomB);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[CORE] Requsting color change for {_device.ToString()}... -");

                await _device.SetColor(randomColor);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[CORE] Successfully performed color change to color {randomColor} for {_device.ToString()}... -");

                Thread.Sleep(250);
            }
        }
    }
}
