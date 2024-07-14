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
using System.Net.Sockets;

namespace UNO_Desktop_Client
{
    public partial class Form1 : Form
    {
        bool bRlA = false;
        bool bRlB = false;
        bool bRlC = false;
        bool bRlD = false;
        bool bRlE = false;
        bool All = false;
        string htmlData = "";
        string  lastip = "";
       
       
        
        

        public Form1()
        {
            InitializeComponent();

           
        }

       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            bRlA = !bRlA;
            if (bRlA == true)
            {
               // string givenIP = textBox1.Text;
                pictureBox1.Image = UNO_Desktop_Client.Properties.Resources.M_On;
               PB1.Image = UNO_Desktop_Client.Properties.Resources.lightbulb_on;
                try
                {
                 //   WebRequest request = WebRequest.Create(
                 //"http://192.168.1.177/Lamp1ON");
                 //   WebResponse response = request.GetResponse();

                 //   Stream webStream = response.GetResponseStream();
                 //   StreamReader webReader = new StreamReader(webStream);
                    //htmlData = webReader.ReadToEnd();
                    //textBox1.Text = htmlData;
                    //response.Close();
                    UdpClient udpL0_on = new UdpClient(8881);
                    string givenIP = txt1.Text;
                    udpL0_on.Connect(givenIP, 8888);
                    string cmd = "L0=1";
                    byte[] cmdByte = Encoding.ASCII.GetBytes(cmd);
                    udpL0_on.Send(cmdByte, cmdByte.Length);
                    udpL0_on.Close();
                 
                }
                catch (Exception)
                {

                    MessageBox.Show("You have entered a 'Wrong IP'");
                }


            }

            if (bRlA == false)
            {
                string givenIP = txt1.Text;
                pictureBox1.Image = UNO_Desktop_Client.Properties.Resources.M_Off;
                PB1.Image = UNO_Desktop_Client.Properties.Resources.lightbulb_off;
                try
                {
                  //  WebRequest request = WebRequest.Create(
                  //"http://192.168.1.177/Lamp1Off");
                  //  WebResponse response = request.GetResponse();
                  //  Stream webStream = response.GetResponseStream();
                  //  StreamReader webReader = new StreamReader(webStream);
                  //  htmlData = webReader.ReadToEnd();
                  //  textBox1.Text = htmlData;
                  //  response.Close();
                    UdpClient udpL0_off = new UdpClient(8810);
                    udpL0_off.Connect(givenIP, 8888);
                    string cmd = "L0=0";
                    byte[] cmdByte = Encoding.ASCII.GetBytes(cmd);
                    udpL0_off.Send(cmdByte, cmdByte.Length);
                    IPEndPoint remoteep = new IPEndPoint(IPAddress.Any, 0);
                    byte[] statusByte = udpL0_off.Receive(ref remoteep);
                    String status = Encoding.ASCII.GetString(statusByte);
                    //MessageBox.Show(status);   
                    udpL0_off.Close();

                }
                catch (Exception)
                {

                    MessageBox.Show("System Error!!!");
                }
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //getStatus();
            backgroundWorker1.RunWorkerAsync();
        }


