namespace Home.TodoistClient.Tests.Converters
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using Home.TodoistClient.Converters;

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class BoolConverter_Tests
    {
        public class MicroObject
        {
            [JsonProperty("t")]
            [JsonConverter(typeof(BoolConverter))]
            public bool T { get; set; }

            [JsonProperty("f")]
            [JsonConverter(typeof(BoolConverter))]
            public bool F { get; set; }
        }

        [TestMethod]
        public void CanConvertABool()
        {
            BoolConverter bc = new BoolConverter();

            Assert.IsTrue(bc.CanConvert(typeof(bool)));
            Assert.IsFalse(bc.CanConvert(bc.GetType()));
            Assert.IsFalse(bc.CanConvert(string.Empty.GetType()));
            Assert.IsFalse(bc.CanConvert(string.Empty.Length.GetType()));
        }

        [TestMethod]
        public void ReadWriteSmoke()
        {
            string example = "{\"t\":1,\"f\":0}";
            var item = JsonConvert.DeserializeObject<MicroObject>(example);

            Assert.IsNotNull(item);
            Assert.IsTrue(item.GetType() == typeof(MicroObject));
            Assert.IsTrue(item.T);
            Assert.IsFalse(item.F);

            var ser = JsonConvert.SerializeObject(item);
            Assert.AreEqual(example, ser);

        }
    }
}