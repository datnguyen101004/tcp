using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tcpclient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPEndPoint iPEndPoint;
            IPAddress iPAddress;
            Byte[] message;
            Socket socket;
            if (IPAddress.TryParse(textBox1.Text, out iPAddress) )
            {
                iPAddress = IPAddress.Parse(textBox1.Text);
                int port = int.Parse(textBox2.Text);
                iPEndPoint = new IPEndPoint(iPAddress, port);
                socket = new Socket(iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(iPEndPoint);
                socket.RemoteEndPoint.ToString();
                message = Encoding.UTF8.GetBytes(textBox3.Text);
                socket.Send(message);
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
