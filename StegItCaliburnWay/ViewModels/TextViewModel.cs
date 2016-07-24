﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Caliburn.Micro;
using StegIt.Text;
using StegItCaliburnWay.Logic.TextSteganography;
using StegItCaliburnWay.Utils;

namespace StegItCaliburnWay.ViewModels
{
   

    public class TextViewModel : Screen, IStegenographyMethodViewModel
    {
        private readonly FilePickerDialog _filePickerDialog;
        private byte[] _containerRawMessage;
        private byte[] _messageToHide;
        private byte[] _hiddenRawMessage;
        private byte[] _decodedMessage;

        public List<TextMethod> TextMethods { get; set; }
        private TextMethod _selectedTextMethod;

        public TextViewModel(
            SemanticCodingMethod semanticCodingMethod,
            WhiteSpaceCodingMethod whiteSpaceCodingMethod,
            FilePickerDialog filePickerDialog)
        {
            _filePickerDialog = filePickerDialog;
            TextMethods = new List<TextMethod>
            {
                semanticCodingMethod,
                whiteSpaceCodingMethod
            };

            SelectedTextMethod = TextMethods[0];
        }

        public override string DisplayName
        {
            get { return "Tekst"; }
            set { }
        }

        public TextMethod SelectedTextMethod
        {
            get { return _selectedTextMethod; }
            set
            {
                _selectedTextMethod = value;
                NotifyOfPropertyChange(() => SelectedTextMethod);
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

        public byte[] ContainerRawMessage
        {
            get { return _containerRawMessage; }
            set
            {
                _containerRawMessage = value;
                NotifyOfPropertyChange(() => ContainerRawMessage);
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
            ContainerRawMessage = _filePickerDialog.OpenReadDialog(DialogType.Text);
        }

        public void Save()
        {
            _filePickerDialog.OpenSaveDialog(DialogType.Text, HiddenRawMessage);
        }

        public void Hide()
        {
            HiddenRawMessage = _selectedTextMethod.PerformHiding(this);
        }

        public void Decode()
        {
            DecodedMessage = _selectedTextMethod.PerformDecoding(this);
        }
    }
}
