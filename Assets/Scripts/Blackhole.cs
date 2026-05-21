using DG.Tweening;
using UnityEngine;

public class Blackhole : MonoBehaviour
{
    void Start()
    {
        transform.DORotate(new Vector3(0, 0, 360), 1, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);
        transform.DOLocalMoveY(transform.position.y - 0.15f, 1)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
