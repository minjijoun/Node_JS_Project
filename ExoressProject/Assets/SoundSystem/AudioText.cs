using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioText : MonoBehaviour
{
    [SerializeField] protected SoundProfileData soundProfileData;
    [SerializeField] protected SoundProfileData soundProfileBGMData;

    private AudioManager audioManager => AudioManager.Instance;

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space))
        {
            audioManager.PlayOneShot(soundProfileData.GetRandomClip());
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            audioManager.PlayMusic(soundProfileData.GetRandomClip());
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Login");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            audioManager.FadeInMuisc(soundProfileBGMData.GetCliplndex(0), 3.0f);
        }

    }

}
