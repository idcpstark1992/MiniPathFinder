using Game.Input;
using System.Collections;
using UnityEngine;
public class PlayerCustomAI : MonoBehaviour
{
    [SerializeField] private Transform _antennaTransform;
    private WaitForSeconds WFS = new (.2f);
    private bool _walker = true;
    private void OnEnable()
    {
        Utils.ON_GAME_RESET += OnResetGame;
    }
    private void OnDisable()
    {
        Utils.ON_GAME_RESET -= OnResetGame;
    }
    private void OnResetGame()
    {
        StopCoroutine(SendSelfSignal());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SendSelfSignal());
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            _walker = !_walker;
        }
           
    }

    private IEnumerator SendSelfSignal()
    {
        int  _turnsCount = 0;
        bool _turn = true;
        while (_walker)
        {
           
            Ray ray = new(_antennaTransform.transform.position, _antennaTransform.transform.forward);
            if(Physics.Raycast(ray,out RaycastHit _out, 1f))
            {
                if(_out.collider.TryGetComponent(out FloorTileItem outcomponent))
                {
                    if (outcomponent.DataController._isBlocker)
                    {
                        _turnsCount++;
                        Utils.ON_ROTATION_PRESSED?.Invoke(90);
                        _turn = _turnsCount >= 4;
                        if (_turn)
                        {
                            Debug.Log("Game Is Blocked");
                            _walker = false;
                        }
                    }
                    else 
                    {
                        Utils.ON_SEND_SIGNAL_BUTTON?.Invoke();
                        _turnsCount = 0;
                    }
                }
            }
            else
            {
                _turnsCount++;
                Utils.ON_ROTATION_PRESSED?.Invoke(90);
            }
            yield return WFS;
            
        }
        
        Utils.ON_GAME_RESET?.Invoke();
    }
}
