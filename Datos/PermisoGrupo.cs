using Microsoft.EntityFrameworkCore;
using Sistema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasePersistente = Entidades.PermisoGrupo;

namespace Datos
{
    public class PermisoGrupo:AlmacenContext
    {
        const string Tabla = "dbo.PermisosGrupos";
        public PermisoGrupo():base() { }

        public void Insertar(ClasePersistente clase)
        {
            try
            {
                base.Permisos.Attach(clase.Permiso);
                base.Grupos.Attach(clase.Grupo);
                base.PermisosGrupos.Add(clase);            
                base.SaveChanges();
            }
            catch(Exception ex) 
            {
                throw new Exception("Error al insertar el Permiso de Grupo: " + ex.Message);
            }
        }

        public void Modificar(ClasePersistente clase)
        {
            base.PermisosGrupos.Update(clase);
            base.SaveChanges();
        }

        public void Eliminar(ClasePersistente clase)
        {
            base.Permisos.Attach(clase.Permiso);
            base.Grupos.Attach(clase.Grupo);
            base.PermisosGrupos.Remove(clase);
            base.SaveChanges();
        }

        public List<ClasePersistente> ListarPermisosGrupos()
        {
            return base.PermisosGrupos.Include(u => u.Permiso).Include(u => u.Grupo).ToList();
        }

        public ClasePersistente Consultar(int ID)
        {
            return base.PermisosGrupos.Find(ID);
        }

        public static bool TienePermiso(int grupoId, string codPermiso)
        {
            using (var context = new AlmacenContext())
            {
                return context.PermisosGrupos
                    .Include(pg => pg.Permiso)
                    .Any(pg => pg.GrupoID == grupoId && pg.Permiso.CodPermiso == codPermiso);
            }
        }

    }
}
