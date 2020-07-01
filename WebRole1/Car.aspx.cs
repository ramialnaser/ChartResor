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
    public partial class Car : Page
    {
        private string accountName = "simpleteststorage";      // YOUR AZURE STORAGE ACCOUNT_NAME";             
        private string accountKey = "U4ujiqjZsKh34YP4dI18u8NbdUFGA3oossZTWNo1BlVAemhK2z50fujczDvIhpBoHHTssIkE0G0TqGZ2Z6b39A==";     // zPie75n + Wcbwr19brs3LNC05ldiv4sDAPLB6ib4 / eVLsYBc20iSULTvRfVlmI2MXBC2SOf1MCaDHv2cihuu4fw ==";     // zPie75n+Wcbwr19bferrs3LNCdiv4sDAPsdLB6ib4/eVLsYBc20iSULTvRfVlmI2MXBC2SOf1MCaDHv2cihuu4fw";   // Write your Azure storage account key here "YOUR_ACCOUNT_KEY";     
        public queue share = new queue();
        public string Fprice;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnPost_Click(object sender, EventArgs e)
        {
            StorageCredentials creds = new StorageCredentials(accountName, accountKey);     //Account and key are already initialized
            CloudStorageAccount storageAccount = new CloudStorageAccount(creds, useHttps: true);

            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient(); //Create an instance of a Cloud QueueClient object to access your queue in the storage

            // Retrieve a reference to a specific queue
            CloudQueue queue = queueClient.GetQueueReference("workercar");

            // Create the queue if it doesn't already exist
            queue.CreateIfNotExists();


            //remove any existing messages (just in case)
            queue.Clear();


            
            share.Passenger = Passenger.Text.ToString();
            share.Model = Model.Text.ToString();
            share.DriverAge = DriverAge.Text.ToString();
            share.DB = DB.Text.ToString();
            

            CloudQueueMessage message0 = new CloudQueueMessage(JsonConvert.SerializeObject(share));
            queue.AddMessage(message0);

            Response.Redirect("Payment.aspx");


        }

       

        protected void cancel(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}