 
namespace Modales.Models
{

using System;
    using System.Collections.Generic;
    
public partial class Tbl_Jornada
{

    public int idJornada { get; set; }

    public string CedulaTra { get; set; }

    public Nullable<int> idSalario { get; set; }

    public string TipoJornada { get; set; }

    public string HoraInicio { get; set; }

    public string HoraFin { get; set; }

    public Nullable<int> PrecioHoraRegular { get; set; }

    public Nullable<int> PrecioHoraExtra { get; set; }

    public Nullable<int> CantidadHorasRegulares { get; set; }

    public Nullable<int> CantidadHorasExtras { get; set; }

    public Nullable<int> ValorTotalHoraExtra { get; set; }

    public Nullable<int> ValorTotalHorasRegulares { get; set; }

    public Nullable<int> PrecioContrato { get; set; }

    public string UnidadMedida { get; set; }

    public Nullable<int> PrecioUnidadMedida { get; set; }

    public Nullable<int> TotalUnidadDeMedida { get; set; }

    public string LaborExtra { get; set; }

    public Nullable<int> PrecioLaborExtra { get; set; }

    public string FechaJornada { get; set; }

    public string Observacion { get; set; }

    public Nullable<decimal> ValorJornada { get; set; }



    public virtual Tbl_Salario Tbl_Salario { get; set; }

    public virtual Tbl_Trabajador Tbl_Trabajador { get; set; }

}

}
