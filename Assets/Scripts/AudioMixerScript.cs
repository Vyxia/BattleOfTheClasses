using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class AudioMixerScript : MonoBehaviour {

	public AudioMixer MasterMixer;

	public void SetALevel(float ALevel)
	{
		MasterMixer.SetFloat("GroupAVol", ALevel);
	}

	public void SetBLevel(float BLevel)
	{
		MasterMixer.SetFloat("GroupBVol", BLevel);
	}

	public void SetCLevel(float CLevel)
	{
		MasterMixer.SetFloat("GroupCVol", CLevel);
	}

	public void SetDLevel(float DLevel)
	{
		MasterMixer.SetFloat("GroupDVol", DLevel);
	}

	public void SetMasterLevel(float MasterLevel)
	{
		MasterMixer.SetFloat("MasterVol", MasterLevel);
	}
}
