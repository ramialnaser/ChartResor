using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure;
using System.Diagnostics;
using Newtonsoft.Json;

namespace WebRole1
{
    public partial class Payment : Page
    {
        private string accountName = "simpleteststorage";      // YOUR AZURE STORAGE ACCOUNT_NAME";             
        private string accountKey = "U4ujiqjZsKh34YP4dI18u8NbdUFGA3oossZTWNo1BlVAemhK2z50fujczDvIhpBoHHTssIkE0G0TqGZ2Z6b39A==";     // zPie75n + Wcbwr19brs3LNC05ldiv4sDAPLB6ib4 / eVLsYBc20iSULTvRfVlmI2MXBC2SOf1MCaDHv2cihuu4fw ==";     // zPie75n+Wcbwr19bferrs3LNCdiv4sDAPsdLB6ib4/eVLsYBc20iSULTvRfVlmI2MXBC2SOf1MCaDHv2cihuu4fw";   // Write your Azure storage account key here "YOUR_ACCOUNT_KEY";     
        public queue share = new queue();
       
        protected void Page_Load(object sender, EventArgs e)
        {
           
            
        }


        protected void BtnGet_Click(object sender, EventArgs e)
        {
            StorageCredentials creds = new StorageCredentials(accountName, accountKey);
            CloudStorageAccount storageAccount = new CloudStorageAccount(creds, useHttps: true);
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            // Retrieve a reference to a queue
            CloudQueue queue = queueClient.GetQueueReference("web");
            CloudQueue queue2 = queueClient.GetQueueReference("webhotel");
            CloudQueue queue3 = queueClient.GetQueueReference("webcar");
            // Create the queue if it doesn't already exist
            // queue.CreateIfNotExists();

            // retrieve the next message
            CloudQueueMessage readMessage = queue.GetMessage();
            CloudQueueMessage readMessage2 = queue2.GetMessage();
            CloudQueueMessage readMessage3 = queue3.GetMessage();
            int i = 0;
            // Display message (populate the textbox with the message you just retrieved.
            if (readMessage != null)
            {
                queue queuet = JsonConvert.DeserializeObject<queue>(readMessage.AsString);
                
                 i = Convert.ToInt32(queuet.FlightPrice) ;
                share.FlightPrice = queuet.FlightPrice;
                        queue.DeleteMessage(readMessage);

            }
            if (readMessage2 != null)
            {
                queue queuet2 = JsonConvert.DeserializeObject<queue>(readMessage2.AsString);
                i = i+Convert.ToInt32(queuet2.HotelPrice);
                share.FlightPrice = queuet2.HotelPrice;
                queue2.DeleteMessage(readMessage2);
            }
            if (readMessage3 != null)
            {
                queue queuet3 = JsonConvert.DeserializeObject<queue>(readMessage3.AsString);
                
                i = i + Convert.ToInt32(queuet3.RentPrice);
                share.FlightPrice = queuet3.RentPrice;
                queue3.DeleteMessage(readMessage3);
            }

            price.Text = Convert.ToString(i);
           post();
           

        }
        public void post()
        {
            StorageCredentials creds = new StorageCredentials(accountName, accountKey);    
            CloudStorageAccount storageAccount = new CloudStorageAccount(creds, useHttps: true);

            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            // Retrieve a reference to a specific queue
            CloudQueue queue = queueClient.GetQueueReference("workerpayment");

            // Create the queue if it doesn't already exist
            queue.CreateIfNotExists();

            //remove any existing messages (just in case)
            queue.Clear();

            CloudQueueMessage message0 = new CloudQueueMessage(JsonConvert.SerializeObject(share));
            queue.AddMessage(message0);
            get();
        }
        public void get()
        {
            StorageCredentials creds = new StorageCredentials(accountName, accountKey);
            CloudStorageAccount storageAccount = new CloudStorageAccount(creds, useHttps: true);
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            // Retrieve a reference to a queue
            CloudQueue queue = queueClient.GetQueueReference("webpayment");

            // Create the queue if it doesn't already exist
            queue.CreateIfNotExists();

            // retrieve the next message
            CloudQueueMessage readMessage = queue.GetMessage();


            // Display message (populate the textbox with the message you just retrieved.
            if (readMessage != null)
            {
                queue queuet = JsonConvert.DeserializeObject<queue>(readMessage.AsString);

                queue.DeleteMessage(readMessage);

            }
        }
    }

    }
