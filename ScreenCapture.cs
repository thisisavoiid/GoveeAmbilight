using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.AccessControl;
using Vanara.PInvoke;
using static Vanara.PInvoke.Gdi32;

namespace GoveeAmbilight
{
    public class ScreenCapture : IDisposable
    {
        private readonly int _downscaleFactor;
        private readonly Size _screenDimensions;
        private readonly Bitmap _screenBitmap;
        private readonly Bitmap _scaledBitmap;

        private readonly Graphics _screenGraphics;
        private readonly Graphics _scaledGraphics;

        public ScreenCapture(int downscaleFactor = 16)
        {
            _screenDimensions = new Size(
                User32.GetSystemMetrics(User32.SystemMetric.SM_CXSCREEN),
                User32.GetSystemMetrics(User32.SystemMetric.SM_CYSCREEN)
            );

            _downscaleFactor = downscaleFactor;

            _screenBitmap = new Bitmap(_screenDimensions.Width, _screenDimensions.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            _scaledBitmap = new Bitmap(_screenBitmap.Width / downscaleFactor, _screenBitmap.Height / downscaleFactor);

            _screenGraphics = Graphics.FromImage(_screenBitmap);
            _scaledGraphics = Graphics.FromImage(_scaledBitmap);

            _scaledGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
        }

        public GoveeColor GetAverageScreenColor()
        {
            _screenGraphics.CopyFromScreen(0, 0, 0, 0, _screenDimensions);

            _scaledGraphics.DrawImage(
                _screenBitmap,
                new Rectangle(0, 0, _screenDimensions.Width / _downscaleFactor, _screenDimensions.Height / _downscaleFactor)
            );

            long totalRed = 0;
            long totalGreen = 0;
            long totalBlue = 0;
;
            for (int x = 0; x < _scaledBitmap.Width; x++)
            {
                for (int y = 0; y < _scaledBitmap.Height; y++)
                {
                    Color baseColor = _scaledBitmap.GetPixel(x, y);

                    totalRed += baseColor.R;
                    totalGreen += baseColor.G;
                    totalBlue += baseColor.B;
                }
            }

            int pixelCount = _scaledBitmap.Width * _scaledBitmap.Height;

            long avgRed = totalRed / pixelCount;
            long avgGreen = totalGreen / pixelCount;
            long avgBlue = totalBlue / pixelCount;

            GoveeColor avgColor = new GoveeColor(avgRed, avgGreen, avgBlue);

            return avgColor;
        }

        public void Dispose()
        {
            _scaledGraphics?.Dispose();
            _screenGraphics?.Dispose();

            _scaledBitmap?.Dispose();
            _screenBitmap?.Dispose();
        }
    }
}
