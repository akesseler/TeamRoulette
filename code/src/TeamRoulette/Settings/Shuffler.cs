/*
 * MIT License
 * 
 * Copyright (c) 2023 plexdata.de
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

namespace Plexdata.TeamRoulette.Settings
{
    internal class Shuffler : ICloneable
    {
        #region Private Fields

        private Int32 duration;
        private Color borderColor;
        private Int32 borderThickness;
        private Color inlayColor;
        private Color textColor;

        #endregion

        #region Construction

        public Shuffler()
            : base()
        {
            this.Duration = 3;
            this.BorderColor = Color.IndianRed;
            this.BorderThickness = 6;
            this.InlayColor = Color.WhiteSmoke;
            this.TextColor = Color.DarkGreen;
        }

        private Shuffler(Shuffler other)
            : this()
        {
            this.Duration = other.Duration;
            this.BorderColor = other.BorderColor;
            this.BorderThickness = other.BorderThickness;
            this.InlayColor = other.InlayColor;
            this.TextColor = other.TextColor;
        }

        #endregion

        #region Properties

        public Int32 Duration
        {
            get
            {
                return this.duration;
            }
            set
            {
                if (value < 0)
                {
                    value = 3;
                }

                this.duration = value;
            }
        }

        public Color BorderColor
        {
            get
            {
                return this.borderColor;
            }
            set
            {
                if (value == Color.Transparent)
                {
                    value = Color.IndianRed;
                }

                this.borderColor = value;
            }
        }

        public Int32 BorderThickness
        {
            get
            {
                return this.borderThickness;
            }
            set
            {
                if (value < 0 || value > 10)
                {
                    value = 6;
                }

                this.borderThickness = value;
            }
        }

        public Color InlayColor
        {
            get
            {
                return this.inlayColor;
            }
            set
            {
                this.inlayColor = value;
            }
        }

        public Color TextColor
        {
            get
            {
                return this.textColor;
            }
            set
            {
                if (value == Color.Transparent)
                {
                    value = Color.DarkGreen;
                }

                this.textColor = value;
            }
        }

        #endregion

        #region ICloneable

        public Object Clone()
        {
            return new Shuffler(this);
        }

        #endregion
    }
}
