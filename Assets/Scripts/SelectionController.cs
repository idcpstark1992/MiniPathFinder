using UnityEngine;

public class SelectionController : MonoBehaviour
{
    private void OnEnable()
    {
        //Utils.ON_ROTATION_PRESSED += DoRotation;
    }
    private void OnDisable()
    {
        //Utils.ON_ROTATION_PRESSED -= DoRotation;
    }

    private void DoRotation(int _amount)
    {
        Utils.ON_ROTATION_PRESSED?.Invoke(_amount);
    }
}
