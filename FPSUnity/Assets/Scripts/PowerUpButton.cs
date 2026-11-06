using UnityEngine;
using UnityEngine.UI;

public class PowerUpButton : MonoBehaviour
{
    public enum PowerUPType
    {
        SpeedBoost,
        JumpBoost,
        Invicibility
    }

    public PowerUPType assignedPowerUp;
    public float duration;
    public FPSController player;

    public void ActivatePowerUp()
    {
        switch(assignedPowerUp)
        {
            case PowerUPType.SpeedBoost:
                player.ActivateSpeedBoost(duration);
                break;
            case PowerUPType.JumpBoost:
                //to do
                break;
            case PowerUPType.Invicibility:
                //to do
                break;

        }

        GetComponent<Button>().interactable = false;

        GameManager.Instance.ResumeGame();
    }
}
