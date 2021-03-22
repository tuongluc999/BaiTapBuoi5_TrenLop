
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace _5951071055_TuongVanTienLuc
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var request = WebRequest.Create("https://graph.facebook.com/utc2hcmc/posts?access_token=EAAAAZAw4FxQIBAPOIldAkdAyWA2qg5AjZBYyg1xPDuWQSUilxGtWy4gVAt7zsZCTEXE3afJd5GvENHygMqFwyfGyV3H01dPpvUmnaGHvJs92ifFrZCwvioQqOhmtP6O6F2wrg0iSRqEAFHmgRdkrT1aKkoKef9odQtZADDK717AZDZD");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseString = reader.ReadToEnd();
            dynamic jsonData = JsonConvert.DeserializeObject(responseString);
            var results = new List<InforPost>();
            foreach (var item in jsonData.data)
            {
            
                results.Add(new InforPost
                {   
                    Time = item.created_time,
                    Content = item.message,
                    Link = item.actions[0].link,
                });
            }
            string s = "";
            for (int i = 0; i < 3; i++)
            {
                s += "<b>Bài thứ " + (i + 1) + ": </b>" + "</br>";
                s += "<b>Ngày đăng: </b>" + results[i].Time + "</br>";
                s += "<b>Nội dung: </b>" + results[i].Content + "</br>";
                s += "<b> Link bài viết: </b>" + results[i].Link + "</br>";
            }

            lbResult.Text = s;

        }
    }
}