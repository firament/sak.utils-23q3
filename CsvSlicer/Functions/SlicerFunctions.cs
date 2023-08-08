using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using CsvSlicer.Models;

namespace CsvSlicer.Functions
{
    internal class SlicerFunctions
    {
        public SlicerFunctions()
        {
            
        }

        public SlicerFunctions(string[] args) {
            RunConfig = ProcessParameters(args);
        }

        public Models.RunArgs RunConfig { get; set; }

        public Models.RunArgs ProcessParameters(string[] args)
        {
            // Extract

            // Validate L1

            // Validate L2

            return null;
        }


        public void DoSlices()
        {

        }

        public void WriteHistory()
        {

        }
    }
}
