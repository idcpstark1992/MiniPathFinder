using Game.GamePlay;
using UnityEngine;

namespace Game.Input
{
    public class FloorTileItem : MonoBehaviour
    {
        [SerializeField] private Material _matBlocked;
        [SerializeField] private Material _matVisited;
        [SerializeField] private Material _matIdle;

        [SerializeField] private Rigidbody _rb;
        private bool _nativeBlocker=false;
        private ItemDataController _dataController;
        public ItemDataController DataController { get { return _dataController; } }
        public void  Init(bool _input)
        {
            _dataController = new(new Vector3(transform.position.x, 1, transform.position.z),_input); 
            _rb.useGravity = false;
            
            _nativeBlocker = _input;

            if(_input)
                gameObject.GetComponent<Renderer>().material = _input? _matBlocked:_matIdle;

            _rb.Sleep();
        }
        private void Fall()
        {
            _dataController.SetDirt(true);
            gameObject.GetComponent<Renderer>().material = _matVisited;
            GameChecker.Instance.AddSquareToRaws(gameObject.name);
        }
        private void OnEnable()
        {
            Utils.ON_GAME_RESET += OnGameReset;
        }
        private void OnDisable()
        {
            Utils.ON_GAME_RESET += OnGameReset;   
        }
        private void OnGameReset()
        {
            _dataController.SetDirt(_nativeBlocker);
            gameObject.GetComponent<Renderer>().material = _nativeBlocker ? _matBlocked: _matIdle;
        }
        public void SetDistance(float _distanceInput)
        {
            _dataController.SetDistsance(_distanceInput);
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(Utils.PlayerTag))
                Fall();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Utils.PlayerTag))
                Fall();
        }
        private void OnMouseDown()
        {
            if (Utils.INITIAL_PLAYER_POINT == Vector3.zero&&!DataController._isBlocker)
            {
                Utils.INITIAL_PLAYER_POINT = _dataController._itemPosition;
                Utils.ON_INSTANTIATE_PLAYER?.Invoke();
            } 
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(_dataController._itemPosition, .5f);
        }
    }

}
