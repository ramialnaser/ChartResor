using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using WebRole1;

namespace WorkerRole1
{
    public class WorkerRole : RoleEntryPoint
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent runCompleteEvent = new ManualResetEvent(false);

        private string accountName = "simpleteststorage";      // YOUR AZURE STORAGE ACCOUNT_NAME";             
        private string accountKey = "U4ujiqjZsKh34YP4dI18u8NbdUFGA3oossZTWNo1BlVAemhK2z50fujczDvIhpBoHHTssIkE0G0TqGZ2Z6b39A==";     // zPie75n + Wcbwr19brs3LNC05ldiv4sDAPLB6ib4 / eVLsYBc20iSULTvRfVlmI2MXBC2SOf1MCaDHv2cihuu4fw ==";     // zPie75n+Wcbwr19bferrs3LNCdiv4sDAPsdLB6ib4/eVLsYBc20iSULTvRfVlmI2MXBC2SOf1MCaDHv2cihuu4fw";   // Write your Azure storage account key here "YOUR_ACCOUNT_KEY";     
        private StorageCredentials creds;
        private CloudStorageAccount storageAccount;
        private CloudQueueClient queueClient;
        private CloudQueue inqueue, outqueue;
        private CloudQueueMessage inMessage, outMessage;
        
        //the following method is called at the start of the worker role to get instances of incoming and outgoing queues 
        private void initQueue()
        {
                 

            creds = new StorageCredentials(accountName, accountKey);
            storageAccount = new CloudStorageAccount(creds, useHttps: true);

            // Create the queue client
            queueClient = storageAccount.CreateCloudQueueClient();

            // Retrieve a reference to a queue
            inqueue = queueClient.GetQueueReference("worker");

            // Create the queue if it doesn't already exist
            inqueue.CreateIfNotExists();

            // Retrieve a reference to a queue
            outqueue = queueClient.GetQueueReference("web");

            // Create the queue if it doesn't already exist
            outqueue.CreateIfNotExists();
        }

        public override void Run()
        {
            Trace.TraceInformation("WorkerRole1 is running");

            try
            {
                this.RunAsync(this.cancellationTokenSource.Token).Wait();
            }
            catch (Exception e) {; }
            finally
            {
                this.runCompleteEvent.Set();
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at https://go.microsoft.com/fwlink/?LinkId=166357.

            bool result = base.OnStart();

            Trace.TraceInformation("WorkerRole1 has been started");

            return result;
        }

        public override void OnStop()
        {
            Trace.TraceInformation("WorkerRole1 is stopping");

            this.cancellationTokenSource.Cancel();
            this.runCompleteEvent.WaitOne();

            base.OnStop();

            Trace.TraceInformation("WorkerRole1 has stopped");
        }

        private async Task RunAsync(CancellationToken cancellationToken)
        {
            // TODO: Replace the following with your own logic.
            initQueue();        //call the queue initialization method

            while (!cancellationToken.IsCancellationRequested)
            {
                // Async dequeue (read) the message
                inMessage = await inqueue.GetMessageAsync();    //not an optimal way to retrieve a message from a queue, but works
                if (inMessage != null)
                {
                    //convert the message to string, parse it, perform your business logic here, etc.
                   

                    queue queuet = JsonConvert.DeserializeObject<queue>(inMessage.AsString);

                   
                        outMessage = new CloudQueueMessage(JsonConvert.SerializeObject(cal(queuet)));
                        
                        outqueue.AddMessage(outMessage);
                        await inqueue.DeleteMessageAsync(inMessage);
                    
                    await Task.Delay(1000);

                }
            }
        }
        public queue cal(queue strlist)
        {
            int CPHDXB = 100;
            int DXBCPH = 200;

            double student = 0.25;
            double infant = 0.9;
            double child = 0.33;

            string re = null;

            if (strlist.From == "CPH" && strlist.To == "DXB")
            {
                
                   re= Convert.ToString(CPHDXB *Convert.ToInt32(strlist.Adult)+ 
                      (CPHDXB - (CPHDXB * student)) * Convert.ToInt32(strlist.Student)
                        + (CPHDXB - (CPHDXB * infant)) * Convert.ToInt32(strlist.Infant)+ 
                        (CPHDXB - (CPHDXB * child)) * Convert.ToInt32(strlist.Child));
               
                

            }else if (strlist.From == "DXB" && strlist.To == "CPH")
            {
                re = Convert.ToString(DXBCPH * Convert.ToInt32(strlist.Adult) +
                      (DXBCPH - (DXBCPH * student)) * Convert.ToInt32(strlist.Student)
                        + (DXBCPH - (DXBCPH * infant)) * Convert.ToInt32(strlist.Infant) +
                        (DXBCPH - (DXBCPH * child)) * Convert.ToInt32(strlist.Child));
            }


            strlist.FlightPrice = re;

            return strlist;
        }
    
        
    }
}
