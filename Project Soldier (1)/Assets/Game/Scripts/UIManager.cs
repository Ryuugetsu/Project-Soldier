using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text _life;

    public void UpdateLifes(int currentLife)
    {
        _life.text = LocalizationManager.instance.GetLocalizedValue("life_text")+ " " + currentLife;
    }
}
