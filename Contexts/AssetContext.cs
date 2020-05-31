using Microsoft.EntityFrameworkCore;
using OAM.Service.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAM.Service.Contexts
{
    public partial class AssetContext : DbContext
    {
        public AssetContext(DbContextOptions<AssetContext> context) : base(context)
        {}

        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetLocation> AssetLocations { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }
    }
}
