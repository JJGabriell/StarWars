using Newtonsoft.Json;
using StarWars.Interface;
using StarWars.Models;
using StarWars.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarWars.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private string Api = "https://swapi.dev/api/";

        private int DefaultPage = 1;

        private int DefaultSize = 10;

        private string urlEndCharacter = "/";

        private string urlData;

        private IDataService dataService;

        private T entity;

        public string Path => urlData;

        public Repository()
            : this((IDataService)new DefaultDataService(new StarWarsService()), "https://swapi.dev/api/")
        {
        }

        public Repository(IDataService dataService)
            : this(dataService, "https://swapi.dev/api/")
        {
        }

        public Repository(IDataService dataService, string url)
        {
            entity = HelperInitializer<T>.Instance();
            this.dataService = dataService;
            if (!url.EndsWith(urlEndCharacter))
            {
                url += urlEndCharacter;
            }
            urlData = url;
        }

        public T GetById(int id)
        {
            string url = $"{urlData}{entity.GetPath()}{id}";
            string jsonResponse = dataService.GetDataResult(url);
            if (jsonResponse == null)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }

        public ICollection<T> GetEntities(int page = 1, int size = 10)
        {
            string url = urlData + entity.GetPath() + "?page=" + page;
            IEnumerable<T> results = new List<T>();
            Helper<T> helper = new Helper<T>
            {
                Next = url,
                Previous = null
            };
            string jsonResponse = string.Empty;
            while (helper.Next != null)
            {
                jsonResponse = dataService.GetDataResult(helper.Next);
                if (jsonResponse == null)
                {
                    return null;
                }
                helper = JsonConvert.DeserializeObject<Helper<T>>(jsonResponse);
                if (helper == null)
                {
                    return null;
                }
                results = results.Union(helper.Results);
                if (results.Count() >= size)
                {
                    return results.Take(size).ToList();
                }
            }
            return results.ToList();
        }
    }
}