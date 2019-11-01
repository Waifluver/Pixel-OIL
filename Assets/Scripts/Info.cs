using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Assets.Scripts
{
    class Info : WebSocketBehavior
    {
        public List<int> infos;
        int i = 0;
        protected override void OnMessage(MessageEventArgs e)
        {
            infos.Add(i++);
            base.OnMessage(e);
        }

        protected override void OnOpen()
        {
            infos.Add(i++);
            base.OnOpen();
        }

        protected override void OnClose(CloseEventArgs e)
        {
            base.OnClose(e);
        }
    }
}
