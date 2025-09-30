using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManageer.Dto.Requests
{
    public class FunctionRequest
    {
        [Required]
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
