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
    public partial class _Default : Page
    {
        private string accountName = "simpleteststorage";      // YOUR AZURE STORAGE ACCOUNT_NAME";             
        private string accountKey = "U4ujiqjZsKh34YP4dI18u8NbdUFGA3oossZTWNo1BlVAemhK2z50fujczDvIhpBoHHTssIkE0G0TqGZ2Z6b39A==";     // zPie75n + Wcbwr19brs3LNC05ldiv4sDAPLB6ib4 / eVLsYBc20iSULTvRfVlmI2MXBC2SOf1MCaDHv2cihuu4fw ==";     // zPie75n+Wcbwr19bferrs3LNCdiv4sDAPsdLB6ib4/eVLsYBc20iSULTvRfVlmI2MXBC2SOf1MCaDHv2cihuu4fw";   // Write your Azure storage account key here "YOUR_ACCOUNT_KEY";     
        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BtnPost_Click()
        {
     

                StorageCredentials creds = new StorageCredentials(accountName, accountKey);     //Account and key are already initialized
                CloudStorageAccount storageAccount = new CloudStorageAccount(creds, useHttps: true);

                CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient(); //Create an instance of a Cloud QueueClient object to access your queue in the storage

                // Retrieve a reference to a specific queue
                CloudQueue queue = queueClient.GetQueueReference("workerqueue");

                // Create the queue if it doesn't already exist
                queue.CreateIfNotExists();
                queue queuet = new queue();

                //remove any existing messages (just in case)
                queue.Clear();
                 id = id+1;
                
                queuet.From = From.SelectedItem.Value.ToString();
                queuet.To = To.SelectedItem.Value.ToString();
                queuet.Adult = Textbox1.Text.ToString();
                queuet.Student = Textbox2.Text.ToString();
                queuet.Infant = Textbox3.Text.ToString();
                queuet.Child = Textbox4.Text.ToString();

                CloudQueueMessage message0 = new CloudQueueMessage(JsonConvert.SerializeObject(queuet));
                queue.AddMessage(message0);
              
        }

        protected void BtnGet_Click(object sender, EventArgs e)
        {
            BtnPost_Click();
            //Refer to the comments in the BtnPost_Click() method 
            StorageCredentials creds = new StorageCredentials(accountName, accountKey);
            CloudStorageAccount storageAccount = new CloudStorageAccount(creds, useHttps: true);
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            
            // Retrieve a reference to a queue
            CloudQueue queue =  queueClient.GetQueueReference("webqueue");
          
                // Create the queue if it doesn't already exist
                queue.CreateIfNotExists();
                
                // retrieve the next message
                CloudQueueMessage readMessage = queue.GetMessage();


                // Display message (populate the textbox with the message you just retrieved.
                if (readMessage != null) {
                    queue queuet = JsonConvert.DeserializeObject<queue>(readMessage.AsString);
                    if ( queuet.Id ==id)
                    {
                    
                        queue.DeleteMessage(readMessage);
                        Textbox5.Text = queuet.Price;
                    }
                    
                }
                
                //Delete the message just read to avoid reading it over and over again
            
        }

    }
}