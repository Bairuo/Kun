using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackWhiteEffect : PostEffectBase
{
    public float time = 4;
    float timer = 0;

    public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        timer += Time.deltaTime;
        if(timer >= time)
        {
            timer = time;
        }

        if (_Material)
        {
            _Material.SetFloat("_Degree", timer / time);
            Graphics.Blit(source, destination, _Material);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }
}
