using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _endValue;
    [SerializeField] private float _duration;

    private void Awake()
    {
        _endValue += transform.position.y;
    }

    private void Start()
    {
        transform.DOMoveY(_endValue,_duration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}