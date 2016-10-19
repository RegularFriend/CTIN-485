using UnityEngine;
using System.Collections;

public class UnitProperty : MonoBehaviour {
    public int m_Team;
    public int m_Health = 100;
    public int m_AttackRange = 5;

	public ParticleSystem bloodParticle;

    private NavMeshAgent m_NavAgent;
    public Vector3 m_Target;
    private GameManager gManager;

    private AnimationStateController m_AnimationStateController;
    private float startSpeed;
    private bool slowed = false;

    private Transform playerBase;
    // Use this for initialization
    void Start () {
        m_NavAgent = GetComponent<NavMeshAgent>();
        m_Target = transform.position;
        m_AnimationStateController = GetComponentInChildren<AnimationStateController>();
        gManager = FindObjectOfType<GameManager>();
        SetTarget(gManager.playerBase.position);
        playerBase = gManager.playerBase;
        startSpeed = m_NavAgent.speed;
    }
	
    public static UnitProperty Create(GameManager gmr, string type, Vector3 initialPos, int team){
        string path = "Prefabs/" + type;
        GameObject nUnit = Instantiate(Resources.Load(path)) as GameObject;
        nUnit.transform.position = initialPos;

        UnitProperty nUP = nUnit.GetComponent<UnitProperty>();
        nUP.m_Team = team;

        return nUP; 
    } 

	// Update is called once per frame
	void Update () {
        if (transform.position != m_Target)
        {
            m_NavAgent.SetDestination(m_Target);
        }
        float distance;
        distance = Mathf.Abs(Vector3.Distance(transform.position, playerBase.position));
        if (distance < 25)
        {
            Debug.Log("dying");
            gManager.health -= 1;
            TakeDamage(100000);
        }
    }

    public void SetTarget(Vector3 target)
    {
        Debug.Log(target);
        m_Target = target;
        m_AnimationStateController.UpdateAnimationState(AnimationState.Walking);
    }

    public void TakeAttack(UnitProperty attacker)
    {
        if ((attacker.transform.position - this.transform.position).magnitude <= attacker.m_AttackRange)
        {
            TakeDamage(20);
			bloodParticle.Play();

		}

    }

    public void TakeDamage(int damage)
    {
        m_Health -= damage;
        if (m_Health <= 0)
        {
           if (gManager.allUnits.Contains(this))
                gManager.allUnits.Remove(this);
            gManager.points += 100;
            Destroy(this.gameObject);
        }
    }

    public void BecomeSlowed(float slowAmount, float slowTime)
    {
        if (!slowed)
        {
            m_NavAgent.speed = startSpeed * slowAmount;
            GetComponentInChildren<Renderer>().material.color = Color.blue;
            Invoke("ReturnToNormalSpeed", slowTime);
            slowed = true;
        }
        
    }

    public void ReturnToNormalSpeed()
    {
        GetComponentInChildren<Renderer>().material.color = Color.white;
        m_NavAgent.speed = startSpeed;
        slowed = false;
    }
}
