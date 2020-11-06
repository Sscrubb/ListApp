using ListApp.Models.Domain;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ListApp.Services
{
    public class FileIOService
    {
        private readonly string PATH;
        public FileIOService(string path)
        {
            PATH = path;
        }
        public List<ToDoItem> LoadData()
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new List<ToDoItem>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<ToDoItem>>(fileText);
            }
        }

        public void SaveData(List<ToDoItem> listAppModels)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(listAppModels);
                writer.Write(output);
            }
        }
    }
}
