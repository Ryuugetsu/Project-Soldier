using UnityEngine;
using System.Collections;

public class Torchelight : MonoBehaviour {
	
	public Light TorchLight;	
	public float MaxLightIntensity;
	public float IntensityLight;
	

	void Start () {
		TorchLight.GetComponent<Light>().intensity=IntensityLight;        
	}
	

	void Update () {
		if (IntensityLight<0) IntensityLight=0;
		if (IntensityLight>MaxLightIntensity) IntensityLight=MaxLightIntensity;		

		TorchLight.intensity=IntensityLight/2f+Mathf.Lerp(IntensityLight+5f,IntensityLight+6f,Mathf.Cos(Time.deltaTime*30));		
	}
}
