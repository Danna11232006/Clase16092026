using System.Collections.Generic;
using UnityEngine;



public class Trabajo : MonoBehaviour

{
    
    public float fuerza = 1f;
    // "fuerza" indica qué tan fuerte se empuja el Pin2.
    // Al ser public, podemos modificar este valor desde el Inspector de Unity.
    // 1f significa que inicialmente la fuerza vale 1.


    public float crecimiento = 4f;
    // "crecimiento" indica cuánto aumentará la altura del Pin1.
    // 4f significa que la altura del Pin1 se multiplicará por 4.
    // Por ejemplo: si mide 1 en Y, pasará a medir 4.


    private Renderer jugador;
    // Guarda el componente Renderer del Player.
    // El Renderer permite modificar la apariencia del objeto,
    // en este caso, cambiar su color.


    private HashSet<Transform> pinesCrecidos = new HashSet<Transform>();
    // Guarda los Pin1 que ya fueron agrandados.
    // HashSet evita guardar el mismo Pin1 dos veces.
    // Esto permite que cada Pin1 crezca solamente una vez.


    
    void Start()
    // Start se ejecuta una vez cuando comienza el juego.
    {
        jugador = GetComponent<Renderer>();
        // Busca el componente Renderer que está en el mismo objeto
        // donde está colocado este script, es decir, el Player.
        // Lo guardamos en "jugador" para poder cambiar su color después.
    }


    
    void OnTriggerEnter(Collider other)
    // Se ejecuta cuando el Player entra en un objeto
    // que tiene un Collider configurado como "Is Trigger".
    // "other" representa el objeto o zona que el Player acaba de tocar.
    {
        
        if (other.CompareTag("Area1"))
        // Comprueba si el objeto que tocamos tiene el Tag "Area1".
        {
            
            if (jugador.material.color == Color.black)
            // Comprueba si actualmente el Player es de color negro.
            {
                jugador.material.color = Color.white;
                // Si el Player es negro, lo cambia a blanco.
            }
            else
            // Si el Player NO es negro...
            {
                jugador.material.color = Color.black;
                // ...lo cambia a negro.
            }
        }


        
        if (other.CompareTag("Area2"))
        // Comprueba si el objeto que tocamos tiene el Tag "Area2".
        {
            
            float matiz = Random.value;
            // Random.value genera un número aleatorio entre 0 y 1.
            // Ese número se guarda en la variable "matiz".
            // "matiz" indica qué color se seleccionará.
            
            
            jugador.material.color = Color.HSVToRGB(matiz, 1f, 1f);
            // Convierte el valor aleatorio en un color.
            // El primer valor (matiz) decide qué color será.
            // 1f de saturación hace que el color sea intenso.
            // 1f de brillo hace que el color tenga brillo máximo.
            // Finalmente, ese color se aplica al Player.
        }
    }


    
    void OnControllerColliderHit(ControllerColliderHit hit)
    // Se ejecuta cuando el CharacterController del Player
    // choca contra un objeto sólido.
    // "hit" contiene información sobre el objeto que fue golpeado.
    {
        
        if (hit.gameObject.CompareTag("Pin1"))
        // Comprueba si el objeto con el que chocamos tiene el Tag "Pin1".
        {
            
            if (!pinesCrecidos.Contains(hit.transform))
            // Comprueba si este Pin1 todavía NO está guardado
            // en la lista de pines que ya crecieron.
            {
                
                pinesCrecidos.Add(hit.transform);
                // Guarda este Pin1.
                // De esta manera sabemos que ya creció
                // y no volveremos a hacerlo otra vez.


                
                hit.transform.localScale = new Vector3(
                    hit.transform.localScale.x,
                    hit.transform.localScale.y * crecimiento,
                    hit.transform.localScale.z
                );
                // Cambia el tamaño del Pin1.
                //
                // X mantiene su tamaño original.
                // Y se multiplica por "crecimiento".
                // Z mantiene su tamaño original.
                //
                // Por ejemplo:
                // X = 1
                // Y = 1
                // Z = 1
                //
                // Con crecimiento = 4:
                // X = 1
                // Y = 4
                // Z = 1
                //
                // Por eso el Pin1 crece solamente hacia arriba.
            }
        }


        
        if (hit.gameObject.CompareTag("Pin2"))
        // Comprueba si el objeto con el que chocamos tiene el Tag "Pin2".
        {
            
            Rigidbody pin = hit.rigidbody;
            // Obtiene el Rigidbody del Pin2.
            // El Rigidbody permite que Unity controle su movimiento físico.


            
            if (pin != null)
            // Comprueba que el Pin2 realmente tenga un Rigidbody.
            // Si no tiene Rigidbody, no podemos aplicarle una fuerza.
            {
                
                Vector3 direccion = new Vector3(
                    hit.moveDirection.x,
                    0,
                    hit.moveDirection.z
                );
                // Crea la dirección en la que se moverá el Pin2.
                //
                // X = dirección horizontal del jugador.
                // Y = 0 para que el Pin2 NO sea empujado hacia arriba o abajo.
                // Z = dirección horizontal del jugador.
                //
                // Por eso el Pin2 se mueve solamente de forma horizontal.


                
                pin.AddForce(direccion * fuerza, ForceMode.VelocityChange);
                // Empuja el Pin2 en la dirección del jugador.
                //
                // "direccion" indica hacia dónde.
                // "fuerza" indica cuánto.
                // "AddForce" aplica el empujón.
                // "VelocityChange" hace que el empujón cambie directamente
                // la velocidad del Pin2.
            }
        }
    }
}