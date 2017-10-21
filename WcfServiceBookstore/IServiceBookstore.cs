using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceBookstore
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceBookstore
    {
        [OperationContract]
        void AddBook(Book newBook);

        [OperationContract]
        List<Book> GetBooks();

        [OperationContract]
        List<Book> GetBooksByCategory(BookCategory category);

        [OperationContract]
        List<Book> GetBooksByTitle(BookCategory category);

        [OperationContract]
        bool DeleteBook(string title);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Book
    {
        [DataMember]
        public string Title
        { get; set; }

        [DataMember]
        public string Author
        { get; set; }

        [DataMember]
        public int Year
        { get; set; }

        [DataMember]
        public double Price
        { get; set; }

        [DataMember]
        public BookCategory Category 
        {
            get;set;
        }

    }
}

public enum BookCategory
{
    Web,
    Children,
    Science,
    Romance,
    Biographies,
    Other
}
