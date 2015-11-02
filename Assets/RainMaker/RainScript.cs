using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RainScript : MonoBehaviour {

    public Camera Camera;
    public float RainIntensity;
    public ParticleSystem RainFallParticleSystem;
    public ParticleSystem RainExplosionParticleSystem;
    public ParticleSystem RainMistParticleSystem;
    public float RainHeight = 25.0f;
    public float RainForwardOffset = -7.0f;
    public WindZone WindZone;
	private Vector3 WindSpeedRange;
	private Vector2 WindChangeInterval;
    private Material rainMaterial;
    private Material rainExplosionMaterial;
    private Material rainMistMaterial;
    private float nextWindTime;
    private float lastRainValue = -1.0f;
	private bool isRaining = true;
	private Image rainImage;
	private GameObject rainPrefab;

    void Start()
    {
		WindSpeedRange = new Vector3(50.0f, 500.0f, 500.0f);
		WindChangeInterval = new Vector2(5.0f, 30.0f);
		rainPrefab = GameObject.Find ("Button Rain");
		rainImage = rainPrefab.GetComponent<Image>();
		rainImage.color = new Color (0,255,0);
        if (Camera == null)
        {
            Camera = Camera.main;
        }
        if (RainFallParticleSystem != null)
        {
            RainFallParticleSystem.enableEmission = false;
            Renderer rainRenderer = RainFallParticleSystem.GetComponent<Renderer>();
            rainRenderer.enabled = false;
            rainMaterial = new Material(rainRenderer.material);
            rainMaterial.EnableKeyword("SOFTPARTICLES_OFF");
            rainRenderer.material = rainMaterial;
        }
        if (RainExplosionParticleSystem != null)
        {
            Renderer rainRenderer = RainExplosionParticleSystem.GetComponent<Renderer>();
            rainExplosionMaterial = new Material(rainRenderer.material);
            rainExplosionMaterial.EnableKeyword("SOFTPARTICLES_OFF");
            rainRenderer.material = rainExplosionMaterial;
        }
        if (RainMistParticleSystem != null)
        {
            RainMistParticleSystem.enableEmission = false;
            Renderer rainRenderer = RainMistParticleSystem.GetComponent<Renderer>();
            rainRenderer.enabled = false;
            rainMistMaterial = new Material(rainRenderer.material);
			rainMistMaterial.EnableKeyword("SOFTPARTICLES_ON");
            rainRenderer.material = rainMistMaterial;
        }
    }

	private void UpdateWind()
	{
		if (WindZone != null && WindSpeedRange.y > 1.0f)
		{
			WindZone.transform.position = Camera.transform.position;
			WindZone.transform.Translate(0.0f, WindZone.radius, 0.0f);
			if (nextWindTime < Time.time)
			{
				WindZone.windMain = UnityEngine.Random.Range(WindSpeedRange.x, WindSpeedRange.y);
				WindZone.windTurbulence = UnityEngine.Random.Range(WindSpeedRange.x, WindSpeedRange.y);
				WindZone.transform.rotation = Quaternion.Euler(UnityEngine.Random.Range(-30.0f, 30.0f), UnityEngine.Random.Range(0.0f, 360.0f), 0.0f);
				nextWindTime = Time.time + UnityEngine.Random.Range(WindChangeInterval.x, WindChangeInterval.y);
			}
		}
	}
	
	public void rainToggle(){
		if (isRaining == true) {
			rainImage.color = new Color(255,0,0);
			RainIntensity = 0f;
			isRaining = false;
		} else{
			rainImage.color = new Color(0,255,0);
			RainIntensity = 1f;
			isRaining = true;
		}
	}
	
	private void CheckForRainChange()
	{
		if (lastRainValue != RainIntensity)
		{
			lastRainValue = RainIntensity;
			if (RainIntensity <= 0.01f)
			{
				if (RainFallParticleSystem != null)
				{
					RainFallParticleSystem.enableEmission = false;
				}
				if (RainMistParticleSystem != null)
				{
					RainMistParticleSystem.enableEmission = false;
				}
			}
			else
			{
				if (RainFallParticleSystem != null)
				{
					RainFallParticleSystem.enableEmission = RainFallParticleSystem.GetComponent<Renderer>().enabled = true;
					RainFallParticleSystem.emissionRate = (RainFallParticleSystem.maxParticles / RainFallParticleSystem.startLifetime) * RainIntensity;
				}
				if (RainMistParticleSystem != null)
				{
					RainMistParticleSystem.enableEmission = RainMistParticleSystem.GetComponent<Renderer>().enabled = true;
					float emissionRate;
					if (RainIntensity < 0.5f)
					{
						emissionRate = 0.0f;
					}
					else
					{
						// must have 0.5 or higher rain intensity to start seeing mist
						emissionRate = (RainMistParticleSystem.maxParticles / RainMistParticleSystem.startLifetime) * RainIntensity * RainIntensity;
					}
					RainMistParticleSystem.emissionRate = emissionRate;
				}
			}
		}
	}
	
	private void UpdateRain()
	{
		CheckForRainChange();
		
		// keep rain on top of the player
		if (RainFallParticleSystem != null)
		{
			RainFallParticleSystem.transform.position = Camera.transform.position;
			RainFallParticleSystem.transform.Translate(0.0f, RainHeight, RainForwardOffset);
			RainFallParticleSystem.transform.rotation = Quaternion.Euler(0.0f, Camera.transform.rotation.eulerAngles.y, 0.0f);
		}
		if (RainMistParticleSystem != null)
		{
			Vector3 pos = Camera.transform.position;
			pos.y = 3.0f;
			RainMistParticleSystem.transform.position = pos;
		}
	}
	
    void Update()
    {
		Debug.Log (RainIntensity);
        UpdateWind();
        UpdateRain();
    }
}