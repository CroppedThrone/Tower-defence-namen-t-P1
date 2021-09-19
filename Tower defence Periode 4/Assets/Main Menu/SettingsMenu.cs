using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public Dropdown resolutionDropdown;
    public GameObject settingCanvas;
    public int lastPressed;
    public GameObject drop;
    public GameObject mapCanvas;
    public MapButton mapButton;
    public Shop shop;

    void Start()
    {
        resolutions = Screen.resolutions;
        
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex =0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && 
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
                
            }
            

        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void ButtonSetting()
    {
        

        

        lastPressed++;
        if (lastPressed == 1)
        {
            settingCanvas.SetActive(true);
            mapCanvas.SetActive(false);
            drop.SetActive(false);
            shop.lastPressed = 0;
            mapButton.lastPressed = 0;
        }
        else
        {
            lastPressed = 0;
            settingCanvas.SetActive(false);
        }
    }
}
