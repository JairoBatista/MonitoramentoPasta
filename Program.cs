using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MonitoramentoPasta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Crie uma nova instância de FileSystemWatcher
            FileSystemWatcher watcher = new FileSystemWatcher();

            // Defina o diretório que você deseja monitorar
            watcher.Path = @ConfigurationManager.AppSettings["PastaMonitorada"];

            // Monitore as alterações no diretório (criação, modificação, exclusão e renomeação de arquivos)
            watcher.NotifyFilter = NotifyFilters.LastWrite
                                 | NotifyFilters.FileName
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.Size;


            // Inicie a vigilância
            watcher.EnableRaisingEvents = true;

            // Adicione um manipulador de eventos para o evento de alteração de arquivos
            watcher.Changed += new FileSystemEventHandler(OnChanged);

            // Aguarde por entrada do usuário
            Console.ReadLine();
        }

        // Este é o manipulador de eventos que será chamado quando ocorrer uma alteração no diretório
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine($"Arquivo: {e.FullPath} {e.ChangeType}");
        }
    }
}
