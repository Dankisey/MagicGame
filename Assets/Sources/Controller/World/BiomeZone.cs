using UnityEngine;

namespace Game.Controller
{
    public class BiomeZone : MonoBehaviour
    {
        [SerializeField] private Biome _biome;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<PlayerBiomeHandler>(out PlayerBiomeHandler biomeHandler))
                biomeHandler.EnterNewBiome(_biome);
        }
    }
}