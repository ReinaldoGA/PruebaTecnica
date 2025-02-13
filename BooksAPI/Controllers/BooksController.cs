using Books.Core.Interfaces;
using Books.Core.Model.BaseModel;
using Books.Core.Model.Book;
using Books.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBooks _bookServices;
        private OperationResult _operationResult;
        private BaseModel _baseresult;

        public BooksController(IBooks Services)
        {
            _bookServices = Services;
            _operationResult = new OperationResult();
            _baseresult = new BaseModel();
        }

        /// <summary>
        /// Get all the books 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<OperationResult>> GetAllBooks()
        {
            _operationResult = await _bookServices.GetAllBooks();
            if (_operationResult.Sucess)
            {
                return Ok(_operationResult);
            }
            return BadRequest(_operationResult);
        }
        /// <summary>
        /// Get the book by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<OperationResult>> GetBooksByID(int id)
        {
            _operationResult = await _bookServices.GetBookByID(id);
            if (_operationResult.Sucess)
            {
                return Ok(_operationResult);
            }
            return BadRequest(_operationResult);
        }

        /// <summary>
        /// Add Books
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<OperationResult>> AddBooks(Book book)
        {
            if (book is null)
            {
                return BadRequest(_operationResult);
            }

            _operationResult = await _bookServices.AddBook(book);
            if (_operationResult.Sucess)
            {
                return CreatedAtAction(nameof(AddBooks), _operationResult.Data );
            }
            return BadRequest(_operationResult);
        }
        /// <summary>
        /// Update the book passed by ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<OperationResult>> UpdateBooks(int id, Book book)
        {
            if (book is null)
            {
                return BadRequest(_operationResult);
            }

            _operationResult =   await _bookServices.EditBook(id, book);
            if (_baseresult.Sucess)
            {
                return CreatedAtAction(nameof(AddBooks), _operationResult.Data);
            }
            return BadRequest(_operationResult);
        }

        /// <summary>
        /// Delete book refered on ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseModel>> DeleteBook(int id)
        {

            _baseresult =   await _bookServices.DeleteBook(id);
            if (_baseresult.Sucess)
            {
                return CreatedAtAction(nameof(AddBooks), _baseresult);
            }
            return BadRequest(_baseresult);
        }

    }
}
