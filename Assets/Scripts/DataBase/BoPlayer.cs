using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VillageAdventure.StaticData;

namespace VillageAdventure.DB
{
    [Serializable]
    public class BoPlayer : BoActor
    {
        /// sdActor�� ���·� �Ǿ� �ִ� �����͸� ������ ���ϰ� ���� ĳ������ ��ȹ
        /// ������ ���·� ĳ�����Ͽ� ��Ƶ� �ʵ�
        public SDPlayer sdPlayer;

        public BoPlayer(SDActor sdActor)
            : base(sdActor)
        {
            sdPlayer = sdActor as SDPlayer;
        }
    }
}