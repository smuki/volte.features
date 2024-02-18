using System.Collections.Generic;
using Volte.Features.Contracts;
using Volte.Features.Models;

namespace Volte.Features.Services;

/// <inheritdoc />
public class InstalledFeatureRegistry : IInstalledFeatureRegistry
{
    private readonly IDictionary<string, FeatureDescriptor> _descriptors = new Dictionary<string, FeatureDescriptor>();

    /// <inheritdoc />
    public void Add(FeatureDescriptor descriptor) => _descriptors[descriptor.FullName] = descriptor;

    /// <inheritdoc />
    public IEnumerable<FeatureDescriptor> List() => _descriptors.Values;

    /// <inheritdoc />
    public FeatureDescriptor? Find(string fullName) => _descriptors.TryGetValue(fullName, out var descriptor) ? descriptor : null;
}