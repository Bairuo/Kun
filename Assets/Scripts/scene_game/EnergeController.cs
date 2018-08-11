using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergeController : MonoBehaviour {
    public GameObject kun;
    public float SeparationDistance;
    public int energy = 100;
    public int minEnergy = 35;
    public float accelerateWaitTime = 2;
    enum MoveState { left = -1, right = 1 };
    int moveState = 1;
    int lastMoveState = 1;
    int maxEnergy;
    int lastEnergy;
    float accelerateTimer = 0;

	// Use this for initialization
	void Start () {
        lastEnergy = energy;
        maxEnergy = energy;
	}


	// Update is called once per frame
    void FixedUpdate()
    {
        if(accelerateTimer > 0)
        {
            accelerateTimer -= Time.deltaTime;
        }


        // 透明度
        if(lastEnergy != energy)
        {
            lastEnergy = energy;
            Color color = GetComponent<SpriteRenderer>().color;

            SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
            foreach(SpriteRenderer sprite in sprites)
            {
                sprite.color = new Color(color.r, color.g, color.b, 1.0f * energy / maxEnergy);
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
        if (other.tag == "Memory" && energy < maxEnergy && (kun.transform.position - this.transform.position).magnitude > SeparationDistance)
        {
            energy += other.GetComponent<MemoryController>().Exploit(this.transform);
        }
    }

    public bool IsWeek()
    {
        return energy <= minEnergy;
    }

    public int getEnerge(int demand)
    {
        if(energy - minEnergy > demand)
        {
            energy -= demand;
            return demand;
        }
        else
        {
            int getvalue = energy - minEnergy;
            energy = minEnergy;
            return getvalue;
        }
    }

    public bool canAccelerate()
    {
        if(energy >= minEnergy && accelerateTimer <= 0)
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
