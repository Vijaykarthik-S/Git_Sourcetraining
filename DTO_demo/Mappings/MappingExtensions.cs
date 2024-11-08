using DTO_demo.Models;
using DTO_demo.DTO;
using System.Runtime.CompilerServices;

namespace DTO_demo.Mappings
{
    public static class MappingExtensions
    {
        public static BookDTO ToDTO(this Book book) {
            return new BookDTO
            { 
                Id = book.Id,   
                Title = book.Title,
                Author = book.Author,
                Price = book.Price
            };
        }
        public static Book ToEntity(this BookDTO bookDTO) {
            return new Book { 
                Id = bookDTO.Id,
                Title = bookDTO.Title,
                Author = bookDTO.Author,
                Price = bookDTO.Price,
                Releasedate = DateTime.Now,
                Genre = "Comic"
            };
        }
        public static List<BookDTO> ToDTOList(this List<Book> books) { 
            return books.Select(book=> book.ToDTO()).ToList();
        }
    }
}
