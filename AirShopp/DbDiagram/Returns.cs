
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
    
public partial class Returns
{

    public long Id { get; set; }

    public long OrderId { get; set; }

    public System.DateTime DeliveryDate { get; set; }

    public string ReturnReason { get; set; }

    public string ProductId { get; set; }

    public int Quantity { get; set; }

    public string CustomerName { get; set; }



    public virtual Orders Orders { get; set; }

}

}
