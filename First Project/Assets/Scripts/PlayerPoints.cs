using UnityEngine;
using UnityEngine.UI;

public class PlayerPoints : MonoBehaviour
{
    public TMPro.TextMeshProUGUI pointsText; // Referensi ke UI Text untuk poin
    private int points;

    public void AddPoints(int amount)
    {
        points += amount;
    }

    void Update()
    {
        pointsText.text = "Points: " + points; // Memperbarui UI poin
    }
}
