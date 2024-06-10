using System.Collections;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private Collider2D platformCollider;
    public Collider2D detectionCollider;

    void Start()
    {
        platformCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        // Jika tombol bawah atau 'S' ditekan, aktifkan trigger pada collider jembatan
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine(DisableColliderTemporarily());
        }
    }

    private IEnumerator DisableColliderTemporarily()
    {
        platformCollider.enabled = false; // Nonaktifkan collider sementara
        yield return new WaitForSeconds(0.3f); // Tunggu beberapa saat (atur sesuai kebutuhan)
        platformCollider.enabled = true; // Aktifkan kembali collider
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && detectionCollider.IsTouching(other))
        {
            platformCollider.enabled = false; // Nonaktifkan collider saat pemain berada di bawah jembatan
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            platformCollider.enabled = true; // Aktifkan kembali collider saat pemain meninggalkan area
        }
    }
}
