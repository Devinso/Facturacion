using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.WebSockets.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Authorization
{
    public class TecnicoAuthorizationHandler :
AuthorizationHandler<OperationAuthorizationRequirement, SolicitudOperacion>
    {
        protected override Task
        HandleRequirementAsync(AuthorizationHandlerContext context,
        OperationAuthorizationRequirement requirement,
        SolicitudOperacion resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }
            if (requirement.Name != Constants.DeleteOperationName ||
            requirement.Name != Constants.ApproveOperationName ||
            requirement.Name != Constants.RejectOperationName)
            {
                return Task.CompletedTask;
            }
            if (context.User.IsInRole(Constants.TecnicosRole))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
    
