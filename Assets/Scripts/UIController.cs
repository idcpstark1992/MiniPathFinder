using UnityEngine;
namespace Game.UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private RectTransform _controllerCanvas;
        [SerializeField] private RectTransform _instructionsCanvas;
        private void Start()
        {
            _controllerCanvas.gameObject.SetActive(false);
        }
        private void OnEnable()
        {
            Utils.ON_INSTANTIATE_PLAYER += OnIntantiatedPlayer;
        }
        private void OnDisable()
        {
            Utils.ON_INSTANTIATE_PLAYER -= OnIntantiatedPlayer;
        }
        private void OnIntantiatedPlayer()
        {
            _controllerCanvas.gameObject.SetActive(true);
            _instructionsCanvas.gameObject.SetActive(false);
        }
        public void OnResetPlayer()
        {
            Utils.ON_GAME_RESET?.Invoke();
            ResetPlayer();
        }
        private void ResetPlayer()
        {
            _controllerCanvas.gameObject.SetActive(false);
            _instructionsCanvas.gameObject.SetActive(true);
        }
        public void RotateItems(int _value)
        {
            if(!Utils.PLAYER_MOVEMENT)
                Utils.ON_ROTATION_PRESSED?.Invoke(_value);
        }
        public void SendSignalRay()
        {
            if(!Utils.PLAYER_MOVEMENT)
                Utils.ON_SEND_SIGNAL_BUTTON?.Invoke();
        }
    }

}
