﻿using SQLite;

namespace MauiAppMinhasCompras.Models
{
    public class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricão { get; set; }
        public double Quantidade {  get; set; }
        public double Preco {  get; set; }

    }
}
