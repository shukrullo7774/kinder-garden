namespace Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(String name, object key)
            : base($"/Entity \"{name}\"({key}) not found") { }
    }
}
    