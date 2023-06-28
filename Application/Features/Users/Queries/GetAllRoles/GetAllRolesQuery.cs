using Domain;
using MediatR;

namespace Application.Features.Users.Queries.GetAllRoles
{
    public class GetAllRolesQuery : IRequest<List<Role>>
    {
    }
}
