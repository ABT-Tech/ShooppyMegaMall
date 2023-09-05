using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppite.UI.Helpers
{
    public class CustomerDetails
    {
        public string customer_id { get; set; }
        public string customer_email { get; set; }
        public string customer_phone { get; set; }
    }

    public class CashfreeRequest
    {
        public string order_id { get; set; }
        public decimal order_amount { get; set; }
        public string order_currency { get; set; }
        public CustomerDetails customer_details { get; set; }
    }

    [Serializable]
    public class MerchantParams
    {
        public string merchantId { get; set; }

        public string apiKey { get; set; }

        public string txnId { get; set; } // Merchant Order Number

        public string amount { get; set; }

        public string dateTime { get; set; }

        public string custMail { get; set; }

        public string custMobile { get; set; }

        public string udf1 { get; set; }

        public string udf2 { get; set; }

        public string returnURL { get; set; }

        public string isMultiSettlement { get; set; }

        public string productId { get; set; }

        public string channelId { get; set; }

        public string txnType { get; set; }
        public string udf3 { get; set; } = "NA";
        public string udf4 { get; set; } = "NA";
        public string udf5 { get; set; } = "NA";
        public string instrumentId { get; set; } = "NA";
        public string cardDetails { get; set; } = "NA";
        public string cardType { get; set; } = "NA";
        public string ResellerTxnId { get; set; } = "NA";
        public string Rid { get; set; } = "R0000259";
    }

    public class MerchantResponse
    {
        public string payment_mode { get; set; }
        public string resp_message { get; set; }
        public string udf5 { get; set; }
        public string cust_email_id { get; set; }
        public string udf6 { get; set; }
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
