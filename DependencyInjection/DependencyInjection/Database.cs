using System;
using Npgsql;
using DependencyInjection.Models;

namespace DependencyInjection
{
    public interface IDatabase
    {
        void Create(Contact contact);
        void Read();
        void Update();
        void Delete();
    }

    public class Database : IDatabase
    {
        // Attributes
        NpgsqlConnection _connection;

        // Contructor
        public Database(NpgsqlConnection connection)
        {
            _connection = connection;

            _connection.Open();
        }

        public void Create(Contact contact)
        {
            var command = new NpgsqlCommand("INSERT INTO contact(username, pass, email, fullname) VALUES(@username, @pass, @email, @fullname)", _connection);
            command.Parameters.AddWithValue("@username", contact.Username);
            command.Parameters.AddWithValue("@pass", contact.Pass);
            command.Parameters.AddWithValue("@email", contact.Email);
            command.Parameters.AddWithValue("@fullname", contact.Full_Name);

            command.Prepare();
            command.ExecuteScalar();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
