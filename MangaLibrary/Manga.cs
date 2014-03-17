using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace MangaLibrary
{
    public class Manga
    {
        private const string IMAGE_PREFIX = "http://cdn.mangaeden.com/mangasimg/";
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "image")]
        private string _imageUrl = string.Empty;
        public string ImageUrl
        {
            get { return IMAGE_PREFIX + _imageUrl; }
            set { _imageUrl = value; }
        }
        [JsonProperty(PropertyName = "chapters")]
        private object[] _serializedChapters { get; set; }
        private Chapter[] _chapters;
        public Chapter[] Chapters
        {
            get
            {
                if (_chapters == null)
                {
                    _chapters = new Chapter[_serializedChapters.Length];
                    for (int i = 0;i<_serializedChapters.Length;i++)
                    {
                        _chapters[i] = Chapter.CreateChapter(_serializedChapters[i]);
                    }
                    _serializedChapters = null;
                }

                return _chapters;
            }
        }
    }
}
