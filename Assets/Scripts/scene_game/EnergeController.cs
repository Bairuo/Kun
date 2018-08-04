using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergeController : MonoBehaviour {
    public GameObject kun;
    public float SeparationDistance;
    public int energe = 100;
    public int minEnerge = 35;
    public float accelerateWaitTime = 2;
    enum MoveState { left = -1, right = 1 };
    int moveState = 1;
    int lastMoveState = 1;
    int maxEnerge;
    int lastEnerge;
    float accelerateTimer = 0;

	// Use this for initialization
	void Start () {
        lastEnerge = energe;
        maxEnerge = energe;
	}


	// Update is called once per frame
    void FixedUpdate()
    {
        if(accelerateTimer > 0)
        {
            accelerateTimer -= Time.deltaTime;
        }


        // 透明度
        if(lastEnerge != energe)
        {
            lastEnerge = energe;
            Color color = GetComponent<SpriteRenderer>().color;

            SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
            foreach(SpriteRenderer sprite in sprites)
            {
                sprite.color = new Color(color.r, color.g, color.b, 1.0f * energe / maxEnerge);
            }
        }

        // 方向
        if(kun.transform.position.x - this.transform.position.x != 0)
        {
            moveState = kun.transform.position.x - this.transform.position.x > 0 ? (int)MoveState.right : (int)MoveState.left;
        }

        if(moveState != lastMoveState)
        {
            GetComponent<Animator>().SetInteger("movestate", moveState);
            lastMoveState = moveState;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Memory")
        {
            //GetComponent<Animation>().Play();

            //GetComponent<Twinkle>().ClearAllKeys();
            //GetComponent<Twinkle>().AddKey(0, GetComponent<SpriteRenderer>().color.a);
            //GetComponent<Twinkle>().AddKey(40, GetComponent<SpriteRenderer>().color.a * 0.5f);
            //GetComponent<Twinkle>().AddKey(80, GetComponent<SpriteRenderer>().color.a);
            //GetComponent<Twinkle>().Play();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Memory")
        {
            //GetComponent<Animation>().Stop();

            //GetComponent<Twinkle>().Stop();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Memory" && energe < maxEnerge && (kun.transform.position - this.transform.position).magnitude > SeparationDistance)
        {
            energe += other.GetComponent<MemoryController>().Exploit();
        }
    }

    public bool IsWeek()
    {
        return energe <= minEnerge;
    }

    public int getEnerge(int demand)
    {
        if(energe - minEnerge > demand)
        {
            energe -= demand;
            return demand;
        }
        else
        {
            int getvalue = energe - minEnerge;
            energe = minEnerge;
            return getvalue;
        }
    }

    public bool canAccelerate()
    {
        if(energe >= minEnerge && accelerateTimer <= 0)
        {
            accelerateTimer = accelerateWaitTime;
            return true;
        }
        else
        {
            return false;
        }
    }
}
