using Microsoft.EntityFrameworkCore;

namespace Week6_Lectorial.Models;

// Set composite primary key with PrimaryKey annotation or Fluent-API in the Week6LectorialContext.cs file.
[PrimaryKey(nameof(StoreID), nameof(ProductID))]
public class StoreProduct
{
    public int StoreID { get; set; }
    public virtual Store Store { get; set; }

    public int ProductID { get; set; }
    public virtual Product Product { get; set; }

    public int Quantity { get; set; }
}
