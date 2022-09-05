using UnityEngine;

namespace TimeControl
{
    public class TimeController : IStopTime, IResumeTime
    {
        public void Stop()
        {
            Time.timeScale = 0f;
        }

        public void Resume()
        {
            Time.timeScale = 1f;
        }
    }
}