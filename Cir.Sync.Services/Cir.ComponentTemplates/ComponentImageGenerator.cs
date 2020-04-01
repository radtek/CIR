using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using Cir.ComponentTemplates.Models;

namespace Cir.ComponentTemplates
{
    internal class ComponentImageGenerator
    {
        public byte[] GenerateImage(IReadOnlyCollection<IReadOnlyCollection<string>> colors, IEnumerable<Label> labels)
        {
            var width = colors.First().Count;
            var height = colors.Count;

            using (var bitmap = new Bitmap(width, height))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(Color.Transparent);
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;

                    DrawLabels(labels, graphics);

                    graphics.Flush();
                }

                DrawPixels(colors, bitmap);
                
                using (var stream = new MemoryStream())
                {
                    bitmap.Save(stream, ImageFormat.Png);

                    return stream.ToArray();
                }
            }
        }

        private void DrawPixels(IReadOnlyCollection<IReadOnlyCollection<string>> colors, Bitmap bitmap)
        {
            for (var i = 0; i < colors.Count; i++)
            {
                for (var j = 0; j < colors.ElementAt(i).Count; j++)
                {
                    var colorHex = colors.ElementAt(i).ElementAt(j);

                    if (colorHex == string.Empty)
                    {
                        continue;
                    }

                    var color = ColorTranslator.FromHtml(colorHex);

                    bitmap.SetPixel(j, i, color);
                }
            }
        }

        private void DrawLabels(IEnumerable<Label> labels, Graphics graphics)
        {
            foreach (var label in labels)
            {
                graphics.DrawString(label.Text, new Font("Arial", 8), Brushes.DarkGray, (label.X < 0 ? 0 : label.X) + 5, label.Y < 0 ? 0 : label.Y);
            }
        }
    }
}
