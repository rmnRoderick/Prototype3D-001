using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class movimiento : MonoBehaviour
{
    [SerializeField] private Transform initPoint;

    [SerializeField] private Transform endPoint;
    [SerializeField] private int time;

    private Sequence mySeq;

    private void Start()
    {
        transform.position = initPoint.position;
        mySeq = DOTween.Sequence();

        mySeq.Append(transform.DOMove(endPoint.position, time));
        mySeq.Append(transform.DOMove(initPoint.position, time));
        mySeq.SetLoops(3);
    }

    
}
