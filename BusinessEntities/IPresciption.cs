using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public interface IPrescription
    {
        int PrescriptionID { get; set; }
        string DrugName { get; set; }
        DateTime DateWritten { get; set; }
        DateTime DateProcessed { get; set; }
        DateTime DateDispensed { get; set; }
        DateTime DateExpires { get; set; }
        string Instruction { get; set; }
        int QuantityWritten { get; set; }
        int QuantityDispensed { get; set; }
        string DrugCategory { get; set; }
        int UserID { get; }
        string ClientID { get; }
        int GpID { get; }
        string ImageLocation { get; set; }
    }
}
