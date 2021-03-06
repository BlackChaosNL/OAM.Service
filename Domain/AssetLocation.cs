﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAM.Service.Domain
{
    public class AssetLocation
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public List<Asset>? Assets { get; set; }
        public string ClientId { get; set; }
    }
}
