using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAM.Service.Domain
{
    public class Asset
    {
        public int Id { get; set; }
        public AssetType Type { get; set; }
        public string Description { get; set; }
        public List<Asset>? SubAssets { get; set; }
    }
}
