using UnityEngine;

public class raycastWeapon : MonoBehaviour
{
    public bool isFiring = false;
    public int fireRate = 25;
    public ParticleSystem[] muzzleFlash;
    public ParticleSystem hitEffect;
    public Transform raycastOrigin;
    public Transform raycastDestination;
    public TrailRenderer tracerEffect;
    public AudioClip Gun;
    public AudioSource aud;

    Ray ray;
    RaycastHit hitInfo;
    private void Awake()
    {
        aud = GetComponent<AudioSource>();
    }
    public void StartFiring()
    {
        isFiring = true;
        FireBullet();

    }

    private void FireBullet()
    {
        foreach (var partical in muzzleFlash)
        {
            partical.Emit(5);
        }
        aud.PlayOneShot(Gun, 1f);

        ray.origin = raycastOrigin.position;
        ray.direction = raycastDestination.position - raycastOrigin.position;

        var tracer = Instantiate(tracerEffect, ray.origin, Quaternion.identity);
        tracer.AddPosition(ray.origin);


        if (Physics.Raycast(ray, out hitInfo))
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 1.0f);
            hitEffect.transform.position = hitInfo.point;
            hitEffect.transform.forward = hitInfo.normal;
            hitEffect.Emit(1);

            tracer.transform.position = hitInfo.point;
        }
    }

    public void StopFiring()
    {
        isFiring = false;

    }
}
