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

using Newtonsoft.Json;
using System.ComponentModel;
using System.Globalization;

namespace Plexdata.TeamRoulette.Settings
{
    internal class Statistic : Entity, ICloneable
    {
        #region Private Fields

        private DateTime date;
        private String team;

        #endregion

        #region Construction

        public Statistic() : this(null, null) { }

        public Statistic(String name, String team)
            : base(name, false)
        {
            this.Team = team;
            this.Date = DateTime.Now;
        }

        private Statistic(Statistic other)
            : base(other)
        {
            this.Team = other.Team;
            this.Date = other.Date;
        }

        #endregion

        #region Properties

        [JsonIgnore]
        [Browsable(false)]
        public override Boolean Active
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        public String Team
        {
            get
            {
                return this.team;
            }
            set
            {
                this.team = value ?? String.Empty;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = new DateTime(value.Year, value.Month, value.Day);
            }
        }

        [JsonIgnore]
        public Int32 Week
        {
            get
            {
                return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(this.Date, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            }
        }

        #endregion

        #region ICloneable

        public Object Clone()
        {
            return new Statistic(this);
        }

        #endregion
    }
}
