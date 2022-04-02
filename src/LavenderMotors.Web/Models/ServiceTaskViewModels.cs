using LavenderMotors.Entities;

namespace LavenderMotors.Web.Models;

public class ServiceTaskListViewModel
{
    public string Code { get; set; }
    public string Description { get; set; }
    public decimal Hours { get; set; }
    public ServiceTaskListViewModel()
    {

    }
    public ServiceTaskListViewModel(ServiceTask serviceTask)
    {
        Code = serviceTask.Code;
        Description = serviceTask.Description;
        Hours = serviceTask.Hours;
    }
}

public class ServiceTaskCreateViewModel
{
    public string Code { get; set; }
    public string Description { get; set; }
    public decimal Hours { get; set; }
    public ServiceTaskCreateViewModel()
    {

    }
    public ServiceTaskCreateViewModel(ServiceTask serviceTask)
    {
        Code = serviceTask.Code;
        Description = serviceTask.Description;
        Hours = serviceTask.Hours;

    }
}

public class ServiceTaskUpdateViewModel
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public decimal Hours { get; set; }
    public ServiceTaskUpdateViewModel()
    {

    }
    public ServiceTaskUpdateViewModel(ServiceTask serviceTask)
    {
        Id = serviceTask.Id;
        Code = serviceTask.Code;
        Description = serviceTask.Description;
        Hours = serviceTask.Hours;
    }
}

public class ServiceTaskFinishViewModel
{
    public Guid Id { get; set; }
    public ServiceTaskFinishViewModel()
    {

    }
    public ServiceTaskFinishViewModel(ServiceTask serviceTask)
    {
        Id = serviceTask.Id;
    }
}

public class ServiceTaskDeleteViewModel
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public decimal Hours { get; set; }
    public ServiceTaskDeleteViewModel()
    {

    }
    public ServiceTaskDeleteViewModel(ServiceTask serviceTask)
    {
        Id = serviceTask.Id;
        Code = serviceTask.Code;
        Description = serviceTask.Description;
        Hours = serviceTask.Hours;

    }
}
