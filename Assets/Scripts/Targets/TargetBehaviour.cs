using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetBehaviour : MonoBehaviour
{
    [SerializeField] private float minSpeed = 12f;
    [SerializeField] private float maxSpeed = 16f;
    [SerializeField] private float maxTorque = 2f;
    [SerializeField] private float xRange = 4f;
    [SerializeField] private float ySpawnPos = -6f;
    
    private Rigidbody _targetRb; // Referência ao RigidBody do game object

    private void Start()
    {
        _targetRb = GetComponent<Rigidbody>(); // Quando a cena começa, o script busca pelo rigidbody do game object
        
        _targetRb.AddForce(RandomForce(), ForceMode.Impulse); // Joga o objeto para cima com força x e impulso imediato
        _targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse); // Rotaciona o objeto com força x e impulso imediato

        transform.position = RandomSpawnPos(); // Coloca o objeto em determinada posição na cena
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed); // Determina um valor randomico entre um mínimo e máximo no qual o objeto será jogado para cima
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque,maxTorque); // Determina um valor randomico entre um mínimo e máximo no qual o objeto poderá rodar em seu próprio eixo
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos); // Determina os locais em que o objeto pode ser instanciado na cena, como x tendo mínimo e máximo, y tendo um valor próprio e z tendo valor 0
    }
}
