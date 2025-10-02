
#nullable disable
using System;
using System.Collections.Generic;

namespace GYM.EF.Models;

public partial class ExternalProviders
{
    public Guid ProviderId { get; set; }

    public Guid UserId { get; set; }

    public string ProviderName { get; set; }

    public string ExternalUserId { get; set; }

    public string AccessToken { get; set; }

    public string RefreshToken { get; set; }

    public DateTime? ExpiresAt { get; set; }

    public DateTime? LastSyncAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Users User { get; set; }
}