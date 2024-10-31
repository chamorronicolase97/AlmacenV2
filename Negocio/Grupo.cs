using ClasePersistente = Entidades.Grupo;
using Capa = Datos.Grupo;
namespace Negocio
{
    public class Grupo
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

        public static List<ClasePersistente> Listar() => new Capa().ListarGrupos(); 
    }
}