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
    internal class Member : Entity, ICloneable
    {
        #region Construction

        public Member() : this(null, true) { }

        public Member(String name) : this(name, true) { }

        public Member(String name, Boolean active) : base(name, active) { }

        private Member(Member other) : base(other) { }

        #endregion

        #region Operators

        public static Boolean operator ==(Member left, Member right)
        {
            return String.Equals(left?.Name, right?.Name, StringComparison.OrdinalIgnoreCase);
        }

        public static Boolean operator !=(Member left, Member right)
        {
            return !(left == right);
        }

        public static Boolean operator ==(Member left, String right)
        {
            return String.Equals(left?.Name, right, StringComparison.OrdinalIgnoreCase);
        }

        public static Boolean operator !=(Member left, String right)
        {
            return !(left == right);
        }

        #endregion

        #region Overrides

        public override Boolean Equals(Object? other)
        {
            return this == (other as Member);
        }

        public override Int32 GetHashCode()
        {
            return this.Name?.GetHashCode() ?? base.GetHashCode();
        }

        #endregion

        #region ICloneable

        public Object Clone()
        {
            return new Member(this);
        }

        #endregion
    }
}
