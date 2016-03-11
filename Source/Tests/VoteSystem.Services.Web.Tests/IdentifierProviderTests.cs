namespace VoteSystem.Services.Web.Tests
{
    using Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IdentifierProviderTests
    {
        [TestMethod]
        public void EncodingAndDecodingDoesntChangeTheId()
        {
            const int Id = 17;
            IIdentifierProvider provider = new IdentifierProvider();
            var encoded = provider.EncodeId(Id);
            var actual = provider.DecodeId(encoded);
            Assert.AreEqual(Id, actual);
        }
    }
}
