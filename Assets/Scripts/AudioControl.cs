using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    [SerializeField] string volumeParameter = "MasterVolume";
    [SerializeField] AudioMixer mixer;
    // [SerializeField] Slider slider;
    // [SerializeField] float multiplier = 30f;
    // [SerializeField] Toggle toggle;
    // bool disableToggleEvent;
    // float unmuteVolume;
    // float pauseVolume;

/*
    private void Awake()
    {
        slider.onValueChanged.AddListener(HandleSliderValueChanged);
        toggle.onValueChanged.AddListener(HandleToggleValueChanged);
    }

    /// <summary>
    /// Increases or decreases the volume of the audio mixer using the slider input value
    /// </summary>
    private void HandleSliderValueChanged(float value)
    {
        mixer.SetFloat(volumeParameter, Mathf.Log10(value) * multiplier);

        // Avoid firing HandleToggleValueChanged to avoid maximising volume on unmute specifically by dragging the slider from no sound and up, not unmuting via toggle
        disableToggleEvent = true;
        // If slider is greater than the minimum value (mute) then the mute button is toggled off, else on
        if (slider.value > slider.minValue)
        {
            toggle.isOn = false;
        }
        else
        {
            toggle.isOn = true;
        }
        disableToggleEvent = false;
    }

    /// <summary>
    /// Enable or disable sound
    /// </summary>
    private void HandleToggleValueChanged(bool enableSound)
    {
        if (disableToggleEvent)
        {
            return;
        }

        if (!enableSound)
        {
            // Unmute and set to volume it was before mute
            slider.value = unmuteVolume;
        }
        else
        {
            // Save current volume before muting
            unmuteVolume = slider.value;
            slider.value = slider.minValue;
        }
    }

    private void OnDisable()
    {
        // Save the current volume to PlayerPrefs
        if (toggle.isOn)
        {
            PlayerPrefs.SetFloat(volumeParameter, unmuteVolume);
        }
        else
        {
        PlayerPrefs.SetFloat(volumeParameter, slider.value);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Load the saved volume from PlayerPrefs, and if nothing is saved use the default slider value
        slider.value = PlayerPrefs.GetFloat(volumeParameter, slider.value);
    }

    #region Pause Volume

        /// <summary>
        /// Decrease the volume
        /// </summary>
        public void PauseVolume(float value)
        {
            pauseVolume = slider.value;
            mixer.SetFloat(volumeParameter, Mathf.Log10(slider.value - value) * multiplier);
        }

        /// <summary>
        /// Return volume to normal
        /// </summary>
        public void NormalVolume()
        {
            mixer.SetFloat(volumeParameter, Mathf.Log10(slider.value) * multiplier);
        }

    #endregion

    public void SetPitch(float pitch)
    {
        mixer.SetFloat("MasterPitch", pitch);
    }
*/
}
