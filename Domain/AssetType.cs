using IdentityServer4.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAM.Service.Domain
{
    public class AssetType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ClientId { get; set; }
    }
}
