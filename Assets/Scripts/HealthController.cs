using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{

    public float hp = 50f;
    public float maxHealth = 100f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public float ToPercentage()
    {
        return hp / maxHealth;
    }

    public void Damage(float amount)
    {
        hp -= amount;
    }
}
