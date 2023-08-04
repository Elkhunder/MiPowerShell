using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Helpers.Managers
{
    public class BackgroundTaskManager
    {
        public EventHandler TaskStarted;
        public EventHandler TaskCompleted;
        public EventHandler<Exception> TaskFailed;

        public async Task RunTask(Action<IProgress<int>> action, IProgress<int> progress)
        {
            OnTaskStarted(EventArgs.Empty);

            try
            {
                await Task.Run(() => action(progress));
            }
            catch (Exception e)
            {

                OnTaskFailed(e);
                return;
            }
            OnTaskCompleted(EventArgs.Empty);
        }

        public async Task RunTask(Action action)
        {
            OnTaskStarted(EventArgs.Empty);

            await Task.Run(action);

            OnTaskCompleted(EventArgs.Empty);
        }

        protected virtual void OnTaskStarted(EventArgs e)
        {
            TaskStarted?.Invoke(this, e);
        }
        protected virtual void OnTaskCompleted(EventArgs e)
        {
            TaskCompleted?.Invoke(this, e);
        }
        protected virtual void OnTaskFailed(Exception e)
        {
            TaskFailed?.Invoke(this, e);
        }
    }
}
