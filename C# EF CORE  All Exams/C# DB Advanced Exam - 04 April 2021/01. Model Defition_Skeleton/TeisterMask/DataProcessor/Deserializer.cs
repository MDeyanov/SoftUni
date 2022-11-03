namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var projectsXml = XmlConverter.Deserializer<ProjectInputModel>(xmlString, "Projects");

            HashSet<Project> projects = new HashSet<Project>();
            foreach (var projectXml in projectsXml)
            {
                if (!IsValid(projectXml))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var openDate = DateTime.ParseExact(
                    projectXml.OpenDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture);

                var isValidueDate = DateTime.TryParseExact(
                    projectXml.DueDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime dueDate);


                var project = new Project
                {
                    Name = projectXml.Name,
                    OpenDate = openDate,
                    DueDate = isValidueDate ? (DateTime?)dueDate : null,
                                     
                };
                HashSet<Task> projectTasks = new HashSet<Task>();

                foreach (var taskDto in projectXml.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isTaskOpenDateValid = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskOpenDate);

                    if (!isTaskOpenDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isTaskDueDateValid = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskDueDate);

                    if (!isTaskDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOpenDate < project.OpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskDueDate > project.DueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task t = new Task()
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = Enum.Parse<ExecutionType>(taskDto.ExecutionType),
                        LabelType = Enum.Parse<LabelType>(taskDto.LabelType)
                    };

                    projectTasks.Add(t);

                    project.Tasks = projectTasks;
                }
                projects.Add(project);

                sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, projectTasks.Count()));
            }
            context.Projects.AddRange(projects);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var employeesJson = JsonConvert.DeserializeObject<IEnumerable<EmployeeModelView>>(jsonString);

            var employees = new List<Employee>();

            foreach (var employeeJson in employeesJson)
            {
                if (!IsValid(employeeJson))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee
                {
                    Username = employeeJson.Username,
                    Email = employeeJson.Email,
                    Phone = employeeJson.Phone            
                };
                 HashSet<EmployeeTask> employeeTasks = new HashSet<EmployeeTask>();
                foreach (var taskId in employeeJson.Tasks.Distinct())
                {
                    var newTask = context.Tasks.Find(taskId);
                    if (newTask==null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    

                    var newEmployeTask = new EmployeeTask
                    {
                        EmployeeId = employee.Id,
                        Employee = employee,
                        TaskId = newTask.Id,
                        Task = newTask
                    };
                   // newTask.EmployeesTasks.Add(newEmployeTask);
                    //employee.EmployeesTasks.Add(newEmployeTask);
                    employeeTasks.Add(newEmployeTask);
                }
                employee.EmployeesTasks = employeeTasks;
                employees.Add(employee);
                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employeeTasks.Count));
            }
            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}

//Tasks = projectXml.Tasks.Select(t => new Task
//{
//    Name = t.Name,
//    OpenDate = DateTime.ParseExact(t.OpenDate, "dd/MM/yyyy",
//                                               CultureInfo.InvariantCulture),
//    DueDate = DateTime.ParseExact(t.DueDate, "dd/MM/yyyy",
//                                               CultureInfo.InvariantCulture),
//    ExecutionType = Enum.Parse<ExecutionType>(t.ExecutionType),
//    LabelType = Enum.Parse<LabelType>(t.LabelType)
//}).ToList().Where(x => x.OpenDate < openDate).ToList()