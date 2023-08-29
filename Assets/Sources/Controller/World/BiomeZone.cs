using UnityEngine;

namespace Game.Controller
{
    public class BiomeZone : MonoBehaviour
    {
        [SerializeField] private Biome _biome;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<PlayerBiomeHandler>(out PlayerBiomeHandler biomeHandler))
            {
                biomeHandler.EnterNewBiome(_biome);
                Debug.Log("Entered");
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<PlayerBiomeHandler>(out PlayerBiomeHandler biomeHandler))
            {
                biomeHandler.ExitBiome();
                Debug.Log("Exited");
            }
        }
    }
}