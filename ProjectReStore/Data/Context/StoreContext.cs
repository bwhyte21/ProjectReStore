using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Context;

public class StoreContext : DbContext
{
    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="options"></param>
    public StoreContext(DbContextOptions options) : base(options) { }

    #region DBSets

    /// <summary>
    /// The table "set" to be created.
    /// </summary>
    public DbSet<Product> Products { get; set; }

    #endregion
}