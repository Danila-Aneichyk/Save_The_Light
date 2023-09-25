using Event_Bus;
using UnityEngine;

namespace Service_Locator
{
    public class ServiceLocatorMain : MonoBehaviour
    {
        [Header("Services")]
        private EventBus _eventBus;

        private void Awake()
        {
            _eventBus = new EventBus();

            RegisterServices();
        }

        private void RegisterServices()
        {
            ServiceLocator.Initialize();

            ServiceLocator.Current.Register(_eventBus);
        }
    }
}