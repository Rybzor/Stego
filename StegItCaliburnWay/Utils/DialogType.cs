﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace StegItCaliburnWay.Utils
{
    public class DialogType
    {
        public static Type Text = new Type(".txt", "TXT Files (*.txt)|*.txt");
        public static Type PngImage = new Type(".png", "PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp");
        public static Type BmpImage = new Type(".bmp", "BMP Files (*.bmp)|*.bmp|PNG Files (*.png)|*.png");
        public static Type GifImage = new Type(".gif", "GIF Files (*.gif)|*.gif");
        public static Type Audio = new Type(".wav", "WAVE Files (*.wav)|*.wav");
        public static Type AviFiles = new Type(".avi", "AVI Files (*.avi)|*.avi");
        public static Type Executable = new Type(".exe", "EXE Files (*.exe)|*.exe");
    }

    public class Type
    {
        public string defaultExt;
        public string filter;

        public Type(string defaultExt, string filter)
        {
            this.defaultExt = defaultExt;
            this.filter = filter;
        }
    }



}
