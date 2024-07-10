using UnityEngine;

namespace Game.Input
{
    public class PlayerSignalSender : MonoBehaviour
    {
        [SerializeField] private Transform _antenna;

        private void OnEnable()
        {
            Utils.ON_SEND_SIGNAL_BUTTON += SendSignal;
        }
        private void OnDisable()
        {
            Utils.ON_SEND_SIGNAL_BUTTON -= SendSignal;
        }
        public void SendSignal()
        {
            Utils.ON_RAY_POSITION_SENDED?.Invoke(_antenna.position, _antenna.transform.forward);
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(_antenna.position, _antenna.forward);
        }
    }

}
