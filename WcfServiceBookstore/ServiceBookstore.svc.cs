using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
namespace WcfServiceBookstore
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IServiceBookstore
    {
        public void AddBook(Book newBook)
        {
           XmlDocument doc = new XmlDocument();
           doc.Load(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\Bookstore.xml");
           XmlNode root = doc.SelectSingleNode("bookstore");

            XmlNode title = doc.CreateNode("element", "title", "");
            title.InnerText = newBook.Title;
            XmlNode _price = doc.CreateNode("element", "price", "");
            _price.InnerText = newBook.Price.ToString();
            XmlNode _author = doc.CreateNode("element", "author", "");
            _author.InnerText = newBook.Author;
            XmlElement _newBook = doc.CreateElement("book");
            XmlNode _year = doc.CreateNode("element", "year", "");
            _year.InnerText = newBook.Year.ToString();

            _newBook.SetAttribute("category", newBook.Category.ToString());
            _newBook.AppendChild(title);
            _newBook.AppendChild(_author);
            _newBook.AppendChild(_year);
            _newBook.AppendChild(_price);
           
            root.AppendChild(_newBook);
            doc.Save(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\Bookstore.xml");
        }

        public bool DeleteBook(string title)
        {
            bool isDeleted = false;
            XmlDocument doc = new XmlDocument();
            doc.Load(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\Bookstore.xml");
            XmlNode root = doc.SelectSingleNode("bookstore");
            XmlNode oldChild = doc.SelectSingleNode("/bookstore/book[title='"+title+"']");
            if (oldChild != null)
            {
                root.RemoveChild(oldChild);
                isDeleted = true;
            }
            doc.Save(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\Bookstore.xml");
            return isDeleted;
        }

        public List<Book> GetBooks()
        {
            List<Book> Books = new List<Book>();
            XmlDocument doc = new XmlDocument();
            doc.Load(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\Bookstore..xml");
            XmlNodeList nodeList = doc.SelectNodes("/bookstore");
            foreach(XmlNode item in nodeList)
                
        }

        public List<Book> GetBooksByCategory(BookCategory category)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetBooksByTitle(BookCategory category)
        {
            throw new NotImplementedException();
        }
    }
}
