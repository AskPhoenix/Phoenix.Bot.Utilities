using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Phoenix.Bot.Utilities.State;
using Phoenix.DataHandle.Identity;
using Phoenix.DataHandle.Main.Models;
using Phoenix.DataHandle.Repositories;

namespace Phoenix.Bot.Utilities.Dialogs
{
    public class StateDialog : ComponentDialog
    {
        private readonly IStatePropertyAccessor<UserData> _userDataAcsr;
        private readonly IStatePropertyAccessor<ConversationData> _convDataAcsr;

        protected readonly ApplicationUserManager _userManager;

        protected readonly UserRepository _userRepository;
        protected readonly SchoolRepository _schoolRepository;

        protected UserData UData { get; set; } = new();
        protected ConversationData CData { get; set; } = new();

        public StateDialog(
            UserState userState,
            ConversationState convState,
            ApplicationUserManager userManager,
            PhoenixContext phoenixContext,
            string? dialogId = null)
            : base(dialogId)
        {
            _convDataAcsr = convState.CreateProperty<ConversationData>(nameof(ConversationData));
            _userDataAcsr = userState.CreateProperty<UserData>(nameof(UserData));

            _userManager = userManager;

            _userRepository = new(phoenixContext, nonObviatedOnly: true);
            _schoolRepository = new(phoenixContext, nonObviatedOnly: true);
        }

        protected override async Task<DialogTurnResult> OnBeginDialogAsync(DialogContext innerDc, object options, CancellationToken cancellationToken = default)
        {
            await this.GetStateAsync(innerDc.Context, cancellationToken);

            return await base.OnBeginDialogAsync(innerDc, options, cancellationToken);
        }

        protected override async Task<DialogTurnResult> OnContinueDialogAsync(DialogContext innerDc,
            CancellationToken cancellationToken = default)
        {
            await this.GetStateAsync(innerDc.Context, cancellationToken);

            return await base.OnContinueDialogAsync(innerDc, cancellationToken);
        }

        private async Task GetStateAsync(ITurnContext turnContext,
            CancellationToken cancellationToken = default)
        {
            UData = await _userDataAcsr.GetAsync(turnContext, () => new(), cancellationToken);
            CData = await _convDataAcsr.GetAsync(turnContext, () => new(), cancellationToken);

            await UData.RefreshAsync(_userRepository, _userManager);
            await CData.RefreshAsync(_schoolRepository);
        }

        protected Task SetUserStateAsync(ITurnContext turnContext,
            CancellationToken cancellationToken = default)
        {
           return _userDataAcsr.SetAsync(turnContext, this.UData, cancellationToken);
        }

        protected Task SetConvStateAsync(ITurnContext turnContext,
            CancellationToken cancellationToken = default)
        {
            return _convDataAcsr.SetAsync(turnContext, this.CData, cancellationToken);
        }
    }
}
