using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Drawing
{


    // Hub
    public class DrawHub : Hub
    {

        public class Point
        {
            public double X { get; set; }
            public double Y { get; set; }
        }
        // Class needed
        // public class DrawObject
        // {
        //     public string Id { get; set; }
        //     public string type { get; set; }
        //     public string Color { get; set; }
        //     public int Size { get; set; }
        //     public string Fill { get; set; }
        //     public List<Point> points { get; set; }
        // }

        public class Command
        {
            public string Name { get; set; }
            public object[] Param { get; set; }
            // public Command(string name, object[] param){
            //     Name = name;
            //     Param = param;
            // }
            public Command(string name, object[] param) => (Name, Param) = (name, param);

        }


        // public async Task SendLine(Point a, Point b, int size, string color)
        // {
        //     commands.Add(new Command("drawLine", new Object[] { a, b, size, color }));
        //     await Clients.Others.SendAsync("ReceiveLine", a, b, size, color);
        // }

        // public async Task SendCurve(Point a, Point b, Point c, int size, string color)
        // {
        //     commands.Add(new Command("drawCurve", new Object[] { a, b, c, size, color }));
        //     await Clients.Others.SendAsync("ReceiveCurve", a, b, c, size, color);
        // }

        // public async Task SendImage(string url)
        // {
        //     commands.Clear();
        //     commands.Add(new Command("drawImage", new Object[] { url }));
        //     await Clients.Others.SendAsync("ReceiveImage", url);
        // }
        // public async Task SendClear()
        // {
        //     commands.Clear();
        //     await Clients.Others.SendAsync("ReceiveClear");
        // }
        private static List<Command> commands = new List<Command>();

        public async Task StartDraw(string id, Point point, string color, string size)
        {
            // commands.Add(new Command("startDraw", new Object[] { id, point, color, size }));
            await Clients.Others.SendAsync("StartDraw", id, point, color, size);
        }
        public async Task Draw(string id, Point pointA, Point pointB)
        {
            // commands.Add(new Command("Draw", new Object[] { id, pointA, pointB }));
            await Clients.Others.SendAsync("Draw", id, pointA, pointB);
        }

        public async Task StartRect(string id, Point point, string color,string size){
            await Clients.Others.SendAsync("StartRect", id, point, color,size);
        }
        public async Task DrawRect(string id, Point point, Point box){
            await Clients.Others.SendAsync("DrawRect", id, point, box);
        }
        public async Task StartCircle(string id, Point point, string color,string size){
            await Clients.Others.SendAsync("StartCircle", id, point, color,size);
        }
        public async Task DrawCircle(string id, Point point, Point box){
            await Clients.Others.SendAsync("DrawCircle", id, point, box);
        }
        // function drawLine(id,point,point2,color,size)
        public async Task DrawLine(string id,Point point,Point point2,string color,string size)
        {
            await Clients.Others.SendAsync("DrawLine", id, point, point2,color,size);
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }
    }
}