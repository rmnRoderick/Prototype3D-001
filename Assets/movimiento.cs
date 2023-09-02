using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class movimiento : MonoBehaviour
{
    [SerializeField] private Transform initPoint;

    [SerializeField] private Transform endPoint;
    [SerializeField] private float time;

    [SerializeField] private int loops;


    private Vector3 initialPosition;
    private Vector3 finalPosition;

    private Sequence mySeq;

    private void Start()
    {
        initialPosition=initPoint.position;
        finalPosition=endPoint.position;
        transform.position = initialPosition;
        mySeq = DOTween.Sequence();

        DOTween.defaultEaseType = Ease.Linear;

        mySeq.Append(transform.DOMove(finalPosition, time));
        mySeq.Append(transform.DOMove(initialPosition, time));

        mySeq.SetLoops(loops);
    }



}
