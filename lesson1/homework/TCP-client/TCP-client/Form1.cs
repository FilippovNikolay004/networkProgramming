using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TCP_client {
    public partial class Form1 : Form {
        Socket sock;
        public Form1() {
            InitializeComponent();
        }

        private async void Connect() {
            await Task.Run(() => {
                try {

                    IPAddress ipAddr = IPAddress.Parse(ip_address.Text);
                    IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 49152);

                    sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                   
                    sock.Connect(ipEndPoint);
                    byte[] msg = Encoding.Default.GetBytes(Dns.GetHostName());
                    int bytesSent = sock.Send(msg);
                    MessageBox.Show("Клиент " + Dns.GetHostName() + " установил соединение с " + sock.RemoteEndPoint.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Клиент: " + ex.Message);
                }
            }); 
        }

        private void button1_Click(object sender, EventArgs e) {
            Connect();            
        }

        private async void Exchange() {
            await Task.Run(() => {
                try {
                    string theMessage = textBox1.Text;
                    byte[] msg = Encoding.Default.GetBytes(theMessage); 
                    int bytesSent = sock.Send(msg);

                    if (theMessage.IndexOf("<end>") > -1) {
                        byte[] bytes = new byte[1024];
                        int bytesRec = sock.Receive(bytes); 
                        MessageBox.Show("Сервер (" + sock.RemoteEndPoint.ToString() + ") ответил: " + Encoding.Default.GetString(bytes, 0, bytesRec));
                        sock.Shutdown(SocketShutdown.Both);
                        sock.Close();
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("Клиент: " + ex.Message);
                }
            }); 
        }

        private void button3_Click(object sender, EventArgs e) {
            Exchange();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            try {
                sock.Shutdown(SocketShutdown.Both); 
                sock.Close(); 
            }
            catch (Exception ex) {
                MessageBox.Show("Клиент: " + ex.Message);
            }
        }
    }
}
