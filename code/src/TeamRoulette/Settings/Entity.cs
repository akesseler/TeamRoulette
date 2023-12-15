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
    public abstract class Entity
    {
        #region Construction

        protected Entity(Entity other)
        {
            this.Name = other.Name;
            this.Active = other.Active;
        }

        protected Entity(String name, Boolean active)
        {
            this.Name = name ?? String.Empty;
            this.Active = active;
        }

        #endregion

        #region Properties

        public virtual Boolean Active { get; set; }

        public String Name { get; set; }

        #endregion

        #region Overrides

        public override String ToString()
        {
            return $"{nameof(Type)}: {this.GetType().Name}, {nameof(this.Name)}: {this.Name}, {nameof(this.Active)}: {this.Active}";
        }

        #endregion
    }
}
