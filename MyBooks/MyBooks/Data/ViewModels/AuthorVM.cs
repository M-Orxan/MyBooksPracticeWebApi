using MyBooks.Data.Models;

namespace MyBooks.Data.ViewModels
{
    public class AuthorVM
    {
        public string FullName { get; set; }

    }



    public class AuthorWithBooksVM
    {
        public string FullName { get; set; }
        public List<string> BookNames { get; set; }

    }
}
