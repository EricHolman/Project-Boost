using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayForCrash = 1f;
    [SerializeField] float delayForNextLevel = 1f;
    [SerializeField] AudioClip finishSoundEffect;
    [SerializeField] AudioClip crashSoundEffect;

    AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void OnCollisionEnter(Collision other)
    {

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("You ran into a friendly");
                break;
            case "Finish":
                audioSource.PlayOneShot(finishSoundEffect);
                StartNextLevelSequence();
                break;
            default:
                audioSource.PlayOneShot(crashSoundEffect);
                StartCrashSequence();
                break;

        }

    }


    void StartCrashSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", delayForCrash);
    }

    void StartNextLevelSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", delayForNextLevel);
    }


    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }


}
