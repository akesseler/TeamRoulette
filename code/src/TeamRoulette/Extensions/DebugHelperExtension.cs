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

using Plexdata.TeamRoulette.Settings;
using System.Diagnostics;

namespace Plexdata.TeamRoulette.Extensions
{
    internal static class DebugHelperExtension
    {
        public static void Dump(this ApplicationSettings settings)
        {
            if (settings is null)
            {
                return;
            }

            settings.Roulette.Dump();
        }

        public static void Dump(this Roulette roulette)
        {
            if (roulette is null)
            {
                return;
            }

            Debug.WriteLine(roulette.Team);

            roulette.Teams.Dump();
        }

        public static void Dump(this IList<Team> teams)
        {
            if (!teams?.Any() ?? true)
            {
                return;
            }

            foreach (Team team in teams)
            {
                team.Dump();
            }
        }

        public static void Dump(this Team team)
        {
            if (team is null)
            {
                return;
            }

            Debug.WriteLine(team);

            team.Members.Dump();
        }

        public static void Dump(this IList<Member> members)
        {
            foreach (Member member in members)
            {
                member.Dump();
            }
        }

        public static void Dump(this Member member)
        {
            if (member is null)
            {
                return;
            }

            Debug.WriteLine($"\t{member}");
        }
    }
}
