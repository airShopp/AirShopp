
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace DbDiagram
{

using System;
    using System.Collections.Generic;
    
public partial class ProductIn
{

    public int Id { get; set; }

    public string ProductId { get; set; }

    public string Amount { get; set; }

    public string Price { get; set; }

    public string InDate { get; set; }



    public virtual Products Products { get; set; }

}

}
