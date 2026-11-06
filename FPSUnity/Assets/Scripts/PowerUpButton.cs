using UnityEngine;
using UnityEngine.UI;

public class PowerUpButton : MonoBehaviour
{
    public enum PowerUpType
    {
        SpeedBoost,
        JumpBoost,
        Invincibility
    }

    public PowerUpType assPowerUp;
    public float duration;
    public FPSController player;

    public void ActivatePowerUp()
    {
         switch (assPowerUp)
        {
            case PowerUpType.SpeedBoost:
                player.ActivateSpeedBoost(duration); 
                break;
            case PowerUpType.JumpBoost:
                //
                break;
            case PowerUpType.Invincibility:
                //
                break;
        }

        GetComponent<Button>().interactable = false;

        GameManager.instance.ResumeGame();
    }
}
