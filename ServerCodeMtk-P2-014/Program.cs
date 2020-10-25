using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ServiceMtk_P1_014;
using System.ServiceModel.Description;
using System.ServiceModel.Channels; //mex

namespace ServerCodeMtk_P2_014
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost hostObj = null;
            Uri address = new Uri("http://localhost:8888/Matematika");
            BasicHttpBinding bind = new BasicHttpBinding();
            try
            {
                hostObj = new ServiceHost(typeof(Matematika), address);
                //ALAMAT BASE ADDRESS
                hostObj.AddServiceEndpoint(typeof(IMatematika), bind, "");
                //ALAMAT ENDPOINT
                //wsdl
                ServiceMetadataBehavior smb = new
               ServiceMetadataBehavior(); //Service Runtime Player
                smb.HttpGetEnabled = true; //untuk mengaktifkan wsdl 
                //(dibuka saat development, tidak untuk dibuka)
                hostObj.Description.Behaviors.Add(smb);
                //mex
                Binding mexbind =
               MetadataExchangeBindings.CreateMexHttpBinding();
                hostObj.AddServiceEndpoint(typeof(IMetadataExchange),
               mexbind, "mex");
                hostObj.Open();
                Console.WriteLine("Server is ready!!!!");
                Console.ReadLine();
                hostObj.Close();
            }
            catch (Exception ex)
            {
                hostObj = null;
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
