using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvSlicer.Models
{
    /// <summary>
    /// Container for all runtime parameters needed for running functions
    /// </summary>
    internal class RunArgs : IRunArgs
    {
        public RunArgs()
        {
            
        }

        public RunArgs(int sliceSize = 10000, int headerRows = 1) : this()
        {
            SliceSize = sliceSize;
            HeaderRows = headerRows;
        }

        /// <summary>
        /// File FQDN passed as argument
        /// </summary>
        public string InputFile { get; set; } = string.Empty;

        /// <summary>
        /// Parent directory of the input file. Calculated. Needed to save output files
        /// </summary>
        public string InputDirPath { get; set; } = string.Empty;

        /// <summary>
        /// Name only, without extension, of the input file. Calculated. Needed to generate output file names
        /// </summary>
        public string InputFileName { get; set; } = string.Empty;

        /// <summary>
        /// Extension of the input file. Calculated. Needed to generate output file names
        /// </summary>
        public string InputFileExtension { get; set; } = string.Empty;

        /// <summary>
        /// Number of initial lines to be treated as header. To be repeated on all slices
        /// </summary>
        public int HeaderRows { get; set; }

        /// <summary>
        /// Number of riows for each slice.
        /// </summary>
        public int SliceSize { get; set; }

        /// <summary>
        /// date time format to use for log files
        /// </summary>
        public string TimeStampFormat { get; set; } = string.Empty;

        /// <summary>
        /// Format to apply for output slices
        /// </summary>
        public string OutFileFormat { get; set; } = string.Empty;

        /// <summary>
        /// number of digits to use for the slice numbering
        /// </summary>
        public int SliceNumberSize { get; set; }

        /// <summary>
        /// Stop processing after specified slices, even if data exists.
        /// </summary>
        public int MaxSlices { get; set; }

        /// <summary>
        /// Number of lines to read and write as a block
        /// </summary>
        public int IO_Block_Size { get; set; }

        /// <param name="jsonData">Serialized json string to deserialize</param>
        public void FromJson(string jsonData)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Serialize object to loggable string format
        /// </summary>
        public override string ToString()
        {
            throw new System.NotImplementedException();
        }
    }
}
