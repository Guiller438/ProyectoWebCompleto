using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IW7PP.Models.ProsthesisM;

namespace IW7PP.Models.Cliente
{
    public class Cliente
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
        
        //Conexion con protesis
        
        public int ProtesisId { get; set; }
        public Prosthesis Prosthesis { get; set; }

        //Conexion con estilo de vida

        public int LifeStyleId { get; set; }
        public LifeStyle LifeStyle { get; set; }
    }
}