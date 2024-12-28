using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioShoot;
    [SerializeField] private AudioSource _audioReload;



    [SerializeField] private Animator gunAim;
    [SerializeField] private Transform gun;
    [SerializeField] private float gunDistance = 1.5f;

    private bool gunFacingRight = true;

    [Header("Bullet")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    public int currentBullet;
    public int maxBullet = 15;

    private void Start()
    {
        ReloadGun();
    }


    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        

        gun.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x)
            * Mathf.Rad2Deg));



        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gun.position = transform.position + Quaternion.Euler(0, 0, angle) * new Vector3(gunDistance, 0, 0);


        if (Input.GetKeyDown(KeyCode.Mouse0)&& HaveBullets())//gun shoots at click
            Shoot(direction);

        if (Input.GetKeyDown(KeyCode.R))//reloads gun
            ReloadGun();

        GunFlipController(mousePos);//flips gun

    }

    private void GunFlipController(Vector3 mousePos)//gun is never upside down
    {
        if (mousePos.x < gun.position.x && gunFacingRight)
            GunFlip();
        else if (mousePos.x > gun.position.x && !gunFacingRight)
            GunFlip();
    }

    private void GunFlip()
    {
        gunFacingRight = !gunFacingRight;
        gun.localScale = new Vector3(gun.localScale.x, gun.localScale.y * -1, gun.localScale.z);
    }

    public void Shoot(Vector3 direction)
    {
        

        gunAim.SetTrigger("Shoot");

        _audioShoot.Play();


        direction.z = 0;//fix normalizeing 
        GameObject newBullet = Instantiate(bulletPrefab, gun.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = direction.normalized  * bulletSpeed;

        Destroy(newBullet, 7);
    }


    private void ReloadGun()
    {
        currentBullet = maxBullet;
        _audioReload.Play();
    }

    public bool HaveBullets()
    {
        if(currentBullet <= 0) return false;

        currentBullet--;
        return true;
    }
   



}
