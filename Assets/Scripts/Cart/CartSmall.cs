using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CartSmall : Cart
{
    public override void Move(Player player, Slider slider, Transform leftPoint, Transform rightPoint)
    {
        player.transform.position = Vector3.Lerp(player.transform.position, leftPoint.position + (rightPoint.position - leftPoint.position) * slider.value, Time.deltaTime * Speed);
    }
}