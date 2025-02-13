using Books.Core.Base;
using Books.Core.Model.BaseModel;
using Books.Core.Model.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core.Interfaces
{
    public interface IBooks  
    {

        /// <summary>
        /// Search the Book  by ID
        /// </summary>
        /// <param name="bookID"></param>
        /// <returns></returns>
        Task<OperationResult> GetBookByID(int bookID);

        /// <summary>
        /// Get all the books listed
        /// /// </summary>
        /// <returns></returns>
        Task<OperationResult> GetAllBooks();

        /// <summary>
        /// Add the Book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        Task<OperationResult> AddBook(Book book);

        /// <summary>
        /// Edit the Book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        Task<OperationResult> EditBook(int BookID, Book book);


        /// <summary>
        /// Delete the Book
        /// </summary>
        /// <param name="BookID"></param>
        /// <returns></returns>
        Task<BaseModel> DeleteBook(int BookID);
    }
}
