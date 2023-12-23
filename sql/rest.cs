using RestSharp;

//sockets
﻿using System;using System.Net;using sck = System.Net.Sockets.Socket;using System.Text;using System.Diagnostics;
using System.Net.Sockets;


using Newtonsoft.Json;
namespace con
{
    public class rest
    {
        public static string consumir(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest();
            // request.AddHeader("X-RapidAPI-Key", "03e643bf21msh709732eca3d2350p1d667fjsnbd6d67745e3e");
            // request.AddHeader("X-RapidAPI-Host", "weatherbit-v1-mashape.p.rapidapi.com");
            RestResponse response = client.Execute(request);
            return response.Content.ToString();
        }
        public static string socket_exec(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest();
            // request.AddHeader("X-RapidAPI-Key", "03e643bf21msh709732eca3d2350p1d667fjsnbd6d67745e3e");
            // request.AddHeader("X-RapidAPI-Host", "weatherbit-v1-mashape.p.rapidapi.com");
            client.Execute(request);

            return socket();
            
        }

        public static string socket()
        {
            string LocalIp=String.Empty;

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    LocalIp = ip.ToString();
                }
            }
            string cadena="";
            //soclet servidor
            string stringData = null;
            try
            {
                IPAddress ip = IPAddress.Parse("127.0.0.1");
                IPEndPoint ipep = new IPEndPoint(ip, 11000);

               sck newsock = new sck(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
                newsock.Bind(ipep);
                newsock.Listen(10);
                // Console.WriteLine("Esperando una conexion...");
                sck client = newsock.Accept();
                IPEndPoint clientep =
                    (IPEndPoint)client.RemoteEndPoint;

                // Console.WriteLine("Conectado con {0} en el puerto {1}",

                    // clientep.Address, clientep.Port);

                byte[] data = new byte[1024];
                int recv = client.Receive(data);
                stringData = Encoding.ASCII.GetString(data);
                // Console.WriteLine("Mensaje recibido: {0}", stringData);
                cadena=stringData;
                client.Close();
                newsock.Close();
                // Console.WriteLine("Conexion finalizada");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }   
            // txthora.Buffer.Text=cadena;

            return stringData;

            // string str = "";
            // byte [] a = new byte[1024];

            // // Console.WriteLine("RUNNIN' SERVER XD");
            // IPHostEntry hostinfo = Dns.GetHostEntry(Dns.GetHostName());
            // IPAddress iPAddress = IPAddress.Parse("127.0.0.1");
            // IPEndPoint EP = new IPEndPoint(iPAddress, 65432);
            // Socket serv = new Socket(iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            // try
            // {
            // serv.Bind(EP);
            // serv.Listen(10);
            // Socket handl = serv.Accept();
            // Console.WriteLine("ACCEPTED");
            // while (true)
            // {
            
            // int byteses = handl.Receive(a);
            // // str += Encoding.ASCII.GetString(a, 0, byteses);
            // str += Encoding.ASCII.GetString(a, 0, byteses);
            
            // if (str.IndexOf("{EOF}")>-1){break;}
            // }
            // handl.Shutdown(SocketShutdown.Both);
            // handl.Close();
            // // Console.WriteLine(str);
            // }
            // catch (SocketException)
            // {}
            // return str;
        }
    }
}