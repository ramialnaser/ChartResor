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
    /*The program starts at this page(Default) which is basically the flight reservation,
     * and from here a client will be able move freely around the program..
     * (From flight to the hotel),(flight to rent a car) or (flight-->hotel and then rent a car).
     * However the program works by first sending the webrole queue from the flight or any
     * page the client is on, the queue will be sent to specific workerrole,
     * then the workerrole will do the needed calculation and return
     * the result by another queue to the payment page, and this process works on all pages.
     * At the payment page, after collecting the results from all queues, the payment then
     * sends them to its workerrole to do the calculation, then fetch the result back to 
     * view it on the page.
     */
    public partial class _Default : Page
    {
        private string accountName = "simpleteststorage";      // YOUR AZURE STORAGE ACCOUNT_NAME";             
        private string accountKey = "U4ujiqjZsKh34YP4dI18u8NbdUFGA3oossZTWNo1BlVAemhK2z50fujczDvIhpBoHHTssIkE0G0TqGZ2Z6b39A==";     // zPie75n + Wcbwr19brs3LNC05ldiv4sDAPLB6ib4 / eVLsYBc20iSULTvRfVlmI2MXBC2SOf1MCaDHv2cihuu4fw ==";     // zPie75n+Wcbwr19bferrs3LNCdiv4sDAPsdLB6ib4/eVLsYBc20iSULTvRfVlmI2MXBC2SOf1MCaDHv2cihuu4fw";   // Write your Azure storage account key here "YOUR_ACCOUNT_KEY";     
        public queue share = new queue();
        public string asd;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        // this method will send the client info the worker.
        //as well as if the client has choosen to move to hotel page or car or both.
        // if the client has choosen both pages, then the program will first go to the hotel page
        // then from the hotel page the client needs to tell if he/she wants to continue to the RentalCar page or not.
        protected void BtnPost_Click(object sender, EventArgs e)
        {
     

                StorageCredentials creds = new StorageCredentials(accountName, accountKey);     //Account and key are already initialized
                CloudStorageAccount storageAccount = new CloudStorageAccount(creds, useHttps: true);

                CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient(); //Create an instance of a Cloud QueueClient object to access your queue in the storage

                // Retrieve a reference to a specific queue
                CloudQueue queue = queueClient.GetQueueReference("worker");

                // Create the queue if it doesn't already exist
                queue.CreateIfNotExists();
                

                //remove any existing messages (just in case)
                queue.Clear();


                    share.From = From.SelectedItem.Value.ToString();
                    share.To = To.SelectedItem.Value.ToString();
                    share.Adult = Textbox1.Text.ToString();
                    share.Student = Textbox2.Text.ToString();
                    share.Infant = Textbox3.Text.ToString();
                    share.Child = Textbox4.Text.ToString();
                   
            CloudQueueMessage message0 = new CloudQueueMessage(JsonConvert.SerializeObject(share));
                    queue.AddMessage(message0);
           
            if (CheckBox1.Checked && CheckBox2.Checked)
            {
              
                Response.Redirect("Hotel.aspx");

            }else if (CheckBox1.Checked)
            {
                Response.Redirect("Hotel.aspx");
            }
            else if  (CheckBox2.Checked)
            {

                Response.Redirect("Car.aspx");

            }
            Response.Redirect("Payment.aspx");
            

        }

    }
}