using System;
namespace DCE.Models
{
    public class GenericResponse
    {
       public Boolean success { get; set; }
       public String message { get; set; }
       public Object payload { get; set; }
    }
}

