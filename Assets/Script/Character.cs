using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class Character : MonoBehaviour {
        [HideInInspector]
        public static Character Main;
        public AnimControl AC;
        public Rigidbody2D Rig;
        [Space]
        public float Speed;
        public float SpeedScale;
        public float InputSpeed;
        public float LastSpeed;
        public float TempSpeedDecay;
        public float TempSpeed;
        public VelocitySwitch VS;
        public Direction direction;
        [Space]
        public bool MoveTargeting;
        public float MoveTargetX;
        public Direction MoveTargetDirection;
        [Space]
        public InterObject TargetInterObject;
        public InterObject ActiveInterObject;
        public Direction DelayProcessDirection;
        public bool DelayProcessing;
        [Space]
        public List<CharacterLimit> LeftLimits;
        public List<CharacterLimit> RightLimits;
        [Space]
        public float JumpSpeed;
        public float MaxFallSpeed;
        public int MaxDoubleJumpCount;
        public int DoubleJumpCount;
        [Space]
        public GameObject DirectionObjectBase;
        public GameObject FirePoint;
        public GameObject TargetPoint;
        [Space]
        public bool GhostForm;
        public float GhostFormSpeed;
        [Space]
        public List<Collider2D> C2Ds;
        public List<MovingPlatform> MPs;
        public bool OnGround;
        [HideInInspector]
        public bool TouchDownOnce;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (MoveTargeting)
            {
                if (MoveTargetCheck())
                    FinishMoveTarget();
                else
                {
                    if (transform.position.x > GetMTX() && CanMove(Direction.Left))
                        SetInputSpeed(-1);
                    else if (transform.position.x < GetMTX() && CanMove(Direction.Right))
                        SetInputSpeed(1);
                    else
                        EndMoveTarget();
                }
            }

            float a = GetInputSpeed();
            float t = GetMovingPlatformsSpeed();
            float v = VS.GetSpeed();

            float b = Rig.velocity.y;
            if (b < MaxFallSpeed)
                b = MaxFallSpeed;

            Rig.velocity = new Vector2(a + t + v + TempSpeed, b);
            Rig.gravityScale = VS.GetGravity();

            TempSpeedUpdate();

            if (a > 0)
                InputDirection(Direction.Right);
            else if (a < 0)
                InputDirection(Direction.Left);

            if (C2Ds.Count > 0 && (Mathf.Abs(Rig.velocity.y) <= 0.01f || MPs.Count > 0))
            {
                if (!OnGround)
                    TouchDown();
                OnGround = true;
                AC.OnGround();
            }
            else
            {
                OnGround = false;
                AC.LeaveGround();
            }
        }

        public void SetInputSpeed(float Value)
        {
            InputSpeed = Value;
        }

        public float GetInputSpeed()
        {
            float a = InputSpeed;
            a *= AC.PositionInputScale;
            if (!GhostForm)
                a *= Speed;
            else
                a *= GhostFormSpeed;
            if (AC.KeepDirection)
            {
                if ((direction == Direction.Left && a > 0) || (direction == Direction.Right && a < 0))
                    a = 0;
            }
            if (AC.LockSpeed)
                a += LastSpeed;
            else
                LastSpeed = a;
            return a;
        }

        public float GetMovingPlatformsSpeed()
        {
            float t = 0;
            foreach (MovingPlatform MP in MPs)
                if (MP.Rig)
                    t += MP.Rig.velocity.x;
            return t;
        }

        public void TempSpeedUpdate()
        {
            if (Mathf.Abs(TempSpeed) <= 0.01f)
                TempSpeed = 0;
            else if (TempSpeed > 0)
                TempSpeed -= TempSpeedDecay * Time.deltaTime;
            else if (TempSpeed < 0)
                TempSpeed += TempSpeedDecay * Time.deltaTime;
        }

        public void InputDirection(Direction D)
        {
            AC.SetDirection(D);
        }

        public void SetDirection(Direction D)
        {
            direction = D;
            if (!DirectionObjectBase)
                return;
            if (D == Direction.Left)
                DirectionObjectBase.transform.localScale = new Vector3(-1, 1, 1);
            else if (D == Direction.Right)
                DirectionObjectBase.transform.localScale = new Vector3(1, 1, 1);
        }

        public void SetPosition(float X)
        {
            SetPosition(X, transform.position.y);
        }

        public void SetPosition(float X, float Y)
        {
            transform.position = new Vector3(X, Y, transform.position.z);
        }

        public void SetTargetInterObject(InterObject IO)
        {
            if (!IO || TargetInterObject == IO)
                return;

            TargetInterObject = IO;
            if (IO.GetInterPosition().x < transform.position.x)
                MoveTargetDirection = Direction.Left;
            else if (IO.GetInterPosition().x > transform.position.x)
                MoveTargetDirection = Direction.Right;
            MoveTargeting = true;
        }

        public void SetMoveTarget(float Value)
        {
            if (transform.position.x == Value)
                return;

            MoveTargetX = Value;
            if (Value < transform.position.x)
                MoveTargetDirection = Direction.Left;
            else if (Value > transform.position.x)
                MoveTargetDirection = Direction.Right;
            DisruptInterObject();
            MoveTargeting = true;
        }

        public void FinishMoveTarget()
        {
            SharedFinishMoveTargetCode();
            SetPosition(GetMTX());
            if (TargetInterObject)
            {
                DelayProcessDirection = TargetInterObject.GetInterDirection();
                StartCoroutine("IODelayAnim");
            }
        }

        public void EndMoveTarget()
        {
            SharedFinishMoveTargetCode();
            DisruptInterObject();
        }

        public void SharedFinishMoveTargetCode()
        {
            SetInputSpeed(0);
            MoveTargeting = false;
        }

        public bool MoveTargetCheck()
        {
            return (GetMTD() == Direction.Left && transform.position.x <= GetMTX()) 
                || (GetMTD() == Direction.Right && transform.position.x >= GetMTX());
        }

        public void DisruptInterObject()
        {
            TargetInterObject = null;
            StopCoroutine("IODelayAnim");
            if (ActiveInterObject)
            {
                AC.StopInterObject();
                ActiveInterObject.Disable();
                ActiveInterObject = null;
            }
        }

        public void ActivateInterObject(InterObject IO)
        {
            AC.StartInterObject(IO);
            ActiveInterObject = IO;
            IO.Activate();
        }

        public IEnumerator IODelayAnim()
        {
            DelayProcessing = true;
            yield return new WaitForSeconds(0.15f);
            InputDirection(DelayProcessDirection);
            ActivateInterObject(TargetInterObject);
            DelayProcessing = false;
        }

        public void AttackInput(int Index)
        {
            AC.AttackInput(Index);
        }

        public void JumpInput()
        {
            AC.Jump();
        }

        public void Jump()
        {
            if (OnGround)
            {
                OnGround = false;
            }
            else
            {
                if (DoubleJumpCount <= 0)
                    return;
                DoubleJumpCount--;
            }
            AddSpeed(0, JumpSpeed);
        }

        public void DodgeInput()
        {
            AC.Dodge();
        }

        public void TouchDown()
        {
            OnGround = true;
            DoubleJumpCount = MaxDoubleJumpCount;
            AC.TouchDown();

            if (!TouchDownOnce)
            {
                TouchDownOnce = true;
                FirstTouchDown();
            }
        }

        public void FirstTouchDown()
        {

        }

        public void AddSpeed(float X, float Y)
        {
            TempSpeed += X;
            if (Y != 0)
                Rig.velocity = new Vector2(Rig.velocity.x, Y);
        }

        public void OnCollisionEnter2D(Collision2D C2D)
        {
            C2Ds.Add(C2D.collider);
            if (C2D.collider.GetComponent<MovingPlatform>())
                MPs.Add(C2D.collider.GetComponent<MovingPlatform>());
        }

        public void OnCollisionExit2D(Collision2D C2D)
        {
            if (C2Ds.Contains(C2D.collider))
                C2Ds.Remove(C2D.collider);
            if (C2D.collider.GetComponent<MovingPlatform>() && MPs.Contains(C2D.collider.GetComponent<MovingPlatform>()))
                MPs.Remove(C2D.collider.GetComponent<MovingPlatform>());
        }

        public void OnTriggerEnter2D(Collider2D C2D)
        {
            if (C2D.GetComponent<CharacterLimit>())
            {
                CharacterLimit CL = C2D.GetComponent<CharacterLimit>();
                if (CL.LimitDirection == Direction.Left && !LeftLimits.Contains(CL))
                    LeftLimits.Add(CL);
                else if (CL.LimitDirection == Direction.Right && !RightLimits.Contains(CL))
                    RightLimits.Add(CL);
            }
        }

        public void OnTriggerExit2D(Collider2D C2D)
        {
            if (C2D.GetComponent<CharacterLimit>())
            {
                CharacterLimit CL = C2D.GetComponent<CharacterLimit>();
                if (LeftLimits.Contains(CL))
                    LeftLimits.Remove(CL);
                else if (RightLimits.Contains(CL))
                    RightLimits.Remove(CL);
            }
        }

        public float GetMTX()
        {
            if (TargetInterObject)
                return TargetInterObject.GetInterPosition().x;
            else
                return MoveTargetX;
        }

        public Direction GetMTD()
        {
            return MoveTargetDirection;
        }

        public Vector2 GetAbsoluteSpeed()
        {
            float X = Rig.velocity.x;
            float Y = Rig.velocity.y;
            foreach (MovingPlatform MP in MPs)
            {
                X -= MP.Rig.velocity.x;
                Y -= MP.Rig.velocity.y;
            }
            return new Vector2(X, Y);
        }

        public Vector3 GetTargetPosition()
        {
            return TargetPoint.transform.position;
        }

        public Vector3 GetFirePosition()
        {
            return FirePoint.transform.position;
        }

        public bool CanInputMoveTarget()
        {
            return !DelayProcessing && (!ActiveInterObject || ActiveInterObject.CanDisrupt());
        }

        public bool CanMove(Direction D)
        {
            if (D == Direction.Left)
                return LeftLimits.Count <= 0;
            else if (D == Direction.Right)
                return RightLimits.Count <= 0;
            else
                return true;
        }
    }

    public enum Direction
    {
        Left,
        Right,
        Both
    }
}