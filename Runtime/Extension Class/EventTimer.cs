using UnityEngine;

namespace MFramework.Extensions.Class
{
    public class EventTimer
    {
        public float defaultTime { get; set; } = 60;
        public float currentTime { get; private set; }
        public bool running { get; private set; }

        public void Start()
        {
            running = true;
            currentTime = defaultTime;
        }

        private void Update()
        {
            if (running)
            {
                currentTime -= Time.deltaTime;
                if (currentTime <= 0)
                {
                    running = false;
                }
            }
        }
    }
}