using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private bool mbPause = false;
    public AudioMixer mixer;
    [SerializeField] Button mPauseButton;
    public Slider mVolumSlider;
    // Start is called before the first frame update
    void Start()
    {
        mPauseButton.onClick.AddListener(GamePause);
        mVolumSlider.onValueChanged.AddListener(GameVolumeChange);
    }
    public void GamePause()
    {
        if (!mbPause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        mbPause = !mbPause;
        Debug.Log("button cliks...");
    }
    public void GameVolumeChange(float fVolume)
    {
        mixer.SetFloat("MasterVolume", fVolume);
        Debug.Log(fVolume);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
