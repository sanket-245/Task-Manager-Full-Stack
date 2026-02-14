using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class CreateUserDTO
    {
        public String UserName; 

        public String Password; 
        
        public String Email;

        public DateTime CreatedAt;
    } 
}
