using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VillageAdventure.Object
{
    public class TriggerController : MonoBehaviour
    {
        // ��ġ�� ���� �����ų ����� �븮�� �븮��
        private Action<Collider2D> enterEvent;
        // ��ħ�� ������ ���� �����ų ����� �븮�� �븮��
        private Action<Collider2D> exitEvent;
        private Action<Collider2D> stayEvent;
        private Collider2D coll;
        private void Start()
        {
            coll = GetComponent<Collider2D>();
        }
        public void Initialize(Action<Collider2D> OnEnter = null, Action<Collider2D> OnExit = null, Action<Collider2D> OnStay = null)
        {
            enterEvent = OnEnter;
            exitEvent = OnExit;
            stayEvent = OnStay;
        }
        // Ư�� �ݶ��̴��� ��ġ�� ���� ����
        private void OnTriggerEnter2D(Collider2D collision)
        {
            enterEvent?.Invoke(collision);
        }
        // Ư�� �ݶ��̴��� ��ħ�� ������ ���� ����
        private void OnTriggerExit2D(Collider2D collision)
        {
            exitEvent?.Invoke(collision);
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            stayEvent?.Invoke(collision);
        }
    }
}