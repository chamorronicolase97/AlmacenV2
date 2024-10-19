using ClasePersistente = Entidades.Usuario;
using Capa = Datos.Usuario;
namespace Negocio
{
    public class Usuario
    {

        public static void Agregar(ClasePersistente clase)
        {
            Capa Capa = new Capa();
            Capa.Insertar(clase);
        }

        public static void Modificar(ClasePersistente clase)
        {
            Capa Capa = new Capa();
            Capa.Modificar(clase);
        }

        public static void Eliminar(ClasePersistente clase)
        {
            Capa Capa = new Capa();
            Capa.Eliminar(clase);
        }
    }
}