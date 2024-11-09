using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{ 

    public class PermisoGrupo
    {
        private int _PermisoGrupoID;
        private Permiso _permiso;
        private Grupo _grupo;

        #region Constantes
        public const string NombreClase = "PermisoGrupo";
        #endregion

        #region Propiedades
        public int PermisoGrupoID { get { return _PermisoGrupoID; } set { _PermisoGrupoID = value; } }
        public int PermisoID { get;set; }
        public Permiso Permiso { get { return _permiso; } set { _permiso = value; } }

        public int GrupoID { get; set; }
        public Grupo Grupo { get { return _grupo; } set { _grupo = value; } }
        #endregion

        public PermisoGrupo()
        { 
            
        }
    }
}
