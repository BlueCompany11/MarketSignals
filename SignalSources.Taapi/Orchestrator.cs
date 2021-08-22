using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SignalSources.Taapi
{
    public class Orchestrator
    {
        private CancellationTokenSource tokenSource;
        public Orchestrator()
        {
            this.tokenSource = new CancellationTokenSource();
            this.requests = new();
            
        }
        private Queue<Action> requests;
        public void PutRequest(Action action)
        {
            this.requests.Enqueue(action);
            if (!this.isRunning)
            {
                this.isRunning = true;
                this.RunRequests();
            }
        }

        private bool isRunning;
        private async Task RunRequests()
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    if (this.requests.TryDequeue(out var action))
                    {
                        action();
                        await Task.Delay(TimeSpan.FromSeconds(15));
                    }
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
            }, this.tokenSource.Token).ContinueWith(task => this.isRunning = false);
        }
    }
}
