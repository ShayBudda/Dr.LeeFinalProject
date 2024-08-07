using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dr.LeeFinalProject
{
    public interface ReportGenerator // Declaring the ReportGenerator interface
    {
        void GenerateReport(List<Item> items); // Method to generate a report
    }
}
