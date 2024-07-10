using System.Collections.Generic;
using UnityEngine;

namespace Game.GamePlay
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerPhysicsController _physicsController;
        private void OnEnable()
        {
            Utils.ON_ROTATION_PRESSED       += RotatePlayer;
            Utils.ON_TRAVEL_PATH_CREATED    += OnPlayerPathSet;
            Utils.ON_GAME_RESET             += OnGameReset;
        }
        private void OnDisable()
        {
            Utils.ON_ROTATION_PRESSED    -= RotatePlayer;
            Utils.ON_TRAVEL_PATH_CREATED -= OnPlayerPathSet;
            Utils.ON_GAME_RESET          -= OnGameReset;
        }
        private void RotatePlayer(int _amount)
        {
            _physicsController.RotatePlayer(_amount);
        }

        private void  OnPlayerPathSet(List<Vector3> _pathPositions)
        {
            if(_pathPositions.Count>0) 
                _physicsController.MovePlayer(_pathPositions[_pathPositions.Count - 1]);
        }
        private void OnGameReset()
        {
            Destroy(gameObject);
        }
    }

}
