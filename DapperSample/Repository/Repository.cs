// <copyright file="RepositoryBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DapperSample.Repository
{
    using DapperSample.Contracts;
    using DapperSample.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using Dapper;

    public class Repository : IRepository<Cohort>
    {
        private IDbConnection dbConnection = null;

        public Repository()
        {
            dbConnection = new SqlConnection(ConfigReader.ConnectionString);
        }

        public List<Cohort> GetAll()
        {
            string sql = ConfigReader.ReadAllCommand;
            var queryResult = dbConnection.Query<Cohort>(sql);

            return queryResult.ToList();
        }

        //public bool Add(Cohort entity)
        //{
        //    var result = false;
        //    try
        //    {
        //        string sql = ConfigReader.InsertCommand;

        //        var count = dbConnection.Execute(sql, book);
        //        result = count > 0;
        //    }
        //    catch { }

        //    return result;
        //}

        //public Cohort GetById(Guid id)
        //{
        //    Book book = null;
        //    string sql = ConfigReader.ReadOneCommand;
        //    var queryResult = dbConnection.Query<Book>(sql, new { Id = id });

        //    if (queryResult != null)
        //    {
        //        book = queryResult.FirstOrDefault();
        //    }
        //    return book;
        //}

        //public bool Update(Cohort entity)
        //{
        //    string sql = ConfigReader.UpdateCommand;
        //    var count = dbConnection.Execute(sql, book);
        //    return count > 0;
        //}

        //public bool Delete(Guid id)
        //{
        //    string sql = ConfigReader.DeleteCommand;
        //    var count = dbConnection.Execute(sql, new { Id = id });
        //    return count > 0;
        //}
    }
}
