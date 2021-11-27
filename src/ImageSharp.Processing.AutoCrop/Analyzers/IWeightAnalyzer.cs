﻿using ImageSharp.Processing.AutoCrop.Models;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;

namespace ImageSharp.Processing.AutoCrop.Analyzers
{
    public interface IWeightAnalyzer<TPixel> where TPixel : unmanaged, IPixel<TPixel>
    {
        IWeightAnalysis GetAnalysis(Image<TPixel> image, Color backgroundColor, int sampleResolution = 5);
    }
}
