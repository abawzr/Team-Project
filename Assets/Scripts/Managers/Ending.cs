using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    [SerializeField] private Animator ending1Animator;
    [SerializeField] private Animator ending2Animator;
    [SerializeField] private AudioClip musicClip;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private IEnumerator Ending1Timer()
    {
        PlayerCamera.IsCameraInputOn = false;
        PlayerMovement.IsMovementInputOn = false;
        PauseManager.CanPause = false;
        Enemy.CanMove = false;

        ending1Animator.SetTrigger("TriggerEnding");
        _audioSource.PlayOneShot(musicClip);

        yield return new WaitForSeconds(musicClip.length);

        SceneManager.LoadSceneAsync("MainMenuScene");
    }

    private IEnumerator Ending2Timer()
    {
        PlayerCamera.IsCameraInputOn = false;
        PlayerMovement.IsMovementInputOn = false;
        PauseManager.CanPause = false;
        Enemy.CanMove = false;

        ending2Animator.SetTrigger("TriggerEnding");
        _audioSource.PlayOneShot(musicClip);

        yield return new WaitForSeconds(musicClip.length);

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
