using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Bullet bullet;
    public bool autoShoot=false;
    public float shootIntervalSeconds=0.5f;
    public float shootDelaySeconds=1.0f;
    public float shootTimer=0f;
    public float delayTimer=0f;
    public bool isActive=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isActive){
            return;
        }
        if(autoShoot){
            if(delayTimer>=shootDelaySeconds){
                if(shootTimer>=shootIntervalSeconds){
                    Shoot();
                    shootTimer=0;
                }else{
                    shootTimer+= Time.deltaTime;
                }
            }else{
                delayTimer+=Time.deltaTime;
            }
        }
    }

    public void Shoot(){
        GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);

    }
}
