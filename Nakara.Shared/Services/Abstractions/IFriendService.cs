using Nakara.Shared.Datas;

namespace Nakara.Shared.Services.Abstractions
{
    public interface IFriendService
    {
        Task<List<FriendData>> GetFriendsAsync();
    }
}
