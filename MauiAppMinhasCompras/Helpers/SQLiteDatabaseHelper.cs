﻿using MauiAppMinhasCompras.Models;
using SQLite;

namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;
        public SQLiteDatabaseHelper(string path) 
        { 
            _conn = new SQLiteAsyncConnection(path);
            _conn.createTableAsync<Produto>().Wait();
        }
        public Task<int> Insert(Produto p) 
        {
            return _conn.InsertAsync(p);
        }
        public Task<List<Produto>> Update(Produto p) 
        {
            String sql = "UPDATE Produto SET Descrição=?, Quantidade=?, Preco=? WHERE Id=?";
            return _conn.QueryAsync<Produto>(sql, p.Descricão, p.Quantidade, p.Preco, p.Id);
        }
        public Task<int> Delete(int id) 
        {
        return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }
        public Task<List<Produto>> GetAll() 
        {
            return _conn.Table<Produto>().ToListAsync();
        }
        public Task<List<Produto>> Search(String q) 
        {
            String sql = "SELECT * Produto WHERE descrição LIKE '%" + q + "%'";
            return _conn.QueryAsync<Produto>(sql);
        }



    }
}
