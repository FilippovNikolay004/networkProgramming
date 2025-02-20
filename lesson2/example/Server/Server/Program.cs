using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class TcpChatServer
{
    private static List<TcpClient> clients = new List<TcpClient>();
    private static TcpListener server;

    static void Main()
    {
        try
        {
            server = new TcpListener(IPAddress.Any, 4900);
            server.Start();
            Console.WriteLine("Сервер запущен на порту 4900...");

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                clients.Add(client);
                Console.WriteLine("Новый клиент подключен.");

                Thread clientThread = new Thread(HandleClient);
                clientThread.Start(client);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }

    private static void HandleClient(object obj)
    {
        TcpClient client = (TcpClient)obj;
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024];
        int bytesRead;

        try
        {
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Получено: " + message);
                BroadcastMessage(message, client);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка с клиентом: " + ex.Message);
        }
        finally
        {
            clients.Remove(client);
            client.Close();
            Console.WriteLine("Клиент отключен.");
        }
    }

    private static void BroadcastMessage(string message, TcpClient sender)
    {
        byte[] data = Encoding.UTF8.GetBytes(message);

        foreach (var client in clients)
        {
            if (client != sender) // Не отправляем сообщение самому отправителю
            {
                try
                {
                    NetworkStream stream = client.GetStream();
                    stream.Write(data, 0, data.Length);
                }
                catch
                {
                    client.Close();
                    clients.Remove(client);
                }
            }
        }
    }
}