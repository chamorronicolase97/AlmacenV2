public class iProductoCosto
{
    public int ProductoID { get; set; }
    public string Descripcion { get; set; }
    public int RecepcionID { get; set; }
    public DateTime FechaRecepcion { get; set; }
    public decimal? CostoActual { get; set; }  // Cambiar a decimal?
    public decimal? PrecioVentaActual { get; set; }
    public decimal? NuevoCosto { get; set; }
    public decimal? NuevoPrecioVenta { get; set; }
    public string Categoria { get; set; }
    public string Proveedor { get; set; }
}
