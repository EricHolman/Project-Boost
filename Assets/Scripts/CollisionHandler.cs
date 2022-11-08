using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("You ran into a friendly");
                break;
            case "Finish":
                Debug.Log("You ran into the finish pad");
                break;
            case "Fuel":
                Debug.Log("You ran into fuel");
                break;
            default:
                ReloadLevel();
                break;

        }

    }


    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }


}
