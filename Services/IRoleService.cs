using DotnetAssignment.Models;

namespace DotnetAssignment.Services;
public interface IRoleService{
    ResponseModel AddRole(RoleDTO model);
    ResponseModel AssignRole(int UserId,int RoleId);
}