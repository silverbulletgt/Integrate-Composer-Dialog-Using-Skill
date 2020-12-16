// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Integrate_Composer_Dialog_Using_Skill.Extensions;
using Integrate_Composer_Dialog_Using_Skill.Models;
using Integrate_Composer_Dialog_Using_Skill.Services;
using Luis;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Microsoft.Bot.Solutions.Responses;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Integrate_Composer_Dialog_Using_Skill.Dialogs
{
    // Dialog providing activity routing and message/event processing.
    public class MainDialog : ComponentDialog
    {
        private readonly BotServices _services;
        private readonly LocaleTemplateManager _templateEngine;

        public MainDialog(
            IServiceProvider serviceProvider)
            : base(nameof(MainDialog))
        {
            _services = serviceProvider.GetService<BotServices>();
            _templateEngine = serviceProvider.GetService<LocaleTemplateManager>();

            var steps = new WaterfallStep[]
            {
                IntroStepAsync
            };

            AddDialog(new WaterfallDialog(nameof(MainDialog), steps));
            AddDialog(new TextPrompt(nameof(TextPrompt)));
            InitialDialogId = nameof(MainDialog);
        }

        // Runs when the dialog is started.
        protected override async Task<DialogTurnResult> OnBeginDialogAsync(DialogContext innerDc, object options, CancellationToken cancellationToken = default)
        {
            var activity = innerDc.Context.Activity;

            if (activity.Type == ActivityTypes.Message && !string.IsNullOrEmpty(activity.Text))
            {
                // Check for any interruptions
                var interrupted = await InterruptDialogAsync(innerDc, cancellationToken);

                if (interrupted != null)
                {
                    // If dialog was interrupted, return interrupted result
                    return interrupted;
                }
            }

            return await base.OnBeginDialogAsync(innerDc, options, cancellationToken);
        }

        // Runs on every turn of the conversation.
        protected override async Task<DialogTurnResult> OnContinueDialogAsync(DialogContext innerDc, CancellationToken cancellationToken = default)
        {
            var activity = innerDc.Context.Activity;

            if (activity.Type == ActivityTypes.Message && !string.IsNullOrEmpty(activity.Text))
            {
                // Check for any interruptions
                var interrupted = await InterruptDialogAsync(innerDc, cancellationToken);

                if (interrupted != null)
                {
                    // If dialog was interrupted, return interrupted result
                    return interrupted;
                }
            }

            return await base.OnContinueDialogAsync(innerDc, cancellationToken);
        }

        // Runs on every turn of the conversation to check if the conversation should be interrupted.
        protected async Task<DialogTurnResult> InterruptDialogAsync(DialogContext innerDc, CancellationToken cancellationToken)
        {
            DialogTurnResult interrupted = null;
            var activity = innerDc.Context.Activity;

            if (activity.Type == ActivityTypes.Message && !string.IsNullOrEmpty(activity.Text))
            {
                
            }

            return interrupted;
        }

        // Handles introduction/continuation prompt logic.
        private async Task<DialogTurnResult> IntroStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            if (stepContext.Context.IsSkill())
            {
                // If the bot is in skill mode, skip directly to route and do not prompt
                return await stepContext.NextAsync(cancellationToken: cancellationToken);
            }

            // If bot is in local mode, prompt with intro or continuation message
            var promptOptions = new PromptOptions
            {
                Prompt = stepContext.Options as Activity ?? _templateEngine.GenerateActivityForLocale("FirstPromptMessage")
            };

            return await stepContext.PromptAsync(nameof(TextPrompt), promptOptions, cancellationToken);
        }

        private async Task LogUserOutAsync(DialogContext dc, CancellationToken cancellationToken)
        {
            var supported = dc.Context.Adapter is IUserTokenProvider;
            if (supported)
            {
                var tokenProvider = (IUserTokenProvider)dc.Context.Adapter;

                // Sign out user
                var tokens = await tokenProvider.GetTokenStatusAsync(dc.Context, dc.Context.Activity.From.Id, cancellationToken: cancellationToken);
                foreach (var token in tokens)
                {
                    await tokenProvider.SignOutUserAsync(dc.Context, token.ConnectionName, cancellationToken: cancellationToken);
                }

                // Cancel all active dialogs
                await dc.CancelAllDialogsAsync(cancellationToken);
            }
            else
            {
                throw new InvalidOperationException("OAuthPrompt.SignOutUser(): not supported by the current adapter");
            }
        }
    }
}