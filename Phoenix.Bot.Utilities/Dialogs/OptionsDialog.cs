using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Phoenix.DataHandle.Identity;
using Phoenix.DataHandle.Main.Models;

namespace Phoenix.Bot.Utilities.Dialogs
{
    public class OptionsDialog<TOptions> : StateDialog
        where TOptions : class, new()
    {
        public TOptions Options { get; private set; } = null!;

        public OptionsDialog(
            UserState userState,
            ConversationState convState,
            ApplicationUserManager userManager,
            PhoenixContext phoenixContext,
            string? dialogId = null)
            : base(userState, convState, userManager, phoenixContext, dialogId)
        {
        }

        protected override Task<DialogTurnResult> OnBeginDialogAsync(
            DialogContext innerDc, object options,
            CancellationToken cancellationToken = default)
        {
            if (options is not TOptions)
                this.Options = new();
            
            return base.OnBeginDialogAsync(innerDc, this.Options, cancellationToken);
        }
    }
}
