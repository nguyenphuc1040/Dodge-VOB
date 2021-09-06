using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireVOB : MonoBehaviour
{
    public GameObject VOB;
    public Transform player, pointAim;
    private float speed;
    
    void Start()
    {
        Physics2D.IgnoreLayerCollision(6,9,true);
        StartCoroutine(Fire());
    }   
    private void FixedUpdate(){
        float angle = (speed>45f) ? AngleBetweenTwoPoints(transform.position, player.position) : AngleBetweenTwoPoints(transform.position, pointAim.position);
        transform.rotation =  Quaternion.Euler (new Vector3(0f,0f,angle));
    }
    IEnumerator Fire(){
        speed = Random.Range(40f,50f);
        yield return new WaitForSeconds(Random.Range(3f,6f));
        var VOBFire =  (GameObject) Instantiate(VOB,transform.position,transform.rotation);      
        VOBFire.GetComponent<Rigidbody2D>().velocity = VOBFire.transform.right * -speed;
        Destroy(VOBFire,5); // Destroy Volleyball after 5 seconds
        StartCoroutine(Fire());
    }
    private float AngleBetweenTwoPoints(Vector2 a, Vector2 b) { 
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
