namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute root = new XmlRootAttribute("Projects");
            XmlSerializer serializer = new XmlSerializer(typeof(ProjectDto[]), root);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            using StringWriter sw = new StringWriter(sb);

            ProjectDto[] projects = context.Projects
                .ToArray()
                .Where(p => p.Tasks.Count >= 1)
                .Select(p => new ProjectDto()
                {
                    TasksCount = p.Tasks.Count,
                    ProjectName = p.Name,
                    HasEndDate = p.DueDate.HasValue ? "Yes" : "No",
                    Tasks = p.Tasks
                             .Select(x => new TaskViewModel()
                             {
                                 Name = x.Name,
                                 Label = x.LabelType.ToString()
                             })
                             .OrderBy(t=>t.Name)
                             .ToArray()
                })
                .OrderByDescending(x => x.Tasks.Count())
                .ThenBy(x => x.ProjectName)
                .ToArray();

            serializer.Serialize(sw, projects, namespaces);

            return sb.ToString().TrimEnd();
            //StringBuilder sb = new StringBuilder();

            //XmlRootAttribute root = new XmlRootAttribute("Projects");
            //XmlSerializer serializer = new XmlSerializer(typeof(ProjectDto[]), root);

            //XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            //namespaces.Add(String.Empty, String.Empty);

            //using StringWriter sw = new StringWriter(sb);

            //ProjectDto[] projects = context.Projects
            //    .ToArray()
            //    .Where(p => p.Tasks.Any())
            //    .Select(p => new ProjectDto()
            //    {
            //        ProjectName = p.Name,
            //        TasksCount = p.Tasks.Count,
            //        HasEndDate = p.DueDate.HasValue ? "Yes" : "No",
            //        Tasks = p.Tasks.Select(t => new TaskViewModel()
            //        {
            //            Name = t.Name,
            //            Label = t.LabelType.ToString()
            //        })
            //            .OrderBy(t => t.Name)
            //            .ToArray()
            //    })
            //    .OrderByDescending(p => p.TasksCount)
            //    .ThenBy(p => p.ProjectName)
            //    .ToArray();

            //serializer.Serialize(sw, projects, namespaces);

            //return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .ToArray()
                .Where(x => x.EmployeesTasks.Any(et => et.Task.OpenDate >= date))
                .Select(e => new
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                     .Where(t => t.Task.OpenDate >= date)
                     .OrderByDescending(t => t.Task.DueDate)
                     .ThenBy(t => t.Task.Name)
                     .Select(et => new
                     {
                         TaskName = et.Task.Name,
                         OpenDate = et.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                         DueDate = et.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                         LabelType = et.Task.LabelType.ToString(),
                         ExecutionType = et.Task.ExecutionType.ToString()
                     })
                     .ToArray()
                })
                .OrderByDescending(e => e.Tasks.Length)
                .ThenBy(e => e.Username)
                .Take(10)
                .ToArray();

            string result = JsonConvert.SerializeObject(employees, Formatting.Indented);

            return result;


        }
    }
}