using System;
using System.Collections;



namespace TestTask
{
    class Program
    {

        static void Main(string[] args)
        {
            string pathToInputFile = "../../../acme_worksheet.csv";
            ArrayList recordsList = Record.ConvertFileToRecords(pathToInputFile);
            ArrayList workloadList = Workload.CreateWorkloadList(recordsList);
            string pathToOutputFile = "../../../acme_worksheet_out.csv";
            Workload.ConvertWorkloadListToFile(pathToOutputFile, workloadList);

        }
    }
}
