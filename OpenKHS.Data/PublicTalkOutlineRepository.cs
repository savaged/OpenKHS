﻿using System;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using OpenKHS.Models;
using System.Collections.Generic;
using OpenKHS.Interfaces;

namespace OpenKHS.Data
{
    public class PublicTalkOutlineRepository : IModelRepository<PublicTalkOutline>
    {
        private IList<PublicTalkOutline> _index;

        public readonly string ResourceLocation;

        public PublicTalkOutlineRepository()
        {
            ResourceLocation = ApplicationData.ResourceLocation + "PublicTalkOutlines.json";            
        }

        public IList<PublicTalkOutline> Index()
        {
            if (_index == null)
            {
                if (File.Exists(ResourceLocation))
                {
                    var json = File.ReadAllText(ResourceLocation);
                    _index = JsonConvert.DeserializeObject<List<PublicTalkOutline>>(json);
                }
                else
                {
                    _index = new List<PublicTalkOutline>();
                }
            }
            return _index;
        }

        public PublicTalkOutline Show(int id)
        {
            return Index().Where(p => p.Id == id).FirstOrDefault();
        }

        public void Store(PublicTalkOutline @new)
        {
            if (!Index().Contains(@new))
            {
                Index().Add(@new);
            }
        }

        public void Delete(PublicTalkOutline model)
        {
            if (!Index().Contains(model))
            {
                Index().Remove(model);
            }
        }

        public void Save()
        {
            var json = JsonConvert.SerializeObject(Index(), Formatting.Indented);
            File.WriteAllText(ResourceLocation, json);
        }

    }
}
