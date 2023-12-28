
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    private int PageNumber = 0;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    // Start is called before the first frame update
    const int MaxPage = 2;
    const int MinPage = 0;
    private void FixedUpdate()
    {
       if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition= Input.GetTouch(0).position;
        }

       if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition= Input.GetTouch(0).position;
            if(endTouchPosition.x < startTouchPosition.x)
            {
                PreviousPage();
            }

            if (endTouchPosition.x > startTouchPosition.x)
            {
                NextPage();
            }
        }
    }

    private void PreviousPage()
    {
        PageNumber--;
        if (PageNumber < MinPage)
        {
            PageNumber = MaxPage;
        }
        GameManager.instance.LoadLevel(PageNumber);
    }

    private void NextPage()
    {
        PageNumber++;
        if (PageNumber > MaxPage)
        {
            PageNumber = MinPage;
        }
        GameManager.instance.LoadLevel(PageNumber);
    }

}
