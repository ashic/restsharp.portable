﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RestSharp.Portable.Test
{
    [TestClass]
    public class CustomDeserializer
    {
        class TestDeserializer : RestSharp.Portable.Deserializers.JsonDeserializer
        {
            protected override void ConfigureSerializer(Newtonsoft.Json.JsonSerializer serializer)
            {
                base.ConfigureSerializer(serializer);
                serializer.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat;
            }
        }

        [TestMethod]
        public void TestReplaceContentTypeDeserializer()
        {
            var restClient = new RestClient();
            var deserializer = new TestDeserializer();
            restClient.ReplaceHandler(typeof(RestSharp.Portable.Deserializers.JsonDeserializer), deserializer);
            Assert.AreSame(deserializer, restClient.GetHandler("application/json"));
            Assert.AreSame(deserializer, restClient.GetHandler("text/json"));
        }
    }
}
