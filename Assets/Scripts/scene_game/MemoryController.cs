using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryController : MonoBehaviour {
    public int energy;
    public float frequency = 0.5f;     // 开采频率
    public int speed;       // 每秒开采
    public bool regenerate = false;     // 是否重生
    public int generateSpeed;           // 重生速度
    float timer = 0;
    float maxEnergy;
    float lastEnergy;
    bool prepare = true;

    void Start()
    {
        lastEnergy = energy;
        maxEnergy = energy;
    }

    void Update()
    {
        // 计时是否可产出
        timer += Time.deltaTime;

        if(energy == 0 && !regenerate)
        {
            Destroy(this.gameObject);
        }

        if(timer > frequency)
        {
            timer = 0;
            prepare = true;

            // 再生
            if (regenerate && energy < maxEnergy)
            {
                energy += generateSpeed;
            }
        }

        // 更新透明度
        if (lastEnergy != energy)
        {
            lastEnergy = energy;
            Color color = GetComponent<SpriteRenderer>().color;
            GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 1.0f * energy / maxEnergy);
        }

    }

    public int Exploit(Transform Miner)
    {
        if(prepare)
        {
            prepare = false;

            if(energy > 0)
            {
                MemoryParticleTrans TransferDevice = GetComponentInChildren<MemoryParticleTrans>();

                if(TransferDevice != null)
                {
                    TransferDevice.target = Miner;
                    TransferDevice.StartTransAnimation();
                }
            }

            if(energy >= speed)
            {
                energy -= speed;
                return speed;
            }
            else
            {
                int real = energy;
                energy = 0;
                return real;
            }

        }
        else
        {
            return 0;
        }
    }
}
