using System.Collections.Generic;
using UnityEngine;

namespace Game.GamePlay
{
    public class GameChecker : MonoBehaviour
    {
        public static GameChecker Instance { get; private set; }
        private int _totalTiles = 0;
        public void Init(int _init)
        {
            _totalTiles = _init;
        }
        private void Start()
        {
            Instance = this;
        }
         private HashSet<string> _addedsquares  = new();

        public  void AddSquareToRaws(string square)
        {
            if (!_addedsquares.Contains(square))
            {
                Debug.Log(square);
                _addedsquares.Add(square);
            }
        }
    }
}