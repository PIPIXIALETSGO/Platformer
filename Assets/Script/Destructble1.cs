using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructble1 : MonoBehaviour
{
    public int scorevalue = 1;
    public int counter = 0;
    public GameManager score;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();
        if (!bullet.isEnemy)
        {
            counter++;
            if (counter >= 3)
            {
                Destroy(gameObject);
                Destroy(bullet.gameObject);
            }
            else
            {
                Destroy(bullet.gameObject);

            }
        }
    }
}
