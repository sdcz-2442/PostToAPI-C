using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using Elasticsearch.Net;
using System.IO;

namespace CtoAPI
{
    class CtoAPI
    {
        static void Main(string[] args)
        {
            try
            {
                List<object> parameters = new List<object>();

                //This are the required parameters for the API I was working on. "Value" is a string with the values the API is going to store. 
                parameters.Add(new
                {
                    Name = "Json",
                    Type = 0,
                    Value = "{\"ReceiveTempCustomer\":\"Prueba0001\",\"NIF\":\"X00000000\", \"Name\":\"Prueba0001\", \"CommercialName\":\"Name\", \"Address\":\"cAddress\", \"CIPCode\":\"00000\",\"CIF\":\"X00000000\", \"City\":\"Barcelona\",\"Province\":\"Barcelona\",\"Country\":\"España\",\"GroupVat\":\"30T//30 dias trasferencia\", \"PaymentType\" : \"90T\", \"CorporateWeb\" : \"clientePrueba.com\",\"NumSocio\" : \"007\",\"DeliveryAddress\" : \"cAddress\",\"DeliveryCIPCode\" : \"08022\", \"DeliveryCity\" : \"Barcelona\",\"DeliveryProvince\":\"Barcelona\",\"ContactPersonC\" : \"PersonaCompras\", \"ContactEmailC\" : \"compras@gmail.com\", \"ContactPhoneC\" : \"999999999\", \"ContactPersonT\" : \"PersonaTienda\", \"ContactEmailT\" : \"tienda@gmail.com\",\"ContactPhoneT\" : \"666666666\", \"ContactPhoneL\" : \"666666666\", \"ContactEmailL\" : \"log@mail.com\", \"ContactPersonL\" : \"PersonaLog\", \"ContactPhoneF\" : \"PersonaF\", \"ContactEmailF\" : \"f@mail.com\", \"ContactPersonF\" : \"PersnaF\"}"
                });

                //This are the credentials for the API
                var Json = new
                {
                    InstanceId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
                    SkillId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
                    Password = "XXXXXXXXXXXXXXXXXXXXX",
                    Parameters = parameters
                };

                //Define type of call we are using
                var request = (HttpWebRequest)WebRequest.Create("https://apiURL"); //Here goes the API url
                request.ContentType = "application/json; charset=utf-8";
                request.Accept = "application/json";
                request.Method = "POST";

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(JsonConvert.SerializeObject(Json));
                    Console.Write(JsonConvert.SerializeObject(Json));
                }


                HttpWebResponse httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        string result = streamReader.ReadToEnd();

                        Console.WriteLine("OK"); 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now.ToString() + " --> " + ex.Message + Environment.NewLine);
            }
        }
    }
}
