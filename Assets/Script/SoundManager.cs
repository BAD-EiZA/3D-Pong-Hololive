using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioClip GuraGoal;
    public AudioClip GuraWin;
    public AudioClip MioGoal;
    public AudioClip MioWin;
    public AudioClip OkayuGoal;

    public AudioClip WatsonGoal;
    public AudioClip WatsonWin;
    public AudioClip BallBounce;
    public AudioSource audios;
    // Start is called before the first frame update
    private void Start()
    {
        instance = this;
        audios = GetComponent<AudioSource>();
    }
    public void BallBounces()
    {
        audios.PlayOneShot(BallBounce);
    }
    public void GuraGoals()
    {
        audios.PlayOneShot(GuraGoal);
    }
    public void GuraWins()
    {
        audios.PlayOneShot(GuraWin);
    }
    public void OkayuGoals()
    {
        audios.PlayOneShot(OkayuGoal);
    }
    
    public void WatsonGoals()
    {
        audios.PlayOneShot(WatsonGoal);
    }
    public void WatsonWins()
    {
        audios.PlayOneShot(WatsonWin);
    }
    public void MioGoals()
    {
        audios.PlayOneShot(MioGoal);
    }
    public void MioWins()
    {
        audios.PlayOneShot(MioWin);
    }


}
