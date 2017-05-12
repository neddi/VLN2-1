using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ProgramWeb.Hubs
{
    public class CodeEditorHub : Hub
    {
        public void UpdateContent(int fileID, string content)
        {
            Clients.All.UpdateContent(fileID, content);
        }
    }
}