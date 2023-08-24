using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using CsvSlicer.Models;
using CsvSlicer.Statics;

namespace CsvSlicer.Functions
{
    internal class SlicerFunctions
    {
        public SlicerFunctions() { }

        public SlicerFunctions(string[] args) : this()
        {
            RunConfig = ProcessParameters(args);
        }

        public Models.IRunArgs RunConfig { get; set; } = new Models.RunArgs();
        public bool Healthy { get => !(RunConfig == null || string.IsNullOrWhiteSpace(RunConfig?.InputFileExtension)); }

        public Models.IRunArgs ProcessParameters(string[] args)
        {
            //List<string> lssErrors = new();
            int liWorkVal;

            Models.IRunArgs runArgs = new Models.RunArgs();
            if (args == null || args.Length < 1)
            {
                Console.WriteLine("Cannot run without an 'input file'.");
                return runArgs;
            }

            // Extract

            // INPUT FILE
            if (string.IsNullOrWhiteSpace(args[Constants.ARG_FILE]))
            {
                Console.WriteLine("Cannot use a blank 'input file'.");
                // Make error entry
            }
            else
            {
                runArgs.InputFile = args[Constants.ARG_FILE];
            }
            if (!File.Exists(runArgs.InputFile))
            {
                Console.WriteLine("Cannot open 'input file'.");
                // make error entry
            }
            else
            {
                FileInfo loIF = new(runArgs.InputFile);
                runArgs.InputDirPath = loIF.DirectoryName ?? string.Empty;
                if (string.IsNullOrWhiteSpace(runArgs.InputDirPath)) { }
                runArgs.InputFileExtension = loIF.Extension;
                runArgs.InputFileName = loIF.Name.Remove(loIF.Name.Length - loIF.Extension.Length);
            }


            // SLICE SIZE
            liWorkVal = -1;
            if (args.Length > Constants.ARG_SLICE_SIZE && int.TryParse(args[Constants.ARG_SLICE_SIZE], out liWorkVal))
            {
                // Make info entry
            }
            else if (liWorkVal < Constants.SLICE_SIZE_MIN)
            {
                // Make info entry
            }
            runArgs.SliceSize = (liWorkVal > 0) ? liWorkVal : Constants.SLICE_SIZE_DEFAULT;
            Console.WriteLine("using SliceSize  = {0}", runArgs.SliceSize);

            // HEADER ROWS
            liWorkVal = -1;
            if (args.Length > Constants.ARG_HEADER_ROWS && int.TryParse(args[Constants.ARG_HEADER_ROWS], out liWorkVal))
            {
                // Make info entry
            }
            else if (liWorkVal < Constants.HEADER_ROWS_MIN)
            {
                // Make info entry
            }
            runArgs.HeaderRows = (liWorkVal > 0) ? liWorkVal : Constants.HEADER_ROWS_DEFAULT;
            Console.WriteLine("using HeaderRows = {0}", runArgs.HeaderRows);

            // FILL DEFAULTS AND NOT-YET IMPLEMENTED ARGS
            runArgs.MaxSlices = Constants.MAX_SLICES_DEFAULT;
            runArgs.SliceNumberSize = Constants.SLICE_NUMBER_DIGITS;
            runArgs.OutFileFormat = Constants.FORMAT_OUTFILE_NAME;
            runArgs.TimeStampFormat = Constants.TIMESTAMP_FORMAT_DEFAULT;
            runArgs.IO_Block_Size = Constants.IO_BLOCK_LINES;

            return runArgs;
        }


        public void DoSlices()
        {
            //bool lbDo = true;
            string lsOutFilePrefix;
            string lsOutFile;
            string? lsLine;
            List<string> lstHeader = new(RunConfig.HeaderRows);
            List<string> lstBlock = new(RunConfig.IO_Block_Size + 5);

            StreamReader? lsrIn = null;
            StreamWriter? lswOut = null;

            // Counters
            int liSlice = 1;
            int liBlock;
            int liFileLines;

            // Timers
            DateTimeOffset ldtStart = DateTimeOffset.Now;
            TimeSpan ltsEffort;

            if (!Healthy)
            {
                Console.WriteLine("Not healthy, cannott run.");
                return;
            }

            try
            {
                lsLine = null;
                lsOutFilePrefix = Path.Combine(RunConfig.InputDirPath, RunConfig.InputFileName);

                // Open file
                lsrIn = new StreamReader(RunConfig.InputFile);

                // Copy headers
                for (int i = 0; i < RunConfig.HeaderRows; i++)
                {
                    lsLine = lsrIn.ReadLine();
                    if (lsLine == null) break;
                    lstHeader.Add(lsLine);
                }

                // Shortcircuit empty file
                if (lsLine == null)
                {
                    // write error
                    return;
                }

                // till EOF
                // for each slice
                // for each block

                while (RunConfig.MaxSlices >= liSlice)
                {
                    Console.WriteLine("Writing Slice: {0:0,000}", liSlice);
                    // update outfile name, and open
                    // {FILENAME}--{SLICE_NUMBER}.{EXTENSION}
                    lsOutFile = string.Format(RunConfig.OutFileFormat, lsOutFilePrefix, liSlice, RunConfig.InputFileExtension);
                    lswOut = new StreamWriter(lsOutFile, false, Encoding.UTF8);
                    foreach (string vsH in lstHeader) lswOut.WriteLine(vsH);
                    lswOut.FlushAsync().Wait();
                    liFileLines = 0;
                    while (liFileLines < RunConfig.SliceSize)
                    {
                        lstBlock.Clear();
                        // Read Block
                        for (liBlock = 0; liBlock < RunConfig.IO_Block_Size; liBlock++)
                        {
                            lsLine = lsrIn?.ReadLine();
                            if (lsLine == null) break;
                            lstBlock.Add(lsLine);
                            liFileLines ++;
                            if (liFileLines >= RunConfig.SliceSize) break;
                        }
                        // Write Block and Flush
                        foreach (string vsB in lstBlock) lswOut.WriteLine(vsB);
                        lswOut.FlushAsync().Wait();
                        //liFileLines += liBlock;
                        if (lsLine == null) break;
                    }
                    lswOut.Close();
                    Console.WriteLine($"Wrote {liFileLines} lines in slice.");

                    if (lsLine == null) break;
                    liSlice++;
                }
                // Write stats
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (lsrIn != null)
                {
                    lsrIn.Close();
                    lsrIn.Dispose();
                }
                lswOut?.Dispose();
            }

            ltsEffort = DateTimeOffset.Now - ldtStart;
            Console.WriteLine("Done. Wrote {0:#,#00} slices in {1:#,#00.000} seconds.", liSlice, ltsEffort.TotalMilliseconds / 1000);
            Console.WriteLine("Exiting.");
        }

        public void WriteHistory()
        {
            Console.WriteLine("To be done");
        }
    }
}
