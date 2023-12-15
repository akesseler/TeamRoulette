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

using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;

using FormsTimer = System.Windows.Forms.Timer;

namespace Plexdata.TeamRoulette.Controls
{
    public class TextShuffler : Control
    {
        #region Events

        public event EventHandler<EventArgs> PlayingStarted;
        public event EventHandler<EventArgs> PlayingStopped;

        #endregion

        #region Private Fields

        private const String defaultValue = "_____";

        private Int32 duration;
        private Boolean playing;
        private List<String> values;

        private Stopwatch watch;
        private FormsTimer timer;
        private Random charger;

        private String currentValue;

        private Color borderColor;
        private Int32 borderThickness;
        private Color inlayColor;

        #endregion

        #region Construction

        public TextShuffler()
            : base()
        {
            base.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.DoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor,
                true);

            base.SetStyle(
                ControlStyles.Selectable |
                ControlStyles.ContainerControl,
                false);

            this.watch = new Stopwatch();
            this.timer = new FormsTimer();
            this.timer.Tick += this.OnPlayTimerTick;
            this.timer.Interval = 200;

            this.charger = new Random((Int32)(unchecked(DateTime.Now.Ticks & 0x00000000FFFFFFFF)));

            this.currentValue = TextShuffler.defaultValue;

            this.Duration = 3;
            this.BorderColor = Color.IndianRed;
            this.BorderThickness = 6;
            this.InlayColor = Color.WhiteSmoke;

            this.playing = false;
            this.values = new List<String>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets and sets execution time in seconds.
        /// </summary>
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 Duration
        {
            get
            {
                return this.duration / 1000;
            }
            set
            {
                this.CheckDisposed();
                this.CheckPlaying();

                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $"{this.Duration} must be greater than or equal to zero.");
                }

