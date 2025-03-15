using System;
using System.Timers;
using UnityEngine;

namespace MFramework.Extensions
{
    public class EventTimer
    {
        private readonly string timerTitle = string.Empty;
        private readonly Timer timer;
        private readonly Action action;

        public EventTimer(Action action, float invokeInterval, bool isLoopTimer, string timerTitle = "")
        {
            timer = new Timer(invokeInterval);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = isLoopTimer;
            timer.Enabled = true;
            this.action = action;
        }

        public void Start() => timer.Start();
        public void Continue() => timer.Enabled = true;
        public void Pause() => timer.Enabled = false;

        private void OnTimedEvent(object source, ElapsedEventArgs eventArgs)
        {
            Debug.Log($"触发定时器事件:{timerTitle} " + eventArgs.SignalTime);
            action?.Invoke();
        }

        public void Dispose()
        {
            timer.Stop();
            timer.Dispose();
        }
    }
}