using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Authorization
{
    public class AdministratorsAuthorizationHandler :
   AuthorizationHandler<OperationAuthorizationRequirement,
       SolicitudOperacion>
{
protected override Task HandleRequirementAsync(
AuthorizationHandlerContext context,
OperationAuthorizationRequirement requirement,
SolicitudOperacion resource)
    {
        if (context.User == null)
        {
            return Task.CompletedTask;
        }
        // Administratorscan do anything.
        if (context.User.IsInRole(Constants.AdministratorsRole))
        {
            context.Succeed(requirement);
        }
        return Task.CompletedTask;
    }
}
 
   
}
