
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fillColor;


    //Sets the max EnergyLevel for the energyBar. 
    public void SetMaxEnergy(float maxEnergy)
    {
        slider.maxValue = maxEnergy;
        slider.value = maxEnergy;
        //The fillColor of the slider is set to the color furthest to the right in the gradient. 
        fillColor.color = gradient.Evaluate(1f);
    }

    //Allows the user to set the energy level of the energyBar. 
    public void SetEnergy(float energy)
    {
        slider.value = energy;
        //Sets the fillColor of the energyBar to the gradients coresponding color. 
        fillColor.color = gradient.Evaluate(slider.normalizedValue);
    }
}
