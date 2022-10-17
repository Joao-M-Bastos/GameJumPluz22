using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    [SerializeField] private AudioSource jumpEffect;
    [SerializeField] private AudioSource menuConfirma;
    [SerializeField] private AudioSource menuVoltar;
    [SerializeField] private AudioSource derrotaFx;
    [SerializeField] private AudioSource vitoriaFx;
    [SerializeField] private AudioSource starCollect;

    public void PlayJumpEffect()
    {
        jumpEffect.Play();
    }

    public void PlayMenuConfirma()
    {
        menuConfirma.Play();
    }
    public void PlayMenuVoltar()
    {
        menuVoltar.Play();
    }

    public void PlayVitoria()
    {
        vitoriaFx.Play();
    }

    public void PlayDerrota()
    {
        derrotaFx.Play();
    }

    public void PlayStarCollect()
    {
        starCollect.Play();
    }
}
