﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain;

[Table("Sales.Orders")]
public class Orders
{
    [Key]
    public int orderid { get; set; }
    public int custid { get; set; }
    public int empid { get; set; }
    public DateTime? orderdate { get; set; }
    public DateTime? requireddate { get; set; }
    public DateTime? shippeddate { get; set; }
    public int shipperid { get; set; }
    public decimal freight { get; set; }
    public string? shipname { get; set; }
    public string? shipaddress { get; set; }
    public string? shipcity { get; set; }
    public string? shipregion { get; set; }
    public string? shippostalcode { get; set; }
    public string? shipcountry { get; set; }
}
