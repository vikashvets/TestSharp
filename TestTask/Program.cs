using System;
using System.Collections;
using System.Collections.Generic;



namespace TestTask
{
    class Program
    {

        static void Main(string[] args)
        {
            string pathToInputFile = "../../../acme_worksheet.csv";
            ArrayList recordsList = Record.ConvertFileToRecords(pathToInputFile);
            Tuple<ArrayList, SortedSet<DateTime>> workloadList = Workload.CreateWorkloadList(recordsList);
            string pathToOutputFile = "../../../acme_worksheet_out.csv";
            Workload.ConvertWorkloadListToFile(pathToOutputFile, workloadList);

        }
    }
}
