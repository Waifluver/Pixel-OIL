using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public int[] xCoordinatesPatrolPoints = new int[] { 0, 5, 7, -5, -7 };
    public float speed = 1.0f;
    Vector3 goal;
    public float lastPosition;
    public bool IsMoving { get { return Mathf.Abs(transform.position.x - lastPosition) > 0.01f; } }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(GetNewPosition), 0.1f, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, goal, step);

        if (!IsMoving)
        {
            StartCoroutine(nameof(CheckIfIdle))
        }

        lastPosition = transform.position.x;
    }

    void GetNewPosition()
    {
        int d = Random.Range(0, xCoordinatesPatrolPoints.Length - 1);
        goal = new Vector3(xCoordinatesPatrolPoints[d], transform.position.y, transform.position.z);

    }
    
    IEnumerator CheckIfIdle()
    {
        float counter = 0;

        if (!IsMoving)
        {
            counter += Time.deltaTime;
        }
    }



}
