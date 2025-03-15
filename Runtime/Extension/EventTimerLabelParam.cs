namespace MFramework
{
    public class EventTimerLabelParam : EventTimerParam
    {
        public readonly string label;

        protected EventTimerLabelParam(string label)
        {
            this.label = label;
        }
    }
}