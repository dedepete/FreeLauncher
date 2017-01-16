using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace dotMCLauncher.Core
{
    public class RawVersionListManifest
    {
        [JsonProperty("latest")] public RawVersionListManifestLatest LatestVersions;
        [JsonProperty("versions")] public List<RawVersionListManifestEntry> Versions;

        public List<RawVersionListManifestEntry> GetVersionsByType(string type, RawVersionListManifestSortMethod sorting = RawVersionListManifestSortMethod.INCLUDE)
            => Versions.Where(x => sorting == RawVersionListManifestSortMethod.INCLUDE
                ? x.ReleaseType == type
                : x.ReleaseType != type).ToList();

        public List<RawVersionListManifestEntry> GetVersionsByType(string[] types, RawVersionListManifestSortMethod sorting = RawVersionListManifestSortMethod.INCLUDE)
            => Versions.Where(x => sorting == RawVersionListManifestSortMethod.INCLUDE
                ? types.Contains(x.ReleaseType)
                : !types.Contains(x.ReleaseType)).ToList();

        public static RawVersionListManifest ParseList(string content)
        {
            RawVersionListManifest manifest =
                (RawVersionListManifest)
                JsonConvert.DeserializeObject(content, typeof(RawVersionListManifest));
            return manifest;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

    public enum RawVersionListManifestSortMethod
    {
        INCLUDE,
        EXCLUDE
    }
}
