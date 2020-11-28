using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchHandler : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
   public enum Direction
   {
       Left,
       Right,
       None

   }
   [SerializeField] internal  Direction btnDirection = Direction.None;
   internal static bool left = false;
   internal static bool Right = false;
    private void Start()
    {
      
         left = false;
         Right = false;
    }
    
   public void OnPointerDown(PointerEventData eventData)
   {
       if (btnDirection == Direction.Left) {
           left = true;
           Right = false;
       } else if(btnDirection == Direction.Right) {
           left = false;
           Right = true;
       }
   }
   public void OnPointerUp(PointerEventData eventData)
   {
        left = false;
        Right = false;
       
   }
   
}
