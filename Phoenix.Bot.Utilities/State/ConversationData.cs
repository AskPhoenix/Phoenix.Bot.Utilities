using Newtonsoft.Json;
using Phoenix.Bot.Utilities.Errors;
using Phoenix.Bot.Utilities.Linguistic;
using Phoenix.DataHandle.Main.Models;
using Phoenix.DataHandle.Repositories;

namespace Phoenix.Bot.Utilities.State
{
    public class ConversationData
    {
        public int? SchoolId { get; set; }
        public Command Command { get; set; }

        [JsonIgnore]
        public School School { get; private set; } = null!;

        public void Refresh(SchoolConnection? schoolConnection)
        {
            if (schoolConnection is null)
                return;

            this.SchoolId = schoolConnection.TenantId;
            this.School = schoolConnection.Tenant;
        }

        public async Task RefreshAsync(SchoolRepository schoolRepository)
        {
            if (!this.SchoolId.HasValue)
                return;

            var school = await schoolRepository.FindPrimaryAsync(this.SchoolId.Value);
            if (school is null)
                throw new BotException(BotError.SchoolNotFound);

            this.School = school;
        }
    }
}
