using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPP2_Lab_1
{
    class Book
    {
        private string name;
        private string author;
        private int price;
        private string publisher;
        private int pages;
        public Book(string name, string author, int price, string publisher, int pages)
        {
            this.name = name;
            this.author = author;
            this.price = price;
            this.publisher = publisher;
            this.pages = pages;
        }
        public string GetName()
        {
            return this.name;
        }
        public string GetAuthor()
        {
            return this.author;
        }
        public int GetPrice()
        {
            return this.price;
        }
        public string GetPublisher()
        {
            return this.publisher;
        }
        public int GetPages()
        {
            return this.pages;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetAuthor(string author)
        {
            this.author = author;
        }
        public void SetPrice(int price)
        {
            this.price = price;
        }
        public void SetPublisher(string publisher)
        {
            this.publisher = publisher;
        }
        public void SetPages(int pages)
        {
            this.pages = pages;
        }
        public override string ToString()
        {
            return String.Format("Name = {0}, Author = {1}, Price = {2}, Publisher = {3}, Pages = {4}", this.name, this.author, this.price, this.publisher, this.pages);
        }
        public bool IsEqual(Book bookToCompare)
        {
            if (this.name == bookToCompare.name && this.author == bookToCompare.author && this.price == bookToCompare.price && this.publisher == bookToCompare.publisher && this.pages == bookToCompare.pages)
                return true;
            else return false;
        }
    }
}
