using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarController : MonoBehaviour
{

    [SerializeField] private Slider sliderComponent;
    [SerializeField] private HealthController playerHealthController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sliderComponent.value = playerHealthController.ToPercentage();  
    }
}
