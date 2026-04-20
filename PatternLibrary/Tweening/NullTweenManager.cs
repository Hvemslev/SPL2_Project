
using System;
using Microsoft.Xna.Framework;

namespace PatternLibrary.Tweening;

public class NullTweenManager : ITweenManager
{
    public void After(float delay, Action callback)
    {
    }

    public void Clear()
    {
    }

    public TweenManager.RepeatTask Every(float interval, Action callback)
    {
        return null;
    }

    public TweenManager.TweenGroup Tween(float duration)
    {
        return null;
    }

    public void Update(GameTime gameTime)
    {
    }
}