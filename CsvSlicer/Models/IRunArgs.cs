namespace CsvSlicer.Models
{
    internal interface IRunArgs
    {
        int HeaderRows { get; set; }
        string InputDirPath { get; set; }
        string InputFileExtension { get; set; }
        string InputFileName { get; set; }
        string InputFilePath { get; set; }
        int SliceSize { get; set; }
        string TimeStampFormat { get; set; }

        void FromJson();
    }
}