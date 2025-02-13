using Books.Core.Interfaces;
using Books.Core.Model.BaseModel;
using Books.Core.Model.Pager;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Books.Core.Base;
using Books.Core.Model.Book;
namespace Books.Core.Services
{
    public class BookServices :  AbstractBaseRequests,IBooks 
    {

        private Pager _pager;
        private OperationResult _result;
        private BaseModel _baseresult;

        public BookServices() : base(Const.API_URL)
        {
            _result = new OperationResult();
            _baseresult = new BaseModel();
        }

        public async Task<OperationResult> AddBook(Book book)
        {
            try
            {
                var result = await Post<Book>("/api/v1/Books", book);
                _result= new OperationResult
                {
                     Data = result.Data
                };
                return _result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<BaseModel> DeleteBook(int BookID)
        {
            try
            {
                var result = await Delete<BaseModel>($"/api/v1/Books/{BookID}");
                _baseresult= new BaseModel
                {
                    Sucess = true,
                    Message = ""
                };
                return _baseresult;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async  Task<OperationResult> EditBook(int BookID, Book book)
        {
            try
            {
                var result = await Put<Book>($"/api/v1/Books/{BookID}", book);
                _result= new OperationResult
                {
                    Data = result.Data
                };
                return _result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<OperationResult> GetAllBooks()
        {
            try
            {
                var result = await Get<List<Book>>($"/api/v1/Books");
                _result= new OperationResult
                {
                   Data = result.Data
                };
                return _result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<OperationResult> GetBookByID(int bookID)
        {
            try
            {
                var result = await Get<Book>($"/api/v1/Books/{bookID}");
                _result= new OperationResult
                {
                    Sucess = true,
                    Message = "",
                    Data = result.Data
                };
                return _result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
