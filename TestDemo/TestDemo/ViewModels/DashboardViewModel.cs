using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using DevExpress.XtraRichEdit.Commands;
using TestDemo.Models;

namespace TestDemo.ViewModels
{
    public class DashboardViewModel
    {

        public Product Product { get; set; }
        public List<AreaRowVM> Rows { get; set; }
        public List<TaskHeaderVM> TaskHeaders { get; set; }

        public DashboardViewModel()
        {
            Product = TestProduct();
            TaskHeaders = TestHeaders();
            Rows = TestRows();
            AreaRowVM firstRecord = Rows.First(x => x.Area == "Area1");
            //making row with same area 
            AreaRowVM rowsWithDifferentMileStone = firstRecord.ShallowCopy();
            rowsWithDifferentMileStone.MileStoneId = 2;
            rowsWithDifferentMileStone.RowKey = "1.2";

//            Task1AreaIDTaskID   "11/28/2017 12:00:00 AM-1-2"    System.String


            rowsWithDifferentMileStone.DynamicTask.Task1AreaIDTaskID = $"11/28/2017 12:00:00 AM-1-1";
            Rows.Insert(1,rowsWithDifferentMileStone);


            AreaRowVM secondRow = Rows.First(x => x.Area == "Area2");
            //AreaRowVM thirdRow = Rows.First(x => x.Area == "Area3");
            //thirdRow.ActivitysList.Clear();
            //thirdRow.ActivitysList.AddRange(secondRow.ActivitysList);
           // Rows.Find(x => x.Area == "Area3").DynamicTask = secondRow.DynamicTask;
            
        }

        public List<AreaRowVM> TestRows()
        {
            Random random = new Random();
            List<AreaRowVM> testRows = new List<AreaRowVM>();

            for (int i = 1; i < 10; i++)
            {
                testRows.Add(new AreaRowVM()
                {
                    RowKey = $"{i}.1",
                    Area = $"Area{i}",
                    AreaID = i,
                    MileStoneId = 1,
                    ConstructionOwner = $"ConstructionOwner{i}",
                    LinePointOfContact = i % 2 == 1 ? "odd Todd" : "even steven",
                    ProductLine = $"Product{i}",
                    Section = $"Section{i}",
                    ActivitysList = new List<ActivityVM>()
                });
                for (int j = 0; j < 5; j++)
                {
                    DateTime randomdate = DateTime.Today.AddDays(random.Next(-180, 180));
                    testRows[i-1].ActivitysList.Add(new ActivityVM()
                    {
                        CommitDate = randomdate,
                        NeedDate = randomdate.AddDays(random.Next(-30,30)),
                        IsAcculized = (i + j) % 2 == 0,
                        TaskDescription = $"Task{j}",
                        TaskID = j,
                        AreaID = i
                      });

                    //make area three same as area 2. 
                    if (i == 3)
                    {
                        testRows[2].ActivitysList[j].CommitDate = testRows[1].ActivitysList[j].CommitDate;
                        testRows[2].ActivitysList[j].NeedDate = testRows[1].ActivitysList[j].NeedDate;
                        testRows[2].ActivitysList[j].IsAcculized = testRows[1].ActivitysList[j].IsAcculized;
                     }

                }
                // create last coloumn with all same data

                testRows[i-1].ActivitysList.Add(new ActivityVM()
                {
                    CommitDate = DateTime.Today,
                    NeedDate = DateTime.Today.AddDays(1),
                    IsAcculized = true,
                    TaskDescription = $"Task5",
                    TaskID = 5,
                    AreaID = i
                });



                testRows[i-1].PopulateTaskDatesDictonary();
            }
            return testRows;
        }

        public List<TaskHeaderVM> TestHeaders()
        {
            List<TaskHeaderVM> testHeaders = new List<TaskHeaderVM>();
            for (int i = 1; i < 6; i++)
            {
                testHeaders.Add(new TaskHeaderVM(i, $"Task{i}", i));

            }
            return testHeaders;
        }

        public void InitializeActivityHeadingsForProduct(int vmProductID)
        {
            List<TaskHeaderVM> list = new List<TaskHeaderVM>();

            for (int i = 1; i < 10; i++)
            {
                list.Add(new TaskHeaderVM(i, $"Task{i}", i));
            }
            TaskHeaders = list;
        }