        private void getStatus()
        {
            WebRequest request = WebRequest.Create("http://192.168.1.177/Status");
            WebResponse response = request.GetResponse();
            Stream webStream = response.GetResponseStream();
            StreamReader webReader = new StreamReader(webStream);
            htmlData = webReader.ReadToEnd();
            decodeStatus(htmlData);
            //textBox2.Text = htmlData;
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
                
                
                txt1.Text = String.Format("{0}{1}{2}{3}{4}", c1 ,c2, c3, c4, c5);
                
                //-----------------------------------------C1

                if (c1 == '0')
                {
                    bRlA = false;
                    pictureBox1.Image = UNO_Desktop_Client.Properties.Resources.stylish_on;
                    PB1.Image = UNO_Desktop_Client.Properties.Resources.lightbulb_off;

                }

                if (c1 == '1')
                {
                    bRlA = true;
                    pictureBox1.Image = UNO_Desktop_Client.Properties.Resources.stylish_off;
                    PB1.Image = UNO_Desktop_Client.Properties.Resources.lightbulb_on;
                }

                //----------------------------------------------

                //-----------------------------------------C2

                if (c2 == '0')
                {
                    bRlB = false;
                    pictureBox2.Image = UNO_Desktop_Client.Properties.Resources.stylish_on;
                    PB2.Image = UNO_Desktop_Client.Properties.Resources.fan_off;
                   
                }

                if (c2 == '1')
                {
                    bRlB = true;
                    pictureBox2.Image = UNO_Desktop_Client.Properties.Resources.stylish_off;
                    PB2.Image = UNO_Desktop_Client.Properties.Resources.fan_on;
                   
                }

                //----------------------------------------------

                //-----------------------------------------C3

                if (c3 == '0')
                {
                    bRlC = false;
                    pictureBox3.Image = UNO_Desktop_Client.Properties.Resources.stylish_on;
                    PB3.Image = UNO_Desktop_Client.Properties.Resources.lightbulb_off;
                   
                }

                if (c3 == '1')
                {
                    bRlC = true;
                    pictureBox3.Image = UNO_Desktop_Client.Properties.Resources.stylish_off;
                    PB3.Image = UNO_Desktop_Client.Properties.Resources.lightbulb_on;
                    
                }

                //----------------------------------------------
                //-----------------------------------------C4

                if (c4 == '0')
                {
                    bRlD = false;
                    pictureBox4.Image = UNO_Desktop_Client.Properties.Resources.stylish_on;
                    PB4.Image = UNO_Desktop_Client.Properties.Resources.lightbulb_off;
                    
                }

                if (c4 == '1')
                {
                    bRlD = true;
                    pictureBox4.Image = UNO_Desktop_Client.Properties.Resources.stylish_off;
                    PB4.Image = UNO_Desktop_Client.Properties.Resources.lightbulb_on;
                   
                }

                //----------------------------------------------
                //-----------------------------------------C5

                if (c5 == '0')
                {
                    bRlE = false;
                    pictureBox5.Image = UNO_Desktop_Client.Properties.Resources.stylish_on;
                    PB5.Image = UNO_Desktop_Client.Properties.Resources.lightbulb_off;
                  
                }

                if (c5 == '1')
                {
                    bRlE = true;
                    pictureBox5.Image = UNO_Desktop_Client.Properties.Resources.stylish_off;
                    PB5.Image = UNO_Desktop_Client.Properties.Resources.lightbulb_on;
                   
                }

                //----------------------------------------------
                //----------------------------------------------All

               
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            bRlC = !bRlC;
            if (bRlC == true)
            {
                try
                {

                 //   WebRequest request = WebRequest.Create(
                 //"http://192.168.1.177/Lamp2ON");
                 //   WebResponse response = request.GetResponse();

                 //   Stream webStream = response.GetResponseStream();
                 //   StreamReader webReader = new StreamReader(webStream);
                 //   htmlData = webReader.ReadToEnd();
                 //   textBox1.Text = htmlData;
                 //   response.Close();

                    UdpClient udpL1_on = new UdpClient(8882);
                    string givenIP = txt1.Text;
                    udpL1_on.Connect(givenIP, 8888);
                    string cmd = "L1=1";
                    byte[] cmdByte = Encoding.ASCII.GetBytes(cmd);
                    udpL1_on.Send(cmdByte, cmdByte.Length);
                    udpL1_on.Close();

                    pictureBox3.Image = UNO_Desktop_Client.Properties.Resources.M_On;
                    PB3.Image = UNO_Desktop_Client.Properties.Resources.lightbulb_on;
                }
                catch (Exception)
                {

                    MessageBox.Show("System Error!!!");
                }

            }
            if (bRlC == false)
            {
                try
                {
                  //  WebRequest request = WebRequest.Create(
                  //"http://192.168.1.177/Lamp2Off");
                  //  WebResponse response = request.GetResponse();
                  //  Stream webStream = response.GetResponseStream();
                  //  StreamReader webReader = new StreamReader(webStream);
                  //  htmlData = webReader.ReadToEnd();
                  //  textBox1.Text = htmlData;
                  //  response.Close();

                    UdpClient udpL1_off = new UdpClient(8820);
                    string givenIP = txt1.Text;
                    udpL1_off.Connect(givenIP, 8888);
                    string cmd = "L1=0";
                    byte[] cmdByte = Encoding.ASCII.GetBytes(cmd);
                    udpL1_off.Send(cmdByte, cmdByte.Length);
                    udpL1_off.Close();

                    pictureBox3.Image = UNO_Desktop_Client.Properties.Resources.M_Off;
                    PB3.Image = UNO_Desktop_Client.Properties.Resources.lightbulb_off;


                }
                catch (Exception)
                {

                    MessageBox.Show("System Error!!!");
                }
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            bRlB = !bRlB;
            if (bRlB == true)
            {
                try
                {
                    //WebRequest request = WebRequest.Create(

                    //"http://192.168.1.177/FanON");
                    //request.Timeout = 2000;
                    //WebResponse response = request.GetResponse();
                    //Stream webStream = response.GetResponseStream();
                    //StreamReader webReader = new StreamReader(webStream);
                    //htmlData = webReader.ReadToEnd();
                    //textBox1.Text = htmlData;
                    //response.Close();

                    UdpClient udpfanon = new UdpClient(8885);
                    string givenIP = txt1.Text;
                    udpfanon.Connect(givenIP, 8888);
                    string cmd = "L4=1";
                    byte[] cmdByte = Encoding.ASCII.GetBytes(cmd);
                    udpfanon.Send(cmdByte, cmdByte.Length);
                    udpfanon.Close();

                }
                catch (Exception)
                {

                    MessageBox.Show("System Error!!!");
                }



                pictureBox2.Image = UNO_Desktop_Client.Properties.Resources.M_On;
                PB2.Image = UNO_Desktop_Client.Properties.Resources.fan_on;

            }

            if (bRlB == false)
            {
                try
                {
                    //WebRequest request = WebRequest.Create(

                    //"http://192.168.1.177/FanOff");
                    //request.Timeout = 2000;
                    //WebResponse response = request.GetResponse();
                    //Stream webStream = response.GetResponseStream();
                    //StreamReader webReader = new StreamReader(webStream);
                    //htmlData = webReader.ReadToEnd();
                    //textBox1.Text = htmlData;
                    //response.Close();



                    //UdpClient udpfan_off = new UdpClient(8898);
                    //string givenIP = txt1.Text;
                    //udpfan_off.Connect(givenIP, 8888);
                    //string cmd = "L4=0";
                    //byte[] cmdByte = Encoding.ASCII.GetBytes(cmd);
                    //udpfan_off.Send(cmdByte, cmdByte.Length);
                    //IPEndPoint remoteep = new IPEndPoint(IPAddress.Any, 0);
                    //byte[] statusByte = udpfan_off.Receive(ref remoteep);
                    //String status = Encoding.ASCII.GetString(statusByte);
                    ////MessageBox.Show(status);   
                    //udpfan_off.Close();


                    UdpClient udpfan_off = new UdpClient(8850);
                    string givenIP = txt1.Text;
                    udpfan_off.Connect(givenIP, 8888);
                    string cmd = "L4=0";
                    byte[] cmdByte = Encoding.ASCII.GetBytes(cmd);
                    udpfan_off.Send(cmdByte, cmdByte.Length);
                    udpfan_off.Close();

                }
                catch (Exception)
                {

                    MessageBox.Show("System Error!!!");
                }

                pictureBox2.Image = UNO_Desktop_Client.Properties.Resources.M_Off;
                PB2.Image = UNO_Desktop_Client.Properties.Resources.fan_off;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            bRlD = !bRlD;
            if (bRlD == true)
            {
                try
                {
                 //   WebRequest request = WebRequest.Create(
                 //"http://192.168.1.177/Lamp3ON");
                 //   WebResponse response = request.GetResponse();

                 //   Stream webStream = response.GetResponseStream();
                 //   StreamReader webReader = new StreamReader(webStream);
                 //   htmlData = webReader.ReadToEnd();
                 //   textBox1.Text = htmlData;
                 //   response.Close();

                    UdpClient udpobject = new UdpClient(8883);
                    string givenIP = txt1.Text;
                    udpobject.Connect(givenIP, 8888);
                    string cmd = "L2=1";
                    byte[] cmdByte = Encoding.ASCII.GetBytes(cmd);
                    udpobject.Send(cmdByte, cmdByte.Length);
                    udpobject.Close();

                   

                }
                catch (Exception)
                {

                    MessageBox.Show("System Error!!!");
                }

                pictureBox4.Image = UNO_Desktop_Client.Properties.Resources.M_On;
                PB4.Image = UNO_Desktop_Client.Properties.Resources.lightbulb_on;

            }

            if (bRlD == false)
            {
                try
                {
                  //  WebRequest request = WebRequest.Create(
                  //"http://192.168.1.177/Lamp3Off");
                  //  WebResponse response = request.GetResponse();
                  //  Stream webStream = response.GetResponseStream();
                  //  StreamReader webReader = new StreamReader(webStream);
                  //  htmlData = webReader.ReadToEnd();
                  //  textBox1.Text = htmlData;
                  //  response.Close();

                    UdpClient udpobject = new UdpClient(8830);
                    string givenIP = txt1.Text;
                    udpobject.Connect(givenIP, 8888);
                    string cmd = "L2=0";
                    byte[] cmdByte = Encoding.ASCII.GetBytes(cmd);
                    udpobject.Send(cmdByte, cmdByte.Length);
                    udpobject.Close();

                    
                }
                catch (Exception)
                {

                    MessageBox.Show("System Error!!!");
                }

                pictureBox4.Image = UNO_Desktop_Client.Properties.Resources.M_Off;
                PB4.Image = UNO_Desktop_Client.Properties.Resources.lightbulb_off;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
           
            bRlE = !bRlE;

            if (bRlE == true)
            {
                try
                {
                 //   WebRequest request = WebRequest.Create(
                 //"http://192.168.1.177/Lamp4ON");
                 //   WebResponse response = request.GetResponse();

                 //   Stream webStream = response.GetResponseStream();
                 //   StreamReader webReader = new StreamReader(webStream);
                 //   htmlData = webReader.ReadToEnd();
                 //   textBox1.Text = htmlData;
                    //   response.Close();

                    UdpClient udpobject = new UdpClient(8884);
                    string givenIP = txt1.Text;
                    udpobject.Connect(givenIP, 8888);
                    string cmd = "L3=1";
                    byte[] cmdByte = Encoding.ASCII.GetBytes(cmd);
                    udpobject.Send(cmdByte, cmdByte.Length);
                    udpobject.Close();

                    pictureBox5.Image = UNO_Desktop_Client.Properties.Resources.M_On;
                    PB5.Image = UNO_Desktop_Client.Properties.Resources.lightbulb_on;

                }
                catch (Exception)
                {

                    MessageBox.Show("System Error!!!");
                }
            }

            if (bRlE == false)
            {
                try
                {
                  //  WebRequest request = WebRequest.Create(
                  //"http://192.168.1.177/Lamp4Off");
                  //  WebResponse response = request.GetResponse();
                  //  Stream webStream = response.GetResponseStream();
                  //  StreamReader webReader = new StreamReader(webStream);
                  //  htmlData = webReader.ReadToEnd();
                  //  textBox1.Text = htmlData;
                  //  response.Close();

                    UdpClient udpobject = new UdpClient(8840);
                    string givenIP = txt1.Text;
                    udpobject.Connect(givenIP, 8888);
                    string cmd = "L3=0";
                    byte[] cmdByte = Encoding.ASCII.GetBytes(cmd);
                    udpobject.Send(cmdByte, cmdByte.Length);
                    udpobject.Close();

                    pictureBox5.Image = UNO_Desktop_Client.Properties.Resources.M_Off;
                    PB5.Image = UNO_Desktop_Client.Properties.Resources.lightbulb_off;



                }
                catch (Exception)
                {

                    MessageBox.Show("System Error!!!");
                }

            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)

        {
            All = !All;
            if (All == true)
            {
                try
                {
                    WebRequest request = WebRequest.Create(
                 "http://192.168.1.177/AllON");
                    WebResponse response = request.GetResponse();

                    Stream webStream = response.GetResponseStream();
                    StreamReader webReader = new StreamReader(webStream);
                    htmlData = webReader.ReadToEnd();
                    txt1.Text = htmlData;
                    response.Close();
                    pictureBox6.Image = UNO_Desktop_Client.Properties.Resources.Toggle_Switch_On;
                    
                }
                catch (Exception)
                {

                    MessageBox.Show("System Error!!!");
                }


            }

            if (All == false)
            {
                try
                {
                    WebRequest request = WebRequest.Create(
                  "http://192.168.1.177/AllOff");
                    WebResponse response = request.GetResponse();
                    Stream webStream = response.GetResponseStream();
                    StreamReader webReader = new StreamReader(webStream);
                    htmlData = webReader.ReadToEnd();
                    txt1.Text = htmlData;
                    response.Close();
                    pictureBox6.Image = UNO_Desktop_Client.Properties.Resources.Toggle_Switch_Off;
                    

                }
                catch (Exception)
                {

                    MessageBox.Show("System Error!!!");
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            timer1.Enabled = false;
            getStatus();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timer1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        
        {
            lastip = txt1.Text;
            //MessageBox.Show("Software is ready to use");
        }

        private void button1_Click(object sender, EventArgs e)
        
       
    {

        if (txt1.Text == "")
        {
            MessageBox.Show("Please enter a valid IP Adress");
        }
        else
        {


            lastip = txt1.Text;


            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = true;
            panel5.Visible = true;
            panel6.Visible = false;
            //MessageBox.Show("You have entered a local IP");





        }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            lastip = txt1.Text;
            button2.Enabled = true;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt1.Text!= "")
            {
                txt1.Text = lastip;
            }
            else
            {
                MessageBox.Show("You have not eneterd an IP");
            }
        }

        

        

        

       
        
        

       
 

    }
}
