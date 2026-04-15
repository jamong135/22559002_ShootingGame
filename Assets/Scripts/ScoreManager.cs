using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TextMEshProUGUI 클래스를 사용하기 위한 네임 스페이스
using TMPro;
public class ScoreManager : MonoBehaviour
{
    //Now Score UI와 연결할 변수
    public TextMeshProUGUI nowScoreUI;

    //실제적인 현재 점수를 받을 정수형 자료형 변수
    public int nowScore;
}
