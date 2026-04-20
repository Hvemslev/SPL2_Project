using System;
using Microsoft.Xna.Framework;
using static PatternLibrary.Tweening.TweenManager;

namespace PatternLibrary.Tweening;

public interface ITweenManager
{
    TweenGroup Tween(float duration);
    void After(float delay, Action callback);
    RepeatTask Every(float interval, Action callback);
    void Clear();
    void Update(GameTime gameTime);
}