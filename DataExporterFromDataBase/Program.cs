namespace DataExporterFromDataBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"Server = DESKTOP-610ITHU; Database = Northwind; Integrated Security = True; TrustServerCertificate = True";

             DatabaseExporter.ExportDataBase(path);
        }
    }
}