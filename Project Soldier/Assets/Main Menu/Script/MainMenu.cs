using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;    
    public GameObject loaderScreen;
    private LevelLoader _levelLoader;
    private Resolution[] _resolutions;
    

    private void Start()
    {
        GetUnityResolutions();
    }


    public void PlayGame()
    {
        //envia para a proxima scene de acordo com a ordem na lista de build
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        loaderScreen.SetActive(true);
        _levelLoader = loaderScreen.GetComponent<LevelLoader>();
        _levelLoader.LoadLevel();
    }

    public void QuitGame()
    {
        //fecha o jogo
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        //alteração do volume do jogo
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        //troca entre os niveis de qualidades
        QualitySettings.SetQualityLevel(qualityIndex);        
    }

    private void GetUnityResolutions()
    {
        //pegar todas as resoluções disponiveis
        _resolutions = Screen.resolutions;
        //limpar as opções atuais do dropdown
        resolutionDropdown.ClearOptions();

        //criar lista para popular o dropdown
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        //varrer o vetor com as resoluções e popular lista com as mesmas
        for (int i = 0; i < _resolutions.Length; i++)
        {
            string option = _resolutions[i].width + "X" + _resolutions[i].height;
            options.Add(option);

            //armazena a atual posição da lista que equivale a resolução do monitos do usuario
            if (_resolutions[i].width == Screen.currentResolution.width && _resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        //popular dropdown com as resoluções já armazenadas na lista options
        resolutionDropdown.AddOptions(options);
        //seta a resolução do monitor como a padrão do dropdown
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolutions(int resolutionIndex)
    {
        //armazena a resolução selecionada do vetor com todas as resoluções com base no index recebido
        Resolution resolution = _resolutions[resolutionIndex];
        //seta a resolução e o full screen
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        //full screen
        Screen.fullScreen = isFullscreen;
    }           
}
