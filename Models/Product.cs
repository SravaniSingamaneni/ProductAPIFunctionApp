using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;

namespace ProductAPIFunctionApp.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("productCode")]
        public string? ProductCode {  get; set; }

        [BsonElement("productName")]
        public string? ProductName { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("productItems")]
        public List<ProductItemsCls>? ProductItems { get; set; }

        [BsonElement("totalAmount")]
        public decimal? TotalAmount {  get; set; }

        [BsonElement("productCreatedDate")]
        public DateTime? ProductCreatedDate {  get; set; }

    }

    public class ProductItemsCls
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("productId")]
        public string? ProductId {  get; set; }

        [BsonElement("quantity")]
        public string? Quantity {  get; set; }

        [BsonElement("price")]
        public decimal? Price {  get; set; }
    }
}
