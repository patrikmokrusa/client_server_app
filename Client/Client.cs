using System.Net.Sockets;
using System.Text;

namespace Client;

public class Client
{
    private string _serverIp;
    private int _serverPort;
    public Client(string serverIp, int serverPort)
    {
        _serverIp = serverIp;
        _serverPort = serverPort;
    }

    private string Connect(string request)
    {
        var client = new TcpClient(_serverIp, _serverPort);
        var stream = client.GetStream();

        HandleRequest(request, stream);
        var response = HandleResponse(stream);

        client.Close();
        return response;
    }

    private string HandleResponse(NetworkStream stream)
    {
        var reader = new StreamReader(stream, Encoding.ASCII);
        string response = "";
        while (reader.Peek() != -1)
        {
            var line = reader.ReadLine();
            if (line == " ") continue;
            response += line + "\n";
        }

        return response;
    }

    private void HandleRequest(string request, NetworkStream stream)
    {
        var writer = new StreamWriter(stream, Encoding.ASCII) { AutoFlush = true };
        writer.WriteLine(request);
    }

    public string Request(string requestKw, string id = "", string name = "", string surname = "")
    {
        var reqStr = GetRequestString(requestKw, id, name, surname);
        var response = Connect(reqStr);
        return response;
    }

    private string GetRequestString(string requestKw, string id, string name, string surname)
    {
        
        if (requestKw == "GET")
        {
            return $"GET {id} x x";
        }
        else if (requestKw == "EDIT")
        {
            return $"EDIT {id} {name} {surname}";
        }
        else if (requestKw == "DELETE")
        {
            return $"DELETE {id} x x";
        }
        else if (requestKw == "ADD")
        {
            return $"ADD x {name} {surname}";
        }
        else if (requestKw == "GETALL")
        {
            return "GETALL x x x";
        }
        else
        {
            throw new Exception("Invalid request");
            return "Invalid request";
        }
    }
}