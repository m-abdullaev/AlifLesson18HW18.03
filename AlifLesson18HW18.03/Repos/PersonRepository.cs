using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using AlifLesson18HW18._03.Models;

namespace AlifLesson18HW18._03.Repos
{
    class PersonRepository : RepositoryBase<Person>
    {
        public PersonRepository() : base()
        { 
                    
        }
        public void Create()
        {
            Person person = new Person();
            Console.WriteLine("Last Name: ");
            person.LastName = Console.ReadLine();
            Console.WriteLine("First Name: ");
            person.FirstName = Console.ReadLine();
            Console.WriteLine("Middle Name: ");
            person.MiddleName = Console.ReadLine();
            Console.WriteLine("Date of Birth: ");
            person.BirthDate = DateTime.Parse(Console.ReadLine());
            try
            {
                using (IDbConnection db = new SqlConnection(conString))
                {
                    var command = $"insert into Persons([LastName],[FirstName],[MiddleName],[BirthDate]) values('{person.LastName}','{person.FirstName}','{person.MiddleName}',{person.BirthDate}); SELECT CAST(SCOPE_IDENTITY() AS INT)";
                    db.Query<int>(command, person);
                    Console.WriteLine("Person successfully added");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        
        
        public void Read()
        {
            foreach (var item in SelectAll())
            {
                Console.WriteLine($"Id: {item.ID} | LastName: {item.LastName} | FirstName: {item.FirstName} | MiddleName: {item.MiddleName} | BirthDate: {item.BirthDate}");
            }        
        }
        public void Delete()
        {
            Console.WriteLine("Please enter id of the person you would like to delete: ");
            Console.Write("ID: "); 
            int ID = int.Parse(Console.ReadLine());
            try
            {
                using (IDbConnection db = new SqlConnection(conString))
                {
                    var command = $"delete from Persons where Id = {ID}";
                    db.Execute(command, new { ID });
                    Console.WriteLine("Successfully deleted");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        

        
    }
}
