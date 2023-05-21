using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VillageAdventure.DB;
using VillageAdventure.Enum;
using VillageAdventure.StaticData;

namespace VillageAdventure.Object
{
    public abstract class Actor : Obj
    {
        public BoActor boActor;
        public string objTagName { get; set; }
        protected ActorState.State _state = ActorState.State.Idle;

        protected SpriteRenderer sr;
        protected Collider2D coll;
        protected Rigidbody2D rigid;
        protected Animator anim;

        protected virtual void Awake()
        {
            sr = GetComponent<SpriteRenderer>();
            coll = GetComponent<Collider2D>();
            rigid = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }
        public override void Init()
        {

        }

        public override void Execute()
        {
            OnMove();
            OnMoveAnim();
        }

        public virtual void Initialize(BoActor boActor)
        {
            this.boActor = boActor;
            SetStats();
        }

        public virtual void SetStats()
        {
            boActor.moveSpeed = boActor.sdActor.moveSpeed;
        }
        
        public virtual ActorState.State State
        {
            get { return _state; }
            set
            {
                _state = value;
                switch (_state)
                {
                    case ActorState.State.Idle:
                        anim.CrossFade($"{objTagName}_Idle", 0.5f);
                        break;
                    case ActorState.State.Move:
                        anim.CrossFade($"{objTagName}_Move", 0.5f);
                        break;
                    case ActorState.State.Hit:
                        break;
                    case ActorState.State.Dead:
                        anim.CrossFade($"{objTagName}_Dead", 0.5f);
                        break;
                    case ActorState.State.Attack:
                        anim.CrossFade($"{objTagName}_Attack", 0.5f);
                        break;
                    case ActorState.State.Hurt:
                        anim.CrossFade($"{objTagName}_Hurt", 0.5f);
                        break;
                    case ActorState.State.Alert:
                        anim.CrossFade($"{objTagName}_Alert", 0.5f);
                        break;
                }
            }
        }
        //public virtual void SetState(State state)
        //{
        //    State = state;
        //
        //    switch (state)
        //    {
        //        case State.Idle:
        //            anim.CrossFade($"{objTagName}_Idle", 0.5f);
        //            break;
        //        case State.Move:
        //            anim.CrossFade($"{objTagName}_Move", 0.5f);
        //            break;
        //        case State.Hit:
        //            break;
        //        case State.Dead:
        //            anim.CrossFade($"{objTagName}_Dead", 0.5f);
        //            break;
        //        case State.Attack:
        //            anim.CrossFade($"{objTagName}_Attack", 0.5f);
        //            break;
        //        case State.Hurt:
        //            anim.CrossFade($"{objTagName}_Hurt", 0.5f);
        //            break;
        //        case State.Alert:
        //            anim.CrossFade($"{objTagName}_Alert", 0.5f);
        //            break;
        //    }
        //}
        public virtual void OnMove()
        {
            //transform.Translate(boActor.moveSpeed * boActor.moveDirection, Space.World);
            
            var newVelocity = boActor.moveDirection * boActor.moveSpeed;
            rigid.velocity = newVelocity;
        }
        public virtual void OnMoveAnim()
        {
            // Actor�� X �ӷ��� �ִٸ�
            if (!(Mathf.Approximately(rigid.velocity.x, 0)))
            {
                if (boActor.moveDirection.x > 0)
                {
                    anim.SetInteger("moveState", 2);
                }
                else if (boActor.moveDirection.x < 0)
                {
                    anim.SetInteger("moveState",3);
                }
            }
            // Actor�� Y �ӷ��� �ִٸ�
            if (!(Mathf.Approximately(rigid.velocity.y, 0)))
            {
                if (boActor.moveDirection.y > 0)
                {
                    anim.SetInteger("moveState", 1);
                }
                else if (boActor.moveDirection.y < 0)
                {
                    anim.SetInteger("moveState", 0);
                }
            }

            // Actor�� �������� ���ٸ�
            anim.SetBool("isMove", !(boActor.moveDirection.x == 0 && boActor.moveDirection.y == 0));
        }
    }
}