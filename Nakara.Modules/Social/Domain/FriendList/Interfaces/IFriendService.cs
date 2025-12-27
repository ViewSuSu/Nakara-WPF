using Nakara.Modules.Social.UI.FriendList.Models;

namespace Nakara.Modules.Social.Domain.FriendList.Interfaces
{
    internal interface IFriendService
    {
        Task<List<Friend>> GetFriendsAsync();
    }
}
