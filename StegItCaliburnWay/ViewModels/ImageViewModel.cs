﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using StegItCaliburnWay.Logic.Steganography.ImageSteganography;
using StegItCaliburnWay.Logic.TextSteganography;
using StegItCaliburnWay.Utils;

namespace StegItCaliburnWay.ViewModels
{
    public class ImageViewModel : Screen, IStegenographyMethodViewModel
    {
        private readonly FilePickerDialog _filePickerDialog;
        private byte[] _containerRawMessage;
        private byte[] _messageToHide;
        private byte[] _hiddenRawMessage;
        private byte[] _decodedMessage;
        private object _hiddenMessageViewModel;

        private Bitmap _containerBitmapMessage;
        private Bitmap _hiddenBitmapMessage;

        public List<ImageMethod> ImageMethods { get; set; }
        private ImageMethod _selectedImageMethod;

        public ImageViewModel(
            FilePickerDialog filePickerDialog,
            Png png,
            BitMap32 bitMap32,
            Gif gif)
        {
            _filePickerDialog = filePickerDialog;
            ImageMethods = new List<ImageMethod>
            {
                bitMap32,
                png,
                gif
            };

            SelectedImageMethod = ImageMethods[0];
        }

        public override string DisplayName
        {
            get { return "Obraz"; }
            set { }
        }

        public ImageMethod SelectedImageMethod
        {
            get { return _selectedImageMethod; }
            set
            {
                _selectedImageMethod = value;
                NotifyOfPropertyChange(() => SelectedImageMethod);
            }
        }

        public byte[] MessageToHide
        {
            get { return _messageToHide; }
            set
            {
                _messageToHide = value;
                NotifyOfPropertyChange(() => MessageToHide);
            }
        }

        public byte[] HiddenRawMessage
        {
            get { return _hiddenRawMessage; }
            set
            {
                _hiddenRawMessage = value;
                NotifyOfPropertyChange(() => HiddenRawMessage);
            }
        }

        public Bitmap HiddenBitmapMessage
        {
            get { return _hiddenBitmapMessage; }
            set
            {
                _hiddenBitmapMessage = value;
                NotifyOfPropertyChange(() => HiddenBitmapMessage);
            }
        }


        public byte[] ContainerRawMessage
        {
            get { return _containerRawMessage; }
            set
            {
                _containerRawMessage = value;
                NotifyOfPropertyChange(() => ContainerRawMessage);
            }
        }

        public Bitmap ContainerBitmapMessage
        {
            get { return _containerBitmapMessage; }
            set
            {
                _containerBitmapMessage = value;
                NotifyOfPropertyChange(() => ContainerBitmapMessage);
            }
        }

        public byte[] DecodedMessage
        {
            get { return _decodedMessage; }
            set
            {
                _decodedMessage = value;
                NotifyOfPropertyChange(() => DecodedMessage);
            }
        }

        public void OpenReadDialog()
        {
            ImageFile file = _filePickerDialog.OpenReadImageDialog(_selectedImageMethod.dialogType);
            ContainerRawMessage = file.Bytes;
            ContainerBitmapMessage = file.Bitmap;
        }

        public void Save()
        {
            _filePickerDialog.OpenSaveImageDialog(HiddenBitmapMessage, _selectedImageMethod.dialogType);
        }

        public object HiddenMessageViewModel
        {

            get { return _hiddenMessageViewModel; }
            set
            {
                _hiddenMessageViewModel = value;
                NotifyOfPropertyChange(() => HiddenMessageViewModel);
            }
        }

        public void Clear()
        {
            ContainerRawMessage = null;
            MessageToHide = null;
            HiddenMessageViewModel = null;
            DecodedMessage = null;
        }

        public async Task Hide()
        {
            ImageFile file = await PerformHiding();
            HiddenRawMessage = file.Bytes;
            HiddenBitmapMessage = file.Bitmap;
            HiddenMessageViewModel = new HiddenMessageImageViewModel(file.Bytes);
        }

        private Task<ImageFile> PerformHiding()
        {
            return Task.Factory.StartNew(() => _selectedImageMethod.PerformHiding(this));
        }

        public async Task Decode()
        {
            ImageFile file = await PerformDecoding();
            DecodedMessage = file.Bytes;
        }

        private Task<ImageFile> PerformDecoding()
        {
            return Task.Factory.StartNew(() => _selectedImageMethod.PerformDecoding(this));   
        }
    }
}
