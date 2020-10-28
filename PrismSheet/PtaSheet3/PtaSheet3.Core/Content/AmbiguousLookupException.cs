using System;

namespace PtaSheet3.Core.Content
{

    /// <summary>
    ///     An <see cref="AmbiguousLookupException"/> is thrown whenever a lookup in a provider results in more than one item being possibly returned.
    ///     The expectation of the caller is to then use a method that will result in a less ambiguous lookup attempt or use a method that can handle
    ///     returning more than one result.
    /// </summary>
    public sealed class AmbiguousLookupException : Exception { }

}
