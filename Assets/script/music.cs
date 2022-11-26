using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    public AudioSource audio;
    public List<AudioClip> musiclist;
    public List<AudioClip> shotlist;
    int nowplay, nextplay;
    public bool fading;
    // Start is called before the first frame update
    void Start()
    {
        fading=false;
        nowplay=0;
        if (GetComponent<AudioSource>())
        audio= this.GetComponent<AudioSource>();
        Fadein();
        print(audio.volume);
    }

    // Update is called once per frame
    /*void Update()
    {
        if (!audio.isPlaying){
            changesong(nextplay);
        }
    }*/

    public void oneshot(int play){
        audio.PlayOneShot(shotlist[play],1.5f);
    }

    public void changesong(int play){
        StartCoroutine(StartFade(3,0, play));
    }

    public void Fadein(){
        StartCoroutine(Fade(2,1));
    }
    public void Fadeout(){
        StartCoroutine(Fade(2,0));
    }

    public IEnumerator StartFade(float duration, float delay, int play)
    {
        float currentTime = 0, targetVolume = 0;
        float start = audio.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audio.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        audio.Stop();
        audio.clip = musiclist[play];
        audio.Play();
        yield return new WaitForSeconds(delay);

        currentTime = 0;
        targetVolume = 1;        
        start = audio.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audio.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }

    public IEnumerator Fade(float duration, float targetVolume)
    {
        fading=true;
        float currentTime = 0;
        float start = audio.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audio.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        fading=false;
        yield break;
    }
}
