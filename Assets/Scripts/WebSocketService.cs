using System.Collections;
using System.Collections.Generic;
using WebSocketSharp.Server;
using WebSocketSharp;
using UnityEngine;
using Assets.Scripts;

public class WebSocketService : MonoBehaviour
{
    List<int> info;
    void Start()
    {
        WebSocketServer webSocketServer = new WebSocketServer("ws://localhost:8095");
        webSocketServer.AddWebSocketService<Info>("/Info", () => new Info{infos = this.info });
            

        
     //   webSocketServer.Start();

        //using (WebSocket ws = new WebSocket("ws://localhost:8095/Info"))
        //{
        //    ws.Connect();
        //    ws.Send("Hey Jongeman!");
        //}


        //using (WebSocket ws = new WebSocket("ws://localhost:8000"))
        //{
        //    ws.OnMessage += (sender, e) =>
        //    {
        //        if (e.IsText)
        //        {

        //        }
        //    };
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
