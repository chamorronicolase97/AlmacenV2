using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Proveedor
    {
        private int _proveedorId;
        private string _cuit;
        private string _razonSocial;
        private string _direccion;
        private string _mail;
        private string _telefono;

        #region Constantes
        public const string NombreClase = "Proveedor";
        #endregion

        #region Propiedades
        public int ProveedorID { get { return _proveedorId; } set { _proveedorId = value; } }
        public string Cuit { get { return _cuit; } set { _cuit = value; } }
        public string RazonSocial { get { return _razonSocial; } set { _razonSocial = value; } }
        public string Direccion { get { return _direccion; } set { _direccion = value; } }
        public string Mail { get { return _mail; } set { _mail = value; } }
        public string Telefono { get { return _telefono; } set { _telefono = value; } }

        #endregion

        public Proveedor() { }
    }

}
