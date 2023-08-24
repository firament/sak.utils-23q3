using CsvSlicer.Functions;

namespace CsvSlicer
{

    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            DoSlices(args);
        }

        static void DoSlices(string[] args)
        {
            SlicerFunctions slicer = new SlicerFunctions(args);
            slicer.DoSlices();
        }
    }
}