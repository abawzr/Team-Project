using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    [SerializeField] private Animator endingAnimator;
    [SerializeField] private AudioClip musicClip;
    [SerializeField] private AudioSource ambientAudioSource1;
    [SerializeField] private AudioSource ambientAudioSource2;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private IEnumerator Ending1Timer()
    {
        PlayerCamera.IsCameraInputOn = false;
        PlayerMovement.IsMovementInputOn = false;
        PlayerInteraction.CanInteract = false;
        PauseManager.CanPause = false;
        Enemy.CanMove = false;

        ambientAudioSource1.Stop();
        ambientAudioSource2.Stop();

        endingAnimator.SetTrigger("TriggerEnding1");
        _audioSource.PlayOneShot(musicClip);

        yield return new WaitForSeconds(musicClip.length + 2f);

        SceneManager.LoadSceneAsync("MainMenuScene");
    }

    private IEnumerator Ending2Timer()
    {
        PlayerCamera.IsCameraInputOn = false;
        PlayerMovement.IsMovementInputOn = false;
        PlayerInteraction.CanInteract = false;
        PauseManager.CanPause = false;
        Enemy.CanMove = false;

        ambientAudioSource1.Stop();
        ambientAudioSource2.Stop();

        endingAnimator.SetTrigger("TriggerEnding2");
        _audioSource.PlayOneShot(musicClip);

        yield return new WaitForSeconds(musicClip.length + 2f);

        SceneManager.LoadSceneAsync("MainMenuScene");
    }

    public void TriggerEnding1()
    {
        StartCoroutine(Ending1Timer());
    }

    public void TriggerEnding2()
    {
        StartCoroutine(Ending2Timer());
    }
}
