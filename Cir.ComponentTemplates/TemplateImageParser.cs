using System.Collections.Generic;
using Cir.ComponentTemplates.Models;

namespace Cir.ComponentTemplates
{
    public class TemplateImageParser
    {
        public byte[] ToImage(int[][][] compressedPixels, IEnumerable<Section> sections, IEnumerable<Label> labels)
        {
            var pixelProcessor = new PixelMatrixProcessor();
            var imgGenerator = new ComponentImageGenerator();
            var coloredPixels = pixelProcessor.ProcessMatrix(compressedPixels, sections);
            var bytes = imgGenerator.GenerateImage(coloredPixels, labels);

            return bytes;
        }
    }
}
