using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MangaLibrary
{
    public class Chapter
    {
        public string ChapterName { get; set; }
        public float ChapterNumber { get; set; }
        public string ChapterID { get; set; }

        internal static Chapter CreateChapter(object x)
        {
            JArray o = x as JArray;
            return new Chapter
                       {
                           ChapterNumber = (float)o[0],
                           ChapterName = o[2] == null ? ((int)o[0]).ToString() : (string)o[2],
                           ChapterID = (string)o[3]
                       };
        }
    }
}
