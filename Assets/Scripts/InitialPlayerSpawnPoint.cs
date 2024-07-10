using UnityEngine;

namespace Game.Input
{
    public class InitialPlayerSpawnPoint : MonoBehaviour
    {
        [SerializeField] private GameObject _playerObject;
        [SerializeField] private GameObject _PlayerHolder;
        private bool _instantiated;

        private void OnEnable()
        {
            Utils.ON_INSTANTIATE_PLAYER += OnInstantiatedPlayer;
            Utils.ON_GAME_RESET += OnGameReset;
        }
        private void OnDisable()
        {
            Utils.ON_INSTANTIATE_PLAYER -= OnInstantiatedPlayer;
            Utils.ON_GAME_RESET -= OnGameReset;
        }
        private void OnGameReset()
        {
            Utils.INITIAL_PLAYER_POINT = Vector3.zero;
            Utils.SetPlayerMovement(false);
            _instantiated = false;
        }

        private void OnInstantiatedPlayer()
        {
            if (_instantiated)
                return;

            _instantiated = true;

            GameObject m_instance = Instantiate(_playerObject);
            m_instance.transform.position = new Vector3(Utils.INITIAL_PLAYER_POINT.x, 1f, Utils.INITIAL_PLAYER_POINT.z);
        }
    }

}
