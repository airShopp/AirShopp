
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
    
public partial class Orders
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Orders()
    {

        this.Deliveries = new HashSet<Deliveries>();

        this.OrderItems = new HashSet<OrderItems>();

        this.Returns = new HashSet<Returns>();

    }


    public long Id { get; set; }

    public long CustomerId { get; set; }

    public decimal TotalAmount { get; set; }

    public System.DateTime OrderDate { get; set; }

    public string OrderStatus { get; set; }

    public System.DateTime DeliveryDate { get; set; }



    public virtual Customers Customers { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Deliveries> Deliveries { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<OrderItems> OrderItems { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Returns> Returns { get; set; }

}

}