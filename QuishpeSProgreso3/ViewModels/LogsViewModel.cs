using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuishpeSProgreso3.Services;

namespace QuishpeSProgreso3.ViewModels
{
    public class LogsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _contenidoLog;
        public string ContenidoLog
        {
            get => _contenidoLog;
            set
            {
                _contenidoLog = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ContenidoLog)));
            }
        }

        private readonly LogsServices _logsServices = new();

        public LogsViewModel()
        {
            CargarLogs();
        }

        private async void CargarLogs()
        {
            ContenidoLog = await _logsServices.LeerLogsAsync();
        }
    }
}
