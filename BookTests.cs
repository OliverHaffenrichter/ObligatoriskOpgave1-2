using ObligatoriskOpgave1;
namespace BookTest
{
    [TestClass]
    public class BookTesting
    {
        private readonly Book _book = new() { Id = 1, Title = "Jeff", Price = 1 };
        private readonly Book _nullTitle = new() { Id = 2, Price = 1 };
        private readonly Book _shortTitle = new() { Id = 3, Title = "", Price = 1 };
        private readonly Book _priceLower = new() { Id = 4, Title = "Jeff", Price = -1 };
        private readonly Book _priceHigher = new() { Id = 5, Title = "Jeff", Price = 1202 };


        [TestMethod]
        public void ToStringTest()
        {
            Assert.AreEqual("1 Jeff 1", _book.ToString());
        }

        [TestMethod()]
        public void ValidateTitleTest()
        {
            _book.ValidateTitle();
            Assert.ThrowsException<ArgumentNullException>(() => _nullTitle.ValidateTitle());
            Assert.ThrowsException<ArgumentException>(() => _shortTitle.ValidateTitle());
        }

        [TestMethod()]
        public void ValidatePriceTest()
        {
            _book.ValidatePrice();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _priceLower.ValidatePrice());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _priceHigher.ValidatePrice());
        }

        [TestMethod()]
        public void ValidateTest()
        {
            _book.Validate();
        }
    }
}