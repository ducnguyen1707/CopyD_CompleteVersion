using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI; 

public class Teacher : MonoBehaviour
{
    [SerializeField] float CatchDistance;
 
    [SerializeField] Transform player;
    [SerializeField] List<Transform> studentList;
     NavMeshAgent teacher;
    [HideInInspector]    public bool IsCatchPlayer ;

    public Transform target { get; private set; }
    public Queue<Transform> studentCatch=new ();

    public void Start()
    {
        teacher = GetComponent<NavMeshAgent>();
        teacher.updateRotation = false;
        teacher.updateUpAxis = false;

        studentList.ForEach(t => studentCatch.Enqueue(t));
    }

    public void Update()
    {
        if (!IsCatchPlayer && (target == null || Vector3.Distance(transform.position, target.position) < CatchDistance))
        {
            target = studentCatch.Dequeue();
            studentCatch.Enqueue(target);
        }
        else if(IsCatchPlayer)
        {
            target = player;
        }

        teacher.SetDestination(target.position);
    }

    public void SetPlayerOnChair(bool isOnChair)
    {
        IsCatchPlayer = !isOnChair;
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UIQuizzController.Instance.End();
            Debug.Log("Thay da cham vao ban");
        }
    }
}
