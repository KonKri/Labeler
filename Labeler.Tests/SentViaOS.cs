using Labeler.Core.Attributes;

namespace Labeler.Tests
{
    enum SentViaOS
    {
        [Label("Sent via iOS 12")]
        [Label("Sent via iOS 13")]
        [Label("Sent via iOS 14")]
        SentViaIOS,

        [Label("Sent via Android 9")]
        [Label("Sent via Android 10")]
        [Label("Sent via Android 11")]
        SentViaAndroid,

        [Label("Send via Windows")]
        SentViaWindows,

        SentViaUbuntu
    }
}
