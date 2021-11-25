using Xunit;

namespace StronglyTypedIds.Tests
{
    public class EmbeddedResourceTests
    {
        [Fact]
        public void StronglyTypedIdAttributeSource_IsSameAsCompiledSource()
        {
            var embeddedInGenerator = GetEmebeddedResource(EmbeddedSources.StronglyTypedIdAttributeSource);
            var compiledInGenerator = GetCompiledResource("StronglyTypedIdAttribute");

            Assert.Equal(embeddedInGenerator, compiledInGenerator);
        }

        [Fact]
        public void StronglyTypedIdDefaultsAttributeSource_IsSameAsCompiledSource()
        {
            var embeddedInGenerator = GetEmebeddedResource(EmbeddedSources.StronglyTypedIdDefaultsAttributeSource);
            var compiledInGenerator = GetCompiledResource("StronglyTypedIdDefaultsAttribute");

            Assert.Equal(embeddedInGenerator, compiledInGenerator);
        }

        [Fact]
        public void StronglyTypedIdBackingTypeSource_IsSameAsCompiledSource()
        {
            var embeddedInGenerator = GetEmebeddedResource(EmbeddedSources.StronglyTypedIdBackingTypeSource);
            var compiledInGenerator = GetCompiledResource("StronglyTypedIdBackingType");

            Assert.Equal(embeddedInGenerator, compiledInGenerator);
        }

        [Fact]
        public void StronglyTypedIdConverterSource_IsSameAsCompiledSource()
        {
            var embeddedInGenerator = GetEmebeddedResource(EmbeddedSources.StronglyTypedIdConverterSource);
            var compiledInGenerator = GetCompiledResource("StronglyTypedIdConverter");

            Assert.Equal(embeddedInGenerator, compiledInGenerator);
        }

        [Fact]
        public void StronglyTypedIdImplementationsSource_IsSameAsCompiledSource()
        {
            var embeddedInGenerator = GetEmebeddedResource(EmbeddedSources.StronglyTypedIdImplementationsSource);
            var compiledInGenerator = GetCompiledResource("StronglyTypedIdImplementations");

            Assert.Equal(embeddedInGenerator, compiledInGenerator);
        }

        static string GetCompiledResource(string filename)
        {
            return TestHelpers.LoadEmbeddedResource($"StronglyTypedIds.Tests.Sources.{filename}.cs")
                .Replace("namespace StronglyTypedIds.Sources", "namespace StronglyTypedIds")
                .Replace("public sealed class ", "internal sealed class ")
                .Replace("public enum ", "internal enum ");
        }

        static string GetEmebeddedResource(string resource)
            => resource.Replace(@"    [System.Diagnostics.Conditional(""STRONGLY_TYPED_ID_USAGES"")]
", string.Empty).Replace(@"#if !STRONGLY_TYPED_ID_EXCLUDE_ATTRIBUTES
", string.Empty).Replace(@"
#endif // STRONGLY_TYPED_ID_EXCLUDE_ATTRIBUTES", string.Empty);
    }
}