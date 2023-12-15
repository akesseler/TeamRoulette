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
    internal class ApplicationSettings : ICloneable
    {
        #region Private Fields

        private Shuffler shuffler = null;
        private Roulette roulette = null;
        private readonly IList<Statistic> statistics = new List<Statistic>();

        #endregion

        #region Construction

        public ApplicationSettings()
            : base()
        {
            this.Shuffler = new Shuffler();
            this.Roulette = new Roulette();
        }

        private ApplicationSettings(ApplicationSettings other)
            : this()
        {
            this.Roulette = other.Roulette;
        }

        #endregion

        #region Properties

        public Shuffler Shuffler
        {
            get
            {
                return this.shuffler;
            }
            set
            {
                this.shuffler = (Shuffler)value?.Clone() ?? new Shuffler();
            }
        }

        public Roulette Roulette
        {
            get
            {
                return this.roulette;
            }
            set
            {
                this.roulette = (Roulette)value?.Clone() ?? new Roulette();
            }
        }

        public IList<Statistic> Statistics
        {
            get
            {
                return this.statistics;
            }
            set
            {
                this.statistics.Clear();

                if (value?.Any() ?? false)
                {
                    foreach (Statistic statistic in value)
                    {
                        if (statistic is not null)
                        {
                            this.statistics.Add(statistic);
                        }
                    }
                }
            }
        }

        #endregion

        #region ICloneable

        public Object Clone()
        {
            return new ApplicationSettings(this);
        }

        #endregion
    }
}
