using log4net;
using Newtonsoft.Json;
using OpenKHS.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace OpenKHS.Data
{
    public class JsonFileGateway : IDataGateway
    {
        private readonly bool _isRunningFromTest;

        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly string _resourceLocation;

        public JsonFileGateway()
        {
            _resourceLocation = ApplicationData.ResourceLocation;
            _isRunningFromTest = ApplicationData.IsRunningFromTest;
        }
        
        public string Request(Type resource, Methods method, IDictionary<string, object> data)
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

        private string FormatContent(IDictionary<string, object> data)
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
                    response = DeleteJsonFile(resource);
                    break;
            }
            return response;
        }

        private string ReadJsonFile(Type resource)
        {
            var filename = resource.Name;
            var resourceLocation = JsonFullLocation(resource);
            string result;
            try
            {
                using (StreamReader sr = new StreamReader(resourceLocation))
                {
                    result = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException e)
            {
                Log.Error(e.Message);
                throw;
            }
            return result;
        }

        private string WriteJsonFile(Type resource, string content)
        {
            var filename = resource.Name;
            var resourceLocation = JsonFullLocation(resource);
            string result = JsonConvert.SerializeObject(true);
            try
            {
                using (StreamWriter sw = new StreamWriter(resourceLocation))
                {
                    sw.Write(content);
                }
            }
            catch (Exception e)
            {
                // TODO catch anticipated exceptions
                Log.Error(e.Message);
                throw;
            }
            return result;
        }

        private string DeleteJsonFile(Type resource)
        {
            var resourceLocation = JsonFullLocation(resource);
            string result = JsonConvert.SerializeObject(true);
            try
            {
                File.Delete(resourceLocation);
            }
            catch (Exception e)
            {
                // TODO catch anticipated exceptions
                Log.Error(e.Message);
                throw;
            }
            return result;
        }

        private string JsonFullLocation(Type resource)
        {
            return _resourceLocation + resource.Name + GetRunningModeSuffix() + ".json";
        }

        private string GetRunningModeSuffix()
        {
            if (_isRunningFromTest)
            {
                return ".test";
            }
            return string.Empty;
        }
    }
}
