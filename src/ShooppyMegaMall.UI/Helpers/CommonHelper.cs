using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using ShooppyMegaMall.Application.Models;
using ShooppyMegaMall.Core.Entities;
using ShooppyMegaMall.Infrastructure.Data;
using ShooppyMegaMall.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShooppyMegaMall.UI.Helpers
{
    public class CommonHelper: ICommonHelper
    {
        protected readonly ShooppyMegaMall_masterContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly ICommonHelper _commonHelper;
        public CommonHelper(ShooppyMegaMall_masterContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }
        public string GetSubDomain(HttpContext httpContext)
        {
            var subDomain = string.Empty;

            var host = httpContext.Request.Host.Host;

            if (!string.IsNullOrWhiteSpace(host))
            {
                subDomain = host.Split('.')[0];
            }

            return subDomain.Trim().ToLower();
        }
        //public string GetSubDomain(Uri url)
        //{
        //    if (url.HostNameType == UriHostNameType.Dns)
        //    {
        //        string host = url.Host;

        //        var nodes = host.Split('.');
        //        int startNode = 0;
        //        if (nodes[0] == "www") startNode = 1;

        //        return string.Format("{0}.{1}", nodes[startNode], nodes[startNode]);
        //    }

        //    return null;
        //}

        public void MyMethod(Microsoft.AspNetCore.Http.HttpContext context)
        {
            var host = $"{context.Request.Scheme}://{context.Request.Host}";
        }

        public int GetOrgID(HttpContext httpContext)
        {
            int orgid = 1;
            var subdomain = GetSubDomain(httpContext);
            if (subdomain.Contains("localhost"))
                orgid = 19;
            else
            {
                LogError(subdomain);
                var orgObject = _dbContext.Organization.Where(x => x.OrgName == subdomain).FirstOrDefault();
                if (orgObject != null)
                    orgid = orgObject.Id;
                else
                    orgid = 0;
            }
            return orgid;

        }
        public void LogError(string msg)
        {
            string logpath = _configuration.GetSection("LogPath")["File"].ToString();
            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message: {0}", msg);
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;          
            string path = logpath +"\\ErrorLog.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }

        public bool DoesPropertyExist(dynamic settings, string name)
        {
            if (settings is ExpandoObject)
                return ((IDictionary<string, object>)settings).ContainsKey(name);

            return settings.GetType().GetProperty(name) != null;
        }

        public Core.Entities.OrganizationAggregatorControl GetMerchantDetails(HttpContext httpContext)
        {
            var orgID = GetOrgID(httpContext);
            var merchantDetails = _dbContext.OrganizationAggregatorControls.Where(x => x.OrgId == orgID).FirstOrDefault();
            return merchantDetails;
        }
        public string DecryptAES256_V3(string cipherText, string _key, string _iv)
        {
            // Instantiate a new Aes object to perform string symmetric encryption
            Aes encryptor = Aes.Create();

            byte[] key = Encoding.ASCII.GetBytes(_key);
            byte[] iv = Encoding.ASCII.GetBytes(_iv);

            encryptor.Mode = CipherMode.CBC;

            // Set key and IV
            encryptor.Key = key;
            encryptor.IV = iv;

            // Instantiate a new MemoryStream object to contain the encrypted bytes
            MemoryStream memoryStream = new MemoryStream();

            // Instantiate a new encryptor from our Aes object
            ICryptoTransform aesDecryptor = encryptor.CreateDecryptor();

            // Instantiate a new CryptoStream object to process the data and write it to the 
            // memory stream
            CryptoStream cryptoStream = new CryptoStream(memoryStream, aesDecryptor, CryptoStreamMode.Write);

            // Will contain decrypted plaintext
            string plainText = String.Empty;

            try
            {
                // Convert the ciphertext string into a byte array
                byte[] cipherBytes = Convert.FromBase64String(cipherText);

                // Decrypt the input ciphertext string
                cryptoStream.Write(cipherBytes, 0, cipherBytes.Length);

                // Complete the decryption process
                cryptoStream.FlushFinalBlock();

                // Convert the decrypted data from a MemoryStream to a byte array
                byte[] plainBytes = memoryStream.ToArray();

                // Convert the decrypted byte array to string
                plainText = Encoding.ASCII.GetString(plainBytes, 0, plainBytes.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // Close both the MemoryStream and the CryptoStream
                memoryStream.Close();
                cryptoStream.Close();
            }

            // Return the decrypted data as a string
            return plainText;
        }

        public string EncryptAES256_V3(string plainText, string _key, string _iv)
        {
            // Instantiate a new Aes object to perform string symmetric encryption
            Aes encryptor = Aes.Create();
            byte[] key = Encoding.ASCII.GetBytes(_key);
            byte[] iv = Encoding.ASCII.GetBytes(_iv);
            encryptor.Mode = CipherMode.CBC;

            // Set key and IV
            encryptor.Key = key;
            encryptor.IV = iv;

            // Instantiate a new MemoryStream object to contain the encrypted bytes
            MemoryStream memoryStream = new MemoryStream();

            // Instantiate a new encryptor from our Aes object
            ICryptoTransform aesEncryptor = encryptor.CreateEncryptor();

            // Instantiate a new CryptoStream object to process the data and write it to the 
            // memory stream
            CryptoStream cryptoStream = new CryptoStream(memoryStream, aesEncryptor, CryptoStreamMode.Write);

            // Convert the plainText string into a byte array
            byte[] plainBytes = Encoding.ASCII.GetBytes(plainText);

            // Encrypt the input plaintext string
            cryptoStream.Write(plainBytes, 0, plainBytes.Length);

            // Complete the encryption process
            cryptoStream.FlushFinalBlock();

            // Convert the encrypted data from a MemoryStream to a byte array
            byte[] cipherBytes = memoryStream.ToArray();

            // Close both the MemoryStream and the CryptoStream
            memoryStream.Close();
            cryptoStream.Close();

            // Convert the encrypted byte array to a base64 encoded string
            string cipherText = Convert.ToBase64String(cipherBytes, 0, cipherBytes.Length);

            // Return the encrypted data as a string
            return cipherText;
        }

        public string OrganizationName(HttpContext httpContext)
        {
            int orgID = GetOrgID(httpContext);
            var orgname = string.Empty;
            var orgObject = _dbContext.Organization.Where(x => x.Id == orgID).FirstOrDefault();
            return orgObject.OrgDescription;
        }

        public Core.Entities.Organization OrganizationDetails(int orgID)
        {
            var orgObject = _dbContext.Organization.Where(x => x.Id == orgID).FirstOrDefault();
            return orgObject;
        }

        public async Task SendWhatsAppMesage(int orderID, string mobileNumber, string orgname , string template)
        {
            try
            {
                var WhatsAppURL = _configuration.GetSection("WhatsAppSettings")["WhatsAppURL"].ToString();
                var APIKey = _configuration.GetSection("WhatsAppSettings")["APIKey"].ToString();
                var templetID = _configuration.GetSection("WhatsAppSettings")[template].ToString();
                var client = new RestClient(WhatsAppURL + "sendnotification");
                var IsTestEnable = _configuration.GetSection("WhatsAppSettings")["IsTest"].ToString();
                var TestMobileNumer = _configuration.GetSection("WhatsAppSettings")["TestMobileNumber"].ToString();
                var request = new RestRequest("Message");
                var MobileNumber = mobileNumber.StartsWith("91") ? mobileNumber : "91" + mobileNumber;
                MobileNumber = IsTestEnable == "1" ? TestMobileNumer : MobileNumber;
                var ordersID = orderID.ToString().PadLeft(5, '0');
                LogError("WhatsApp Request initialize - MobileNumber : " + MobileNumber + ", WhatsAppURL : " + WhatsAppURL + ", ordersID : '" + ordersID + "', Template : "+ templetID + ", orgname :" + orgname + " , APIKEY : " + APIKey);
                string body = "";
                request.AddHeader("API-KEY", APIKey);
                request.AddHeader("Content-Type", "application/json");
                if(template == "order_notify_to_vendor_templateid")
                {
                 body = "{\r\n" + "\"mobile\": \"" + MobileNumber + "\",\"templateid\": \"" + templetID + "\",\"template\":{ \"components\":[{ \"type\":\"body\",\"parameters\":[{ \"type\":\"text\",\"text\":\"" + orgname + "\"},{ \"type\":\"text\",\"text\":\"" + ordersID + "\"}]}]}}";
                 LogError("WhatsApp Request Body - WhatsappRequestBody : " + body);
                }
                if (template == "order_shiping_templateid")
                {
                 body = "{\r\n" + "\"mobile\": \"" + MobileNumber + "\",\"templateid\": \"" + templetID + "\",\"template\":{ \"components\":[{ \"type\":\"body\",\"parameters\":[{ \"type\":\"text\",\"text\":\"" + orgname + "\"},{ \"type\":\"text\",\"text\":\"" + ordersID + "\"}]}]}}";
                 LogError("WhatsApp Request Body - WhatsappRequestBody : " + body);
                }
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                var response = await client.ExecutePostAsync(request);
                LogError("WhatsApp response - StatusCode   :" + response.IsSuccessStatusCode);
                    JObject jObject = JsonConvert.DeserializeObject<JObject>(response.Content);
                    bool status = (bool)jObject["status"];
                    LogError("status : " + status);          
                    WhatsAppMessages whatsApp = new WhatsAppMessages();
                    whatsApp.MobileNumber = MobileNumber;
                    whatsApp.MessageRequest = body;
                    whatsApp.TemplateID = templetID;
                    whatsApp.Is_SendMessage = status;
                    whatsApp.MessageResponse = response.Content;
                    whatsApp.OrgName = orgname;
                    whatsApp.InsertDateTime = DateTime.Now;
                    LogError("WhatsApp Insert Request in Database - MobileNo : " + whatsApp.MobileNumber + ", MessageRequest : " + whatsApp.MessageRequest + ", TemplateID : " + whatsApp.TemplateID + ", Is_SendMessage : " + whatsApp.Is_SendMessage + ", MessageResponse : " + whatsApp.MessageResponse + ", OrgName : " + whatsApp.OrgName + "InsertDateTime : "+ whatsApp.InsertDateTime);
                    await _dbContext.WhatsAppMessages.AddAsync(whatsApp);
                    await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                LogError("WhatsApp Exception - Mobile Number : " + mobileNumber+ ", Template : "+ template + ", Message : "+ ex.Message + ", Stack Trace : " + ex.StackTrace);
            }
        }
    }
}
