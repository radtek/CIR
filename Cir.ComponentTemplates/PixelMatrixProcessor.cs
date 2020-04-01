using System;
using System.Collections.Generic;
using System.Linq;
using Cir.ComponentTemplates.Models;

namespace Cir.ComponentTemplates
{
    internal class PixelMatrixProcessor
    {
        public IReadOnlyCollection<IReadOnlyCollection<string>> ProcessMatrix(int[][][] compressedPixels, IEnumerable<Section> sections)
        {
            if (compressedPixels == null)
            {
                throw new ArgumentNullException(nameof(compressedPixels));
            }
            if (compressedPixels.Length == 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(compressedPixels)} is empty.");
            }
            if (sections == null)
            {
                throw new ArgumentNullException(nameof(sections));
            }

            var sectionsDict = sections.ToDictionary(s => s.Id, s => s.Color);
            var pixels = Decompress(compressedPixels);
            var coloredPixels = ColorTemplate(pixels, sectionsDict);

            return coloredPixels;
        }

        private IReadOnlyCollection<IReadOnlyCollection<int>> Decompress(IEnumerable<int[][]> compressedPixels)
        {
            var rows = new List<List<int>>();

            foreach (var compressedRow in compressedPixels)
            {
                var row = new List<int>();

                foreach (var compressedColumns in compressedRow)
                {
                    var count = compressedColumns[1];

                    for (var k = 0; k < count; k++)
                    {
                        row.Add(compressedColumns[0]);
                    }
                }

                rows.Add(row);
            }

            return rows;
        }

        private IReadOnlyCollection<IReadOnlyCollection<string>> ColorTemplate(
            IEnumerable<IEnumerable<int>> pixels,
            IDictionary<int, string> sectionsData) =>
            (
                from row in pixels
                let coloredRow = (
                    from pixel in row
                    let color = sectionsData.ContainsKey(pixel) ? sectionsData[pixel] : pixel == -1 ? string.Empty : SeverityColors.UnassignedColor
                    select color
                )
                select new List<string>(coloredRow)
            ).ToList();
    }
}
