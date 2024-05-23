

using BuildingBlocks.Exceptions;

namespace STBEverywhere.Application.Exceptions
{
    public class ClientNotFoundException : NotFoundException
    {
        public ClientNotFoundException(Guid id) : base("Client", id)
        {
        }
    }
}
