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

        public static Tuple<ArrayList, SortedSet<DateTime>> CreateWorkloadList(ArrayList recordsList)
        {  
            
            SortedDictionary<string, Workload> workloadEmployees = new SortedDictionary<string, Workload>();
            SortedSet<DateTime> dates = new SortedSet<DateTime>();

            foreach (Record i in recordsList)
            {
                dates.Add(i.Date);
                
                if (!workloadEmployees.ContainsKey(i.EmployeeName))
                {
                    Workload newWorkload = new Workload(i.EmployeeName, new SortedDictionary<DateTime, double>());
                    workloadEmployees.Add(i.EmployeeName, newWorkload);
                }

                if (!workloadEmployees[i.EmployeeName].EmployeeWorkload.ContainsKey(i.Date))
                {
                    workloadEmployees[i.EmployeeName].EmployeeWorkload.Add(i.Date, i.WorkHours);
                }
                else
                {
                    workloadEmployees[i.EmployeeName].EmployeeWorkload[i.Date] += i.WorkHours;
                }
               
            }

            ArrayList workloadList = new ArrayList(workloadEmployees.Values);
            return Tuple.Create(workloadList, dates);
            
        }


        public static void ConvertWorkloadListToFile(string pathToOutputFile, Tuple<ArrayList, SortedSet<DateTime>> workloadListTuple)
        {
            
            using (StreamWriter streamWriter = new StreamWriter(pathToOutputFile, false, System.Text.Encoding.Default))
            {
                ArrayList workloadList = workloadListTuple.Item1;
                SortedSet<DateTime> dates = workloadListTuple.Item2;

                streamWriter.Write("Name / Date");
                foreach (DateTime i in dates)
                {
                    streamWriter.Write(",");
                    streamWriter.Write(i.ToString("d"));
                }
                streamWriter.WriteLine();
                foreach (Workload i in workloadList)
                {
                    streamWriter.Write(i.EmployeeName);

                    foreach (DateTime j in dates)
                    {
                        streamWriter.Write(",");
                        if (i.EmployeeWorkload.ContainsKey(j))
                        {
                            
                            streamWriter.Write(Convert.ToString(i.EmployeeWorkload[j]).Replace(',', '.'));
                        }
                        else
                        {
                            streamWriter.Write("0");
                        }
                    }
                    streamWriter.WriteLine(); 
                }

            }
        }

    }
}
