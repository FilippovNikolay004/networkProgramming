using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;


class Server {
    [Serializable]
    struct Message {
        public string mes; // текст сообщения
        public string host; // имя хоста
        public string user; // имя пользователя
    }
    async void ReadMessage(TcpClient client) {
        await Task.Run(() =>
        {
            try {
                // Получим объект NetworkStream, используемый для приема и передачи данных.
                NetworkStream netstream = client.GetStream();
                byte[] arr = new byte[client.ReceiveBufferSize /* размер приемного буфера */];
                // Читаем данные из объекта NetworkStream.
                int len = netstream.Read(arr, 0, client.ReceiveBufferSize);
                if (len > 0) {
                    // Создадим поток, резервным хранилищем которого является память.
                    MemoryStream stream = new MemoryStream(arr);
                    // BinaryFormatter сериализует и десериализует объект в двоичном формате 
                    BinaryFormatter formatter = new BinaryFormatter();
                    Message m = (Message)formatter.Deserialize(stream); // выполняем десериализацию
                                                                        // полученную от клиента информацию добавляем в список

                    // uiContext.Send отправляет синхронное сообщение в контекст синхронизации
                    // SendOrPostCallback - делегат указывает метод, вызываемый при отправке сообщения в контекст синхронизации. 
                    uiContext.Send(d => listBox1.Items.Add(m.host) /* Вызываемый делегат SendOrPostCallback */,
                        null /* Объект, переданный делегату */); // добавляем в список имя клиента
                    uiContext.Send(d => listBox1.Items.Add(m.user), null);
                    uiContext.Send(d => listBox1.Items.Add(m.mes), null);
                    stream.Close();
                }
                netstream.Close();
                client.Close(); // закрываем TCP-подключение и освобождаем все ресурсы, связанные с объектом TcpClient.
            }
            catch (Exception ex) {
                client.Close(); // закрываем TCP-подключение и освобождаем все ресурсы, связанные с объектом TcpClient.
                Console.WriteLine("Сервер: " + ex.Message);
            }
        });

    }

    async static void WaitClientQuery() {
        await Task.Run(() =>
        {
            try {
                // TcpListener ожидает подключения от TCP-клиентов сети.
                TcpListener listener = new TcpListener(
                IPAddress.Any /* Предоставляет IP-адрес, указывающий, что сервер должен контролировать действия клиентов на всех сетевых интерфейсах.*/,
                49152 /* порт */);
                listener.Start(); // Запускаем ожидание входящих запросов на подключение
                while (true) {
                    // Принимаем ожидающий запрос на подключение 
                    // Метод AcceptTcpClient — это блокирующий метод, возвращающий объект TcpClient, 
                    // который может использоваться для приема и передачи данных.
                    TcpClient client = listener.AcceptTcpClient();
                    ReadMessage(client);
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Сервер: " + ex.Message);
            }
        });

    }
}

