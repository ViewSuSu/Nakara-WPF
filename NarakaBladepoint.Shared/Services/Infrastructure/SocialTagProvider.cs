using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarakaBladepoint.Shared.Services.Infrastructure
{
    [Component(ComponentLifetime.Singleton)]
    internal class SocialTagProvider : ISocialTagProvider
    {
        private readonly ICurrentUserInfoProvider currentUserInfoProvider;

        public SocialTagProvider(ICurrentUserInfoProvider currentUserInfoProvider)
        {
            this.currentUserInfoProvider = currentUserInfoProvider;
        }

        public async Task<List<SocialTagData>> GetSocialTags(SocialTagType socialTagType)
        {
            var datas = ConfigurationDataReader.GetList<SocialTagData>();
            return datas.Where(x => x.TagType == socialTagType).ToList();
        }

        public async Task<List<SocialTagData>> GetSocialTags()
        {
            return ConfigurationDataReader.GetList<SocialTagData>();
        }

        public async Task<bool> GetSocialTagIsSelectedByIndex(int index)
        {
            var currentModel = await currentUserInfoProvider.GetCurrentUserInfoAsync();
            return currentModel.SelectedSocialTags.Contains(index);
        }
    }
}
