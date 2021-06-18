using System;
using SQLite;

namespace Recetas.Models
{
    public class Receta
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Ingredients { get; set; }
        public string Instruction { get; set; }
    }
}