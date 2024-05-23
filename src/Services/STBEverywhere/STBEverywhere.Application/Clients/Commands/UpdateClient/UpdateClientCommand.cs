using BuildingBlocks.CQRS;
using STBEverywhere.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Application.Clients.Commands.UpdateClient
{
    public record UpdateClientCommand(ClientDto Client)
        : ICommand<UpdateClientResult>;

    public record UpdateClientResult(bool Is)


}
