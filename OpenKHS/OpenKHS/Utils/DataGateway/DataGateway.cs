using log4net;
using Newtonsoft.Json;
using OpenKHS.Interfaces;
using System;
using System.IO;

namespace OpenKHS.Utils.DataGateway
{
    public class DataGateway : IDataGateway
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
#if DEBUG
        private readonly string _resourceLocation = "c:\\tmp\\";
#else
        private readonly string _resourceLocation = Properties.Settings.Default.DataResourceLocation;
#endif
        public string Request(Type resource, Methods method, IJsonEncode data)
        {
            Log.Info("Requesting access at " + _resourceLocation);

            var content = FormatContent(data);

            string rawResponse;
            try
            {
                rawResponse = GetRawResponse(resource, method, content);
            }
            catch (Exception e)
            {
                Log.Fatal("Unexpected error accessing gateway. \n" + e.Message);
                throw;
            }
            return rawResponse;
        }

        private string FormatContent(IJsonEncode data)
        {
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            return json;
        }
        
        private string GetRawResponse(Type resource, Methods method, string content)
        {
            string response = "";
            switch (method)
            {
                case Methods.Post:
                    // create
                case Methods.Put:
                    // update
                    response = WriteJsonFile(resource, content);
                    break;
                case Methods.Get:
                    response = ReadJsonFile(resource);
                    break;
                case Methods.Delete:
                    // delete
                    // TODO use real object for success and error
                    response = "{ \"error\":\"Not implemented\" }";
                    break;
            }
            return response;
        }

        private string ReadJsonFile(Type resource)
        {
            var filename = resource.Name;
            string result = JsonConvert.SerializeObject(false);
            try
            {
                using (StreamReader sr = new StreamReader(_resourceLocation + filename + ".json"))
                {
                    result = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                result = JsonConvert.SerializeObject(e.Message);
            }
            return result;
        }

        private string WriteJsonFile(Type resource, string content)
        {
            var filename = resource.Name;
            string result = JsonConvert.SerializeObject(true);
            try
            {
                using (StreamWriter sw = new StreamWriter(_resourceLocation + filename + ".json"))
                {
                    sw.Write(content);
                }
            }
            catch (Exception e)
            {
                result = JsonConvert.SerializeObject(e.Message);
            }
            return result;
        }
    }
}
