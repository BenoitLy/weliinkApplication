using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WeliinkApplication
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
            InitializeComponent();

            try
            {
                string url = "http://weliink.fr/post/api.php";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET/POST";
                //using GET - request.Headers.Add ("Authorization","Authorizaation value");
                request.ContentType = "application/json";
                HttpWebResponse myResp = (HttpWebResponse)request.GetResponse();
                string responseText;

                using (var response = request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseText = reader.ReadToEnd();
                        //Console.WriteLine(responseText);
                        Name.Text = responseText;
                    }
                }
            }

            catch (WebException exception)
            {
                string responseText;
                using (var reader = new StreamReader(exception.Response.GetResponseStream()))
                {
                    responseText = reader.ReadToEnd();
                    Console.WriteLine(responseText);
                    Name.Text = responseText;
                }
            }
        }
    }
}
