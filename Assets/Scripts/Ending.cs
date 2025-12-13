using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    [SerializeField] private Animator endingAnimator;
    [SerializeField] private AudioClip musicClip;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private IEnumerator EndingTimer()
    {
        PlayerCamera.IsCameraInputOn = false;
        PlayerMovement.IsMovementInputOn = false;
        PauseManager.CanPause = false;
        Enemy.CanMove = false;

        endingAnimator.SetTrigger("TriggerEnding");
        _audioSource.PlayOneShot(musicClip);

        yield return new WaitForSeconds(musicClip.length);

        SceneManager.LoadSceneAsync("MainMenuScene");
    }

    public void TriggerEnding1()
    {
        StartCoroutine(EndingTimer());
    }
}
