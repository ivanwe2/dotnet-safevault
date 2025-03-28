public class AuthorizeAttribute : ActionFilterAttribute
{
    private readonly string _role;

    public AuthorizeAttribute(string role)
    {
        _role = role;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var user = context.HttpContext.User;
        if (!user.Identity.IsAuthenticated || !user.IsInRole(_role))
        {
            context.Result = new ForbidResult();
        }
    }
}