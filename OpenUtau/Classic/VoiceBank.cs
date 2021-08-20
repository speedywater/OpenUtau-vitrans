﻿using System;
using System.Collections.Generic;

namespace OpenUtau.Classic {
    public class Voicebank {
        public string File;
        public string OrigFile;
        public string Name;
        public string Image;
        public string Author;
        public string Web;
        public string OtherInfo;
        public List<OtoSet> OtoSets = new List<OtoSet>();
        public PrefixMap PrefixMap;

        public override string ToString() {
            return Name;
        }
    }

    public class OtoSet {
        public string File;
        public string OrigFile;
        public string Name;
        public List<Oto> Otos = new List<Oto>();

        public override string ToString() {
            return Name;
        }
    }

    public class Oto {
        public string Name;
        public string Wav;
        public string OrigWav;

        // Wav layout:
        // |-offset-|-consonant-(fixed)-|-stretched-|-cutoff-|
        // |        |-preutter-----|
        // |        |-overlap-|
        // Note position:
        // ... ----------prev-note-|-this-note-- ...
        // Phoneme overlap:
        // ... --prev-phoneme-\
        //          /-this-phoneme-------------- ...

        // Length of left offset.
        public double Offset;
        // Length of unstretched consonant in wav, AKA fixed.
        public double Consonant;
        // Length of right cutoff, AKA end blank. If negative, length of (consonant + stretched). 
        public double Cutoff;
        // Length before note start, usually within consonant range.
        public double Preutter;
        // Length overlap with previous note, usually within consonant range.
        public double Overlap;

        public override string ToString() {
            return Name;
        }
    }

    public class PrefixMap {
        public string File;
        public string OrigFile;
        public Dictionary<string, Tuple<string, string>> Map = new Dictionary<string, Tuple<string, string>>();
    }
}
