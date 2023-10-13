using ObligatoriskOpgave1;
namespace BookTest
{
    [TestClass]
    public class BooksRepositoryTests
    {
        public BooksRepository _repo;
        private Book _BadBook;

        [TestInitialize]
        public void Init()
        {
            _repo = new BooksRepository();

            _repo.Add(new Book() { Title = "Bird", Price = 117});
            _repo.Add(new Book() { Title = "Sun", Price = 109});
            _repo.Add(new Book() { Title = "Cave", Price = 125});
            _repo.Add(new Book() { Title = "Yard", Price = 148 });

            _BadBook = new Book();
        }

        [TestMethod]
        public void GetTest()
        {
            IEnumerable<Book> Books = _repo.Get();
            Assert.AreEqual(4, Books.Count());
            Assert.AreEqual(Books.First().Title, "Bird");

            IEnumerable<Book> BookSort = _repo.Get(orderBy: "Title");
            Assert.AreEqual(BookSort.First().Title, "Bird");

            IEnumerable<Book> BookSort2 = _repo.Get(orderBy: "Price");
            Assert.AreEqual(BookSort2.First().Title, "Bird");
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Assert.IsNotNull(_repo.GetById(1));
            Assert.IsNull(_repo.GetById(100));
        }

        [TestMethod()]
        public void AddTest()
        {
            Book m = new() { Title = "Test", Price = 213};
            Assert.AreEqual("Test", _repo.Add(m).Title);
            Assert.AreEqual(5, _repo.Get().Count());
            _BadBook.Title = "Good";
            _BadBook.Price = -10;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _repo.Add(_BadBook));
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.IsNull(_repo.Delete(100));
            Assert.AreEqual(1, _repo.Delete(1)?.Id);
            Assert.AreEqual(3, _repo.Get().Count());
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.AreEqual(4, _repo.Get().Count());
            Book m = new() { Title = "Test", Price = 213 };
            Assert.IsNull(_repo.Update(100, m));
            Assert.AreEqual(1, _repo.Update(1, m)?.Id);
            Assert.AreEqual(4, _repo.Get().Count());
            _BadBook.Title = "Good";
            _BadBook.Price = -10;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _repo.Update(1, _BadBook));
        }
    }
}