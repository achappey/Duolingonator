using Duolingonator.Models;
using System.Text;

namespace Duolingonator.Extensions;

public static class HttpExtensions
{
    public static User GetUser(this HttpContext context)
    {
        var header = context.Request.Headers["x-api-key"].FirstOrDefault();

        if (header == null)
        {
            header = context.Request.Query["x-api-key"].FirstOrDefault();
        }

        if (header != null)
        {
            var decoded = header.DecodeBase64();

            var items = decoded.Split(":");

            if (items.Count() == 2)
            {
                return new User()
                {
                    Username = items.First(),
                    Password = items.Last()
                };
            }
        }

        throw new UnauthorizedAccessException();
    }

    public static string DecodeBase64(this string value)
    {
        var valueBytes = System.Convert.FromBase64String(value);

        return Encoding.UTF8.GetString(valueBytes);
    }
}