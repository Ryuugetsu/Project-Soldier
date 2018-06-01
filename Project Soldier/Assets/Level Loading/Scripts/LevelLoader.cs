using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {
    
    public Image _loadingImage;
    public Text _percent;
    public int _sceneIndex;

    public void LoadLevel()
    {
        StartCoroutine(LoadAsynchronously());
    }

    IEnumerator LoadAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(_sceneIndex);
        

        while (!operation.isDone)
        {
            

            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            _loadingImage.fillAmount = progress;
            _percent.text = Mathf.Round(progress * 100f) + " %";
            yield return null;
        }        
    }

}
