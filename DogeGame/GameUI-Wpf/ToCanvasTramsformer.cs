using System;

namespace GameUI_Wpf
{
    internal class ToCanvasTramsformer
    {
        private double _heightOffset;
        private double _widthOffset;

        public ToCanvasTramsformer(double objectSize, double matrixHeigth, double matrixWidth, double canvasHeight, double canvasWidth)
        {
            _heightOffset = (canvasHeight - objectSize) / (matrixHeigth);
            _widthOffset = (canvasWidth - objectSize) / (matrixWidth);
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