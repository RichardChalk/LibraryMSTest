using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Book
    {
        public Book(string isbn, string author, string title)
        {
            Isbn = isbn;
            Author = author;
            Count = 0;
        }
        public string Isbn { get; }
        public string Author { get; }
        public string Title { get; }
        public int Count { get; protected set; }
        public int Borrowed => borrowers.Count;
        public int Available => Count - Borrowed;

        private List<string> borrowers = new List<string>();

        public bool Borrow(string borrower)
        {
            if (borrowers.Count() >= Count) return false;
            borrowers.Add(borrower);
            return true;
        }

        public bool IsBorrower(string borrower)
        {
            return borrowers.Contains(borrower);
        }

        public void BuyNewEx(int count)
        {
            Count += count;
        }
    }
}
