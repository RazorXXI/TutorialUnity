using UnityEngine;

//Este script de movimiento y salto, es para juegos 2D, no es valido
//para juegos 3D.
//Para el salto tenemos creado un archivo llamado CheckGround.cs
//el cual nos devuelve si el personaje esta tocando suelo o no

public class MovimientoSalto2D : MonoBehaviour
{
    [SerializeField] Rigidbody2D rbPlayer;
    //En caso de tener animaciones
    //[SerializeField] Animator anPlayer;
    [SerializeField] float speedPlayer;
    [SerializeField] float jumpForce;

    float movH;

    void Awake()
    {
        if (rbPlayer == null) rbPlayer = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoverPlayer();
        SaltarPlayer();
    }

    void FixedUpdate()
    {
        rbPlayer.velocity = new Vector2(movH * speedPlayer, rbPlayer.velocity.y);
    }

    void MoverPlayer()
    {
        movH = Input.GetAxisRaw("Horizontal");
        //Si tenemos animaciones, aqui vendria el animator de movimiento
        if(movH > 0 || movH < 0) transform.localScale = new Vector2(movH, 1);
    }

    void SaltarPlayer()
    {
        if (Input.GetButtonDown("Jump") && CheckGround.isOnGround)
        {
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, jumpForce);
            //Si tenemos animaciones, aqui vendria el Animator del salto
        }
    }
}