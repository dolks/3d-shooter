using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5;
    [SerializeField] float turnSpeed = 5;
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    Animator animator;
    EnemyHealth health;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        health = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.GetIsDead()) {
            enabled = false;
            navMeshAgent.enabled = false;
        }
        distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (isProvoked) {
            Debug.Log("provooked");
            EngageTarget();
        } else if (distanceToTarget <= chaseRange) {
            isProvoked = true;
        }
    }

    public void OnDamageTaken() {
        isProvoked = true;
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    void EngageTarget() {
        FaceTarget();
        if (distanceToTarget > navMeshAgent.stoppingDistance) {
            ChaseTarget();
        } else if (distanceToTarget <= navMeshAgent.stoppingDistance) {
            AttackTarget();
        }
    }

    void AttackTarget() {
        animator.SetBool("attack", true);
        GetComponent<EnemyAttack>().AttackHitEvent();
    }

    void ChaseTarget() {
        animator.SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    private void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation( new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);

    }
}
