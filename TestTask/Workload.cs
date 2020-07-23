using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace TestTask
{
    class Workload
    {
        private string employeeName;
        private SortedDictionary<DateTime, double> employeeWorkload;

        public string EmployeeName
        {
            get
            {
                return employeeName;
            }

            set
            {
                employeeName = value;
            }
        }

        public SortedDictionary<DateTime, double> EmployeeWorkload
        {
            get
            {
                return employeeWorkload;
            }

            set
            {
                employeeWorkload = value;
            }
        }
        public Workload(string name, SortedDictionary<DateTime, double> workload)
        {
            employeeName = name;
            employeeWorkload = workload;
        }

        public static ArrayList CreateWorkloadList(ArrayList recordsList)
        {
            SortedSet<DateTime> dates = new SortedSet<DateTime>();
            SortedSet<string> employees = new SortedSet<string>();
            foreach (Record i in recordsList)
            {
                dates.Add(i.Date);
                employees.Add(i.EmployeeName);
            }
            ArrayList workloadList = new ArrayList();
            foreach (string i in employees)
            {
                SortedDictionary<DateTime, double> newDayHourList = new SortedDictionary<DateTime, double>();
                foreach (DateTime j in dates)
                {
                    newDayHourList.Add(j, 0);
                }
                Workload newWorkload = new Workload(i, newDayHourList);
                workloadList.Add(newWorkload);
            }
            foreach (Record i in recordsList)
            {
                foreach (Workload j in workloadList)
                {
                    if (i.EmployeeName == j.EmployeeName)
                    {
                        j.EmployeeWorkload[i.Date] += i.WorkHours;
                    }
                }
            }
            return workloadList;
        }


        public static void ConvertWorkloadListToFile(string pathToOutputFile, ArrayList workloadList)
        {
            using (StreamWriter streamWriter = new StreamWriter(pathToOutputFile, false, System.Text.Encoding.Default))
            {
                Workload firstWorkload = (Workload)workloadList[0];
                streamWriter.Write("Name / Date");
                foreach (KeyValuePair<DateTime, double> i in firstWorkload.EmployeeWorkload)
                {
                    streamWriter.Write(",");
                    streamWriter.Write(i.Key.ToString("d"));
                }
                streamWriter.WriteLine();
                foreach (Workload i in workloadList)
                {
                    streamWriter.Write(i.EmployeeName);
                    foreach (KeyValuePair<DateTime, double> j in i.EmployeeWorkload)
                    {
                        streamWriter.Write(",");
                        streamWriter.Write(Convert.ToString(j.Value).Replace(',', '.'));
                    }
                    streamWriter.WriteLine();
                }

            }
        }

    }
}
