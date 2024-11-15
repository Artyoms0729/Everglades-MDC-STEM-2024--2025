using System.Collections;
using UnityEngine;

public class SkyboxCycle : MonoBehaviour
{
    // Skybox materials for each phase
    public Material earlyDaySkybox, middleDaySkybox, hurricaneMildSkybox, hurricaneHeavySkybox, clearSkybox, nightSkybox;

    // Durations for each phase
    [Header("Skybox Durations (in seconds)")]
    public float earlyDayDuration = 150f;
    public float middleDayDuration = 150f;
    public float hurricaneMildDuration = 150f;
    public float hurricaneHeavyDuration = 150f;
    public float clearSkyDuration = 150f;
    public float nightDuration = 150f;
    public float transitionDuration = 5.0f;

    [Header("Skybox Rotation")]
    public float skyboxRotationSpeed = 0.5f; // Adjusted for slower rotation in VR

    // Rain particle system and sound effects
    public ParticleSystem rainEffect;
    public AudioSource rainSound;
    public AudioSource windSound;

    // Rain settings for Mild and Heavy Hurricane phases
    [Header("Mild Hurricane Rain Settings")]
    public float mildRainParticles = 50f;
    public float mildRainStartSpeed = 5f;
    public float mildRainLifetime = 1f;

    [Header("Heavy Hurricane Rain Settings")]
    public float heavyRainParticles = 100f;
    public float heavyRainStartSpeed = 10f;
    public float heavyRainLifetime = 1.5f;
    public float heavyRainVolume = 1.0f;
    public float heavyWindVolume = 1.0f;

    private Material[] skyboxes;
    private float[] durations;
    private int currentSkyboxIndex = 0;
    private float timer = 0f;

    private Coroutine skyboxTransitionCoroutine;
    private Coroutine rainFadeCoroutine;

    void Start()
    {
        // Initialize skyboxes and durations arrays
        skyboxes = new Material[] { earlyDaySkybox, middleDaySkybox, hurricaneMildSkybox, hurricaneHeavySkybox, clearSkybox, nightSkybox };
        durations = new float[] { earlyDayDuration, middleDayDuration, hurricaneMildDuration, hurricaneHeavyDuration, clearSkyDuration, nightDuration };

        // Check for unassigned skyboxes or audio/particle components
        if (!CheckAssignments()) return;

        // Set initial skybox and start the cycle timer
        RenderSettings.skybox = skyboxes[currentSkyboxIndex];
        timer = durations[currentSkyboxIndex];
    }

    void Update()
    {
        // Rotate the skybox slowly for VR comfort
        if (RenderSettings.skybox != null)
            RenderSettings.skybox.SetFloat("_Rotation", Time.time * skyboxRotationSpeed);

        // Decrement timer for current skybox phase
        timer -= Time.deltaTime;

        // When timer runs out, transition to the next skybox
        if (timer <= 0)
        {
            int nextSkyboxIndex = (currentSkyboxIndex + 1) % skyboxes.Length;
            timer = durations[nextSkyboxIndex];

            // Start smooth transition between skyboxes if both are assigned
            if (skyboxes[currentSkyboxIndex] != null && skyboxes[nextSkyboxIndex] != null)
            {
                if (skyboxTransitionCoroutine != null)
                {
                    StopCoroutine(skyboxTransitionCoroutine);
                }
                skyboxTransitionCoroutine = StartCoroutine(FadeOutAndInSkybox(skyboxes[currentSkyboxIndex], skyboxes[nextSkyboxIndex]));
            }

            // Update rain and wind effects based on the next skybox
            ManageWeatherEffects(nextSkyboxIndex);

            // Update the current skybox index
            currentSkyboxIndex = nextSkyboxIndex;
        }
    }

    // Coroutine to smoothly fade out the current skybox and then fade in the next
    IEnumerator FadeOutAndInSkybox(Material currentSkybox, Material nextSkybox)
    {
        float halfTransitionDuration = transitionDuration / 2f;
        float elapsedTime = 0f;

        // Fade out current skybox
        while (elapsedTime < halfTransitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float blend = Mathf.Clamp01(1 - (elapsedTime / halfTransitionDuration));
            if (RenderSettings.skybox != null)
                RenderSettings.skybox.Lerp(currentSkybox, nextSkybox, blend);
            yield return null;
        }

        RenderSettings.skybox = null; // Ensure full fade-out

        // Reset elapsed time for fade-in
        elapsedTime = 0f;

        // Fade in next skybox
        while (elapsedTime < halfTransitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float blend = Mathf.Clamp01(elapsedTime / halfTransitionDuration);
            if (RenderSettings.skybox != null)
                RenderSettings.skybox.Lerp(currentSkybox, nextSkybox, blend);
            yield return null;
        }

        RenderSettings.skybox = nextSkybox; // Set final skybox
    }

