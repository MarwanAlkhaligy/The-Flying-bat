using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float rotationSpeed = 5f;
    private Vector3 targetPos = Vector3.zero;
    [SerializeField] private float horizontalBoundary = 2.25f;
    [SerializeField] private float VerticalBoundary = 4.7f;
    [SerializeField] private float accurancy = 0.1f;
    private Animator animator;
    internal  bool isDestroyed = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        targetPos = new Vector2(Random.Range(-horizontalBoundary, horizontalBoundary),
                    Random.Range(-VerticalBoundary, VerticalBoundary));
        Invoke("Disappear", Random.Range(6, 8));
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDestroyed) {
            if(Vector3.Distance(transform.position, targetPos) < accurancy) {
            targetPos = new Vector2(Random.Range(-horizontalBoundary, horizontalBoundary),
                    Random.Range(-VerticalBoundary, VerticalBoundary));
            } else{
                Vector2 direction = targetPos - this.transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle * rotationSpeed));
                //transform.Rotate(direction  * rotationSpeed);
                transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            }
        }
    }
    private void Disappear()
    {
        if(animator) {
            animator.SetTrigger("Disappear");
            Destroy(gameObject,1f);
            EnemySpawner.count--;
        }
    }
}
