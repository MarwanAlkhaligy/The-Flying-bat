using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointPath : MonoBehaviour
{
    [SerializeField] private List<Transform> WayPoint;
    [SerializeField] private float movementSpeed = 5f; 
    [SerializeField] private float rotationSpeed = 2f;
    [SerializeField] private float accuracy = 0.3f;
    private int wayPointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position =  WayPoint[wayPointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       Move();
    }
    private void Move()
    {
        if(wayPointIndex < WayPoint.Count)
        {
            Vector3 targetPos = WayPoint[wayPointIndex].transform.position;
            if(Vector3.Distance(transform.position, targetPos) < accuracy) {
                wayPointIndex++;
            } else{
                Vector2 direction = targetPos - this.transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle * rotationSpeed));
                //transform.Rotate(direction  * rotationSpeed);
                transform.position = Vector2.MoveTowards(transform.position, targetPos, movementSpeed * Time.deltaTime);
            }
                 
        }else{
            wayPointIndex = 0;
        }
    }
}
