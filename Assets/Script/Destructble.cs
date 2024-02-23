using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructble : MonoBehaviour
{
    bool canBeDestroyed=false;
    public int scorevalue=1;
    public GameManager score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x<14.99f&&!canBeDestroyed){
            canBeDestroyed=true;
           Gun[] guns= transform.GetComponentsInChildren<Gun>();
           foreach(Gun gun in guns){
            gun.isActive=true;
           }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(!canBeDestroyed){
            return;
        }
        Bullet bullet = collision.GetComponent<Bullet>();
        if(bullet !=null)
        {
            if(!bullet.isEnemy){
            Destroy(gameObject);
            Destroy(bullet.gameObject);
            score.AddScore(scorevalue);
            }
        }
    }
    private void OnDestroy() {
        
    }
}
