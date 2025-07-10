using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuishpeSProgreso3.Services
{
    public class LogsServices
    {
        private readonly string _filePath;

        public LogsServices()
        {
            var filename = $"Logs_Quishpe.txt";
            _filePath = Path.Combine(FileSystem.AppDataDirectory, filename);
        }

        public async Task AppendLogAsync(string producto)
        {
            string log = $"Se incluyó el registro [{producto}] el {DateTime.Now:dd/MM/yyyy HH:mm}\n";
            await File.AppendAllTextAsync(_filePath, log);
        }

        public async Task<string> LeerLogsAsync()
        {
            if (File.Exists(_filePath))
                return await File.ReadAllTextAsync(_filePath);
            return "No hay logs.";
        }
    }
}