                this.duration = value * 1000;
            }
        }

        /// <summary>
        /// Gets and sets the color of the outer border.
        /// </summary>
        [Browsable(true)]
        [DefaultValue(typeof(Color), "IndianRed")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor
        {
            get
            {
                return this.borderColor;
            }
            set
            {
                this.CheckDisposed();
                this.CheckPlaying();

                if (value == Color.Transparent)
                {
                    throw new NotSupportedException("Transparent is not supported as border color.");
                }

                this.borderColor = value;

                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets and sets the thickness of the outer border.
        /// </summary>
        [Browsable(true)]
        [DefaultValue(6)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 BorderThickness
        {
            get
            {
                return this.borderThickness;
            }
            set
            {
                this.CheckDisposed();
                this.CheckPlaying();

                if (value < 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.BorderThickness), "The border thickness must be in the range from 0 to 10.");
                }

                this.borderThickness = value;

                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets and sets the color of the inlay filling.
        /// </summary>
        [Browsable(true)]
        [DefaultValue(typeof(Color), "WhiteSmoke")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color InlayColor
        {
            get
            {
                return this.inlayColor;
            }
            set
            {
                this.CheckDisposed();
                this.CheckPlaying();

                this.inlayColor = value;

                this.Invalidate();
            }
        }

        /// <summary>
        /// Determines whether the text shuffler is running or not.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Boolean IsPlaying
        {
            get
            {
                return this.playing;
            }
            private set
            {
                this.playing = value;

                if (this.playing)
                {
                    this.timer.Start();
                    this.watch.Restart();

                    this.currentValue = this.GetRandomValue();

                    this.Invalidate();

                    this.PlayingStarted?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    this.timer.Stop();
                    this.watch.Stop();

                    this.currentValue = this.GetResultValue();

                    this.Invalidate();

                    this.PlayingStopped?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets and sets the values from which a random result is determined.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IEnumerable<String> Values
        {
            get
            {
                return this.values;
            }
            set
            {
                this.CheckDisposed();
                this.CheckPlaying();

                this.values = new List<String>();

                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value), $"{this.Values} must not be null.");
                }

                this.values = value.Where(x => !String.IsNullOrWhiteSpace(x)).Distinct().ToList();

                if (!this.values.Any())
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $"{this.Values} must contain at least one item.");
                }
            }
        }

        /// <summary>
        /// Gets the result of the text mingling.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String Result
        {
            get
            {
                return this.currentValue;
            }
        }

        /// <summary>
        /// Indicate whether the result value is valid or not.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Boolean IsValid
        {
            get
            {
                return this.values.Contains(this.currentValue);
            }
        }

        #endregion

        #region Methods

        public void Play()
        {
            this.CheckDisposed();

            if (this.IsPlaying)
            {
                return;
            }

            this.CheckValues();

            this.IsPlaying = true;
        }

        #endregion

        #region Overrides

        protected override void Dispose(Boolean disposing)
        {
            if (disposing)
            {
                this.timer?.Stop();
                this.timer?.Dispose();
                this.timer = null;

                this.watch?.Stop();
                this.watch = null;
            }

            base.Dispose(disposing);
        }

        protected override void OnPaint(PaintEventArgs args)
        {
            Graphics graphics = args.Graphics;
            GraphicsState state = graphics.Save();

            try
            {
                graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

                this.RenderShuffleText(graphics, this.currentValue);
                this.RenderResultFrame(graphics);
            }
            finally
            {
                graphics.Restore(state);
            }
        }

        #endregion

        #region Handlers

        private void OnPlayTimerTick(Object? sender, EventArgs arg)
        {
            if (this.IsExpired())
            {
                this.IsPlaying = false;
                return;
            }

            this.currentValue = this.GetRandomValue();

            this.Invalidate();
        }

        #endregion

        #region Rendering

        private void RenderShuffleText(Graphics graphics, String text)
        {
            Rectangle bounds = this.GetInlayBounds();

            if (bounds.Height < 1 || bounds.Width < 1)
            {
                return;
            }

            if (this.InlayColor != Color.Transparent)
            {
                using (Brush brush = new SolidBrush(this.InlayColor))
                {
                    graphics.FillRectangle(brush, bounds);
                }
            }

            Single pixelsPerPoint = graphics.DpiY / 72.0F;
            Single fontHeight = (bounds.Height * 0.5F) / pixelsPerPoint;

            using (StringFormat format = StringFormat.GenericTypographic)
            {
                using (Font font = new Font(base.Font.FontFamily, fontHeight, FontStyle.Bold, GraphicsUnit.Pixel))
                {
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;
                    format.FormatFlags = StringFormatFlags.NoWrap;

                    using (Brush brush = new SolidBrush(base.ForeColor))
                    {
                        graphics.DrawString(text, font, brush, bounds, format);
                    }
                }
            }
        }

        private void RenderResultFrame(Graphics graphics)
        {
            if (this.BorderThickness > 0)
            {
                using (Pen p = new Pen(this.BorderColor, this.BorderThickness))
                {
                    graphics.DrawRectangle(p, this.GetBorderBounds());
                }
            }
        }

        #endregion

        #region Helpers

        private void CheckDisposed()
        {
            if (base.IsDisposed)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
        }

        private void CheckPlaying([CallerMemberName] String property = null)
        {
            if (this.IsPlaying)
            {
                throw new InvalidOperationException($"Property '{property}' cannot be changed while playing is active.");
            }
        }

        private void CheckValues()
        {
            if (!this.values?.Any() ?? true)
            {
                throw new InvalidOperationException($"Property '{nameof(this.Values)}' cannot be null or empty.");
            }
        }

        private Rectangle GetBorderBounds()
        {
            Int32 t = this.BorderThickness;

            Int32 x = 0;
            Int32 y = 0;
            Int32 w = this.ClientRectangle.Width;
            Int32 h = this.ClientRectangle.Height;

            x += t / 2;
            y += t / 2;
            w -= t;
            h -= t;

            return new Rectangle(x, y, w, h);
        }

        private Rectangle GetInlayBounds()
        {
            Int32 t = 4 * this.BorderThickness;

            Rectangle rectangle = this.GetBorderBounds();

            Int32 x = rectangle.X;
            Int32 y = rectangle.Y;
            Int32 w = rectangle.Width;
            Int32 h = rectangle.Height;

            x += t / 2;
            y += t / 2;
            w -= t;
            h -= t;

            return new Rectangle(x, y, w, h);
        }

        private String GetRandomValue()
        {
            String result = String.Empty;

            if (this.values.Count > 1)
            {
                do
                {
                    result = this.GetResultValue();
                }
                while (result == this.currentValue);
            }
            else
            {
                result = this.values[0];
            }

            return result;
        }

        private String GetResultValue()
        {
            return this.values[this.charger.Next(0, this.values.Count)];
        }

        private Boolean IsExpired()
        {
            return this.watch.ElapsedMilliseconds + this.timer.Interval >= this.duration;
        }

        #endregion
    }
}
