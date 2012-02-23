using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DreamSongs.MongoRepository;
using MongoDB.Bson;

namespace webapi_mongo.Models
{
    public class Workshop : Entity
    {
        public string Title { get; set; }
        public string Location { get; set; }
    }
}