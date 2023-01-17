using Microsoft.AspNetCore.Authorization;

namespace PREGUNTAS.Interfaces.Authorization
{
    public class Custom_AuthHandler : AuthorizationHandler<Custom_AtuhAttribute>
    {
        private readonly IHttpContextAccessor _application;

        public Custom_AuthHandler(IServiceProvider service)
        {
            _application = service.GetRequiredService<IHttpContextAccessor>();
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, Custom_AtuhAttribute requirement)
        {

            if (context.User.HasClaim(id => id.Type == "id"))
            {
                context.Succeed(requirement);
            }
            else
            {
                _application.HttpContext.Response.Headers.Add("status", new Microsoft.Extensions.Primitives.StringValues("no cumple"));
                context.Fail(new AuthorizationFailureReason(this, "no cumple"));
            }



            return Task.CompletedTask;

            //para indicar que cumple la política
            //context.Succeed(requirement);

            //para indicar que no se cumple la política
            //context.Fail(new AuthorizationFailureReason(this, "no cumple"));


        }
    }
}
