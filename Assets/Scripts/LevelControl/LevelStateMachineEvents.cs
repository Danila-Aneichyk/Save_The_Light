using Event_Bus;
using Interfaces;
using Service_Locator;

namespace LevelControl
{
    public class LevelStateMachineEvents : IService
    {
        private EventBus _eventBus;

        public void Init()
        {
            _eventBus = ServiceLocator.Current.Get<EventBus>();
        }
    }
}