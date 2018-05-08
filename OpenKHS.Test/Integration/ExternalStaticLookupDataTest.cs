using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenKHS.Data;
using OpenKHS.Models;

namespace OpenKHS.Test.Integration
{
    [TestClass]
    public class ExternalStaticLookupDataTest : TestBase
    {
        [TestMethod]
        public void IntegrationTestPublicTalkOutlineRW()
        {
            var repo = new PublicTalkOutlineRepository();
            var file = repo.ResourceLocation + "Test.json";

            if (File.Exists(file)) File.Delete(file);

            var index = repo.Index();
            Assert.IsNotNull(index);
            Assert.AreEqual(0, index.Count);

            for (int i = 1; i < 11; i++)
            {
                var pto = new PublicTalkOutline()
                {
                    Id = i,
                    Title = $"Title {i}"
                };
                repo.Store(pto);
            }
            repo.Save();

            Assert.AreEqual(10, repo.Index().Count);

            var sample = repo.Show(7);
            Assert.AreEqual("Title 7", sample.Title);

            File.Delete(file);
        }
    }
}
