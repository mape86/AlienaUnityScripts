
using UnityEngine;

public class PlayerEnergyLevel : MonoBehaviour
{

    public float maxEnergyLevel = 100f;
    public float currentEnergyLevel;
    public EnergyBar energyBar;
    public GameObject PowerOutUI;


    void Start()
    {
        currentEnergyLevel = maxEnergyLevel;
        energyBar.SetMaxEnergy(maxEnergyLevel);
        //Drains 1% energy every 10 seconds. 
        InvokeRepeating("DrainEnergy", 1f, 10f);
        PowerOutUI.SetActive(false);
    }


    public void LoseEnergy(float energyLost)
    {
        currentEnergyLevel -= energyLost;
        energyBar.SetEnergy(currentEnergyLevel);

        if (currentEnergyLevel <= 0)
        {
            PowerOutUI.SetActive(true);

            Time.timeScale = 0;
            AudioListener.pause = true;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }

    }

    void DrainEnergy()
    {
        LoseEnergy(1);
    }

    public void GainEnergy(float energyGained)
    {
        currentEnergyLevel += energyGained;

        if (currentEnergyLevel > maxEnergyLevel)
        {
            currentEnergyLevel = maxEnergyLevel;
        }
        energyBar.SetEnergy(currentEnergyLevel);
    }
}
