using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambilight
{
    public class Settings
    {
        public string port { get; set; }
        public int baud { get; set; }
        public int numberOfLeds { get; set; }
        public int offset { get; set; }
        public int height { get; set; }
        public int pixelPerX { get; set; }
        public int pixelPerY { get; set; }
        public int brightness { get; set; }
        public int extant { get; set; }
        public bool linearCapture { get; set; }
        public bool turnOffWhenClosed { get; set; }
        public byte redAmount { get; set; }
        public byte greenAmount { get; set; }
        public byte blueAmount { get; set;}
        public bool running { get; set; }

        public mode currentMode { get; set; }

        public enum mode { video, audio, color, ambient}

        public void setConfiguration(string po, int ba, int numLed, int os, int he, int ppX, int ppY, int br, int ex, bool lc, bool off, string cm, byte r, byte g, byte b, bool ru)
        {
            port = po;
            baud = ba;
            numberOfLeds = numLed;
            offset = os;
            height = he;
            pixelPerX = ppX;
            pixelPerY = ppY;
            brightness = br;
            extant = ex;
            linearCapture = lc;
            turnOffWhenClosed = off;
            currentMode = (mode) Enum.Parse(typeof(mode), cm, true);
            redAmount = r;
            greenAmount = g;
            blueAmount = b;
            running = ru;
        }
        public void setDefaultConfiguration()
        {
            port = "COM15";
            baud = 115200;
            numberOfLeds = 30;
            offset = 0;
            height = 4;
            pixelPerX = 10;
            pixelPerY = 10;
            brightness = 100;
            extant = 0;
            linearCapture = false;
            turnOffWhenClosed = true;
            currentMode = mode.video;
            redAmount = 0;
            greenAmount = 0;
            blueAmount = 0;
        }
    }
}
