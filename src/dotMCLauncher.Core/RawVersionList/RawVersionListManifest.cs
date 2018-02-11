using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Newtonsoft.Json;

namespace dotMCLauncher.Core
{
    public class RawVersionListManifest
    {
        [JsonProperty("latest")] public RawVersionListManifestLatest LatestVersions { get; set; }
        [JsonProperty("versions")] public List<RawVersionListManifestEntry> Versions { get; set; }

        public List<RawVersionListManifestEntry> GetVersionsByType(string type)
            => GetVersionsByType(type, RawVersionListManifestSortMethod.INCLUDE);

        public List<RawVersionListManifestEntry> GetVersionsByType(string type, RawVersionListManifestSortMethod sorting)
            => Versions.Where(x => sorting == RawVersionListManifestSortMethod.INCLUDE
                ? x.ReleaseType == type
                : x.ReleaseType != type).ToList();

        public List<RawVersionListManifestEntry> GetVersionsByTypes(string[] types)
            => GetVersionsByTypes(types, RawVersionListManifestSortMethod.INCLUDE);

        public List<RawVersionListManifestEntry> GetVersionsByTypes(string[] types, RawVersionListManifestSortMethod sorting)
            => Versions.Where(x => sorting == RawVersionListManifestSortMethod.INCLUDE
                ? types.Contains(x.ReleaseType)
                : !types.Contains(x.ReleaseType)).ToList();

        public RawVersionListManifestEntry GetVersion(string version)
        {
            return Versions.Count(x => x.VersionId == version) == 1
                ? Versions.Where(x => x.VersionId == version).ToArray()[0]
                : null;
        }

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
