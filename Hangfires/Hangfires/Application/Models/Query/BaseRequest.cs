using System;
namespace Hangfires.Application.Models.Query
{
    public class BaseRequest<T>
    {
        public Attributes<T> data { get; set; }
    }

    public class Attributes<T>
    {
        public T attributes { get; set; }
    }
}
