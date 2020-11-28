using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float rotationSpeed = 2f;
    [SerializeField] private float horizontalEgde = 2.25f;
    [SerializeField] private float VerticalEgde = 5f;
    [SerializeField] private float dieWaitTime = 0.5f;
    private AudioSource audioSource;
    internal static bool isGameOver = false;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isGameOver = false;
    }
    private void Update()
    {
        if (!isGameOver) {
           TouchControll();
           PlayerBoundries();
        }   
    }
    private void TouchControll()
    {
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
        if(TouchHandler.left) {
            transform.Rotate( Vector3.forward * rotationSpeed );
        } else if(TouchHandler.Right) {
            transform.Rotate(-Vector3.forward * rotationSpeed );
        }
    }
    private void PlayerBoundries()
    {
        if (transform.position.x > horizontalEgde|| transform.position.x < - horizontalEgde) {
                transform.position = new Vector2(- transform.position.x , transform.position.y);
        }
        if(transform.position.y > VerticalEgde || transform.position.y < - VerticalEgde) {
            transform.position = new Vector2(transform.position.x, - transform.position.y);
        }
   }
   private void OnTriggerEnter2D(Collider2D other) 
   {
       if (other.gameObject.tag == "Enemy") {
           other.gameObject.GetComponent<EnemyController>().isDestroyed = true;
           other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
           other.gameObject.transform.GetChild(0).gameObject.SetActive(true);

           audioSource.Play();
           GetComponent<SpriteRenderer>().enabled = false;
           gameObject.transform.GetChild(0).gameObject.SetActive(true);
           StartCoroutine(Die());
           isGameOver = true;
       }
   }
   private IEnumerator Die()
   {
       yield return new WaitForSeconds(dieWaitTime);
       Destroy(gameObject);
       
       
   }
}

