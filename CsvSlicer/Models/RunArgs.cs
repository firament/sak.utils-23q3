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
        /// <summary>
        /// File FQDN passed as argument
        /// </summary>
        public string InputFilePath
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Parent directory of the input file. Calculated. Needed to save output files
        /// </summary>
        public string InputDirPath
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Name only, without extension, of the input file. Calculated. Needed to generate output file names
        /// </summary>
        public string InputFileName
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Extension of the input file. Calculated. Needed to generate output file names
        /// </summary>
        public string InputFileExtension
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Number of initial lines to be treated as header. To be repeated on all slices
        /// </summary>
        public int HeaderRows
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Number of riows for each slice.
        /// </summary>
        public int SliceSize
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// date time format to use for log files
        /// </summary>
        public string TimeStampFormat
        {
            get => default;
            set
            {
            }
        }

        public void FromJson()
        {
            throw new System.NotImplementedException();
        }
    }
}
