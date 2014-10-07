﻿namespace Roslyn.Services.Shared.Utilities
{
    /// <summary>
    /// NOTE(cyrusn): The pattern matcher is threadsafe.  However, it maintains an internal cache of
    /// information as it is used.  Therefor, you should not keep it around forever and should get
    /// and release the matcher appropriately once you no longer need it.
    /// </summary>
    internal class VisualBasicPatternMatcher : AbstractPatternMatcher
    {
        public VisualBasicPatternMatcher() 
            : base(caseSensitive: false)
        {
        }

        protected override int CompareMatchResultsWorker(MatchResult result1, MatchResult result2)
        {
            int diff;
            if ((diff = CompareType(result1, result2)) != 0 ||
                (diff = CompareCamelCase(result1, result2)) != 0 ||
                (diff = CompareCase(result1, result2)) != 0)
            {
                return diff;
            }

            return 0;
        }
    }
}