﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog
{

    public string[] names;
    public string[] sentences;
    public string selectDialog;

    public void LoadDialogs()
    {
        switch (selectDialog)
        {
            case "InitialDialog":

                names = new string[12];
                sentences = new string[12];

                names[0] = LocalizationManager.instance.GetLocalizedValue("sacerdotisa");
                sentences[0] = LocalizationManager.instance.GetLocalizedValue("Dialogo_01");

                names[1] = LocalizationManager.instance.GetLocalizedValue("soldado");
                sentences[1] = LocalizationManager.instance.GetLocalizedValue("Dialogo_02");

                names[2] = LocalizationManager.instance.GetLocalizedValue("soldado");
                sentences[2] = LocalizationManager.instance.GetLocalizedValue("Dialogo_03");

                names[3] = LocalizationManager.instance.GetLocalizedValue("sacerdotisa");
                sentences[3] = LocalizationManager.instance.GetLocalizedValue("Dialogo_04");

                names[4] = LocalizationManager.instance.GetLocalizedValue("soldado");
                sentences[4] = LocalizationManager.instance.GetLocalizedValue("Dialogo_05");

                names[5] = LocalizationManager.instance.GetLocalizedValue("sacerdotisa");
                sentences[5] = LocalizationManager.instance.GetLocalizedValue("Dialogo_06");

                names[6] = LocalizationManager.instance.GetLocalizedValue("soldado");
                sentences[6] = LocalizationManager.instance.GetLocalizedValue("Dialogo_07");

                names[7] = LocalizationManager.instance.GetLocalizedValue("sacerdotisa");
                sentences[7] = LocalizationManager.instance.GetLocalizedValue("Dialogo_08");

                names[8] = LocalizationManager.instance.GetLocalizedValue("soldado");
                sentences[8] = LocalizationManager.instance.GetLocalizedValue("Dialogo_09");

                names[9] = LocalizationManager.instance.GetLocalizedValue("sacerdotisa");
                sentences[9] = LocalizationManager.instance.GetLocalizedValue("Dialogo_10");

                names[10] = LocalizationManager.instance.GetLocalizedValue("soldado");
                sentences[10] = LocalizationManager.instance.GetLocalizedValue("Dialogo_11");

                names[11] = LocalizationManager.instance.GetLocalizedValue("sacerdotisa");
                sentences[11] = LocalizationManager.instance.GetLocalizedValue("Dialogo_12");

                break;

            case "dialogo 2":

                names = new string[9];
                sentences = new string[9];

                names[0] = LocalizationManager.instance.GetLocalizedValue("soldado");
                sentences[0] = LocalizationManager.instance.GetLocalizedValue("Dialogo_13");

                names[1] = LocalizationManager.instance.GetLocalizedValue("sacerdotisa");
                sentences[1] = LocalizationManager.instance.GetLocalizedValue("Dialogo_14");

                names[2] = LocalizationManager.instance.GetLocalizedValue("soldado");
                sentences[2] = LocalizationManager.instance.GetLocalizedValue("Dialogo_15"); 
                
                names[3] = LocalizationManager.instance.GetLocalizedValue("sacerdotisa");
                sentences[3] = LocalizationManager.instance.GetLocalizedValue("Dialogo_16");
                
                names[4] = LocalizationManager.instance.GetLocalizedValue("soldado");
                sentences[4] = LocalizationManager.instance.GetLocalizedValue("Dialogo_17");
                
                names[5] = LocalizationManager.instance.GetLocalizedValue("sacerdotisa");
                sentences[5] = LocalizationManager.instance.GetLocalizedValue("Dialogo_18"); 
                
                names[6] = LocalizationManager.instance.GetLocalizedValue("soldado");
                sentences[6] = LocalizationManager.instance.GetLocalizedValue("Dialogo_19"); 
                
                names[7] = LocalizationManager.instance.GetLocalizedValue("sacerdotisa");
                sentences[7] = LocalizationManager.instance.GetLocalizedValue("Dialogo_20");

                names[8] = LocalizationManager.instance.GetLocalizedValue("soldado");
                sentences[8] = LocalizationManager.instance.GetLocalizedValue("Dialogo_21");

                break;

            case "dialogo 3":

                names = new string[7];
                sentences = new string[7];

                names[0] = LocalizationManager.instance.GetLocalizedValue("soldado");
                sentences[0] = LocalizationManager.instance.GetLocalizedValue("Dialogo_22");

                names[1] = LocalizationManager.instance.GetLocalizedValue("sacerdotisa");
                sentences[1] = LocalizationManager.instance.GetLocalizedValue("Dialogo_23");

                names[2] = LocalizationManager.instance.GetLocalizedValue("soldado");
                sentences[2] = LocalizationManager.instance.GetLocalizedValue("Dialogo_24");

                names[3] = LocalizationManager.instance.GetLocalizedValue("sacerdotisa");
                sentences[3] = LocalizationManager.instance.GetLocalizedValue("Dialogo_25");

                names[4] = LocalizationManager.instance.GetLocalizedValue("soldado");
                sentences[4] = LocalizationManager.instance.GetLocalizedValue("Dialogo_26");

                names[5] = LocalizationManager.instance.GetLocalizedValue("sacerdotisa");
                sentences[5] = LocalizationManager.instance.GetLocalizedValue("Dialogo_27");

                names[6] = LocalizationManager.instance.GetLocalizedValue("soldado");
                sentences[6] = LocalizationManager.instance.GetLocalizedValue("Dialogo_28");
                

                break;

            case "dialogo 4":             

                names = new string[4];
                sentences = new string[4];

                names[0] = LocalizationManager.instance.GetLocalizedValue("soldado");
                sentences[0] = LocalizationManager.instance.GetLocalizedValue("Dialogo_29");

                names[1] = LocalizationManager.instance.GetLocalizedValue("sacerdotisa");
                sentences[1] = LocalizationManager.instance.GetLocalizedValue("Dialogo_30");

                names[2] = LocalizationManager.instance.GetLocalizedValue("soldado");
                sentences[2] = LocalizationManager.instance.GetLocalizedValue("Dialogo_31");

                names[3] = LocalizationManager.instance.GetLocalizedValue("sacerdotisa");
                sentences[3] = LocalizationManager.instance.GetLocalizedValue("Dialogo_32");
               
                break;

           
        }
    }  
    
}
