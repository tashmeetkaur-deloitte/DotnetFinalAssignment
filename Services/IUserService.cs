
using DotnetAssignment.Models;

namespace DotnetAssignment.Services;
public interface IUserService{
    // List<User> GetAllUsers();
    User GetUserById(int UserId);
    ResponseModel SaveUser(UserDTO User);
    ResponseModel DeleteUser(int UserId);
}