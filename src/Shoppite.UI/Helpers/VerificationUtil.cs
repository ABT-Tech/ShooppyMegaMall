using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Shoppite.UI.Helpers
{
    public class VerificationUtil
    {
        public VerificationResponse VerificationCall(String sURL, String data)
        {
            //JavaScriptSerializer ser = new JavaScriptSerializer();
            VerificationResponse resp = new VerificationResponse();
            var requestJson = string.Empty;
            try
            {
                string requestUrl = sURL + "?" + data;
                Console.WriteLine(":: Verify URL : " + requestUrl);
                HttpResponseMessage response;

                using (var handler = new HttpClientHandler())
                using (var client = new HttpClient(handler))
                {
                    using (var content = new StringContent(requestJson, Encoding.Unicode, "application/json"))
                    {
                        client.Timeout = TimeSpan.FromMinutes(5);
                        //client.DefaultRequestHeaders.Add(Common.AuthenticateHeaderKey, Settings.AppAuthKey);
                        response = client.PostAsync(new Uri(requestUrl), content).Result;
                    }
                }

                Console.WriteLine("Verification call HTTP response code " + (short)response.StatusCode);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(":: HTTP OK");
                    var responseResult = response.Content.ReadAsStringAsync();
                    responseResult.Wait();
                    var result = responseResult.Result;
                    Console.WriteLine(":: Response : " + result);
                    resp = JsonConvert.DeserializeObject<VerificationResponse>(result);

                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (ex.InnerException != null)
                    Console.WriteLine(":: Error Occurred while Processing Request : " + ex.InnerException.Message);
                else
                    Console.WriteLine(":: Error Occurred while Processing Request : " + ex.Message);
                Console.ResetColor();
            }
            return resp;
        }
    }


    public class VerificationResponse
    {
        public string payment_mode { get; set; }
        public string resp_message { get; set; }
        public string udf5 { get; set; }
        public string cust_email_id { get; set; }
        public string udf3 { get; set; }
        public string merchant_id { get; set; }
        public string txn_amount { get; set; }
        public string udf4 { get; set; }
        public string udf1 { get; set; }
        public string udf2 { get; set; }
        public string pg_ref_id { get; set; }
        public string txn_id { get; set; }
        public string resp_date_time { get; set; }
        public string bank_ref_id { get; set; }
        public string resp_code { get; set; }
        public string txn_date_time { get; set; }
        public string trans_status { get; set; }
        public string cust_mobile_no { get; set; }
    }

    public class PayproceesResponseClass
    {
        public string payment_mode { get; set; }
        public string resp_message { get; set; }
        public string udf5 { get; set; }
        public string cust_email_id { get; set; }
        public string udf3 { get; set; }
        public string merchant_id { get; set; }
        public string txn_amount { get; set; }
        public string udf4 { get; set; }
        public string udf1 { get; set; }
        public string udf2 { get; set; }
        public string pg_ref_id { get; set; }
        public string txn_id { get; set; }
        public string resp_date_time { get; set; }
        public string bank_ref_id { get; set; }
        public string resp_code { get; set; }
        public string txn_date_time { get; set; }
        public string trans_status { get; set; }
        public string cust_mobile_no { get; set; }
    }
}
