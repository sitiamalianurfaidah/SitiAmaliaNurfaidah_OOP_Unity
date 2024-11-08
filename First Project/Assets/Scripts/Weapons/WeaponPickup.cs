using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private Weapon weaponHolder;  // objek weapon yang menerima weapon secara serialized
    private Weapon weapon;  // objek weapon yang diinisialisasi dari weaponHolder
    public Transform parentTransform;
    private static Weapon newWeapon;

    private void Awake()
    {
        // Inisialisasi weapon dengan referensi dari weaponHolder
        weapon = weaponHolder;
    }

    private void Start()
    {
        // Nonaktifkan visual weapon jika weapon tidak null
        if (weapon != null)
        {
            TurnVisual(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Memeriksa apakah objek yang bertabrakan memiliki tag "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player berhasil mengambil senjata!");

            // Cek apakah Player sudah memiliki senjata dan ganti jika ada senjata baru
            if (newWeapon != null)
            {
                newWeapon.gameObject.SetActive(false);
            }
            weapon.transform.SetParent(other.transform);
            weapon.transform.position = other.transform.position;

            newWeapon = weapon;
            TurnVisual(true, weapon);
        }
    }

    // Method untuk mengaktifkan/nonaktifkan visual weapon
    private void TurnVisual(bool on)
    {
        if (weapon != null)
        {
            weapon.gameObject.SetActive(on);
            Debug.Log("Weapon visual set to: " + on);
        }
    }

    // Overload method TurnVisual untuk polymorphism
    private void TurnVisual(bool on, Weapon weapon)
    {
        weapon.gameObject.SetActive(on);
    }
}
