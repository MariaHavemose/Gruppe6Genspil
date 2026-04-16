using System;
using System.Collections.Generic;
using System.Text;

namespace Gruppe6Genspil
{
    public class RequestStorage
    {
        public string FilePath { get; set; }
        public List<Request> Requests { get; set; } = new List<Request>();
        public void SaveRequestToFile(List<Request> requests)
        {
            using (StreamWriter sw = new StreamWriter(FilePath))
            {
                foreach (var request in requests)
                {
                    sw.WriteLine(request.ToString());
                }
            }
        }
        public List<Request> LoadRequestFromFile()
        {
            List<Request> requests = new List<Request>();
            if (!File.Exists(FilePath))
                return requests;
            using (StreamReader sr = new StreamReader(FilePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    requests.Add(Request.FromString(line));
                }
            }
            return requests;
        }
        public RequestStorage(string filePath)
        {
            FilePath = filePath;
            Requests = LoadRequestFromFile();
        }
        public void AddRequest(Request request)
        {
            Requests.Add(request);
            SaveRequestToFile(Requests);
        }
        public void ShowRequests()
        {
            int longestCustomerName = 13;
            int longestGameName = 14;
            foreach (var request in Requests)
            {
                if (request.CustomerName.Length > longestCustomerName)
                    longestCustomerName = request.CustomerName.Length;
                if (request.GameName.Length > longestGameName)
                    longestGameName = request.GameName.ToString().Length;
            }
            Console.WriteLine("Kundens navn:".PadRight(longestCustomerName) + " | " + "Kundens ønske:".PadRight(longestGameName) + " | " + "Kundens kommentar: ");
            Console.WriteLine("---------------------------------------------------");
            foreach (var request in Requests)
            {
                string requestCustomerName = request.CustomerName.PadRight(longestCustomerName);
                string requestGameName = request.GameName.PadRight(longestGameName);
                string requestCustomerComment = request.Comment;
                Console.WriteLine(requestCustomerName.PadRight(longestCustomerName) + " | " + requestGameName.PadRight(longestGameName) + " | " + requestCustomerComment);
            }
        }
    }
}
