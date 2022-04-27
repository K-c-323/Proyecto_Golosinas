namespace Blazor.Data
{
    public class MySQLConfiguration
    {
        public string CadenaConexion { get; } //Obtener

        public MySQLConfiguration(string cadenaConexion)
        {
            CadenaConexion = cadenaConexion;
        }


    }
}
