using UnityEngine;
using UnityEngine.UI; // Menambahkan ini untuk mengakses elemen UI

public class HealthUI : MonoBehaviour
{
    // Referensi ke komponen Text untuk menampilkan kesehatan
    public TMPro.TextMeshProUGUI healthText;

    public HealthComponent playerHealth; // Referensi ke HealthComponent pemain

    void Update()
    {
        healthText.text = "Health: " + playerHealth.GetHealth(); // Memperbarui UI kesehatan
    }
}
