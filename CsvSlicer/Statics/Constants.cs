using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvSlicer.Statics
{
    internal static class Constants
    {
        // Positional Args
        public const int ARG_FILE = 0;
        public const int ARG_SLICE_SIZE = 1;
        public const int ARG_HEADER_ROWS = 2;

        // DEFAULT VALUES
        public const int HEADER_ROWS_DEFAULT = 1;
        public const int SLICE_SIZE_DEFAULT = 100000;
        public const int MAX_SLICES_DEFAULT = int.MaxValue; // 0 implies unlimited slices, till data runs out.


        public const int IO_BLOCK_LINES = 5000;
        public const int SLICE_NUMBER_DIGITS = 2;
        public const string TIMESTAMP_FORMAT_DEFAULT = "yyyyMMdd-HHmm";
        public const string FORMAT_OUTFILE_NAME = "{0}--{1:00}.{2}"; // {FILENAME}--{SLICE_NUMBER}.{EXTENSION}

        // MINIMUM VALUES
        public const int HEADER_ROWS_MIN = 1;
        public const int SLICE_SIZE_MIN = 10;

    }
}
