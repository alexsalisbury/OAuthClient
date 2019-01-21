namespace Home.Todoist.Converters
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// https://stackoverflow.com/questions/14427596/convert-an-int-to-bool-with-json-net
    /// </summary>
    public class BoolConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(bool);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return reader.Value.ToString() == "1";
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((bool)value) ? 1 : 0);
        }
    }
}