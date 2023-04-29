using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform patroller;
    [SerializeField] private Transform firstPoint;
    [SerializeField] private Transform secondPoint;
    [SerializeField] private float speed;

    private int activePoint = 0;
    private Vector3 target;

    private void Start()
    {
        target = firstPoint.position;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position == target)
        {
            if (target == firstPoint.position)
                target = secondPoint.position;
            else if(target == secondPoint.position)
                target = firstPoint.position;
        }
    }
}
