using UnityEngine;

public class Coin : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enabled && collision.gameObject.CompareTag("Player"))
        {
            var renderer = GetComponent<Renderer>();
            renderer.enabled = false;

            var audio = GetComponent<AudioSource>();

            Invoke("DestroyMe", audio.clip.length);
            audio.Play();
            enabled = false;
        }
    }

    private void DestroyMe()
    {
        Destroy(gameObject);
    }
}
