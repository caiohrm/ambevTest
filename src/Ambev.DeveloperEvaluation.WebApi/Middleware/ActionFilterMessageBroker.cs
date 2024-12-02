using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Consumer;
using Ambev.DeveloperEvaluation.WebApi.Features.ProductSale.AddProductSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ambev.DeveloperEvaluation.WebApi.Middleware;

public class ActionFilterMessageBroker : IActionFilter
{
    private IPublishEndpoint _publishEndpoint;
    public ActionFilterMessageBroker(IPublishEndpoint publishEndpoint)
    {
        this._publishEndpoint = publishEndpoint;
    }
    void IActionFilter.OnActionExecuted(ActionExecutedContext context)
    {
        
        var response = (CreatedResult)context.Result;
        if(response == null)
            return;
        var data = context.RouteData.Values["salesId"];
        if (data != null)
        {
            _publishEndpoint.Publish<Message>(new Message() { Text= $"Sales with id {data} was created or changed" });
            return;
        }

        var dataCreated = (response.Value as ApiResponseWithData<CreateSalesResponse>);
        if (dataCreated != null)
        {
            _publishEndpoint.Publish<Message>(new Message() { Text = $"Sales with id {dataCreated.Data.Id} was created " });
        }
    }

    void IActionFilter.OnActionExecuting(ActionExecutingContext context)
    {
        var result = context.Result;
        Console.WriteLine(result);
    }
}
