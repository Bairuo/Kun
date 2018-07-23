using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunController : MonoBehaviour {
    public Rocker rocker;
    public GameObject deathcurtain;
    public float operability;   // 玩家摇杆对鲲的控制力度
    public int energe = 100;
    public int weekEnerge = 40;         // 虚弱能量线
    public float absorbTime = 0.5f;     // 吸收时间
    public int absorbSpeed = 5;         // 每次吸收数量
    public float consumeTime = 0.5f;    // 消耗能量时间
    public int consumeSpeed = 1;        // 消耗能量速度
    public int moveState;
    public int moveStateY;
    enum MoveState { left = -1, right = 1 };
    enum MoveStateY { down = -1, up = 1 };
    int lastMoveState;
    int lastMoveStateY;
    int lastEnerge;
    int maxEnerge;
    float startTimer = 0;
    float absorbTimer = 0;
    float consumeTimer = 0;
    bool absorbWait = true;
    float originOperability;

	// Use this for initialization
	void Start () {
        lastMoveState = (int)MoveState.right;
        moveState = lastMoveState;

        lastMoveStateY = (int)MoveStateY.up;
        moveStateY = lastMoveStateY;

        lastEnerge = energe;
        maxEnerge = energe;

        originOperability = operability;
	}
	
    public void Absorb(GameObject energeBall)
    {
        EnergeController energeController = energeBall.GetComponent<EnergeController>();
        if(absorbWait && energe < maxEnerge)
        {
            absorbWait = false;
            absorbTimer = 0;
            energe += energeController.getEnerge(absorbSpeed);
        }
    }

    public void GameOver()
    {
        deathcurtain.SetActive(true);
    }

	// Update is called once per frame
    void FixedUpdate()
    {
        if(energe <= 0)
        {
            return;
        }

        startTimer += Time.deltaTime;
        absorbTimer += Time.deltaTime;
        consumeTimer += Time.deltaTime;


        if(absorbTimer > absorbTime)
        {
            absorbWait = true;
            absorbTimer = 0;
        }

        if(consumeTimer > consumeTime)
        {
            consumeTimer = 0;
            if(energe > 0)
            {
                energe -= consumeSpeed;

                if(energe <= 0)
                {
                    GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                    GameOver();
                }
            }
        }

        if (lastEnerge != energe)
        {
            lastEnerge = energe;
            Color color = GetComponent<SpriteRenderer>().color;
            GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 1.0f * energe / maxEnerge);
        }

        // 虚弱
        if (energe < weekEnerge)
        {
            operability = 1.0f * energe / weekEnerge * originOperability;
        }
        else
        {
            operability = originOperability;
        }

        // 方向与动画,转向处理
        if(rocker.x != 0)
        {
            moveState = rocker.x > 0 ? (int)MoveState.right : (int)MoveState.left;
        }

        if(rocker.y != 0)
        {
            moveStateY = rocker.y > 0 ? (int)MoveStateY.up : (int)MoveStateY.down;
        }
        
        if(moveState != lastMoveState)
        {
            GetComponent<Animator>().SetInteger("movestate", moveState);
            lastMoveState = moveState;

            if(GetComponent<Rigidbody2D>().velocity.magnitude > 2)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x * -0.3f, GetComponent<Rigidbody2D>().velocity.y);
            }
            
        }

        if (moveStateY != lastMoveStateY)
        {
            lastMoveStateY = moveStateY;

            if (GetComponent<Rigidbody2D>().velocity.magnitude > 2)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y * -0.3f);
            }

        }

        // 受力与起步加速
        if (startTimer >= 0.25f)
        {
            startTimer = 0;
            // 分段起步速度（自动挡？？）
            if (GetComponent<Rigidbody2D>().velocity.magnitude < 0.2f)
            {
                //GetComponent<Rigidbody2D>().AddForce(operability * rocker.relative.normalized * 6, ForceMode2D.Impulse);
                GetComponent<Rigidbody2D>().AddForce(operability * new Vector2(rocker.x, rocker.y * 2) * 6, ForceMode2D.Impulse);
            }
            if(GetComponent<Rigidbody2D>().velocity.magnitude < 0.5f)
            {
                //GetComponent<Rigidbody2D>().AddForce(operability * rocker.relative.normalized * 4, ForceMode2D.Impulse);
                GetComponent<Rigidbody2D>().AddForce(operability * new Vector2(rocker.x, rocker.y * 2) * 4, ForceMode2D.Impulse);
            }
            else if(GetComponent<Rigidbody2D>().velocity.magnitude < 1)
            {
                //GetComponent<Rigidbody2D>().AddForce(operability * rocker.relative.normalized * 2, ForceMode2D.Impulse);
                GetComponent<Rigidbody2D>().AddForce(operability * new Vector2(rocker.x, rocker.y * 2) * 2, ForceMode2D.Impulse);
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(operability * new Vector2(rocker.x, rocker.y * 2), ForceMode2D.Impulse);
            }
        }
	}
}
