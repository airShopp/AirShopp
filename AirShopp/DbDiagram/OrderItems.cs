
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
    
public partial class OrderItems
{

    public long Id { get; set; }

    public long OrderId { get; set; }

    public long ProductId { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal DiscountPrice { get; set; }

    public int Quantity { get; set; }

    public System.DateTime OrderDate { get; set; }



    public virtual Orders Orders { get; set; }

    public virtual Products Products { get; set; }

}

}
