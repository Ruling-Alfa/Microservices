using System;

namespace CrossCutting.Persistance.Mongo.Entities
{
    public interface IDocument
    {
        public string Id { get; set; }
    }
}
