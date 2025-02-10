using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TaskList.Data.Base;
using TaskList.Data.Model;
using TaskList.Requests;
using TaskList.Responses;

namespace TaskList.Endpoints;

public static class TaskExtentions
{
    public static void AddEndpointsTask(this WebApplication app)
    
    {
        app.MapGet("/Tasks", ([FromServices]DAL<Tarefa> dal) =>
        {
            var taskList = dal.Listar();
            if (taskList is null)
            {
                return Results.NotFound();
            }
            var TaskListResponse = ConvertEntityToResponseList(taskList);
            return Results.Ok(TaskListResponse);
        });
        app.MapPost("/Tasks", (
            [FromServices]DAL<Tarefa> dal,
            [FromBody]TaskRequest request
            ) =>
        {
            var task = ConvertRequestToEntity(request);
            dal.Cadastrar(task);
            return Results.Created();
        });
        app.MapPut("/Tasks", ([FromServices]DAL<Tarefa> dal,[FromBody] TaskRequestEdit request) =>
        {
            var task = dal.RecuperarPor(x=>x.Id==request.Id);
            if (task is null)
            {
                return Results.NotFound();
            }
            task.Name = request.Name;
            task.Description = request.Description;
            task.IsCompleted = request.IsCompleted;
            task.DateTask = request.Date;
            
            dal.Alterar(task);
            var taskResponse = EntityUnitToResponse(task);
            return Results.Ok(taskResponse);
        });
        app.MapDelete("Tasks/{Id}", (
            [FromServices]DAL<Tarefa> dal,
            int Id) =>
        {
            var task = dal.RecuperarPor(dal=>dal.Id==Id);
            if (task is null)
            {
                return Results.NotFound();
            }
            dal.Deletar(task);
            var taskResponse = EntityUnitToResponse(task);
            return Results.Ok(taskResponse);
        });
    }
    
    private static Tarefa ConvertRequestToEntity(TaskRequest tarefas)
    {
        return new Tarefa
        {
            Name = tarefas.Name,
            Description = tarefas.Description,
            DateTask = tarefas.Date
        };
    }

    private static IEnumerable<TaskResponse> ConvertEntityToResponseList(IEnumerable<Tarefa> tarefas)
    {
        return tarefas.Select(x=>EntityUnitToResponse(x));
    }
    private static TaskResponse EntityUnitToResponse(Tarefa tarefa)
    {
        return new TaskResponse
        (
            tarefa.Id,
            tarefa.Name,
            tarefa.Description,
            tarefa.DateTask,
            tarefa.IsCompleted
        );
    }
    
}
