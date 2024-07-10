using UnityEngine;

namespace Game.GamePlay
{
    public class GameBoardController : MonoBehaviour
    {
        [SerializeField] private SignalQueueController _signalSenderController;
        private void Start()
        {
            _signalSenderController = new();
        }

        private void OnEnable()
        {
            Utils.ON_RAY_POSITION_SENDED += SendRaycastSignal;
        }

        private void OnDisable()
        {
            Utils.ON_RAY_POSITION_SENDED -= SendRaycastSignal;
        }
        private void SendRaycastSignal(Vector3 _inputPosition, Vector3 _outputPosition)
        {
            _signalSenderController.SendRaycastSignal(_inputPosition, _outputPosition);
        }
    }

}

