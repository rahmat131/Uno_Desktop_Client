using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace UNO_Desktop_Client
{
    public partial class Form1 : Form
    {
        bool bRlA = false;
        bool bRlB = false;
        bool bRlC = false;
        bool bRlD = false;
        bool bRlE = false;
        string htmlData = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bRlA = !bRlA;
            if (bRlA == true)
            {
                WebRequest request = WebRequest.Create(
             "http://192.168.1.177/Lamp1ON");
                WebResponse response = request.GetResponse();
                Stream webStream = response.GetResponseStream();
                StreamReader webReader = new StreamReader(webStream);
                htmlData = webReader.ReadToEnd();
                textBox1.Text = htmlData;
                response.Close();

                pictureBox1.Image = UNO_Desktop_Client.Properties.Resources.stylish_off;
                pictureBox6.Image = UNO_Desktop_Client.Properties.Resources.lightbulb_on;

            }

            if (bRlA == false)
            {
                WebRequest request = WebRequest.Create(
              "http://192.168.1.177/Lamp1Off");
                WebResponse response = request.GetResponse();
                Stream webStream = response.GetResponseStream();
                StreamReader webReader = new StreamReader(webStream);
                htmlData = webReader.ReadToEnd();
                textBox1.Text = htmlData;
                response.Close();

                pictureBox1.Image = UNO_Desktop_Client.Properties.Resources.stylish_on;
                pictureBox6.Image = UNO_Desktop_Client.Properties.Resources.lightbulb_off;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {



        }

        private void button4_Click(object sender, EventArgs e)
        {
            bRlB = !bRlB;
            if (bRlB == true)
            {
                try
                {
                    WebRequest request = WebRequest.Create(

                    "http://192.168.1.177/Lamp2ON");
                    request.Timeout = 2000;
                    WebResponse response = request.GetResponse();
                    Stream webStream = response.GetResponseStream();
                    StreamReader webReader = new StreamReader(webStream);
                    htmlData = webReader.ReadToEnd();
                    textBox1.Text = htmlData;
                    response.Close();
                }
                catch (Exception)
                {

                    MessageBox.Show("System Error!!!");
                }



                pictureBox2.Image = UNO_Desktop_Client.Properties.Resources.stylish_off;
                pictureBox7.Image = UNO_Desktop_Client.Properties.Resources.fan_on;

            }

            if (bRlB == false)
            {
                try
                {
                    WebRequest request = WebRequest.Create(

                    "http://192.168.1.177/Lamp2Off");
                    request.Timeout = 2000;
                    WebResponse response = request.GetResponse();
                    Stream webStream = response.GetResponseStream();
                    StreamReader webReader = new StreamReader(webStream);
                    htmlData = webReader.ReadToEnd();
                    textBox1.Text = htmlData;
                    response.Close();
                }
                catch (Exception)
                {
                    
                    MessageBox.Show("System Error!!!");
                }

                pictureBox2.Image = UNO_Desktop_Client.Properties.Resources.stylish_on;
                pictureBox7.Image = UNO_Desktop_Client.Properties.Resources.fan_off;
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {
            bRlC = !bRlC;
            if (bRlC == true)
            {
                WebRequest request = WebRequest.Create(
             "http://192.168.1.177/Lamp3ON");
                WebResponse response = request.GetResponse();
                Stream webStream = response.GetResponseStream();
                StreamReader webReader = new StreamReader(webStream);
                htmlData = webReader.ReadToEnd();
                textBox1.Text = htmlData;
                response.Close();

                pictureBox3.Image = UNO_Desktop_Client.Properties.Resources.stylish_off;

            }

            if (bRlC == false)
            {
                WebRequest request = WebRequest.Create(
              "http://192.168.1.177/Lamp3Off");
                WebResponse response = request.GetResponse();
                Stream webStream = response.GetResponseStream();
                StreamReader webReader = new StreamReader(webStream);
                htmlData = webReader.ReadToEnd();
                textBox1.Text = htmlData;
                response.Close();

                pictureBox3.Image = UNO_Desktop_Client.Properties.Resources.stylish_on;
            }
        }


        private void button8_Click(object sender, EventArgs e)
        {
            bRlD = !bRlD;
            if (bRlD == true)
            {
                WebRequest request = WebRequest.Create(
             "http://192.168.1.177/FanON");
                WebResponse response = request.GetResponse();
                Stream webStream = response.GetResponseStream();
                StreamReader webReader = new StreamReader(webStream);
                htmlData = webReader.ReadToEnd();
                textBox1.Text = htmlData;
                response.Close();

                pictureBox4.Image = UNO_Desktop_Client.Properties.Resources.stylish_off;
                //pictureBox8.Image = UNO_Desktop_Client.Properties.Resources.lightbulb_on;

            }

            if (bRlD == false)
            {
                WebRequest request = WebRequest.Create(
              "http://192.168.1.177/FanOff");
                WebResponse response = request.GetResponse();
                Stream webStream = response.GetResponseStream();
                StreamReader webReader = new StreamReader(webStream);
                htmlData = webReader.ReadToEnd();
                textBox1.Text = htmlData;
                response.Close();

                pictureBox4.Image = UNO_Desktop_Client.Properties.Resources.stylish_on;
                //pictureBox8.Image = UNO_Desktop_Client.Properties.Resources.lightbulb_off;
            }
        }




        private void button10_Click(object sender, EventArgs e)
        {
            bRlE = !bRlE;
            if (bRlE == true)
            {
                WebRequest request = WebRequest.Create(
             "http://192.168.1.177/Lamp4ON");
                WebResponse response = request.GetResponse();
                Stream webStream = response.GetResponseStream();
                StreamReader webReader = new StreamReader(webStream);
                htmlData = webReader.ReadToEnd();
                textBox1.Text = htmlData;
                response.Close();

                pictureBox5.Image = UNO_Desktop_Client.Properties.Resources.stylish_off;

            }

            if (bRlE == false)
            {
                WebRequest request = WebRequest.Create(
              "http://192.168.1.177/Lamp4Off");
                WebResponse response = request.GetResponse();
                Stream webStream = response.GetResponseStream();
                StreamReader webReader = new StreamReader(webStream);
                htmlData = webReader.ReadToEnd();
                textBox1.Text = htmlData;
                response.Close();

                pictureBox5.Image = UNO_Desktop_Client.Properties.Resources.stylish_on;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            getStatus();

        }

        private void getStatus()
        {
            WebRequest request = WebRequest.Create("http://192.168.1.177/Status");
            WebResponse response = request.GetResponse();
            Stream webStream = response.GetResponseStream();
            StreamReader webReader = new StreamReader(webStream);
            htmlData = webReader.ReadToEnd();
            decodeStatus(htmlData);
            textBox1.Text = htmlData;
            response.Close();
        }

        private void decodeStatus(string htmlData)
        {
            if (htmlData != "")
            {
                char c1 = htmlData[0];
                char c2 = htmlData[1];
                char c3 = htmlData[2];
                char c4 = htmlData[3];
                char c5 = htmlData[4];
                //    textBox2.Text = c3.ToString();
                textBox2.Text = String.Format("{0}{1}{2}{3}{4}", c1, c2, c3, c4, c5);
                //-----------------------------------------C1

                if (c1 == '0')
                {
                    bRlA = false;
                    pictureBox1.Image = UNO_Desktop_Client.Properties.Resources.stylish_on;
                    pictureBox6.Image = UNO_Desktop_Client.Properties.Resources.lightbulb_off;
                }

                if (c1 == '1')
                {
                    bRlA = true;
                    pictureBox1.Image = UNO_Desktop_Client.Properties.Resources.stylish_off;
                    pictureBox6.Image = UNO_Desktop_Client.Properties.Resources.lightbulb_on;
                }

                //----------------------------------------------

                //-----------------------------------------C2

                if (c2 == '0')
                {
                    bRlB = false;
                    pictureBox3.Image = UNO_Desktop_Client.Properties.Resources.stylish_on;
                    pictureBox7.Image = UNO_Desktop_Client.Properties.Resources.fan_off;
                }

                if (c2 == '1')
                {
                    bRlA = true;
                    pictureBox3.Image = UNO_Desktop_Client.Properties.Resources.stylish_off;
                    pictureBox7.Image = UNO_Desktop_Client.Properties.Resources.fan_on;
                }

                //----------------------------------------------

                //-----------------------------------------C3

                if (c3 == '0')
                {
                    bRlA = false;
                    pictureBox2.Image = UNO_Desktop_Client.Properties.Resources.stylish_on;
                }

                if (c3 == '1')
                {
                    bRlA = true;
                    pictureBox2.Image = UNO_Desktop_Client.Properties.Resources.stylish_off;
                }

                //----------------------------------------------
                //-----------------------------------------C4

                if (c4 == '0')
                {
                    bRlA = false;
                    pictureBox4.Image = UNO_Desktop_Client.Properties.Resources.stylish_on;
                }

                if (c4 == '1')
                {
                    bRlA = true;
                    pictureBox4.Image = UNO_Desktop_Client.Properties.Resources.stylish_off;
                }

                //----------------------------------------------
                //-----------------------------------------C5

                if (c5 == '0')
                {
                    bRlA = false;
                    pictureBox5.Image = UNO_Desktop_Client.Properties.Resources.stylish_on;
                }

                if (c5 == '1')
                {
                    bRlA = true;
                    pictureBox5.Image = UNO_Desktop_Client.Properties.Resources.stylish_off;
                }

                //----------------------------------------------

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            getStatus();
        }







    }
}
