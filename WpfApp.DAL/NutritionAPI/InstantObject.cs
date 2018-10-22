using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WpfApp.DAL.NutritionAPI
{
    public partial class InstantObject
    {
        [JsonProperty("food_name")]
        public string FoodName { get; set; }

        [JsonProperty("serving_unit")]
        public string ServingUnit { get; set; }

        [JsonProperty("serving_qty")]
        public long ServingQty { get; set; }

        [JsonProperty("common_type")]
        public object CommonType { get; set; }

        [JsonProperty("photo")]
        public Photo Photo { get; set; }

        [JsonProperty("tag_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long TagId { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }
    }

    public partial class Photo
    {
        [JsonProperty("thumb")]
        public Uri Thumb { get; set; }
    }

    public partial class InstantObject
    {
        public static InstantObject FromJson(string json) => JsonConvert.DeserializeObject<InstantObject>(json, NutritionAPI.Converter.Settings);
    }

    public static partial class Serialize
    {
        public static string ToJson(this InstantObject self) => JsonConvert.SerializeObject(self, NutritionAPI.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
            new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
        },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
