using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveCameraSample
{
    public static class UpdateData
    {

        public static void UpdateDataYeh(Microsoft.ProjectOxford.Vision.Contract.Tag tag)
        {

            //上传tag
            //await 
            var client = new RestClient("https://prod-33.westus.logic.azure.com:443/workflows/bd0434bd9e094105a9bc2644810bac75/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=24mvSH5194CeGouNg_kIpRxFAMZF7Q3wHYjw1Z83kCE");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Postman-Token", "7fd825d9-f91c-40b2-87ca-a3ff378a160b");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\n\t\"Name\":\"" + tag.Name + "\",\n    \"Confidence\":\"" + tag.Confidence + "\",\n    \"Hint\":\"" + tag.Hint + "\"\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

           
        }


    }
}
