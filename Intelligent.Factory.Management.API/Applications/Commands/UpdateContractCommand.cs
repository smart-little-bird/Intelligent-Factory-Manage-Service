using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Intelligent.Factory.Management.API.Applications.Commands;

public class UpdateContractCommand: IRequest<int>
{
    [FromRoute] public int Id { get; set; }

}