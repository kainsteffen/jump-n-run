using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    public float speed;
    public GameObject collectible;
    public GameObject bomb;
    public GameObject missile;

    public SpriteRenderer sprite;

    private bool moved;
    private Vector3 targetPos;


    // Use this for initialization
    void Start ()
    {
		
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moved)
        {
            targetPos = new Vector3(Random.Range(-150, 150), transform.localPosition.y, transform.localPosition.z);

            if (targetPos.x > transform.localPosition.x)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }

            moved = false;
        }
        else if (Mathf.Abs(transform.localPosition.x - targetPos.x) < 5)
        {

            if (Random.value > .5f)
            {
                Instantiate(bomb, transform.position, transform.rotation);
            }
            else
            {
                if (Random.value > .5f)
                {
                    Instantiate(collectible, transform.position, transform.rotation);
                }
                else
                {
                    Instantiate(missile, transform.position, transform.rotation);
                }

            }

            moved = true;
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, speed);
        }

	}
}
