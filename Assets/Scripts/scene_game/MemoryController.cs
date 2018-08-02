﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryController : MonoBehaviour {
    public int energe;
    public float frequency = 0.5f;     // 开采频率
    public int speed;       // 每秒开采
    public bool regenerate = false;     // 是否重生
    public int generateSpeed;           // 重生速度
    float timer = 0;
    float maxEnerge;
    float lastEnerge;
    bool prepare = true;

    void Start()
    {
        lastEnerge = energe;
        maxEnerge = energe;
    }

    void Update()
    {
        // 计时是否可产出
        timer += Time.deltaTime;

        if(timer > frequency)
        {
            timer = 0;
            prepare = true;

            // 再生
            if (regenerate && energe < maxEnerge)
            {
                energe += generateSpeed;
            }
        }

        // 更新透明度
        if (lastEnerge != energe)
        {
            lastEnerge = energe;
            Color color = GetComponent<SpriteRenderer>().color;
            GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 1.0f * energe / maxEnerge);
        }

    }

    public int Exploit()
    {
        if(prepare)
        {
            prepare = false;

            if(energe >= speed)
            {
                energe -= speed;
                return speed;
            }
            else
            {
                int real = energe;
                energe = 0;
                return real;
            }

        }
        else
        {
            return 0;
        }
    }
}
