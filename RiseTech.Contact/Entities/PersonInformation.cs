using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RiseTech.Contact.Enums;

namespace RiseTech.Contact.Entities
{
    public class PersonInformation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("PersonId")]
        public string PersonId { get; set; }

        [BsonElement("ContactType")]
        public ContactType ContactType { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }
    }
}
