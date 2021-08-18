using System;
using NAudio.CoreAudioApi;
using System.Diagnostics;
using NAudio.CoreAudioApi.Interfaces;
using System.Media;
using GetSession;

namespace MixerMixer
{
    partial class Maino
    {
        static void Main()
        {
            GetSessions s = new GetSessions();
           
            s.volumechange();

        }

    }   
}


