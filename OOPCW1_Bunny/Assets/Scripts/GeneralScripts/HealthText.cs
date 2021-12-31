using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    private HealthLogic Health;
    public Text healthText;
 
    void Start()
    {
        Health = gameObject.GetComponent<HealthLogic>();
    }

    void Update()
    {
        healthText.text = Health.CurrentHealth.ToString();

        if (Health.CurrentHealth >= 50)
        {
            healthText.GetComponent<Text>().color = Color.green;
        }

        if (Health.CurrentHealth <= 50)
        {
            healthText.GetComponent<Text>().color = Color.yellow;
        }

        if (Health.CurrentHealth <= 30)
        {
            healthText.GetComponent<Text>().color = Color.red;
        }
    }
}
