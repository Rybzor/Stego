﻿using System;
using System.Linq;

namespace StegItCaliburnWay.Logic.Steganography.AudioSteganography.Methods.Wave
{
    public class WaveCodingValidator
    {
        
        public void CheckIfCanHideMessageOrThrow(AudioFile containerAudioFile, byte[] messageToHide)
        {
            var bitsFromMessageToSave = TextUtils.GetMessageBitArray(messageToHide);

            if (containerAudioFile.waveFile.bitsPerSample != 8 &&
                containerAudioFile.waveFile.bitsPerSample != 16 &&
                containerAudioFile.waveFile.bitsPerSample != 24 &&
                containerAudioFile.waveFile.bitsPerSample != 32)
            {
                throw new Exception("Nieprawidłowa liczba bitów na próbkę! Wspierane: 8/16/24");
            }

            var audioCapacity = containerAudioFile.waveFile.samples.Length * (containerAudioFile.waveFile.bitsPerSample / WaveCoding.CHANGING_SAMPLES_FACTOR);

            if (bitsFromMessageToSave.Length > audioCapacity)
                throw new Exception("Wiadomość jest zbyt długa aby umieścić ją w pliku .wav" + Environment.NewLine +
                                    "Długość wiadomości w bajtach: " + bitsFromMessageToSave.Length + Environment.NewLine +
                                    "Ilośc dostępnego miejsca w pliku audio: " + audioCapacity);

            if (containerAudioFile.waveFile.samples.Count() <= 10)
                throw new Exception("Niepoprawny plik audio!");
        }
    }
}
