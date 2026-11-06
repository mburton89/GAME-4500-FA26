using UnityEngine;

public class PowerUpButton : MonoBehaviour
{
    public enum PowerUpType
    {
        SpeedBoost,
        JumpBoost,
        Invincibility
    }

    [Header("Power-Up Settings")]
    public PowerUpType powerUpType;
    public float duration = 20f;

    // Reference to the player (assign in inspector or find at runtime)
    public FPSController player;   // Change this to whatever your player script is called

    public void ActivatePowerUp()
    {
        if (player == null)
        {
            Debug.LogWarning("Player reference is missing!");
            return;
        }

        switch (powerUpType)
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

        Debug.Log($"Activated {powerUpType} for {duration} seconds");

        gameObject.SetActive(false);
        GameManager.Instance.ResumeGame();
    }
}