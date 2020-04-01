using System.Collections.Generic;

namespace Cir.Data.Access.Models
{
    public class ValidationMethodsModel
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public IList<ValidationInput> ValidationInputs { get; set; }
    } 

    public class ValidationInput
    {
        public string ControlKey { get; set; }
        public string ControlName { get; set; }
    }
}
