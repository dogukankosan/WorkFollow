using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Script.Serialization;

namespace MVCFirmaCagri.CAPTCHA
{
    public class Capt
    {
        public bool Success { get; set; }
        public List<string> ErrorCodes { get; set; }
        public static bool Validate(string encoresponse)
        {
            try
            {
                if (string.IsNullOrEmpty(encoresponse)) return false;
                WebClient client = new WebClient();
                string secret = "6LfrU-sfAAAAAPkp4FXyKoZJiDrWcxMO8owhqBVO";
                if (string.IsNullOrEmpty(secret)) return false;
                string googledow = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, encoresponse));
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                var recap = serializer.Deserialize<Capt>(googledow);
                return recap.Success;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}