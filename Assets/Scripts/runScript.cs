using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class runScript : MonoBehaviour
{
    [SerializeField] private Transform[] bolls;
    [SerializeField] private Vector3[] points;
    [SerializeField] private Transform childTransform;
    [SerializeField] private float speed;



    private Vector3 target;
    private Transform curentBollTransform;
    private int curentBollActiv = 0;
    private int curentPoint = 0;



    void Start()

    {
        if (points.Length != 0)
        {
            target = points[curentPoint];
        }

        if (bolls.Length != 0)
        {
            curentBollTransform = bolls[curentBollActiv];
        }


    }

    void Update()
    {

        curentBollTransform.position = Vector3.MoveTowards(curentBollTransform.position, target, speed * Time.deltaTime);


        if (curentBollTransform.position == target)
        {

            if (target == points[curentPoint])
            {
                curentBollActiv++;
                curentPoint++;

                if (curentPoint >= points.Length)
                {
                    curentPoint = 0;
                }

                if (curentBollActiv >= bolls.Length)
                {
                    curentBollActiv = 0;
                }

                Debug.Log(curentBollActiv);

                curentBollTransform = bolls[curentBollActiv];
                target = points[curentPoint];
                childTransform.SetParent(curentBollTransform);
                childTransform.position = new Vector3(curentBollTransform.position.x, curentBollTransform.position.y + 2f, curentBollTransform.position.z);

            }
        }
    }
}
