﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Ado.Net.Data
{
    internal class Sql
    {
        private const string _connectionString= "server=DESKTOP-2BIHFIP;database=TaskArtist;Trusted_connection=true;integrated security=true";
        private static SqlConnection _connection=new SqlConnection(_connectionString);

        public int ExecuteCommand(string cmd)
        {
            int result = 0;
            try
            {
                SqlCommand command = new SqlCommand(cmd, _connection);
                result=command.ExecuteNonQuery();
            }
            catch (Exception )
            {

                throw ;
            }
            finally
            {
                _connection.Close();
            } 
            return result;
        } 

        public DataTable ExecuteQuery(string query)
        {
            DataTable table = new DataTable();
            try
            {
                _connection.Open();
                SqlDataAdapter adapter= new SqlDataAdapter(query, _connection);
                adapter.Fill(table);
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                _connection.Close();
            }
            return table;
            
            
                
           
        }
        
    }
}
