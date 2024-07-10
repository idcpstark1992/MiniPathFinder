using Game.Input;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GamePlay
{
    [System.Serializable]
    public struct LevelBlockersAddress
    {
        public int X;
        public int Y;
        public TilesColors TileColor;
    }
    public class BoardGenerator : MonoBehaviour
    {
        [SerializeField] private Transform _holder;
        [SerializeField] private GameObject _boardObject;
        [SerializeField] private PlayerController _playerObject;
        [SerializeField] private int _boardWidht;
        [SerializeField] private int _boardHeight;
        [SerializeField] private List<LevelBlockersAddress> _levelAddressBlockers;
        [SerializeField] private LevelBlockersAddress       _playerSpawnPosition;
        [SerializeField] private Material _blockerMaterial;

        private readonly HashSet<string> _levelBlockersDictionary = new();

        private void Start()
        {
            GenerateBoard();
        }
        private void GenerateBoard ()
        {
            int _xPosition = 0;
            int _yPosition = 0;
            Vector3Int m_position = Vector3Int.zero;
            foreach (var item in _levelAddressBlockers)
            {
                string m_Key = string.Concat(item.X, "_", item.Y);
                if (!_levelBlockersDictionary.Contains(m_Key))
                {
                    _levelBlockersDictionary.Add(m_Key);
                }

            }
            while (_xPosition < _boardWidht)
            {
                while (_yPosition < _boardHeight)
                {

                    m_position.x = _xPosition;
                    m_position.z = _yPosition;
                    GameObject m_toInstantiate = Instantiate(_boardObject, _holder.transform);
                    m_toInstantiate.name = string.Concat(_xPosition, "--", _yPosition);
                    bool m_blocker = IsBlocker(_xPosition, _yPosition);
                    m_toInstantiate.transform.position = m_position;
                    m_toInstantiate.GetComponent<FloorTileItem>().Init(m_blocker);
                    m_toInstantiate.transform.localScale = Vector3.one * .9f;
                    _yPosition++;
                }
                _xPosition++;
                _yPosition = 0;
            }
        }
        private bool IsBlocker(int _x , int _y)
        {
            string m_search = string.Concat(_x,"_",_y);
            return _levelBlockersDictionary.Contains(m_search);
        }
        private void OnSetNewPlayerPoint()
        {
            _playerSpawnPosition.X++;
            _playerSpawnPosition.Y++;

        }
        private void OnEnable()
        {
            Utils.ON_SET_NEW_PLAYER_POINT += OnSetNewPlayerPoint; 
        }
        private void OnDisable()
        {
            Utils.ON_SET_NEW_PLAYER_POINT -= OnSetNewPlayerPoint;
        }
        internal class RNG
        {
            private List<LevelBlockersAddress> _randomList;
            private int _width;
            private int _height;
            public RNG(int _widthIN, int _heightIN)
            {
                _randomList = new();
                _width = _widthIN;
                _height = _heightIN;
            }

            public List<LevelBlockersAddress> GetList(int _seedCount)
            {
                List<LevelBlockersAddress> _blockerAdders = new();
                for (int i = 0; i < _seedCount; i++)
                {
                    int _randomX = Random.Range(0, _width);
                    int _randomY = Random.Range(0, _height);
                    LevelBlockersAddress m_toAddLevel = new()
                    {
                        X = _randomX,
                        Y = _randomY
                    };
                    _blockerAdders.Add(m_toAddLevel);
                }
                return _randomList;
            }
        }
    }


    
}
