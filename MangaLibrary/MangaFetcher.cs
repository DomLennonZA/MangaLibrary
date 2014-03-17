using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MangaLibrary
{
    public class MangaFetcher
    {
        public Series[] GetAllSeries()
        {
            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString("http://www.mangaeden.com/api/list/0/");
                SeriesContainer container = JsonConvert.DeserializeObject<SeriesContainer>(json);
                return container.manga;
            }
        }

        public Manga GetChapters(string id)
        {
            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString(string.Format("http://www.mangaeden.com/api/manga/{0}/", id));
                Manga o = JsonConvert.DeserializeObject<Manga>(json);
                return o;
            }
        }

        public Dictionary<int, string> GetPages(string id)
        {
            using (WebClient wc = new WebClient())
            {
                Dictionary<int, string> result = new Dictionary<int, string>();
                string json = wc.DownloadString(string.Format("http://www.mangaeden.com/api/chapter/{0}/", id));
                PageContainer o = JsonConvert.DeserializeObject<PageContainer>(json);
                foreach (JArray ja in o.Images)
                {
                    result.Add((int)ja[0], string.Format("http://cdn.mangaeden.com/mangasimg/{0}", ja[1]));
                }

                return result;
            }
        }
    }
}
