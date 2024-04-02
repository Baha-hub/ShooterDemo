using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    private float hp = 100f, lerpSpeed = 0.03f;
    [SerializeField] private Slider hpSlider, easeSlider;
    private bool enemyDie = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void SetCameraTransform(Transform camTransform)
    {
        transform.GetChild(0).GetChild(0).GetComponent<LookCamera>().cam = camTransform;
    }
    private void Update()
    {
        if (!enemyDie)
        {
            agent.destination = player.position;
            
            if (easeSlider.value != hp)
            {
                easeSlider.value = Mathf.Lerp(easeSlider.value, hp, lerpSpeed);
            }
        }
    }

    public void TakeDamage(float damagePoint)
    {
        if (!enemyDie)
        {
            hp -= damagePoint;
            hpSlider.value = hp;
            if (hp <= 0) // die
            {
                enemyDie = true;
                Destroy(GetComponent<NavMeshAgent>());
                Destroy(transform.GetChild(0).GetChild(0).gameObject);
                transform.AddComponent<Rigidbody>();
            
                StartCoroutine(DieDelay());
                IEnumerator DieDelay()
                {
                    yield return new WaitForSeconds(2f);
                    Destroy(gameObject);
                }
            }
        }
    }
}