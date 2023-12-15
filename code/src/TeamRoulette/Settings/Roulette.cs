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
    internal class Roulette : ICloneable
    {
        #region Private Fields

        private readonly IList<Team> teams = new List<Team>();

        #endregion

        #region Construction

        public Roulette() : base() { }

        private Roulette(Roulette other)
            : this()
        {
            this.Team = other.Team;
            this.Teams = other.Teams?.Select(x => (Team)x.Clone()).ToList();
        }

        #endregion

        #region Properties

        public String Team { get; set; }

        public IList<Team> Teams
        {
            get
            {
                return this.teams;
            }
            set
            {
                this.teams.Clear();

                if (value?.Any() ?? false)
                {
                    foreach (Team team in value)
                    {
                        if (team is not null)
                        {
                            this.teams.Add(team);
                        }
                    }
                }
            }
        }

        #endregion

        #region ICloneable

        public Object Clone()
        {
            return new Roulette(this);
        }

        #endregion
    }
}
