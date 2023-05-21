using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VillageAdventure.DB;
using VillageAdventure.Util;

namespace VillageAdventure.Object
{
    using SceneType = Enum.SceneType;
    public class Portal : Obj
    {
        // �ش� ������ ����� ���������� ���� �����͸� ��� ����
        public SceneType bindStage;

        private TriggerController portalTrigger;

        public override void Init()
        {
            UsingPortal();
        }
        private void UsingPortal()
        {
            portalTrigger = GetComponent<TriggerController>();
            var currentScene = GameManager.Instance.currentScene;
            portalTrigger.Initialize(OnEnterPortal, null, null);

            void OnEnterPortal(Collider2D collision)
            {
                if (!collision.CompareTag("Player"))
                    return;

                var gameManager = GameManager.Instance;
                var inGameManager = InGameManager.Instance;

                // ���������� ���� ���� ���� ���������� ���� ������ ���� �������� �ʵ忡 ����
                gameManager.prevStage = gameManager.currentScene;
                // ������ ������Ƿ� ����� ���������� ���� ������
                gameManager.LoadScene(bindStage, PortalProgress);

                void PortalProgress()
                {
                    // ���� �����Ͽ����Ƿ� ��Ż���� ������ ���� �ҷ���
                    inGameManager.InitPortals();
                    // ���� �������� ������ ������
                    var prevStage = gameManager.prevStage;
                    // �� ���� �Ϸ� ��, ��Ƶ� ���� ���������� ������ �̿��Ͽ� ���� ���������� ����� ��Ż �˻�
                    var bindPortal = inGameManager.portals.Where(_ => _.bindStage == prevStage).SingleOrDefault();
                    // �ش� ��Ż�� ĳ���͸� ��ġ��Ŵ
                    collision.transform.position = bindPortal.transform.GetChild(0).position;
                }
            }
        }
    }
}