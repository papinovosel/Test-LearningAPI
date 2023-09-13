using System;

namespace ModelsProject.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<BooksUsers> BooksUsers { get; set; }
    }
}
