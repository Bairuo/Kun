using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenVibration : MonoBehaviour {
    public Camera cam;
    public static float shakeTime = 0.8f;
    public static float shakeTimer = 0.8f;
    public float fps = 20.0f;
    public float shakeDelta = 0.005f;
    public static float frameTime = 0.00f;
    public static bool isshakeCamera = false;

    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    public static void Shake()
    {
        shakeTimer = shakeTime;
        isshakeCamera = true;
    }

    void Update()
    {
        if (isshakeCamera)
        {
            if (shakeTimer > 0)
            {
                shakeTimer -= Time.deltaTime;
                if (shakeTimer <= 0)
                {
                    cam.rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
                    isshakeCamera = false;
                    shakeTimer = 1.0f;
                    fps = 20.0f;
                    frameTime = 0.03f;
                    shakeDelta = 0.005f;
                }
                else
                {
                    frameTime += Time.deltaTime;
                    if (frameTime > 1.0 / fps)
                    {
                        frameTime = 0;
                        cam.rect = new Rect(shakeDelta * (-1.0f + 2.0f * Random.value), shakeDelta * (-1.0f + 2.0f * Random.value), 1.0f, 1.0f);
                    }
                }
            }
        }
    }
}
