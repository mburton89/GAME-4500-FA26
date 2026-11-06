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



    public PowerUpType assignedPowerUp;
    public float duration;
    public FPSController player;


    public void ActivatePowerUp()
    {

        switch(assignedPowerUp)
        {

            case PowerUpType.SpeedBoost:
                player.ActivateSpeedBoost(duration);
                break;
            

            case PowerUpType.JumpBoost:
                //TODO
                break;

            case PowerUpType.Invincibility:
                //TODO
                break;







        }

        GetComponent<Button>().interactable = false;
        
        GameManager.Instance.ResumeGame();
    }

}
