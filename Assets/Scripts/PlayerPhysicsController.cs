using System.Collections;
using UnityEngine;

namespace Game.GamePlay
{
    public class PlayerPhysicsController : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidBody;
        private WaitForSeconds _wfs = new(.2f);
        private bool _startedPoint = true;
        public void RotatePlayer(int _degrees)
        {
            Quaternion m_Rotation = Quaternion.Euler(0f, _degrees, 0f) * _rigidBody.rotation;
            _rigidBody.MoveRotation(m_Rotation);
        }
        public void MovePlayer(Vector3 _newPosition)
        {
            StartCoroutine(PlayerMotor(_newPosition));
        }


        private IEnumerator PlayerMotor(Vector3 _destination)
        {
            Utils.SetPlayerMovement(true);
            while (GetPlayerDistanteToDestination(_rigidBody.position, _destination)>.1f)
            {
                _rigidBody.MovePosition(_rigidBody.position + _rigidBody.transform.forward);
                yield return _wfs;
            }
            Utils.SetPlayerMovement(false);
        }
        private float GetPlayerDistanteToDestination(Vector3 _playerposition , Vector3 _inputDestination)
        {
            return Vector3.Distance(_playerposition, _inputDestination);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (_startedPoint)
                _startedPoint = false;

        }
    }
}

