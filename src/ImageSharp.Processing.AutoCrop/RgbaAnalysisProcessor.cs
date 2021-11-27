﻿using ImageSharp.Processing.AutoCrop.Analyzers;
using ImageSharp.Processing.AutoCrop.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace ImageSharp.Processing.AutoCrop
{
    public class RgbaAnalysisProcessor : AnalysisProcessor<Rgba32>
    {
        private readonly IWeightAnalyzer<Rgba32> _weightAnalyzer;
        private readonly ICropAnalyzer<Rgba32> _cropAnalyzer;

        public RgbaAnalysisProcessor(Configuration configuration, IAutoCropSettings settings, Image<Rgba32> source) : base(configuration, settings, source)
        {
            _cropAnalyzer = new RgbaThresholdAnalyzer();
            _weightAnalyzer = new RgbaWeightAnalyzer();
        }

        public override ICropAnalysis GetCropAnalysis()
        {
            return _cropAnalyzer.GetAnalysis(Source, Settings.ColorThreshold, Settings.BucketThreshold);
        }

        public override IWeightAnalysis GetWeightAnalysis(ICropAnalysis cropAnalysis)
        {
            return _weightAnalyzer.GetAnalysis(Source, cropAnalysis.Background);
        }
    }
}
