namespace KinhDoanhTraiCay.Helper
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                string token = context.Request.Headers["Authorization"].ToString();

                if (string.IsNullOrEmpty(token))
                {
                    context.Items["UserId"] = "";
                }
                else
                {
                    string id = token.Substring(7);
                    string userID = JWT.GetUserId(id);

                    context.Items["UserId"] = userID;
                }
                await _next(context);

            }
            catch
            {
                context.Items["UserId"] = "";
                await _next(context);

            }
        }
    }
}
