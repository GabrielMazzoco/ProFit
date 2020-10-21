using IronFit.Domain.AuthAggregate.Dtos;
using IronFit.Domain.Shared.Filters;

namespace IronFit.Domain.AuthAggregate.Services
{
    public interface IUserService
    {
        void RegisterAdmin(AdminForRegisterDto adminForRegisterDto);
        void RegisterUser(UserForRegisterDto userForRegisterDto);
        void UpdateUser(UserForUpdateDto userForUpdateDto);
        void InactivateUserAsAdmin(int idUser);
        void InactivateUser();
        GenericFilter<UsersForList> GetUsers(GenericFilter<UsersForList> filter);
    }
}
