using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VillageAdventure.Object;

namespace VillageAdventure.Util
{
    public static class Extension 
    {
        public static void Update<T>(this List<T> list) where T : Obj
        {
            // (int i = list.Count-1; i>=0; i--)
            for (int i = 0; i < list.Count; i++)
            {
                // ��ü�� ������ �����ϴ��� Ȯ��
                if (list[i])
                {
                    // �����Ѵٸ� ��ü�� ������Ʈ ����
                    list[i].Execute();
                }
                // �������� �ʴ´ٸ�, ���� ���� Ư�� �������� ���� ��ü�� ���ŵ� ���
                else
                {
                    // ���ŵ� ��ü�̹Ƿ� ����Ʈ���� �ش� ������ ����
                    list.RemoveAt(i);
                    i--;
                }

                // �����ؾ��� ��
                // �ݺ��� �ȿ��� ����Ʈ�� ���Ҹ� ������ �� ��������
                /// 1. �ݺ����� �������� ++�� ����� ���, ���Ҹ� ���� �� i ���� -- ��
                /// 2. �ݺ����� �������� --�� ����ϰ�, �ʱ���� ������ �ε����� �����Ͽ�
                ///    �ڿ� ���Һ��� ���� ���Ҽ����� �ݺ�
            }
        }
    }
}