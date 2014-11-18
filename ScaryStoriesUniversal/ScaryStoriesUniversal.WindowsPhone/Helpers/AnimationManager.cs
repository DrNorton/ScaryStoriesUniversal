using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI.Xaml.Media.Animation;
using Telerik.Core;


namespace ScaryStoriesUniversal.Helpers
{
    public class AnimationManager
    {
        private List<RadAnimation> _addAnimations;
        private List<RadAnimation> _removeAnimations;

        private void PrepareAnimations()
        {
            this._addAnimations = new List<RadAnimation>();
            this._removeAnimations = new List<RadAnimation>();

            RadMoveAndFadeAnimation moveAndFade = new RadMoveAndFadeAnimation();
            moveAndFade.MoveAnimation.StartPoint = new Point(500, 0);
            moveAndFade.MoveAnimation.EndPoint = new Point(0, 0);
            moveAndFade.FadeAnimation.StartOpacity = 0;
            moveAndFade.FadeAnimation.EndOpacity = 1;
            moveAndFade.Easing = new CubicEase();
            this._addAnimations.Add(moveAndFade);

            moveAndFade = new RadMoveAndFadeAnimation();
            moveAndFade.MoveAnimation.StartPoint = new Point(0, 0);
            moveAndFade.MoveAnimation.EndPoint = new Point(500, 0);
            moveAndFade.FadeAnimation.StartOpacity = 1;
            moveAndFade.FadeAnimation.EndOpacity = 0;
            moveAndFade.Easing = new CubicEase() { EasingMode = EasingMode.EaseOut };
            this._removeAnimations.Add(moveAndFade);

            moveAndFade = new RadMoveAndFadeAnimation();
            moveAndFade.MoveAnimation.StartPoint = new Point(0, -90);
            moveAndFade.MoveAnimation.EndPoint = new Point(0, 0);
            moveAndFade.FadeAnimation.StartOpacity = 0;
            moveAndFade.FadeAnimation.EndOpacity = 1;
            moveAndFade.Easing = new CubicEase();
            this._addAnimations.Add(moveAndFade);

            moveAndFade = new RadMoveAndFadeAnimation();
            moveAndFade.MoveAnimation.StartPoint = new Point(0, 0);
            moveAndFade.MoveAnimation.EndPoint = new Point(0, -90);
            moveAndFade.FadeAnimation.StartOpacity = 1;
            moveAndFade.FadeAnimation.EndOpacity = 0;
            moveAndFade.Easing = new CubicEase() { EasingMode = EasingMode.EaseOut };
            this._removeAnimations.Add(moveAndFade);

            RadPlaneProjectionAnimation planeProjection = new RadPlaneProjectionAnimation();
            planeProjection.CenterX = 0;
            planeProjection.StartAngleY = 90;
            planeProjection.StartAngleX = 0;
            planeProjection.StartAngleZ = 0;
            planeProjection.EndAngleY = 0;
            planeProjection.Easing = new CubicEase();
            this._addAnimations.Add(planeProjection);

            planeProjection = new RadPlaneProjectionAnimation();
            planeProjection.CenterX = 0;
            planeProjection.StartAngleY = 0;
            planeProjection.StartAngleX = 0;
            planeProjection.StartAngleZ = 0;
            planeProjection.EndAngleY = 90;
            planeProjection.Easing = new CubicEase() { EasingMode = EasingMode.EaseOut };
            this._removeAnimations.Add(planeProjection);

            RadScaleAnimation scale = new RadScaleAnimation();
            scale.StartScaleX = 0;
            scale.EndScaleX = 1;
            scale.Duration = TimeSpan.FromMilliseconds(400);
            scale.Easing = new ElasticEase() { Oscillations = 2 };
            this._addAnimations.Add(scale);

            scale = new RadScaleAnimation();
            scale.StartScaleX = 1;
            scale.EndScaleX = 0;
            scale.Duration = TimeSpan.FromMilliseconds(400);
            scale.Easing = new ElasticEase() { Oscillations = 2 };
            this._removeAnimations.Add(scale);

            RadFadeAnimation fade = new RadFadeAnimation();
            fade.StartOpacity = 0;
            fade.EndOpacity = 1;
            fade.Easing = new CubicEase();

            this._addAnimations.Add(fade);

            fade = new RadFadeAnimation();
            fade.StartOpacity = 1;
            fade.EndOpacity = 0;
            fade.Easing = new CubicEase() { EasingMode = EasingMode.EaseOut };
            this._removeAnimations.Add(fade);
        }

        public AnimationManager()
        {
           
            PrepareAnimations();
        }

        public AnimationTuple GetAnimationByType(AnimationType type)
        {
            switch (type)
            {
                case AnimationType.HorizontalMoveFade:
                    return new AnimationTuple(){AddAnimation = _addAnimations[0],RemoveAnimation = _removeAnimations[0]};

                case AnimationType.VerticalMoveFade:
                    return new AnimationTuple() { AddAnimation = _addAnimations[1], RemoveAnimation = _removeAnimations[1] };

                case AnimationType.PlanPtojection:
                    return new AnimationTuple() { AddAnimation = _addAnimations[2], RemoveAnimation = _removeAnimations[2] };

                case AnimationType.Scale:
                    return new AnimationTuple() { AddAnimation = _addAnimations[3], RemoveAnimation = _removeAnimations[3] };

                case AnimationType.Fade:
                    return new AnimationTuple() { AddAnimation = _addAnimations[4], RemoveAnimation = _removeAnimations[4] };

            }
            return null;
        }

    }

    public class AnimationTuple
    {
        public RadAnimation AddAnimation { get; set; }
        public RadAnimation RemoveAnimation { get; set; }
    }

    public enum AnimationType
    {
        HorizontalMoveFade,
        VerticalMoveFade,
        PlanPtojection,
        Scale,
        Fade
    }

    
}
