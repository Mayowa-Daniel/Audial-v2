using System;
using System.Collections.Generic;
using System.Text;
using NAudio.CoreAudioApi;
using System.Diagnostics;
using NAudio.CoreAudioApi.Interfaces;
using System.Media;


namespace GetApp
{
    public partial class Getapp
    {
        //Individual program playing audio
        private readonly AudioSessionControl session;

        //Individual Audio device
        private MMDevice device;

        //device enumerators 
        private MMDeviceEnumerator deviceEnumerator = new MMDeviceEnumerator();

        //Collection of all audio Devices
        private MMDeviceCollection allDevices;


        /*
        public Getapp(AudioSessionControl _session)
        {
            session = _session;
 
            //Process process = Process.GetProcessById((int)session.GetProcessID);

            //float volume = this.session.SimpleAudioVolume.Volume;
            //Console.WriteLine("volume = " + volume);
            //Console.WriteLine("Proces Name:" + process.ProcessName);

        } 
        */
        public Getapp()
        {
            //Get all Active Audio Renderers(aka speakers,headphones etc) 
            allDevices = deviceEnumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);

            foreach (MMDevice speaker in allDevices)
            {
                //Console.WriteLine(i + " = " + sessions[i].IconPath);
                Console.WriteLine(speaker.FriendlyName);
                //Console.WriteLine(speaker.DeviceFriendlyName);
            }


        }



        public void volumechange(AudioSessionControl currsession)
        {
            uint currprocesses = currsession.GetProcessID;
            float volume = session.SimpleAudioVolume.Volume;
            Console.WriteLine(volume);
            //Process.GetProcessById;
            
        }
    }

}



