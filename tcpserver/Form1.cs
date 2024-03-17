using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tcpserver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int port = int.Parse(textBox1.Text);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, port);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(iPEndPoint);
            socket.Listen(5);
            Socket accSocket = socket.Accept();
            Byte[] bytes = new Byte[255];
            int messageLength = accSocket.Receive(bytes);
            Array.Resize(ref bytes, messageLength);
            String recMessage = Encoding.UTF8.GetString(bytes);
            textBox2.Text = recMessage;
            accSocket.Shutdown(SocketShutdown.Both);
            accSocket.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
