using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class TCPClient : MonoBehaviour
{
    TCP tcp;
    GameObject character;
    const int PORT = 26;
    const string IpAddress = "192.168.137.183";
    void Start()
    {
        tcp = new TCP();
        tcp.Begin(IpAddress, PORT);
        character = GameObject.Find("Character");
        
    }

    // Update is called once per frame
    void Update()
    {
        string data = tcp.readStr;

        if (!tcp.IsConnected)
        {
            tcp.StopTcpActivity();
            tcp.Begin(IpAddress, PORT);
        }
        else
        {
            bool stringNumerical = int.TryParse(data, out _);
            if (stringNumerical)
            {

            }
            else
            {
                switch (data)
                {
                    case "TOO LOUD":
                        character.GetComponent<Animator>().SetBool("IsAngry", true);
                        break;
                    case "FINE":
                        character.GetComponent<Animator>().SetBool("IsAngry", false);
                        break;
                }

            }
        }
    }

    private void OnApplicationQuit()
    {
        tcp.StopTcpActivity();
    }
}
