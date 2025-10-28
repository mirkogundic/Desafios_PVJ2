using UnityEngine;
using System.Collections;
using NUnit.Framework.Constraints;

public class Jefe_CaminarBehavior : StateMachineBehaviour
{
    private JefeArrow Jefe;
    private Rigidbody2D rb2D;
    [SerializeField] private float intervalo;
    [SerializeField] private float velocidadMovimiento;
    private Coroutine corrutinaGuardada;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Jefe = animator.GetComponent<JefeArrow>();
        rb2D = Jefe.rb2D;

        corrutinaGuardada = Jefe.StartCoroutine(TimerMirarJugador());

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        rb2D.linearVelocity = new Vector2(velocidadMovimiento, rb2D.linearVelocityY) * animator.transform.right;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb2D.linearVelocity = new Vector2(0, rb2D.linearVelocityY);

        if (corrutinaGuardada != null)
        {
            Jefe.StopCoroutine(corrutinaGuardada);
            corrutinaGuardada = null;
        }
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
    IEnumerator TimerMirarJugador()
    {
        while (true)
        {
            Jefe.MirarJugador();
            yield return new WaitForSeconds(intervalo);
        }
    }

}
