﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunController : MonoBehaviour {
    Rocker rocker;
    public GameObject deathcurtain;
    [Range(0, 3)]
    public int forward = 3;     // 关卡的前进方向
    public float operability;   // 玩家摇杆对鲲的控制力度
    public int energy = 100;
    public int weekEnergy = 40;         // 虚弱能量线
    public float absorbTime = 0.5f;     // 吸收时间
    public int absorbSpeed = 5;         // 每次吸收数量
    public float consumeTime = 0.5f;    // 消耗能量时间
    public int consumeSpeed = 1;        // 消耗能量速度
    public int moveForwardX;
    public int moveForwardY;
    public bool invincible = false;

    Vector2 startFactor;
    enum MoveState { left = -1, right = 1 };
    enum MoveStateY { down = -1, up = 1 };
    int lastMoveForwardX;
    int lastMoveForwardY;
    int lastEnerge;
    int maxEnerge;
    float startTimer = 0;
    float absorbTimer = 0;
    float consumeTimer = 0;
    bool absorbWait = true;
    float originOperability;

	// Use this for initialization
	void Start () {
        rocker = GameObject.FindGameObjectWithTag("Rocker").GetComponent<Rocker>();

        moveForwardX = (int)MoveState.right;
        lastMoveForwardX = moveForwardX;

        moveForwardY = (int)MoveStateY.up;
        lastMoveForwardY = moveForwardY;

        lastEnerge = energy;
        maxEnerge = energy;

        originOperability = operability;

        switch(forward)
        {
            case 0:
            case 1:
                startFactor = new Vector2(2.8f, 1);
                break;
            case 2:
            case 3:
                startFactor = new Vector2(1, 2.8f);
                break;
        }
	}

    public bool EnergySaturation()
    {
        return energy >= maxEnerge;
    }
	
    public bool Absorb(GameObject energeBall)
    {
        EnergeController energeController = energeBall.GetComponent<EnergeController>();
        if(absorbWait && !EnergySaturation())
        {
            absorbWait = false;
            absorbTimer = 0;
            int getEnerge = energeController.getEnerge(absorbSpeed);
            energy += getEnerge;

            if(getEnerge > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public void GameOver()
    {
        deathcurtain.SetActive(true);
    }

	// Update is called once per frame
    void FixedUpdate()
    {
        if(energy <= 0)
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

        if(consumeTimer > consumeTime && !invincible)
        {
            consumeTimer = 0;
            if(energy > 0)
            {
                energy -= consumeSpeed;

                if(energy <= 0)
                {
                    GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                    GameOver();
                }
            }
        }

        if (lastEnerge != energy)
        {
            lastEnerge = energy;
            Color color = GetComponent<SpriteRenderer>().color;
            GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 1.0f * energy / maxEnerge);
        }

        // 虚弱
        if (energy < weekEnergy)
        {
            operability = 1.0f * energy / weekEnergy * originOperability;
        }
        else
        {
            operability = originOperability;
        }

        // 方向与动画,转向处理
        if(rocker.x != 0)
        {
            moveForwardX = rocker.x > 0 ? (int)MoveState.right : (int)MoveState.left;
        }

        if(rocker.y != 0)
        {
            moveForwardY = rocker.y > 0 ? (int)MoveStateY.up : (int)MoveStateY.down;
        }

        if(moveForwardX != lastMoveForwardX)
        {
            float animationTime = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime % 1;
            
            //GetComponent<Animator>().SetInteger("movestate", moveForwardX);

            if (moveForwardX == 1)
            {
                GetComponent<Animator>().Play("right", 0, animationTime);
            }
            else
            {
                GetComponent<Animator>().Play("left", 0, animationTime);
            }

            lastMoveForwardX = moveForwardX;

            if(GetComponent<Rigidbody2D>().velocity.magnitude > 2)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x * -0.3f, GetComponent<Rigidbody2D>().velocity.y);
            }
            
        }

        if (moveForwardY != lastMoveForwardY)
        {
            lastMoveForwardY = moveForwardY;

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
                GetComponent<Rigidbody2D>().AddForce(operability * new Vector2(rocker.x, rocker.y) * startFactor * 6, ForceMode2D.Impulse);
            }
            if(GetComponent<Rigidbody2D>().velocity.magnitude < 0.5f)
            {
                GetComponent<Rigidbody2D>().AddForce(operability * new Vector2(rocker.x, rocker.y) * startFactor * 4, ForceMode2D.Impulse);
            }
            else if(GetComponent<Rigidbody2D>().velocity.magnitude < 1)
            {
                GetComponent<Rigidbody2D>().AddForce(operability * new Vector2(rocker.x, rocker.y) * startFactor * 2, ForceMode2D.Impulse);
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(operability * new Vector2(rocker.x, rocker.y) * startFactor, ForceMode2D.Impulse);
            }
        }
	}
}
