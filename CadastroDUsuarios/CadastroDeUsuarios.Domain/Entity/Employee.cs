using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeUsuarios.Domain.Entity
{
    public class Employee
    {
        [Key]
        public Guid Id { get; private set; } 
        public string name { get; set; }
        public int age { get; set; }
        public string? photo { get; set; }

        public string imageURL { get; set; }

        public Employee() { }
        public Employee(string name, int age, string photo, string imageUrl)
        {
            Id = Guid.NewGuid();
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.age = age;
            this.photo = photo;
            this.imageURL = imageUrl;
        }
    }
}

