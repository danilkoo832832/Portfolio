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
using DopModule;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            RunBotAsync();
            

        }

        DiscordSocketClient client;
        ChatHandler chatHandler = new ChatHandler();
        CommandService command;
        IServiceProvider service;
        public async Task RunBotAsync()
        {
            client = new DiscordSocketClient(new DiscordSocketConfig
            { WebSocketProvider = WS4NetProvider.Instance });
            command = new CommandService();
            service = new ServiceCollection()
                .AddSingleton(client)
                .AddSingleton(command)
                .BuildServiceProvider();

            client.Log += Log;
            client.MessageReceived += chatHandler.ProcessMesage;

            await command.AddModulesAsync(Assembly.GetEntryAssembly(), service);

            string token = "OOOOOOOOOOOOOOOOOOOOOOOPS";
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());

            return Task.CompletedTask;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
    public class Her
    {
        public int i;
        public Her(int i)
        {
            this.i = i;
        }
        public void Herplus()
        {
            this.i++;
        }
    }
}
