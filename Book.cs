using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ObligatoriskOpgave1
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return $"{Id} {Title} {Price}";
        }

        public void ValidateTitle()
        {
            if (Title == null)
            {
                throw new ArgumentNullException(nameof(Title), "Title kan ikke være null");
            }
            if (Title.Length < 3)
            {
                throw new ArgumentException("Title skal have mindst 1 karakter", nameof(Title));
            }
        }

        public void ValidatePrice()
        {
            if (Price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Price), "Price skal mindst være 1");
            }
            if (Price > 1201)
            {
                throw new ArgumentOutOfRangeException(nameof(Price), "Price skal være under 1201");
            }
        }

        public void Validate()
        {
            ValidateTitle();
            ValidatePrice();
        }
    }
}
