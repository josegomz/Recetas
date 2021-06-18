using System;

namespace Recetas.Models
{
    public class Receta
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Ingredients { get; set; }
        public string Instruction { get; set; }
    }
}