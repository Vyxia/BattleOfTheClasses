using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadLevels : MonoBehaviour {
	
	public Button StartM;
	
	// Use this for initialization
	void Start () 
	{
		StartM = StartM.GetComponent<Button> ();
	}
	
	public void StartCredits()
	{
		Application.LoadLevel ("_credits");
	}

	public void StartScenes()
	{
		Application.LoadLevel("_scenes");
	}

	public void StartMenu()
	{
		Application.LoadLevel ("_main");
	}

	public void StartLOD()
	{
		Application.LoadLevel ("");
	}
	
	public void StartParticle()
	{
		Application.LoadLevel("");
	}
	
	public void StartShaders()
	{
		Application.LoadLevel ("");
	}

	public void StartAudio()
	{
		Application.LoadLevel ("");
	}
	
	public void StartJoints()
	{
		Application.LoadLevel("");
	}
	
	public void StartTerrain()
	{
		Application.LoadLevel ("");
	}
	public void StartPreProccesing()
	{
		Application.LoadLevel ("");
	}
	
	public void StartPhysics()
	{
		Application.LoadLevel("");
	}
	
	public void StartCamera()
	{
		Application.LoadLevel ("");
	}
	
}