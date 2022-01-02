using System;
using NAudio.CoreAudioApi;
using System.Diagnostics;
using NAudio.CoreAudioApi.Interfaces;
using System.Media;
using GetSession;
using System.IO.Ports;

namespace MixerMixer
{
    partial class Maino
    {
        static void Main()
        {
            GetSessions xex = new GetSessions();
            //make a serial port object tied to com6 with baudrate same as arduino usart baudrate
            SerialPort cereal = new SerialPort("COM6", 9600);


            /*
            foreach (var word in words)
            {
                System.Console.WriteLine($"<{word}>");
            }
            */

            //open a cereal port
            try
            {
                cereal.Open();
            }
            catch
            {
                Console.WriteLine("Wrong PORT chief!!!");
            }

            //while(true)
            //{
            //collect knob readings from Arduino
            string knobs = cereal.ReadLine();
            Console.WriteLine(knobs);

            string[] volums = knobs.Split('|');
            //sbyte is 8 bit integer space
            //space efficiency is cool kids
            float masta = Convert.ToSByte(volums[0]);

            //xex.volumechange(masta);
            int len = Math.Min(volums.Length, xex.noofapps());

            for (sbyte i = 1; i < len; i++)
            {
                float app1 = (Convert.ToSByte(volums[i])) / 100.0f;
                xex.volumechangeapp(i, app1);
            }

            //Console.SetCursorPosition(0, Console.CursorTop - 5);

            //}
        }
    }
}


