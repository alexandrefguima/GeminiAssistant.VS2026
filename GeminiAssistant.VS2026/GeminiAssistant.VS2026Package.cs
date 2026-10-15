using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using Task = System.Threading.Tasks.Task;

namespace GeminiAssistant.VS2026
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [Guid(PackageGuidString)]
    [ProvideToolWindow(typeof(GeminiToolWindow))]
    public sealed class GeminiAssistantVS2026Package : AsyncPackage
    {
        public const string PackageGuidString = "d3b07384-d113-41ec-b174-8b67104b2b73";

        protected async override Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
            await GeminiToolWindowCommand.InitializeAsync(this);
        }
    }
}