        private List<ActivityVM> AddMissingCellsToRow(dynamic row, IEnumerable<int?> headerIDs)
        {
            List<ActivityVM> temp = (List<ActivityVM>) row.ActivitysList;
            foreach (int? headerID in headerIDs)
            {
                ActivityVM activity = new ActivityVM()
                {
                    CommitDate = null,
                    NeedDate = null,
                    IsAcculized = false,
                    TaskID = headerID,
                    TaskDescription = TaskHeaders.Single(x => x.ID == headerID).Decription
                };
                temp.Add(activity);
                row.ActivitysList = (List<ActivityVM>) row.ActivitysList;
            }
            return temp;
        }

        public List<int?> HeaderIdsWithoutCells(List<ActivityVM> activitysList)
        {
            List<int?> headerIDs = TaskHeaders.Select(x => x.ID).ToList();
            foreach (ActivityVM activity in activitysList)
            {
                if (headerIDs.Contains(activity.TaskID))
                {
                    headerIDs.Remove(activity.TaskID);
                }
            }
            // headerID now contains only headers that have no values in row.Activity list.
            return headerIDs;
        }

        public class TaskHeaderVM
        {
            public int? ID { get; set; }
            public string Decription { get; set; }
            public int? SortOrder { get; set; }

            public TaskHeaderVM(int? id, string decription, int? sortorder)
            {
                ID = id;
                Decription = decription;
                SortOrder = sortorder;
            }

            public TaskHeaderVM()
            {
            }
        }

        public Product TestProduct()
        {
          Product product = new Product()
            {
                ProductID = 1,
                ProductName = "test Product",
                Areas = new List<Area>(),
                ProductTasks = new List<ProductTask>(),
            };
            for (int i = 1; i < 10; i++)
            {
                product.Areas.Add(new Area()
                {
                    AreaID = i,
                    AreaName = $"AreaName{i}",
                    Section = $"section{i}",
                    PointOfContactUser = i % 2 == 0 ? "Even steven" : "odd todd"
                });
 }
            return product;
        }

    public class AreaRowVM
    {
        public int AreaID { get; set; }
        public String Section { get; set; }
        public String ProductLine { get; set; }
        public String Area { get; set; }
        public string Phase { get; set; }
        public string LinePointOfContact { get; set; }
        public string ConstructionOwner { get; set; }

        //ActivityList is only used as a temp staging location for Activies that ultimately populates the TaskDates array for the view. 
        public List<ActivityVM> ActivitysList { get; set; }

        //TaskDates is used by the view and is based off the ActivityList
        public dynamic DynamicTask { get; set; }

        public int MileStoneId { get; set; }
        public string RowKey { get; set; }

        public void PopulateTaskDatesDictonary()
        {
            IDictionary<string, Object> taskDateExpando = new ExpandoObject() as IDictionary<string, Object>;
            foreach (ActivityVM a in ActivitysList)
            {
                taskDateExpando.Add($"{a.TaskDescription}Commit", a.CommitDate);
                taskDateExpando.Add($"{a.TaskDescription}Need", a.NeedDate);
                taskDateExpando.Add($"{a.TaskDescription}IsAcculized", a.IsAcculized);
                taskDateExpando.Add($"{a.TaskDescription}AreaIDTaskID", $"{a.CommitDate}-{a.AreaID}-{a.TaskID}");
                taskDateExpando.Add($"{a.TaskDescription}AreaID", $"{a.AreaID}");
                taskDateExpando.Add($"{a.TaskDescription}TaskID", $"{a.TaskID}");
                }
            DynamicTask = taskDateExpando;
        }

        public AreaRowVM ShallowCopy()
        {
            return (AreaRowVM) MemberwiseClone();

        }



    }

    public class ActivityVM
    {
        public DateTime? CommitDate { get; set; }
        public DateTime? NeedDate { get; set; }
        public bool IsAcculized { get; set; }
        public int? TaskID { get; set; }
        public string TaskDescription { get; set; }
        public int AreaID { get; set; }

    }

    }
}