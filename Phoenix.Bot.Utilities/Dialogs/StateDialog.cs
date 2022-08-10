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

            _userRepository = new(phoenixContext);
            _schoolRepository = new(phoenixContext);
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

        // TODO: Use Enum for errors
        protected async Task<DialogTurnResult> ExitAsync(string message, string solution, int error,
            WaterfallStepContext stepCtx, CancellationToken canTkn)
        {
            await stepCtx.Context.SendActivityAsync(
                $"{message} (Κωδ. σφάλματος: {error.ToString("D4"):0})", cancellationToken: canTkn);

            if (!string.IsNullOrEmpty(solution))
                await stepCtx.Context.SendActivityAsync(solution, cancellationToken: canTkn);
            else
                await stepCtx.Context.SendActivityAsync(
                    "Παρακαλώ επικοινώνησε με το φροντιστήριο για την επίλυση του προβλήματος.", cancellationToken: canTkn);

            return await stepCtx.CancelAllDialogsAsync(canTkn);
        }

        protected Task<DialogTurnResult> ExitAsync(WaterfallStepContext stepCtx, CancellationToken canTkn)
        {
            return ExitAsync(
                message: "Υπήρξε κάποιο πρόβλημα.",
                solution: "Παρακαλώ επικοινωνήστε με το κέντρο σας για την επίλυσή του.",
                error: 0,
                stepCtx, canTkn);
        }

        private async Task GetStateAsync(ITurnContext turnContext,
            CancellationToken cancellationToken = default)
        {
            // The state refresh is performed in the Dialog Bot class

            UData = await _userDataAcsr.GetAsync(turnContext, () => new(), cancellationToken);
            CData = await _convDataAcsr.GetAsync(turnContext, () => new(), cancellationToken);
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
