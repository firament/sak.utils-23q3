namespace CsvSlicer.Models
{
    internal interface IRunArgs
    {
        int HeaderRows { get; set; }
        string InputDirPath { get; set; }
        string InputFileExtension { get; set; }
        string InputFileName { get; set; }
        string InputFile { get; set; }
        int SliceSize { get; set; }
        string TimeStampFormat { get; set; }
        string OutFileFormat { get; set; }
        int SliceNumberSize { get; set; }
        int MaxSlices { get; set; }
        int IO_Block_Size { get; set; }

        void FromJson(string jsonData);
        string ToString();
    }
}