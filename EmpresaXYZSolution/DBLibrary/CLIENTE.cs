//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class CLIENTE
    {
        public long ID_CLIENTE { get; set; }
        public string NOME { get; set; }
        public decimal TEL_RESIDENCIAL { get; set; }
        public string ENDERECO { get; set; }
        public Nullable<System.DateTime> DATA_NASCIMENTO { get; set; }
        public Nullable<decimal> TEL_CELULAR { get; set; }
    }
}
