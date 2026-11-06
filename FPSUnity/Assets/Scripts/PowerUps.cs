using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{
    public enum PowerUpType
    {
        SpeedBoost,
        Shield,
        Shotgun
    }

    public PowerUpType assignedPowerUp;
    public float duration;
    public FPSController player;

    public void ActivatePowerUp()
    {
        switch (assignedPowerUp)
        {
            case PowerUpType.SpeedBoost:
                player.ActivateSpeedBoost(duration);
                break;

            case PowerUpType.Shield:
                //TODO
                break;

            case PowerUpType.Shotgun:
                //TODO
                break;
        }

        GetComponent<Button>().interactable = false;

        GameManager.Instance.ResumeGame();
    }

}