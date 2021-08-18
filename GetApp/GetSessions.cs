using System;
using System.Collections.Generic;
using System.Text;
using NAudio.CoreAudioApi;
using System.Diagnostics;
using NAudio.CoreAudioApi.Interfaces;
using System.Media;


namespace GetSession
{
    public partial class GetSessions
    {
        //All sessions on currebnt device
        private SessionCollection allcurrdevicesession;

        /// <summary>
        /// Individual program playing audio 
        /// </summary>
        private readonly AudioSessionControl session;
        Process process;
        string processnamae;

        //Individual Audio device
        private MMDevice device;

        //device enumerators 
        private MMDeviceEnumerator deviceEnumerator = new MMDeviceEnumerator();

        //Collection of all audio Devices
        //private MMDeviceCollection allDevices;

       

        int program;


        public GetSessions()
        {
            //Get all Active Audio Renderers(aka speakers,headphones etc) 
            //allDevices = deviceEnumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);

            //Get current device being used and all its sessions
            device = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            Console.Write(device.FriendlyName + "\n");

            allcurrdevicesession = device.AudioSessionManager.Sessions;

            session = allcurrdevicesession[0];

            process = Process.GetProcessById((int)session.GetProcessID);

            if (session.IsSystemSoundsSession)
             {
                Console.WriteLine("System Sounds");
                processnamae = "System Sounds";
             }
            else
            {
                Console.WriteLine(process.ProcessName);
                processnamae = process.ProcessName;
            }


        }


        public void volumechange()
        {
            float volume = (float)(Math.Round(session.SimpleAudioVolume.Volume)*100);

            Console.WriteLine("volume = " + volume);
            Console.WriteLine(device.AudioEndpointVolume.MasterVolumeLevelScalar);
            Console.WriteLine("Process Name:" + processnamae);
            Console.WriteLine("Change Volume");
            volume = (float)Convert.ToDouble(Console.ReadLine());

            device.AudioEndpointVolume.MasterVolumeLevelScalar = volume / 100.0f;

            volume = volume / device.AudioEndpointVolume.MasterVolumeLevelScalar;
            session.SimpleAudioVolume.Volume = 0.5f;
            

            /*
            float volume = session.SimpleAudioVolume.Volume;
            Console.WriteLine(volume);
            Process.GetProcessById;
            Console.WriteLine(device.FriendlyName);
            float volume = session.SimpleAudioVolume.Volume;
            var volumo = (int)(Math.Round(device.AudioEndpointVolume.MasterVolumeLevelScalar*100));
            Console.WriteLine(volumo);*/


        }
    }

}



/*
            foreach (MMDevice speaker in allDevices)
            {
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine(speaker.FriendlyName);
                Console.WriteLine(speaker.State);
                //Console.WriteLine(speaker.DeviceFriendlyName);
                //if(speaker.State == DeviceState.Active)
                alldevicesession = speaker.AudioSessionManager.Sessions;
                for (int i = 0; i < alldevicesession.Count; i++)
                {
                    
                    session = alldevicesession[i];
                    if (!session.IsSystemSoundsSession)
                    {
                        Process process = Process.GetProcessById((int)session.GetProcessID);
                        Console.WriteLine(process.ProcessName);
                        //Console.WriteLine(process.ProcessName+" "+ process.MainWindowTitle);
                        //Console.WriteLine(i + session.DisplayName);
                        //Console.WriteLine(session.State);

                    }


                }

            }

*/