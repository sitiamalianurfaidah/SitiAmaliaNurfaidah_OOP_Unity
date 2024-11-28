using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI waveText; // Referensi ke UI Text untuk nomor wave
    public TMPro.TextMeshProUGUI enemiesLeftText; // Referensi ke UI Text untuk musuh yang tersisa
    public CombatManager combatManager;

    void Update()
    {
        waveText.text = "Wave: " + combatManager.waveNumber; // Memperbarui UI wave
        enemiesLeftText.text = "Enemies Left: " + combatManager.totalEnemies; // Memperbarui UI musuh yang tersisa
    }
}
