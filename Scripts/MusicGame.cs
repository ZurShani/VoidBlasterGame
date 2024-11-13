
using UnityEngine.SceneManagement;
using UnityEngine;

public class MusicGame : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        
        if (FindObjectsOfType<MusicGame>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);  
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)  
        {
            audioSource.Stop();
        }
        else if (scene.buildIndex == 1 && !audioSource.isPlaying)  
        {
            audioSource.Play();
        }
    }
}
