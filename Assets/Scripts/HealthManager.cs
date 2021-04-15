using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDHealthManager : MonoBehaviour
{
	
	public float health;
	public float maxHealth;
	public float minHealth;
	public Image healthbar;
	public TextMeshProUGUI number;



    void Start()
    {
        health = maxHealth;
		minHealth = 0;
		healthbar.fillAmount = 1;
    }

    void Update()
    {
		if(Input.GetKeyDown("space"))
		{
			health = health - 10;
			
			// makes sure health doesnt go below 0
			
			if(health < minHealth)
			{
				health = minHealth;
			}
			
			
			float fraction = health / maxHealth;
			healthbar.fillAmount = fraction;
		}
		
		if(Input.GetKeyDown("n"))
		{
			health = health + 10;
			
			// makes sure health doesnt go above 100
			if(health > maxHealth)
			{
				health = maxHealth;
			}
			
			
			float fraction = health / maxHealth;
			healthbar.fillAmount = fraction;
		}
		
		//health = Mathf.Clamp(health, 0, maxHealth);
		number.text = string.Format("{0}/{1}", health, maxHealth);
        //number.text = health + "/" + maxHealth;

    }
}
