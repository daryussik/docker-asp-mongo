using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AspNetService.Models
{
    public class MessageDataModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        
        public string Message { get; set; }
        
        public DateTime DateUtc { get; set; }
    }
}