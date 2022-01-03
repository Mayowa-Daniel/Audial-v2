using System;
using System.Collections.Generic;
using System.Text;
using NAudio.CoreAudioApi;
using System.Diagnostics;
using NAudio.CoreAudioApi.Interfaces;
using System.Media;
using System.IO.Ports;


namespace GetSession
{
    public partial class GetSessions
    {
        //All sessions on currebnt device
        private SessionCollection allcurrdevicesession;

        /// <summary>
        /// Individual program playing audio 
        /// </summary>
        private AudioSessionControl session;
        Process process;
        string processnamae;

        //Individual Audio device
        private MMDevice device;

        //device enumerators 
        private MMDeviceEnumerator deviceEnumerator = new MMDeviceEnumerator();

        //Collection of all audio Devices
        //private MMDeviceCollection allDevices;




        public GetSessions()
        {
            //Get current device being used and all its sessions
            device = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            Console.Write(device.FriendlyName + "\n");

            allcurrdevicesession = device.AudioSessionManager.Sessions;
        }

        public void volumechange(float sys)
        {
            //absolute/master volume
            device.AudioEndpointVolume.MasterVolumeLevelScalar = sys / 100.0f;
        }

        public int noofapps()
        {
            return allcurrdevicesession.Count;
        }

        public void volumechangeapp(sbyte appo, float app1)
        {
            session = allcurrdevicesession[appo];
            process = Process.GetProcessById((int)session.GetProcessID);

            if (session.IsSystemSoundsSession)
            {
                Console.WriteLine(appo + ". System Sounds");
                processnamae = "System Sounds";
            }
            else
            {
                Console.WriteLine(appo + ". " + process.ProcessName);
                processnamae = process.ProcessName;
            }

            //Change session(individual program) volume
            //will obviously be a percentage of device volume i.e 0.5 = 50% of device volume
            session.SimpleAudioVolume.Volume = app1;

        }
    }


}