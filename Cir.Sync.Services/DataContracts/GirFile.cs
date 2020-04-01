﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Sync.Services.DataContracts
{
    public class GirFile
    {
        public long Id { get; set; }
        public string FileName { get; set; }
        public string DownloadUrl { get; set; }
        public byte[] FileBytes { get; set; }
    }
}
