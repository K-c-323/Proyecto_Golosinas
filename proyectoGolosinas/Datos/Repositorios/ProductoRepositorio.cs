using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;

namespace Datos.Repositorios;

public class ProductoRepositorio : IProductoRepositorio
{
    private string CadenaConexion;


    public ProductoRepositorio(string cadenaConexion)
    {
        CadenaConexion = cadenaConexion;
    }


    private MySqlConnection Conexion() //METODO PARA CONECTARNOS A MYSQL
    {
        return new MySqlConnection(CadenaConexion);
    }




    public async Task<bool> Actualizar(Producto producto)
    {
        int resultado;
        try
        {
            using MySqlConnection conexion = Conexion(); //Conexión que esta arriba    
            await conexion.OpenAsync();
            string sql = "UPDATE producto SET Codigo = @Codigo, Descripcion = @Descripcion, Precio = @Precio, Existencia = @Existencia WHERE Codigo = @Codigo;";
            resultado = await conexion.ExecuteAsync(sql, new
            {
                producto.Codigo,
                producto.Descripcion,
                producto.Precio,
                producto.Existencia,
                
            });
            return resultado > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> Eliminar(Producto producto)
    {
        int resultado;
        try
        {
            using MySqlConnection conexion = Conexion(); //Conexión que esta arriba    
            await conexion.OpenAsync();
            string sql = "DELETE FROM producto WHERE Codigo = @Codigo;";
            resultado = await conexion.ExecuteAsync(sql, new { producto.Codigo });
            return resultado > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }



    public async Task<IEnumerable<Producto>> GetLista()
    {
        IEnumerable<Producto> lista = new List<Producto>();

        try
        {
            using MySqlConnection conexion = Conexion(); //Conexión que esta arriba    
            await conexion.OpenAsync();
            string sql = "SELECT * FROM producto;";
            lista = await conexion.QueryAsync<Producto>(sql);
        }
        catch (Exception ex)
        {
        }

        return lista;
    }



    public async Task<Producto> GetPorCodigo(string codigo)
    {
        Producto user = new Producto();
        try
        {
            using MySqlConnection conexion = Conexion(); //Conexión que esta arriba    
            await conexion.OpenAsync();
            string sql = "SELECT * FROM producto WHERE Codigo = @Codigo;";
            user = await conexion.QueryFirstAsync<Producto>(sql, new { codigo });
        }
        catch (Exception ex)
        {
        }
        return user;
    }

    public async Task<bool> Nuevo(Producto producto)
    {
        int resultado;
        try
        {
            using MySqlConnection conexion = Conexion(); //Conexión que esta arriba    
            await conexion.OpenAsync();
            string sql = "INSERT INTO producto (Codigo, Descripcion, Precio, Existencia) VALUES (@Codigo, @Descripcion, @Precio, @Existencia)";
            resultado = await conexion.ExecuteAsync(sql, producto);
            return resultado > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
