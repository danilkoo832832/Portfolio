using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BotCommand
{
    public class Command
    {
        public bool active { get; private set; }
        public string name{ get; }
        public string description { get; private set; }
        object obj;
        MethodInfo method;

        public Command(string NameCommand,string descrpt, object Obj)
        {
            this.obj = Obj;
            this.method = Obj.GetType().GetMethod(NameCommand);
            this.name = NameCommand;
            this.description = descrpt;
            active = true;
        }
        public Command(string NameCommand, object Obj)
        {
            this.obj = Obj;
            this.method = Obj.GetType().GetMethod(NameCommand);
            this.name = NameCommand;
        }

        public void Activate() => active = true;
        public void Deactivate() => active = false;
        public void SetDescription(string descrpt) => this.description = descrpt;
        public void Call(SocketMessage message)
        {
            if (this.active) this.method.Invoke(obj, new object[] { message });
        }
    }
}
