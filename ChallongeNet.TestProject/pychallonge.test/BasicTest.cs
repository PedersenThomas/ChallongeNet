using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallongeNet.TestProject.Pychallonge.Test
{
    [TestClass]
    public class BasicTest
    {
        [TestMethod]
        [TestCategory("Basic"), TestCategory("pychallongeTest")]
        public void GetCredentials_Test()
        {
            const string Username = "user";
            const string ApiKey = "ApiKey";
            var challonge = new ChallongeV1(Username, ApiKey);

            Assert.AreEqual(Username, challonge.Username);
            Assert.AreEqual(ApiKey, challonge.Apikey);
        }
    }
}
