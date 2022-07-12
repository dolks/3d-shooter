using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5;
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    Animator animator;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (isProvoked) {
            EngageTarget();
        } else if (distanceToTarget <= chaseRange) {
            isProvoked = true;
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    void EngageTarget() {
        if (distanceToTarget > navMeshAgent.stoppingDistance) {
            animator.SetBool("attack", true);
            ChaseTarget();
        } else if (distanceToTarget <= navMeshAgent.stoppingDistance) {
            AttackTarget();
        }
    }

    void AttackTarget() {
        Debug.Log("attack");
        animator.SetBool("attack", true);
    }

    void ChaseTarget() {
        animator.SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }
}
