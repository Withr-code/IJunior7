using UnityEngine;
using DG.Tweening;

public class Mace : MonoBehaviour
{
    [SerializeField] private Transform[] _pathsPoints = new Transform[4];
    [SerializeField] private float _duration;

    private Vector3[] _paths = new Vector3[4];

    private void Awake()
    {
        for (int i = 0; i < _pathsPoints.Length; i++)
        {
            _paths[i] = TransformToVector3(_pathsPoints[i]);
        }
    }

    private void Start()
    {
        transform.DOPath(_paths, _duration, PathType.CatmullRom).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

    private Vector3 TransformToVector3(Transform transform)
    {
        return new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}
