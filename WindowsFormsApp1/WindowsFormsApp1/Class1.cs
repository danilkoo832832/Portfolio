using Discord;
using Discord.Commands;
using Discord.Net.Providers.WS4Net;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLua;
using WindowsFormsApp1;
using System.Collections.Generic;
using BotCommand;

namespace DopModule
{
    class ChatHandler
    {
        static List<Command> commands = new List<Command>();
        Lua lua = new Lua();
        public ChatHandler()
        {
            commands.Add(new Command("Help", "Выводит список команд или описание команды если есть аргументы.",this));
        }
        public async Task ProcessMesage(SocketMessage message)
        {
            
            var _message = message as SocketUserMessage;
            if (_message is null || message.Author.IsBot) return;
            int argPos = 0;
            
            if (_message.HasStringPrefix("|g", ref argPos))
            {
                string text = _message.Content.Substring(3);
                if (text.IndexOf(" ") !=-1) text = text.Substring(0, text.IndexOf(" "));
                //string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (Command com in commands)
                {
                    if (com.name.ToLower() == text)
                    {
                        com.Call(message);
                        break;
                    }
                }
            }
        }

        public async Task Help(SocketMessage message)
        {
            var _message = message as SocketUserMessage;
            string text = _message.Content;
            string output;
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length >= 3)
            {
                foreach (Command com in commands)
                {
                    if (com.name.ToLower() == words[2])
                    {
                        await _message.Channel.SendMessageAsync($"```{com.name} - {com.description}```");
                        break;
                    }
                }
            }
            else
            {
                output = "```\r\n";
                foreach (Command com in commands)
                {
                    if (com.active == true)
                    {
                        output += $"{com.name} - {com.description}\r\n";
                    }
                }
                output += "```";
                await _message.Channel.SendMessageAsync(output);
            }
        }
    }
    static class RCommands
    {

    }
}
