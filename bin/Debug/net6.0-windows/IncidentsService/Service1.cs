using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using static System.Net.Mime.MediaTypeNames;

namespace IncidentsService
{
    public partial class Service1 : ServiceBase
    {
        string login, password, botToken, dialogID;
        public CookieContainer cookies = new CookieContainer();
        public string id, username, email, avatar, is_active, first_name, last_name;
        public int interval, incidentID, incidentNumber;
        public string authorFirstName, authorLastName, authorCityName, postContetnt;
        string attention, messageText, incidentLink;
        public string responseString;
        List<string> incidendsList = new List<string>();
        public string accessToken, accessExpired_at, refreshToken, refreshExpired_at, log;
        //string logFile = @"E:\Мои документы\Incidents\IncidentsService\bin\Debug\Log.txt";
        //string incidentsFile = @"E:\Мои документы\Incidents\IncidentsService\bin\Debug\Incidents.txt";
        string logFile, incidentsFile;
        HttpClient httpClient = new HttpClient();


        public Service1()
        {
            InitializeComponent();
        }
        async protected override void OnStart(string[] args)
        {
            //login = args[0];60000
            //password = args[1];
            //site = args[2];
            //interval = args[3];
            //accessToken = args[0];
            interval = Convert.ToInt32(args[0]);
            botToken = args[1];
            dialogID = args[2];
            login = args[3];
            password = args[4];
            logFile = args[5];
            incidentsFile = args[6];
            log = args[7];

            if (log == "True")
                AddRecordToLog($"служба запущена\n");
            using (StreamReader read = new StreamReader(incidentsFile))
                    while (!read.EndOfStream)
                    incidendsList.Add(read.ReadLine());
            while (true)
            {
                try
                {
                    await CheckTwoFactorAsyncHTTPClient();
                    await LoginAndGetDataAsyncHTTPClient();
                    await GetIncidentsString();
                    await GetIncidentInfo(responseString);
                    await Task.Delay(interval);
                }
                catch (Exception)
                {}
            }
        }
        async private Task GetIncidentInfo(string _responseString)
        {
            List<string> newIncidens = new List<string>();
            await Task.Run
                (
                 () =>
                 {
                     Root myDeserializedClass = null;
                     try
                     {
                         myDeserializedClass = JsonConvert.DeserializeObject<Root>(_responseString);
                         if (myDeserializedClass.results.Count == 0)
                         {
                             if (log== "True")
                                {AddRecordToLog($"инциденты отсутствуют\n");}
                             System.IO.File.WriteAllText(incidentsFile, string.Empty);
                             return;
                         }
                     }
                     catch (Exception ex)
                     {
                         return;
                     }

                     HttpClient client1 = new HttpClient();
                     for (int i = 0; i < myDeserializedClass.results.Count; i++)
                     {
                         incidentNumber = myDeserializedClass.results[i].number;
                         if (incidendsList.Contains(incidentNumber.ToString()))
                         {
                             continue;
                         }
                         else
                         {
                             AddRecordToLog($"пишу инфу в телегу\n");

                             string text = "https://api.telegram.org/bot6493971849:AAHWNb5GeDKn-qP8rJfPIqYrUTiDWfWPl8o/sendMessage?chat_id=-1002021846019&text=" + 
                             $"{DateTime.Now} обнаружен инцидент номер {incidentNumber}";
                             AddRecordToLog($"{text}\n");

                             client1.PostAsync(text, null);
                             if (log == "True")
                                 AddRecordToLog($"{DateTime.Now} обнаружен инцидент номер {incidentNumber}\n");
                             System.IO.File.AppendAllText(incidentsFile, incidentNumber.ToString() + "\n");
                             incidendsList.Add(incidentNumber.ToString());
                         }
                     }
                 }
                );
        }
        async private Task GetIncidentsString()
        {
            string uri = "https://im.gosuslugi.ru/api/inc/incidents/?offset=0&limit=10&ordering=-current_stage_term&current_stage=3&workflow=317";
            HttpRequestMessage request;
            try
            {
                using (request = new HttpRequestMessage(HttpMethod.Get, uri))
                {
                    request.Headers.Add("Authorization", $"Token {accessToken}");
                    using (HttpResponseMessage response = await httpClient.SendAsync(request))
                    {
                        responseString = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                System.Windows.Forms.Application.Exit();
            }
        }
        private async Task CheckTwoFactorAsyncHTTPClient()
        {
            Uri uri = new Uri("https://im.gosuslugi.ru/api/check-two-factor/");
            var data = new Dictionary<string, string>
            {
                { "username", login},
                { "password", password}
            };
            var encodedContent = new FormUrlEncodedContent(data);

            // отправляем запрос
            var response = await httpClient.PostAsync(uri, encodedContent);
            // получаем ответ
            string responseText = await response.Content.ReadAsStringAsync();
        }
        private async Task LoginAndGetDataAsyncHTTPClient()
        {
            string uri = "https://im.gosuslugi.ru/api/token-auth/";
            var data = new Dictionary<string, string>
            {
                { "username", login},
                { "password", password}
            };
            var encodedContent = new FormUrlEncodedContent(data);


            try
            {
                using (var response = await httpClient.PostAsync(uri, encodedContent))
                {
                    string responseText = await response.Content.ReadAsStringAsync();

                    var myDeserializedClass = JsonConvert.DeserializeObject<RootTokens>("{\"Tokens\":[" + responseText + "]}");
                    try
                    {
                        accessToken = myDeserializedClass.Tokens[0].access.token;
                        accessExpired_at = myDeserializedClass.Tokens[0].access.expired_at;
                        refreshToken = myDeserializedClass.Tokens[0].refresh.token;
                        refreshExpired_at = myDeserializedClass.Tokens[0].refresh.expired_at;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка при получении токена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                System.Windows.Forms.Application.Exit();
            }
        }
        private void AddRecordToLog(string _text)
        {
            System.IO.File.AppendAllText(logFile, DateTime.Now + " " + _text);
        }

    }
}