    // Manage rain and wind effects based on the current skybox phase
    void ManageWeatherEffects(int skyboxIndex)
    {
        if (skyboxes[skyboxIndex] == hurricaneMildSkybox)
        {
            StartRain(false);
        }
        else if (skyboxes[skyboxIndex] == hurricaneHeavySkybox)
        {
            StartRain(true);
            SetSoundVolume(heavyRainVolume, heavyWindVolume);
        }
        else if (skyboxes[skyboxIndex] == clearSkybox)
        {
            // Fade out rain gradually when transitioning to clear sky
            StopRainAndSoundsGradually();
        }
        else
        {
            // Stop rain immediately for other skyboxes without fade-out
            StopRainImmediately();
        }
    }

    // Start rain effect based on hurricane intensity
    void StartRain(bool heavyRain)
    {
        if (rainEffect != null)
        {
            var emission = rainEffect.emission;
            var main = rainEffect.main;

            if (heavyRain)
            {
                emission.rateOverTime = heavyRainParticles;
                main.startSpeed = heavyRainStartSpeed;
                main.startLifetime = heavyRainLifetime;
                if (windSound != null && !windSound.isPlaying)
                {
                    windSound.Play();
                }
            }
            else
            {
                emission.rateOverTime = mildRainParticles;
                main.startSpeed = mildRainStartSpeed;
                main.startLifetime = mildRainLifetime;
            }

            rainEffect.Play();

            if (rainSound != null && !rainSound.isPlaying)
            {
                rainSound.Play();
            }
        }
    }

    // Gradually stop rain and sounds when transitioning to clear sky
    void StopRainAndSoundsGradually()
    {
        if (rainFadeCoroutine != null)
        {
            StopCoroutine(rainFadeCoroutine);
        }
        rainFadeCoroutine = StartCoroutine(FadeOutRainAndSounds());
    }

    // Immediately stop rain and sounds for other skybox transitions
    void StopRainImmediately()
    {
        if (rainEffect != null)
        {
            rainEffect.Stop();
        }

        if (rainSound != null && rainSound.isPlaying)
        {
            rainSound.Stop();
        }

        if (windSound != null && windSound.isPlaying)
        {
            windSound.Stop();
        }
    }

    IEnumerator FadeOutRainAndSounds()
    {
        if (rainEffect != null)
        {
            var emission = rainEffect.emission;
            float initialRate = emission.rateOverTime.constant;
            float fadeDuration = 5f;
            float elapsed = 0f;

            while (elapsed < fadeDuration)
            {
                emission.rateOverTime = Mathf.Lerp(initialRate, 0, elapsed / fadeDuration);
                elapsed += Time.deltaTime;
                yield return null;
            }

            emission.rateOverTime = 0;
            rainEffect.Stop();
        }

        if (rainSound != null && rainSound.isPlaying)
        {
            StartCoroutine(FadeOutSound(rainSound));
        }

        if (windSound != null && windSound.isPlaying)
        {
            StartCoroutine(FadeOutSound(windSound));
        }
    }

    IEnumerator FadeOutSound(AudioSource audioSource)
    {
        float initialVolume = audioSource.volume;
        float fadeDuration = 5f;
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            audioSource.volume = Mathf.Lerp(initialVolume, 0, elapsed / fadeDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        audioSource.volume = 0;
        audioSource.Stop();
    }

    void SetSoundVolume(float rainVolume, float windVolume)
    {
        if (rainSound != null) rainSound.volume = rainVolume;
        if (windSound != null) windSound.volume = windVolume;
    }

    // Check if all necessary components are assigned
    bool CheckAssignments()
    {
        bool allAssigned = true;

        if (earlyDaySkybox == null) { UnityEngine.Debug.LogError("earlyDaySkybox is not assigned."); allAssigned = false; }
        if (middleDaySkybox == null) { UnityEngine.Debug.LogError("middleDaySkybox is not assigned."); allAssigned = false; }
        if (hurricaneMildSkybox == null) { UnityEngine.Debug.LogError("hurricaneMildSkybox is not assigned."); allAssigned = false; }
        if (hurricaneHeavySkybox == null) { UnityEngine.Debug.LogError("hurricaneHeavySkybox is not assigned."); allAssigned = false; }
        if (clearSkybox == null) { UnityEngine.Debug.LogError("clearSkybox is not assigned."); allAssigned = false; }
        if (nightSkybox == null) { UnityEngine.Debug.LogError("nightSkybox is not assigned."); allAssigned = false; }
        if (rainEffect == null) { UnityEngine.Debug.LogError("RainEffect ParticleSystem is not assigned."); allAssigned = false; }
        if (rainSound == null) { UnityEngine.Debug.LogError("RainSound AudioSource is not assigned."); allAssigned = false; }
        if (windSound == null) { UnityEngine.Debug.LogError("WindSound AudioSource is not assigned."); allAssigned = false; }

        return allAssigned;
    }
}
