using Modelos;

namespace Datos.Interfaces;
//Interfaz del usuario
public interface IUsuarioRepositorio
{
    Task<bool> Nuevo(Usuario usuario);

    Task<bool> Actualizar(Usuario usuario);
    Task<bool> Eliminar(Usuario usuario);
    Task<IEnumerable<Usuario>> GetLista(); //Traer todos los usuarios
    Task<Usuario> GetPorCodigo(string codigo);
    Task<bool> ValidaUsuario(Login login);
}
