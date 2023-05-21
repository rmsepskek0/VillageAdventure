using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VillageAdventure.StaticData;

namespace VillageAdventure.DB
{
    [Serializable]
    public class BoActor 
    {
        /// �ΰ��� ������
        public float moveSpeed; // �ΰ��� ���ǵ�
        public Vector2 moveDirection;
        public SDActor sdActor; // ���� ���ǵ�

        public BoActor(SDActor sdActor)
        {
            this.sdActor = sdActor;
        }
    }
}