using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Animation: IUpdatable
    {
        public List<Image> images;
        public float speedAnimation;
        private bool isLooping;

        private int frameNumber;
        private float currentTime;

        public Image CurrentImage => images[frameNumber];

        public Animation(List<Image> images, float speedAnimation, bool isLooping)
        {
            this.images = images;
            this.speedAnimation = speedAnimation;
            this.isLooping = isLooping;
        }

        public void Update()
        {
            currentTime += Time.DeltaTime;
            if (currentTime > speedAnimation)
            {
                frameNumber++;
                currentTime = 0;

                if (frameNumber >= images.Count) 
                {
                    if (isLooping) 
                    {
                        frameNumber = 0;
                    }
                    else 
                    { 
                        frameNumber--;
                    }
                }
            }
        }
    }
}
