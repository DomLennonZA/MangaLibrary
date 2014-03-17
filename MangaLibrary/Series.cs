using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace MangaLibrary
{
    public class Series
    {
        private const string IMAGE_PREFIX = "http://cdn.mangaeden.com/mangasimg/";
        [JsonProperty(PropertyName = "t")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "im")]
        private string _imageUrl = string.Empty;
        public string ImageUrl
        {
            get { return IMAGE_PREFIX + _imageUrl; }
            set { _imageUrl = value; }
        }
        [JsonProperty(PropertyName = "i")]
        public string ID { get; set; }
        [JsonProperty(PropertyName = "a")]
        public string Alias { get; set; }
    }
}
