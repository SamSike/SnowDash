using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailEffect : MonoBehaviour
{
    public Player player;

    public ParticleSystem snowEffect;
    public ParticleSystem lavaEffect;
    public ParticleSystem desertEffect;
    public ParticleSystem forestEffect;

    private ParticleSystem currentEffect;

    private List<ParticleSystem> ThemedEffects;
    private List<ParticleSystem> newEffect;
    private List<float> newEffectStart;

    // Start is called before the first frame update
    void Start()
    {
        newEffect = new List<ParticleSystem>();
        newEffectStart = new List<float>();
        ThemedEffects = new List<ParticleSystem>();
        ThemedEffects.Add(snowEffect);
        ThemedEffects.Add(lavaEffect);
        ThemedEffects.Add(desertEffect);
        ThemedEffects.Add(forestEffect);

        currentEffect = snowEffect;
    }

    void Update()
    {
        if (newEffectStart.Count > 0 && player.transform.position.z >= newEffectStart[0])
        {
            {
                currentEffect.Stop(true);
                //ParticleSystem.EmissionModule currentEmission = currentEffect.emission;
                //currentEmission.rateOverTime = 0f;
            }
            currentEffect = newEffect[0];
            currentEffect.Play(true);
            newEffect.RemoveAt(0);
            newEffectStart.RemoveAt(0);
        }
    }

    public ParticleSystem GetThemedEffects(int index) { return ThemedEffects[index]; }
    public ParticleSystem SetNewEffect(int index, float location)
    {
        newEffect.Add(ThemedEffects[index]);
        newEffectStart.Add(location);

        return ThemedEffects[index];
    }
    public ParticleSystem SetNewEffect(ParticleSystem effect)
    {
        foreach (ParticleSystem t in ThemedEffects)
        {
            //ParticleSystem.EmissionModule tEmission = t.emission;
            //tEmission.rateOverTime = 0f;
            t.Stop(true);
        }
        currentEffect = effect;
        currentEffect.Play(true);
        return currentEffect;
    }
    public void SetTrailEmission(float newEmission)
    {
        ParticleSystem.EmissionModule currentEmission = currentEffect.emission;
        currentEmission.rateOverTime = newEmission;
    }
}