﻿using System;

namespace Gma.QrCodeNet.Encoding.Positioning
{
    public class TriStateMatrix : SimpleBitMatrix
    {
        private readonly SimpleBitMatrix m_IsUsed;

        public TriStateMatrix(int width)
            : base(width)
        {
            m_IsUsed = new SimpleBitMatrix(width);
        }

        public override bool this[int i, int j]
        {
            get
            {
                if (!IsUsed(i, j))
                {
                    throw new InvalidOperationException(string.Format("The value of cell [{0},{1}] is not set.", i, j));
                }
                return base[i, j];
            }
            set
            {
                m_IsUsed[i, j] = true;
                base[i, j] = value;
            }
        }

        internal bool IsUsed(int i, int j)
        {
            return m_IsUsed[i, j];
        }

        internal bool IsUsed(Point point)
        {
            return IsUsed(point.X, point.Y);
        }
    }
}