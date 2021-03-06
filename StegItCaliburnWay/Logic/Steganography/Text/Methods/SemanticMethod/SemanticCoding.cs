﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StegIt.Text.StegoTools.SemanticMethod;
using StegItCaliburnWay;
using StegItCaliburnWay.Logic.Steganography.TextSteganography.Methods.SemanticMethod;

namespace StegIt.Text.StegoTools
{
    public class SemanticCoding : ITextCodingMethod
    {
        private readonly SemanticCodingValidator _semanticCodingValidator;
        private readonly Dictionary<char, char> listOfLettersThatCanBeChanged = SemanticLettersValues.GetLetters();

        public SemanticCoding(SemanticCodingValidator semanticCodingValidator)
        {
            _semanticCodingValidator = semanticCodingValidator;
        }

        public byte[] CreateHiddenMessage(byte[] container, byte[] message)
        {
            var openedFile = TextUtils.GetUTF8CharArrayFromByteStream(container);

            _semanticCodingValidator.CheckIfCanHideMessageOrThrow(openedFile, message);

            var fileToSaveBytes = message;

            var bitsFromFileToSave = TextUtils.GetMessageBitArray(fileToSaveBytes);

            var messageChars = new char[openedFile.Length];
            var insertedHiddenBits = 0;

            for (var i = 0; i < openedFile.Length; i++)
            {
                Console.WriteLine("Step: " + i + " of " + openedFile.Length);

                if (listOfLettersThatCanBeChanged.ContainsKey(openedFile[i]) &&
                    insertedHiddenBits < bitsFromFileToSave.Length)
                {
                    if (bitsFromFileToSave.Get(insertedHiddenBits))
                    {
                        messageChars[i] = listOfLettersThatCanBeChanged[openedFile[i]];
                    }
                    else
                    {
                        messageChars[i] = openedFile[i];
                    }
                    insertedHiddenBits++;
                }
                else
                {
                    messageChars[i] = openedFile[i];
                }
            }

            return TextUtils.GetBytesFromMessage(messageChars);
        }

        public byte[] DecodeHiddenMessage(byte[] container)
        {
            var openedFile = TextUtils.GetUTF8CharArrayFromByteStream(container);

            var numberOfBitsHidden = GetNumberOfLettersThatCouldBeHidden(openedFile);
            var messageBits = new BitArray(numberOfBitsHidden);

            var bitInputNumber = 0;

            foreach (char letter in openedFile)
            {
                if (listOfLettersThatCanBeChanged.ContainsKey(letter) ||
                    listOfLettersThatCanBeChanged.ContainsValue(letter))
                {
                    messageBits.Set(bitInputNumber, listOfLettersThatCanBeChanged.ContainsValue(letter));
                    bitInputNumber++;
                }
            }

            var messageBytes = new byte[messageBits.Count];
            messageBits.CopyTo(messageBytes, 0);

            return messageBytes;
        }

        private int GetNumberOfLettersThatCouldBeHidden(char[] openedFile)
        {
            return
                openedFile.Count(
                    c => listOfLettersThatCanBeChanged.ContainsKey(c) || listOfLettersThatCanBeChanged.ContainsValue(c));
        }
    }
}
