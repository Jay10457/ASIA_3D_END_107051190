using UnityEngine;

public class raycastWeapon : MonoBehaviour
{
    class Bullet
    {
        public float time;
        public Vector3 initialPosition;
        public Vector3 initialVelocity;
    }
    //public int fireRate = 500;//for Rifle
    public bool isFiring = false;
    public float bulletSpeed = 1000.0f;
    public float bulletDrop = 0.0f;
    public float range = 200f;
    public float damage = 100f;
    public ParticleSystem[] muzzleFlash;
    public ParticleSystem hitEffect;
    public Transform raycastOrigin;
    public Transform raycastDestination;
    public TrailRenderer tracerEffect;
    public AudioClip Gun;
    public AudioSource aud;

    Ray ray;
    RaycastHit hitInfo;
    float accumulatedTime;
    
    private void Awake()
    {
        aud = GetComponent<AudioSource>();
    }
    public void StartFiring()
    {
        isFiring = true;
        accumulatedTime = 0.0f;
        FireBullet();

    }
    /*
     *<For Rifle>
    public void UpdateFiring(float deltaTime)
    {
        accumulatedTime += deltaTime;
        float fireInterval = 1.0f / fireRate;
        while (accumulatedTime >= 0.0f)
        {
            FireBullet();
            accumulatedTime -= fireInterval;
        }
    }
    */

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


        if (Physics.Raycast(ray, out hitInfo, range))
        {
            if (hitInfo.transform.tag != "player" && hitInfo.transform.tag != "enermy")
            {
                //Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 1.0f);
                hitEffect.transform.position = hitInfo.point;
                hitEffect.transform.forward = hitInfo.normal;
                hitEffect.Emit(1);
                
                tracer.transform.position = hitInfo.point;
            }
           
        }
        else
        {
            
        }
        target _target = hitInfo.transform.GetComponent<target>();
        if (_target != null)
        {
            _target.TakeDamage(damage);
        }
    }

    public void StopFiring()
    {
        isFiring = false;

    }
}
