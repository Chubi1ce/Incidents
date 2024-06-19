using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Numerics;
using System.Reflection.Metadata;
using System.Security.Policy;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Text;
using System.ComponentModel;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Claims;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.ServiceProcess;
using System.Diagnostics;
using Microsoft.VisualBasic.Logging;

namespace Incidents
{
    public partial class FServiceParameters : Form
    {
        static string site = Properties.Settings.Default.Site;
        private static HttpClient httpClient = new HttpClient();
        private HttpRequestMessage request;
        private HttpResponseMessage response;
        public CookieContainer cookies = new CookieContainer();
        public string accessToken, accessExpired_at, refreshToken, refreshExpired_at;
        public string id, username, email, avatar, is_active, first_name, last_name;
        public string responseString;
        ServiceController service;
        string authorFirstName, authorLastName, authorCityName, postContetnt, attention, messageText;
        int incidentNumber, incidentID;
        string pathUtil, pathService;
        List<string> incidendsList = new List<string>();


        public FServiceParameters()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void tbServiceOnOff_CheckedChanged(object sender, EventArgs e)
        {
            service.Refresh();
            try
            {
                if (tbServiceOnOff.Checked && service.Status == ServiceControllerStatus.Stopped)
                {
                    StartIncidetnService();
                }
                if (!tbServiceOnOff.Checked && service.Status == ServiceControllerStatus.Running)
                {
                    StopIncidentService();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                tbServiceOnOff.Checked = false;
            }
        }
        async private void StartIncidetnService()
        {

            string oldLogin = Properties.Settings.Default.Login;
            string oldPassword = Properties.Settings.Default.Password;
            string oldBotToken = Properties.Settings.Default.botToken;
            string oldDialogID = Properties.Settings.Default.dialogID;



            if ((txtLogin.Text != oldLogin) || (txtPassword.Text != oldPassword))
            {
                DialogResult res = MessageBox.Show("������� ������ ���� ��������. ��������� ����� �����?", "���������� ������� ������", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {
                    Properties.Settings.Default.Login = txtLogin.Text;
                    Properties.Settings.Default.Password = txtPassword.Text;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("������� ������ ��� ������ ������ ���������", "���������� ������� ������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                { return; }
            }

            if ((txtBotToken.Text != oldBotToken) || (txtDialogID.Text != oldDialogID))
            {
                DialogResult res = MessageBox.Show("����� ���� ��� ID ������� ���� ��������. ��������� ����� �����?", "���������� ������ Telegram", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {
                    Properties.Settings.Default.botToken = txtBotToken.Text;
                    Properties.Settings.Default.dialogID = txtDialogID.Text;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("������ Telegram ���������", "���������� ������ Telegram", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                { return; }
            }

            await CheckTwoFactorAsyncHTTPClient();
            await LoginAndGetDataAsyncHTTPClient();
            await GetUserDataAsyncHTTPClient();

            try
            {
                DisableFields();
                string[] args = new string[8];
                //args[0] = accessToken;
                args[0] = (udInterval.Value*60000).ToString();
                args[1] = txtBotToken.Text;
                args[2] = txtDialogID.Text;
                args[3] = txtLogin.Text;
                args[4] = txtPassword.Text;
                args[5] = Directory.GetCurrentDirectory() + @"\IncidentsService\bin\Debug\Log.txt";
                args[6] = Directory.GetCurrentDirectory() + @"\IncidentsService\bin\Debug\Incidents.txt";
                args[7] = cbLog.Checked.ToString();


                service.Start(args);
                lblCurrentStatus.Text = "��������";
            }
            catch (Exception)
            {
                EnableFields();
                tbServiceOnOff.Checked = false;
                MessageBox.Show("��� ������� ������ ��������� ������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void StopIncidentService()
        {
            try
            {
                if (service.CanStop)
                {
                    EnableFields();
                    tbServiceOnOff.Checked = false;
                    service.Stop();
                    lblCurrentStatus.Text = "�����������";
                }
            }
            catch (Exception)
            {
                DisableFields();
                tbServiceOnOff.Checked = true;
                MessageBox.Show("��� ��������� ������ ��������� ������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task GetUserDataAsyncHTTPClient()
        {

            string uri = "https://im.gosuslugi.ru/api/accounts/users/me/";

            try
            {
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri))
                {
                    request.Headers.Add("Authorization", $"Token {accessToken}");
                    using (HttpResponseMessage response = await httpClient.SendAsync(request))
                    {

                        responseString = await response.Content.ReadAsStringAsync();
                        var myDeserializedClass = JsonConvert.DeserializeObject<UserInfo>("{\"AllInfo\":[" + responseString + "]}");
                        try
                        {
                            id = myDeserializedClass.AllInfo[0].id;
                            username = myDeserializedClass.AllInfo[0].username;
                            email = myDeserializedClass.AllInfo[0].email;
                            txtEmail.Text = email;
                            avatar = myDeserializedClass.AllInfo[0].avatar;
                            is_active = myDeserializedClass.AllInfo[0].is_active;
                            first_name = myDeserializedClass.AllInfo[0].first_name;
                            last_name = myDeserializedClass.AllInfo[0].last_name;
                            txtUser.Text = $"{last_name}{Environment.NewLine}{first_name}";
                            txtLastCheckTime.Text = DateTime.Now.ToShortDateString();
                            Properties.Settings.Default.LastCheckTime = DateTime.Now;
                            Properties.Settings.Default.Save();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("������ ��� ��������� ������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                System.Windows.Forms.Application.Exit();
            }
        }
        private async Task LoginAndGetDataAsyncHTTPClient()
        {
            string uri = "https://im.gosuslugi.ru/api/token-auth/";
            var data = new Dictionary<string, string>
            {
                { "username", Properties.Settings.Default.Login},
                { "password", Properties.Settings.Default.Password}
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
                        MessageBox.Show("������ ��� ��������� ������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                { "username", Properties.Settings.Default.Login},
                { "password", Properties.Settings.Default.Password}
            };
            var encodedContent = new FormUrlEncodedContent(data);

            // ���������� ������
            using var response = await httpClient.PostAsync(uri, encodedContent);
            // �������� �����
            string responseText = await response.Content.ReadAsStringAsync();
        }

        async private void FServiceParameters_Load(object sender, EventArgs e)
        {
            Start();
            notifyIcon.BalloonTipTitle = "����� ����������� �� ����������";
            notifyIcon.BalloonTipText = service.Status.ToString();
            //notifyIcon.Text = "OK";
        }
        private void Start()
        {
            ServiceControllerStatus? serviceStatus = CheckCerviceStatus();

            txtLogin.Text = Properties.Settings.Default.Login;
            txtPassword.Text = Properties.Settings.Default.Password;
            udInterval.Text = Properties.Settings.Default.Interval;
            txtLastCheckTime.Text = Properties.Settings.Default.LastCheckTime.ToShortDateString();
            txtBotToken.Text = Properties.Settings.Default.botToken;
            txtDialogID.Text = Properties.Settings.Default.dialogID;

            switch (serviceStatus)
            {
                case ServiceControllerStatus.Stopped:
                    lblCurrentStatus.Text = "�����������";
                    tbServiceOnOff.Checked = false;
                    EnableFields();
                    break;
                case ServiceControllerStatus.StartPending: break;
                case ServiceControllerStatus.StopPending: break;
                case ServiceControllerStatus.Running:
                    lblCurrentStatus.Text = "��������";
                    DisableFields();
                    tbServiceOnOff.Checked = true;
                    break;
                case ServiceControllerStatus.ContinuePending: break;
                case ServiceControllerStatus.PausePending: break;
                case ServiceControllerStatus.Paused: break;
                case null:
                    DialogResult result = MessageBox.Show("������ �� �����������.\n��������� ��������� ������?", "������", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.OK)
                    {
                        //await Task.Run(() => { ServiceInstall(); });
                        ServiceInstall();
                        serviceStatus = CheckCerviceStatus();
                        if (serviceStatus != null)
                        {
                            Start();
                        }
                        else
                        {
                            MessageBox.Show("������ ��� ��������� ������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            System.Windows.Forms.Application.Exit();
                        }
                    }
                    else
                    {
                        System.Windows.Forms.Application.Exit();
                    }
                    break;
                default: break;
            }
        }
        private void ServiceStarted()
        {
            DisableFields();
            tbServiceOnOff.Checked = true;
        }
        private ServiceControllerStatus? CheckCerviceStatus()
        {
            service = new ServiceController("IncidentsService");
            try
            {
                switch (service.Status)
                {
                    case ServiceControllerStatus.Stopped:
                        return service.Status;
                    case ServiceControllerStatus.StartPending:
                        return service.Status;
                    case ServiceControllerStatus.StopPending:
                        return service.Status;
                    case ServiceControllerStatus.Running:
                        return service.Status;
                    case ServiceControllerStatus.ContinuePending:
                        return service.Status;
                    case ServiceControllerStatus.PausePending:
                        return service.Status;
                    case ServiceControllerStatus.Paused:
                        return service.Status;
                    default:
                        return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        private void ServiceInstall()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            //string pathUtil = Path.Combine(currentDirectory, "IncidentsService", "InstallUtil");
            //string pathService = Path.Combine(currentDirectory, "IncidentsService", "IncidentsService.exe");

            //string pathUtil = Path.Combine(@"E:\��� ���������\Incidents\IncidentsService\bin\Debug\InstallUtil");
            pathUtil = currentDirectory + @"\IncidentsService\bin\Debug\InstallUtil";
            //string pathUtil = Path.Combine(@"E:\��� ���������\Incidents\Incidents\bin\Debug\net6.0-windows\IncidentsService\InstallUtil");

            //string pathService = Path.Combine(@"E:\��� ���������\Incidents\IncidentsService\bin\Debug\IncidentsService.exe");
            pathService = currentDirectory + @"\IncidentsService\bin\Debug\IncidentsService.exe";
            //string pathService = Path.Combine(@"E:\��� ���������\Incidents\Incidents\bin\Debug\net6.0-windows\IncidentsService\IncidentsService.exe");

            Process serviceInstall = new Process();
            serviceInstall.StartInfo.FileName = "cmd";
            serviceInstall.StartInfo.UseShellExecute = true;
            serviceInstall.StartInfo.Verb = "runas";
            serviceInstall.StartInfo.Arguments = $"/c chcp 65001 & \"{pathUtil}\" \"{pathService}\"";
            serviceInstall.Start();
            serviceInstall.WaitForExit();
        }
        private void DisableFields()
        {
            txtLogin.Enabled = false;
            txtPassword.Enabled = false;
            txtSite.Enabled = false;
            udInterval.Enabled = false;
            txtDialogID.Enabled = false;
            txtBotToken.Enabled = false;
            cbLog.Enabled = false;
        }
        private void EnableFields()
        {
            txtLogin.Enabled = true;
            txtPassword.Enabled = true;
            txtSite.Enabled = true;
            udInterval.Enabled = true;
            txtDialogID.Enabled = true;
            txtBotToken.Enabled = true;
            cbLog.Enabled = true;
        }
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon.Visible = false;
            WindowState = FormWindowState.Normal;
        }
        private void FServiceParameters_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                service.Refresh();
                notifyIcon.BalloonTipText = service.Status.ToString();
                this.Hide();
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(10);
            }
            else if (WindowState == FormWindowState.Normal)
            {
                service.Refresh();
                notifyIcon.BalloonTipText = service.Status.ToString();
                notifyIcon.Visible = false;
            }
        }
        async private void lblLogin_Click(object sender, EventArgs e)
        {
            await CheckTwoFactorAsyncHTTPClient();
            await LoginAndGetDataAsyncHTTPClient();
            await GetUserDataAsyncHTTPClient();
            await GetIncidentsString();
            //AddRecordToLog($"�������� ������-�����\n {responseString}");
            //responseString = System.IO.File.ReadAllText("E:\\��� ���������\\Incidents\\IncidentsService\\bin\\Debug\\1.txt");
            //responseString = System.IO.File.ReadAllText("E:\\��� ���������\\Incidents\\IncidentsService\\bin\\Debug\\3.txt");
            await GetIncidentInfo1(responseString);
            //AddRecordToLog($"���������� ������-����� {responseString}\n");
            await Task.Delay(600);

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
        async private Task GetIncidentInfo(string _responseString)
        {

            string[] incidentNumbers;
            if (Properties.Settings.Default.incidentNumbers != "")
            {
                incidentNumbers = Properties.Settings.Default.incidentNumbers.Split(',');
            }
            else
            {
                incidentNumbers = new string[0];
            }
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
                             Properties.Settings.Default.incidentNumbers = "";
                             Properties.Settings.Default.Save();
                             AddRecordToLog($"��������� �����������\n");
                             return;
                         }
                     }
                     catch (Exception ex)
                     {
                         AddRecordToLog(ex.Message + "\n");
                         AddRecordToLog($"������ ��� ������ ����������\n");
                         return;
                     }

                     for (int i = 0; i < myDeserializedClass.results.Count; i++)
                     {
                         try
                         {
                             incidentID = myDeserializedClass.results[i].id;
                             incidentNumber = myDeserializedClass.results[i].number;
                             authorFirstName = myDeserializedClass.results[i].last_published_post.author.meta_author.first_name;
                             authorLastName = myDeserializedClass.results[i].last_published_post.author.meta_author.last_name;
                             authorCityName = myDeserializedClass.results[0].last_published_post.author.meta_author.geo_tags.city.name;
                             postContetnt = myDeserializedClass.results[i].last_published_post.content;
                             attention = $"�������� ����� �������� ����� {incidentNumber}\n";
                             messageText = $"{authorFirstName} {authorLastName} �� ����������� ������ {authorCityName} ����������:\n";
                             if (!incidentNumbers.Contains(incidentNumber.ToString()))
                             {
                                 newIncidens.Add(incidentNumber.ToString());
                                 HttpClient client = new HttpClient();
                                 client.PostAsync($"https://api.telegram.org/bot6493971849:AAHWNb5GeDKn-qP8rJfPIqYrUTiDWfWPl8o/sendMessage?chat_id=-1002021846019&text=" +
                                                  $"{attention}{messageText}{postContetnt}", null);
                                 AddRecordToLog($"{DateTime.Now} ��������� �������� ����� {incidentNumber}\n");

                             }
                             else
                             { }

                         }
                         catch (Exception)
                         {
                             HttpClient client = new HttpClient();
                             client.PostAsync($"https://api.telegram.org/bot6493971849:AAHWNb5GeDKn-qP8rJfPIqYrUTiDWfWPl8o/sendMessage?chat_id=-1002021846019&text=" +
                                              $"{attention}", null);
                             AddRecordToLog($"{DateTime.Now} ��������� �������� ����� {incidentNumber}\n");
                         }
                     }
                     Properties.Settings.Default.incidentNumbers = string.Join(",", incidentNumbers.Concat(newIncidens.ToArray()));
                     Properties.Settings.Default.Save();
                 }
                );
        }

        async private Task GetIncidentInfo1(string _responseString)
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
                             //if (log == "True")
                             //{ AddRecordToLog($"��������� �����������\n"); }
                             //System.IO.File.WriteAllText(incidentsFile, string.Empty);
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
                             string text = "https://api.telegram.org/bot6493971849:AAHWNb5GeDKn-qP8rJfPIqYrUTiDWfWPl8o/sendMessage?chat_id=-1002021846019&text=" + incidentNumber;
                             client1.PostAsync(text, null);
                             //if (log == "True") AddRecordToLog($"{DateTime.Now} ��������� �������� ����� {incidentNumber}\n");
                             //System.IO.File.AppendAllText(incidentsFile, incidentNumber.ToString() + "\n");
                             incidendsList.Add(incidentNumber.ToString());
                         }
                     }
                 }
                );
        }
        private void AddRecordToLog(string _text)
        {
            System.IO.File.AppendAllText(Path.Combine(@"E:\��� ���������\Incidents\IncidentsService\bin\Debug\Log.txt"), _text);
        }

        private void cbLog_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLog.Checked)
            { lblLog.Text = "�������"; }
            else
            { lblLog.Text = "�� �������"; }
        }
    }
}