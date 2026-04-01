using System;
using System.Collections.Generic;
using System.Text;

namespace Gruppe6Genspil
{
    internal class RequestStorage
    {
        public string FilePath { get; set; }

        public RequestStorage(string filePath)
        {
            FilePath = filePath;
        }

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
    }



}



