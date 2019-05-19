using NUnit.Framework;
using FluentAssertions;
using Shortify;
using Shortify.Library;
using System;

namespace Shortify.Tests
{
    public class URLNormalizerTest
    {
        [TestCase("asdf1234fkkk")]
        [TestCase("  89(&#@ 839  ;;;;;")]
        [TestCase("")]
        [TestCase("foo")]
        [TestCase("//////localhost")]
        [TestCase("//www.example.com/")]
        [TestCase("! www.example.com")]
        [TestCase("1111111111111")]
        [TestCase("#######/////////")]
        [TestCase(":// should fail")]
        [TestCase("http://.www.foo.bar./")]
        public void ShouldFailOnInvalidURL(string url)
        {
            Action normalize = () => URLNormalizer.Normalize(url);
            normalize.Should().Throw<Exception>();
        }

        [TestCase("http://www.example.com/", ExpectedResult = "http://www.example.com/")]
        [TestCase("hTtP://wWw.exAMple.Com", ExpectedResult = "http://www.example.com/")]
        [TestCase("  hTtPs://ZZ.zz ", ExpectedResult = "https://zz.zz/")]
        [TestCase("http://wWw.example.com/asd/foo", ExpectedResult = "http://www.example.com/asd/foo")]
        [TestCase("http://www.example.com/", ExpectedResult = "http://www.example.com/")]
        [TestCase("www.example.com", ExpectedResult = "https://www.example.com/")]
        [TestCase("www.example.com/", ExpectedResult = "https://www.example.com/")]
        [TestCase("www.google.com ", ExpectedResult = "https://www.google.com/")]
        [TestCase("www.google.com/Foo%20Bar/asd", ExpectedResult = "https://www.google.com/Foo Bar/asd")]
        [TestCase("aaaaaaa.aaaaa.aaaa/#3&d81hjd", ExpectedResult = "https://aaaaaaa.aaaaa.aaaa/#3&d81hjd")]
        [TestCase("www.foo", ExpectedResult = "https://www.foo/")]
        [TestCase("xx.foo.xx", ExpectedResult = "https://xx.foo.xx/")]
        [TestCase(" a/a/a/a.c", ExpectedResult = "https://a/a/a/a.c")]
        [TestCase("www.foo", ExpectedResult = "https://www.foo/")]
        [TestCase("https://उदाहरण.परीक्ष/", ExpectedResult = "https://उदाहरण.परीक्ष/")]
        [TestCase("http://foo.com/blah_blah_(wikipedia)_(again)", ExpectedResult = "http://foo.com/blah_blah_(wikipedia)_(again)")]
        [TestCase("https://WWW.FOO/?a=3&b=3#69", ExpectedResult = "https://www.foo/?a=3&b=3#69")]
        [TestCase("http://useRid@exaMple.com:8080/", ExpectedResult = "http://useRid@example.com:8080/")]
        [TestCase("HTTP://FOO.COM/Unicode_(✪)_in_parens", ExpectedResult = "http://foo.com/Unicode_(✪)_in_parens")]
        [TestCase("http://-.~_!$&'()*+,;=:%40:80%2f::::::@example.com", ExpectedResult = "http://-.~_!$&'()*+,;=:%40:80%2f::::::@example.com/")]
        [TestCase("http://1.1.1.1", ExpectedResult = "http://1.1.1.1/")]
        [TestCase("1.1.1.1", ExpectedResult = "https://1.1.1.1/")]
        [TestCase("http://foo.bar/foo(bar)baz quux", ExpectedResult = "http://foo.bar/foo(bar)baz quux")]
        [TestCase("http://foo.bar?q=Spaces asd asd asd", ExpectedResult = "http://foo.bar/?q=Spaces asd asd asd")]
        [TestCase("htps:/gogle.com", ExpectedResult = "https://htps/gogle.com")]

        public string ShouldCorrectlyNormalizeURL(string url)
        {
            return URLNormalizer.Normalize(url);
        }
    }
}
