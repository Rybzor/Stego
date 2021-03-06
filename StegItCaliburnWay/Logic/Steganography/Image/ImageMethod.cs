﻿using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StegItCaliburnWay.Logic.Steganography.Image.Methods.Bitmap32;
using StegItCaliburnWay.Logic.Steganography.ImageSteganography.Methods.Bitmap24;
using StegItCaliburnWay.Logic.Steganography.ImageSteganography.Methods.Gif;
using StegItCaliburnWay.Utils;
using StegItCaliburnWay.ViewModels;
using Type = StegItCaliburnWay.Utils.Type;

namespace StegItCaliburnWay.Logic.Steganography.ImageSteganography
{
    public abstract class ImageMethod
    {
        public abstract string Name { get; }
        public abstract Type dialogType { get; }
        public abstract ImageFile PerformDecoding(ImageViewModel imageViewModel);
        public abstract ImageFile PerformHiding(ImageViewModel imageViewModel);
    }

    public class Png : ImageMethod
    {
        private readonly Bitmap24Coding _bitmap24Coding;

        public Png(
            Bitmap24Coding bitmap24Coding)
        {
            _bitmap24Coding = bitmap24Coding;
        }

        public override string Name
        {
            get { return "PNG/BMP - 24/32 bitowe, bez kanału alfa"; }
        }

        public override Type dialogType
        {
            get { return DialogType.PngImage; }
        }

        public override ImageFile PerformHiding(ImageViewModel imageViewModel)
        {
            return _bitmap24Coding.CreateHiddenMessage(imageViewModel.ContainerBitmapMessage, imageViewModel.MessageToHide);
        }

        public override ImageFile PerformDecoding(ImageViewModel imageViewModel)
        {
            return _bitmap24Coding.DecodeHiddenMessage(imageViewModel.ContainerBitmapMessage);
        }
    }

    public class BitMap32 : ImageMethod
    {
        private readonly Bitmap32Coding _bitmap32Coding;

        public BitMap32(
            Bitmap32Coding bitmap32Coding)
        {
            _bitmap32Coding = bitmap32Coding;
        }

        public override string Name
        {
            get { return "PNG/BMP - 32 bitowe, z kanałem alfa"; }
        }

        public override Type dialogType
        {
            get { return DialogType.PngImage; }
        }

        public override ImageFile PerformHiding(ImageViewModel imageViewModel)
        {
            return _bitmap32Coding.CreateHiddenMessage(imageViewModel.ContainerBitmapMessage, imageViewModel.MessageToHide);
        }

        public override ImageFile PerformDecoding(ImageViewModel imageViewModel)
        {
            return _bitmap32Coding.DecodeHiddenMessage(imageViewModel.ContainerBitmapMessage);
        }
    }

    public class Gif : ImageMethod
    {
        private readonly GifCoding _gifCoding;

        public Gif(GifCoding gifCoding)
        {
            _gifCoding = gifCoding;
        }

        public override string Name
        {
            get { return "GIF"; }
        }

        public override Type dialogType
        {
            get { return DialogType.GifImage; }
        }
        public override ImageFile PerformHiding(ImageViewModel imageViewModel)
        {
            return _gifCoding.CreateHiddenMessage(imageViewModel.ContainerBitmapMessage, imageViewModel.MessageToHide);
        }

        public override ImageFile PerformDecoding(ImageViewModel imageViewModel)
        {
            return _gifCoding.DecodeHiddenMessage(imageViewModel.ContainerBitmapMessage);
        }
    }
}