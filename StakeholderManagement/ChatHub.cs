using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Hubs;
using BLLRMS;

namespace StakeholderManagement
{

    public class ChatHub : Hub
    {
        //static List<UserDetail> ConnectedUsers = new List<UserDetail>();
        //static List<MessageDetail> CurrentMessage = new List<MessageDetail>();
        //SqlConnection con;
        DataSet ds;
        DataTable dt;
        BLLFeedback objCHat = new BLLFeedback();
        public string UserImage = "~/assets/images/no-image.gif";
        BLLUserCategory bLLUserCategory = new BLLUserCategory();


        public void Hello()
        {
            Clients.All.hello();
        }
        public class ChatApi
        {




        }

        public string getdetails(string s)
        {
            return "Hi" + s;

        }

        //Co

        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }




        static List<Users> ConnectedUsers = new List<Users>();
        static List<Messages> CurrentMessage = new List<Messages>();
        // ConnClass ConnC = new ConnClass();

        public void Connect(string userName,string UserId)
        {
            var id = Context.ConnectionId;

            if (ConnectedUsers.Count(x => x.ConnectionId == id) == 0)
            {
                string UserImg = GetUserImage(userName);
                string logintime = DateTime.Now.ToString();
                ConnectedUsers.Add(new Users { ConnectionId = id, UserName = userName, UserImage = UserImg, LoginTime = logintime });

                // send to caller
                Clients.Caller.onConnected(id, userName, ConnectedUsers, CurrentMessage);

                // send to all except caller client
                Clients.AllExcept(id).onNewUserConnected(id, userName, UserImg, logintime);


               // GetHistory(UserId);
            }
        }

        public void SendMessageToAll(string UserId,string userName, string message, string time)
        {
            string UserImg = GetUserImage(userName);
            // store last 100 messages in cache
            AddMessageinCache( UserId,userName, message, time, UserImg);

            // Broad cast message
            Clients.All.messageReceived(userName, message, time, UserImg);

        }

        private void AddMessageinCache(string UserId,string userName, string message, string time, string UserImg)
        {
            CurrentMessage.Add(new Messages { UserName = userName, Message = message, Time = time, UserImage = UserImg });

            if (CurrentMessage.Count > 100)
                CurrentMessage.RemoveAt(0);


            objCHat.AddChat(userName, message, UserId);
            // Refresh();
        }


        private void GetHistory(string UserID)
        {
            // Get Chat History from DB. You got to create a DB class to handle this.
            // string History = DB.GetChatHistory(UserID);
            string userName = "";
            string message = "";
            string time = DateTime.Now.ToString();
            string UserImg = null;

            //DataSet dsChat;
            //dsChat = objCHat.GetChat(UserID, 0);

            //if (dsChat.Tables[0].Rows.Count > 0)
            //{

            //    for (int i = 0; i < dsChat.Tables[0].Rows.Count; i++)
            //    {
            //        message = dsChat.Tables[0].Rows[i]["ChatName"].ToString();
            //        userName = dsChat.Tables[0].Rows[i]["UserName"].ToString();

            //        Clients.All.messageReceived(userName, message, time, UserImg);
            //    }
            //}
            //   Clients.Caller.chatHistory(History);
            // Send Chat History to Client. You got to create chatHistory handler in Client side.

        }



        public string GetUserImage(string username)
        {

            if (username == "pmsadmin")
            {
                UserImage = "~/assets/images/dummy.pdf";


            }
            else
            {
                if (username != null)
                {
                    string query = "select UserImageString from HealthUser where fname='" + username + "'";

                    string ImageName = bLLUserCategory.GetQuery(query, "UserImageString");
                    if (ImageName != "")
                        UserImage = "images/DP/" + ImageName;
                }
            }


            return UserImage;



            //{
            //    string RetimgName = "images/dummy.png";
            //    try
            //    {
            //        //string query = "select Photo from tbl_Users where UserName='" + username + "'";
            //        //string ImageName = ConnC.GetColumnVal(query, "Photo");

            //        //if (ImageName != "")
            //        //    RetimgName = "images/DP/" + ImageName;
            //        return RetimgName;
            //    }
            //    catch (Exception ex)
            //    {

            //        return "";
            //    }
        }




        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            var item = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                ConnectedUsers.Remove(item);

                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.UserName);

            }
            return base.OnDisconnected(stopCalled);
        }
    }
}