using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MangaLibrary
{
    class PageContainer
    {
        [JsonProperty(PropertyName = "images")]
        public JArray[] Images { get; set; }
    }
}
