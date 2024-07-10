using UnityEngine;

namespace Game.Input
{
    public class ItemDataController 
    {
        
        [field: SerializeField]
        public float    _distance {  get; private set; }
        [field:SerializeField]
        public Vector3  _itemPosition { get; }
        [field: SerializeField]
        public bool     _isBlocker { get; private set; }

        public ItemDataController(Vector3 _position, bool _blocker)
        {
            _itemPosition = _position;
            _isBlocker = _blocker;
        }
        public void SetDistsance(float _distanceIn)
        {
            _distance = _distanceIn;
        }
        public void SetDirt(bool _isDirt)
        {
            _isBlocker = _isDirt;
        }

    }

}
