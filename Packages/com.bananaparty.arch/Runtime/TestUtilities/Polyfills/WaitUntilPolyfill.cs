// This is a copy of WaitUntil.cs from Unity 6, to make it available in Unity 2022.3.

using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace BananaParty.Arch.TestUtilities.Polyfills
{
    /// <summary>
    /// Suspends the coroutine execution until the supplied delegate evaluates to true.
    /// </summary>
    public sealed class WaitUntilPolyfill : CustomYieldInstruction
    {
        private readonly Func<bool> m_Predicate;

        private readonly Action m_TimeoutCallback;

        private readonly WaitTimeoutMode m_TimeoutMode;

        private readonly double m_MaxExecutionTime = -1.0;

        public override bool keepWaiting
        {
            get
            {
                if (m_MaxExecutionTime == -1.0)
                {
                    return !m_Predicate();
                }

                if (GetTime() > m_MaxExecutionTime)
                {
                    m_TimeoutCallback();
                    return false;
                }

                return !m_Predicate();
            }
        }

        public WaitUntilPolyfill(Func<bool> predicate)
        {
            m_Predicate = predicate;
        }

        public WaitUntilPolyfill(Func<bool> predicate, TimeSpan timeout, Action onTimeout, WaitTimeoutMode timeoutMode = WaitTimeoutMode.Realtime) : this(predicate)
        {
            if (timeoutMode == WaitTimeoutMode.InGameTime && !Application.isPlaying)
            {
                throw new ArgumentException("InGameTime mode is not supported in Editor in edit mode", "timeoutMode");
            }

            if (timeout <= TimeSpan.Zero)
            {
                throw new ArgumentException("Timeout must be greater than zero", "timeout");
            }

            m_TimeoutCallback = onTimeout ?? throw new ArgumentNullException("onTimeout", "Timeout callback must be specified");
            m_TimeoutMode = timeoutMode;
            m_MaxExecutionTime = GetTime() + timeout.TotalSeconds;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private double GetTime()
        {
            return (m_TimeoutMode == WaitTimeoutMode.InGameTime) ? Time.timeAsDouble : Time.realtimeSinceStartupAsDouble;
        }
    }
}
