﻿namespace DesafioBackend.Models
{
    public class Autor
    {
  
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime Date { get; set; }
        public List<Book> Books { get; set; }
    }
}
