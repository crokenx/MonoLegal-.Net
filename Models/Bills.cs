using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiNetCoreMonoLegal.Models {

    public class Bills
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }

        public string CodigoFactura { get; set; }

        public string Cliente { get; set; }

        public string Ciudad { get; set; }

        public string NIT { get; set; }

        public int TotalFactura { get; set; }

        public int SubTotal { get; set; }

        public int Iva { get; set; }

        public int Retencion { get; set; }

        public string FechaCreacion { get; set; }

        public string Estado { get; set; }

        public bool Pagada { get; set; }

        public string FechaPago { get; set; }

        public string email { get; set; }
    }

    public class getResponse
    {
        public bool ok { get; set; }

        public Bills bills { get; set; }
    }
}

