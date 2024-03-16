using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public float timePerQuestion=60f;
    float m_curTime;
    float m_score;
    int m_rightCount;
    private void Awake()
    {
        m_curTime=timePerQuestion;
    }
    void Start()
    {
        StartCoroutine(TimeCountingDown());
        UIManager.Ins.SetTimeText("00: "+m_curTime);
        UIManager.Ins.SetScoreText(" "+m_score);
        CreateQuestion();
    }
    void Update()
    {
        
    }
    public void CreateQuestion()
    {
        QuestionData qs=QuestionManager.Ins.GetRandomQuestion();
        if(qs!=null)
        {
            UIManager.Ins.SetQuestionText(qs.question);
            string[] wrongAnswer=new string[]{qs.answerA,qs.answerB,qs.answerC};
            UIManager.Ins.ShuffleAnswer();
            var temp=UIManager.Ins.answerButtons;
            if(temp!=null && temp.Length>0)
            {
                int wrongAnswerCount=0;
                for(int i=0;i<temp.Length;i++)
                {
                    int answerId=i;
                    if(string.Compare(temp[i].tag,"RightAnswer")==0)
                    {
                        temp[i].SetAnswerText(qs.rightAnswer);
                    }
                    else
                    {
                        temp[i].SetAnswerText(wrongAnswer[wrongAnswerCount]);
                        wrongAnswerCount++;
                    }
                    temp[answerId].btnComp.onClick.RemoveAllListeners();
                    temp[answerId].btnComp.onClick.AddListener(()=>CheckRightAnswerEvent(temp[answerId]));
                }
            }
        }
    }
    void CheckRightAnswerEvent(AnswerButton answerButtons)
    {
        if(answerButtons.CompareTag("RightAnswer"))
        {
            m_score+=10;
            m_curTime=timePerQuestion;
            UIManager.Ins.SetTimeText("00: "+m_curTime);
            UIManager.Ins.SetScoreText(" "+m_score);
            m_rightCount++;
            if(m_rightCount==QuestionManager.Ins.questions.Length)
            {
                UIManager.Ins.dialog.SetDialogContent("Bạn đã chiến thắng");
                UIManager.Ins.dialog.Show(true);
                AudioController.Ins.PlayWinSound();
                StopAllCoroutines();
            }
            else
            {
               AudioController.Ins.PlayRightSound();
           
                CreateQuestion();
            }
        }
        else
        {
            UIManager.Ins.dialog.SetDialogContent("Bạn đã trả lời sai!\n Trò chơi kết thúc!");
            UIManager.Ins.dialog.Show(true);
            m_score=0;
            AudioController.Ins.PlayLoseSound();
        }
    }
    IEnumerator TimeCountingDown()
    {
        yield return new WaitForSeconds(1);
        if(m_curTime>0)
        {
            m_curTime--;
            UIManager.Ins.SetTimeText("00: "+m_curTime);
            StartCoroutine(TimeCountingDown());
            
        }
        else
        {
            UIManager.Ins.dialog.SetDialogContent("Hết giờ bạn đã thua!Trò chơi kết thúc!");
            UIManager.Ins.dialog.Show(true);
            AudioController.Ins.PlayLoseSound();
            StopAllCoroutines();
        }
    }
    public void Replay()
    {
        AudioController.Ins.StopMusic();
        SceneManager.LoadScene("GamePlay");
    }
    public void Exit()
    {
        Application.Quit();
    }
}


//Doc file csv sau nay se sua

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// public class GameController : MonoBehaviour
// {
//     public static GameController Ins; 
//     public float timePerQuestion=60f;
//     float m_curTime;
//     float m_score;
//     int m_rightCount;
 
//     private void Awake()
//     {
//         Ins=this;
     
//         m_curTime=timePerQuestion;
//     }
//     void Start()
//     {
//         StartCoroutine(TimeCountingDown());
//         UIManager.Ins.SetTimeText("00: "+m_curTime);
//         UIManager.Ins.SetScoreText(" "+m_score);
//         CreateQuestion();
//     }
    
//     public void CreateQuestion()
//     {
//         QuestionData qs=QuestionManager.Ins.GetRandomQuestion();
//         if(qs!=null)
//         {
//             UIManager.Ins.SetQuestionText(qs.question);
//             string[] wrongAnswer=new string[]{qs.answerA,qs.answerB,qs.answerC};
//             UIManager.Ins.ShuffleAnswer();
//             var temp=UIManager.Ins.answerButtons;
//             if(temp!=null && temp.Length>0)
//             {
//                 int wrongAnswerCount=0;
//                 for(int i=0;i<temp.Length;i++)
//                 {
//                     int answerId=i;
//                     if(string.Compare(temp[i].tag,"RightAnswer")==0)
//                     {
//                         temp[i].SetAnswerText(qs.rightAnswer);
//                     }
//                     else
//                     {
//                         temp[i].SetAnswerText(wrongAnswer[wrongAnswerCount]);
//                         wrongAnswerCount++;
//                     }
//                     temp[answerId].btnComp.onClick.RemoveAllListeners();
//                     temp[answerId].btnComp.onClick.AddListener(()=>CheckRightAnswerEvent(temp[answerId]));
//                 }
//             }
//         }
//     }
//     void CheckRightAnswerEvent(AnswerButton answerButtons)
//     {
//         if(answerButtons.CompareTag("RightAnswer"))
//         {
//             m_score+=10;
//             m_curTime=timePerQuestion;
//             UIManager.Ins.SetTimeText("00: "+m_curTime);
//             UIManager.Ins.SetScoreText(" "+m_score);
//             m_rightCount++;
//             if(m_rightCount==QuestionCSV.Ins.questions.Length)
//             {
//                 UIManager.Ins.dialog.SetDialogContent("Bạn đã chiến thắng");
//                 UIManager.Ins.dialog.Show(true);
//                 AudioController.Ins.PlayWinSound();
//                 StopAllCoroutines();
//             }
//             else
//             {
//                AudioController.Ins.PlayRightSound();
           
//                 CreateQuestion();
//             }
//         }
//         else
//         {
//             UIManager.Ins.dialog.SetDialogContent("Bạn đã trả lời sai!\n Trò chơi kết thúc!");
//             UIManager.Ins.dialog.Show(true);
//             m_score=0;
//             AudioController.Ins.PlayLoseSound();
//         }
//     }
//     IEnumerator TimeCountingDown()
//     {
//         yield return new WaitForSeconds(1);
//         if(m_curTime>0)
//         {
//             m_curTime--;
//             UIManager.Ins.SetTimeText("00: "+m_curTime);
//             StartCoroutine(TimeCountingDown());
            
//         }
//         else
//         {
//             UIManager.Ins.dialog.SetDialogContent("Hết giờ bạn đã thua!Trò chơi kết thúc!");
//             UIManager.Ins.dialog.Show(true);
//             AudioController.Ins.PlayLoseSound();
//             StopAllCoroutines();
//         }
//     }
  
//     public void Replay()
//     {
//         AudioController.Ins.StopMusic();

//         SceneManager.LoadScene("GamePlay");
       
//     }
//     public void Exit()
//     {
//         Application.Quit();
//     }
// }
