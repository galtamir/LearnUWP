using System;

namespace GameUI_Wpf
{
    internal class ToCanvasTramsformer
    {
        private double _heightOffset;
        private double _widthOffset;

        public ToCanvasTramsformer(double heigth, double width, double canvasHeight, double canvasWidth)
        {
            _heightOffset = canvasHeight / (heigth);
            _widthOffset = canvasWidth / (width);
        }

        internal double ToLeft(int width)
        {
            return _widthOffset * width;
        }

        internal double ToTop(int height)
        {
            return _heightOffset * height;
        }
    }
}