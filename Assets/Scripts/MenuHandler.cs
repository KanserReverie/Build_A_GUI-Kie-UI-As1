using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuHandler : MonoBehaviour
{

    public Resolution[] resolutions;
    public Dropdown resolutionDropDown;
    public Dropdown qualitiyDropDown;

    // These are all slider and toggles on the settings pannel.
    public Slider musicSlider;
    public Slider pitchSlider;
    public Toggle fullScreenToggle;

    public AudioMixer musicAudio;
    public AudioMixer masterAudio;



    private void Start()
    {
       

        SetUpResolutions();
        SetUpQuality();
        
        LoadPlayerPrefs2();
    }

    // Sets up Quality drop down.
    public void SetUpQuality()
    {
        List<string> names = new List<string>(QualitySettings.names);
        qualitiyDropDown.ClearOptions();
        qualitiyDropDown.AddOptions(names);
        qualitiyDropDown.value = QualitySettings.GetQualityLevel();

    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    // Basically sets up Resolution drop down.
    void SetUpResolutions()
    {
        // Makes resolution
        resolutions = Screen.resolutions;

        resolutionDropDown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        foreach (Resolution resolution in resolutions)
        {
            string option = resolution + "x" + resolution.height + "@" + resolution.refreshRate;
            options.Add(option);

            if (resolution.width == Screen.currentResolution.width
                && resolution.height == Screen.currentResolution.height
                && resolution.refreshRate == Screen.currentResolution.refreshRate)
            {
                currentResolutionIndex = options.Count - 1;
            }
        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();
    }

    public void SetResolutions(int resolutionIndex)
    {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen, res.refreshRate);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void ChangeVolume(float volume)
    {
        musicAudio.SetFloat("MusicVol", volume);
    }

    public void ChangePitch(float volume)
    {
        musicAudio.SetFloat("PitchShift", volume);
    }

    public void ToggleMute(bool isMuted)
    {
        if (isMuted)
        {
            musicAudio.SetFloat("MusicVol", -80);
        }
        else
        {
            musicAudio.SetFloat("MusicVol", 0);
        }
    }
    


    // On disable run this
    private void OnDisable()
    {
        SavePlayerPrefs2();
    }

    public void SavePlayerPrefs2()
    {
        // Gets volume, sets volume and saves volume.
        float volume;
        if (masterAudio.GetFloat("MusicVol", out volume))       // "MusicVol" is the "Exposed Parameters" in the Audio Mixer
        {
            PlayerPrefs.SetFloat("MusicVol", volume);
        }

        // Gets pitch, sets pitch and saves pitch.
        float Pitch;
        if (masterAudio.GetFloat("PitchShift", out Pitch))       // "volumeDistortion" is the "Exposed Parameters" in the Audio Mixer
        {
            PlayerPrefs.SetFloat("PitchShift", Pitch);
        }
        
        // For full screen.
        // 0 = false
        // 1 = truetrue
        PlayerPrefs.SetInt("fullscreen", fullScreenToggle.isOn == true ? 1 :0);

        // Gets quality, sets quality and saves quality.
        if (resolutionDropDown != null)
        {
            PlayerPrefs.SetInt("Resolution", resolutionDropDown.value);
        }

    }

    // On start run volume.
    public void LoadPlayerPrefs2()
    {
        // Gets volume sets volume and saves volume.
        if (PlayerPrefs.HasKey("MusicVol"))
        {
            float musicVol = PlayerPrefs.GetFloat("MusicVol");
            masterAudio.SetFloat("MusicVol", musicVol);
            musicSlider.value = musicVol;
        }

        // Gets volume sets pitch and saves pitch.
        if (PlayerPrefs.HasKey("PitchShift"))
        {
            float pitchShift = PlayerPrefs.GetFloat("PitchShift");
            masterAudio.SetFloat("PitchShift", pitchShift);
            pitchSlider.value = pitchShift;
        }

        if (PlayerPrefs.HasKey("fullscreen"))
        {
            fullScreenToggle.isOn = PlayerPrefs.GetInt("fullscreen") == 0 ? false : true; // Anything but 0 is true.
            Screen.fullScreen = fullScreenToggle.isOn;
        }

        
        if (PlayerPrefs.HasKey("Resolution"))
        {
            int resolution = PlayerPrefs.GetInt("Resolution");
            resolutionDropDown.value =  resolution;
            }
        
        
    }
}

