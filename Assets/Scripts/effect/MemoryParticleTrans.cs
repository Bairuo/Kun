using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryParticleTrans : MonoBehaviour {
    public Transform target = null;
    public float transAnimationTime = 1.5f;  // 转移动画时长
    public float transVelocity = 0.1f;     // 粒子转移速度
    ParticleSystem[] particleSys;
    ParticleSystem.Particle[][] particles;
    float transAnimationTimer = 0;

    void Awake()
    {
        particleSys = GetComponents<ParticleSystem>();
        particles = new ParticleSystem.Particle[particleSys.Length][];

        for (int i = 0; i < particleSys.Length; i++)
        {
            particles[i] = new ParticleSystem.Particle[particleSys[i].main.maxParticles];
            ParticleSystem.MainModule main = particleSys[i].main;
            main.simulationSpace = ParticleSystemSimulationSpace.World;
        }
    }

    public void StartTransAnimation()
    {
        transAnimationTimer = 0;
    }
	
	void FixedUpdate () {
        if(transAnimationTimer > transAnimationTime || target == null)
        {
            return;
        }

        transAnimationTimer += Time.deltaTime;

        for (int i = 0; i < particleSys.Length; i++)
        {
            int count = particleSys[i].GetParticles(particles[i]);

            for(int j = 0; j < count; j++)
            {
                particles[i][j].position = Vector3.Lerp(particles[i][j].position, target.position, transVelocity);
                particleSys[i].SetParticles(particles[i], count);
            }
        }
	}
}
