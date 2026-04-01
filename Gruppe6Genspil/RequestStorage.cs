using System;
using System.Collections.Generic;
using System.Text;

namespace Gruppe6Genspil
{
    internal class RequestStorage
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
            foreach (var request in Requests)
            {
                Console.WriteLine(request.ToString());
            }
        }

    }



}



