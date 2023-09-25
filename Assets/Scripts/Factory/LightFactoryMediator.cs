using LevelControl;
using UnityEngine;

namespace Factory
{
    public class LightFactoryMediator : MonoBehaviour
    {
        [Header("Target Factory")]
        private LightFactory _lightFactory;
        [SerializeField] private LightMarker[] _lightMarkers;
        private bool _allLightsCreated;
        private LightType _lightType;

        public void Start()
        {
            LevelStateMachine.Instance.OnGameStateChanged += LevelStateMachine_OnGameStateChanged;
            _lightFactory = GetComponent<LightFactory>();
            _lightFactory.Load();
        }

        private void LevelStateMachine_OnGameStateChanged(object sender, LevelStates e)
        {
            if (e == LevelStates.StartGameplay)
            {
                TargetCreating();
            }
        }

        private void TargetCreating()
        {
            for (int i = 0; i < _lightMarkers.Length; i++)
            {
                _lightFactory.Create(_lightType, _lightMarkers[i].transform.position);
            }
        }
    }
}