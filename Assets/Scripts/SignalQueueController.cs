using Game.Input;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SignalQueueController 
{
    public List<FloorTileItem> _hitCounts;
    public SignalQueueController() 
    {
        _hitCounts = new ();
    }
    public void  SendRaycastSignal (Vector3 _origin, Vector3 _direction)
    {
        RaycastHit[] m_hits = new RaycastHit[10];
        Ray m_ray = new(_origin, _direction);
        int m_hitCount = Physics.RaycastNonAlloc(m_ray, m_hits, 10);
        _hitCounts.Clear();

        for (int i = 0; i < m_hitCount; i++)
        {
            var item = m_hits[i];

            if (item.collider.TryGetComponent(out FloorTileItem _outItem))
            {
                FloorTileItem m_holder = _outItem;
                m_holder.SetDistance(GetPointsDistances(_origin, item.point));
                _hitCounts.Add(m_holder);
            }
        }
        _hitCounts.Sort((x, y) => x.DataController._distance.CompareTo(y.DataController._distance));
        List<Vector3> _movementPoints = new();



        foreach (var item in _hitCounts)
        {
            if (item.DataController._isBlocker)
                break;

            _movementPoints.Add(item.DataController._itemPosition);
        }
        Utils.ON_TRAVEL_PATH_CREATED?.Invoke(_movementPoints);
    }
    public float GetPointsDistances(Vector3 _origin, Vector3 _end) => Vector3.Distance(_origin, _end);
   
}
