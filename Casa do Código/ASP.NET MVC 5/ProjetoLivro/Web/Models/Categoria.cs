﻿using System.Collections.Generic;

namespace Web.Models
{
    public class Categoria
    {
        public long Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}