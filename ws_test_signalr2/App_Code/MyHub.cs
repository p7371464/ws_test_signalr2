using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

/// <summary>
/// Summary description for MyHub
/// </summary>
public class MyHub : Hub
{
    public MyHub()
    {
        //
        // TODO: Add constructor logic here
        //
        int i = 3;

    }
    public void ServerMethod1(int i)
    {
        //Clients.Gr
        
        Clients.All.ClientMethod1(i + 1);
        //連接識別碼所識別的特定用戶端
        //Clients.Client(Context.ConnectionId).addContosoChatMessageToPage(name, message);
        //Clients.
    }

    public void ServerMethod2()
    {
        Clients.All.ClientMethod2(new MyObj()
        {
            Name = "j",
            Age = 3,
        });
    }

    public String GetConnectionId()
    {
        return Context.ConnectionId;
    }

    public void AddToGroup(String gname)
    {
        Groups.Add(Context.ConnectionId, gname);
    }

    public void RemoveFromGroup(String gname)
    {
        Groups.Remove(Context.ConnectionId,gname);
    }

    public void SendMessageToGroup(String gname, String msg)
    {
        Clients.Group(gname).ReceiveMessageFromGroup(msg);
    }


    //public dynamic GetContext()
    //{
    //    return Context;
    //}


    class MyObj
    {
        public String Name { get; set; }
        public int Age { get; set; }
    }

    public Task<int> TestServerAsync1()
    {
        return Task.Factory.StartNew(() =>
        {
            Thread.Sleep(2000);
            Random r = new Random();
            //return r.Next();
            return 999;
        });
    }
}