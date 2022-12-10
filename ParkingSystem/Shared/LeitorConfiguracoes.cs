using System;
using Newtonsoft.Json;
using System.IO;
using ParkingSystem.Views;
using ParkingSystem.Utils.Implements;

namespace ParkingSystem.Shared
{
    class LeitorConfiguracoes
    {
        public static void LoadConfig()
        {
            CheckFile();
            if (FileHasContent()) ReadFile();
            else new frmConfigDatabase().ShowDialog();
        }

        private static void CheckDiretory()
        {
            if (!Directory.Exists(General.DIRETORIO))
            {
                Directory.CreateDirectory(General.DIRETORIO);
            }
        }

        private static void CheckFile()
        {
            CheckDiretory();
            if (!File.Exists($"{General.DIRETORIO}\\{General.ARQUIVOCONFIG}"))
            {
                File.Create($"{General.DIRETORIO}\\{General.ARQUIVOCONFIG}");
            }
        }

        private static bool FileHasContent()
        {
            return File.ReadAllText($"{General.DIRETORIO}\\{General.ARQUIVOCONFIG}").Trim().Length > 0;
        }

        private static void ReadFile()
        {
            try
            {
                var config = JsonConvert.DeserializeObject<ConfigJson>(@"" + File.ReadAllText($"{General.DIRETORIO}\\{General.ARQUIVOCONFIG}".Trim()));
                ConfiguracaoDatabase.SetConfig(config.Sgbd, config.Server.Replace("/", "\\"), config.AutenticationWindows, config.User, config.Password);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public static void WriteFileConfig(Database.Tipo tipo, string server, bool autenticationWindows, string user, string password)
        {
            using (StreamWriter writer = new StreamWriter($"{General.DIRETORIO}\\{General.ARQUIVOCONFIG}"))
            {
                server = server.Replace(@"\", @"\\");

                writer.WriteLine("{");
                writer.WriteLine($"\"Sgbd\": \"{tipo}\",");
                writer.WriteLine($"\"Server\": \"{server}\",");
                writer.WriteLine($"\"User\": \"{user}\",");
                writer.WriteLine($"\"Password\": \"{password}\",");
                writer.WriteLine($"\"AutenticationWindows\": {autenticationWindows.ToString().ToLower()}");
                writer.WriteLine("}");

                writer.Close();
            }
        }


    }
}
