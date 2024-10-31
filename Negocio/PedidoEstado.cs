using ClasePersistente = Entidades.PedidoEstado;
using Capa = Datos.PedidoEstado;
namespace Negocio
{
    public class PedidoEstado
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

        public static List<ClasePersistente>  Listar()
        {
            Capa Capa = new Capa();
            return Capa.Listar();         
        }
    }
}