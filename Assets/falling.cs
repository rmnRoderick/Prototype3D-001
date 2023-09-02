using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling : MonoBehaviour
{

    [SerializeField] private float time;

    private Sequence seq;

    // Start is called before the first frame update
    void Start()
    {

        seq = DOTween.Sequence();

        seq.Append(transform.DOShakePosition(2,1,2,2));

        seq.SetLoops(5);

    }


}
