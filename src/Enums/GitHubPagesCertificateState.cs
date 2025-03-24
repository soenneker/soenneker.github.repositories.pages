using Intellenum;

namespace Soenneker.GitHub.Repositories.Pages.Enums;

/// <summary>
/// Represents the state of the HTTPS certificate for GitHub Pages.
/// </summary>
[Intellenum<string>]
public partial class GitHubPagesCertificateState
{
    public static readonly GitHubPagesCertificateState New = new("new");
    public static readonly GitHubPagesCertificateState AuthorizationCreated = new("authorization_created");
    public static readonly GitHubPagesCertificateState AuthorizationPending = new("authorization_pending");
    public static readonly GitHubPagesCertificateState Authorized = new("authorized");
    public static readonly GitHubPagesCertificateState AuthorizationRevoked = new("authorization_revoked");
    public static readonly GitHubPagesCertificateState Issued = new("issued");
    public static readonly GitHubPagesCertificateState Uploaded = new("uploaded");
    public static readonly GitHubPagesCertificateState Approved = new("approved");
    public static readonly GitHubPagesCertificateState Errored = new("errored");
    public static readonly GitHubPagesCertificateState BadAuthz = new("bad_authz");
    public static readonly GitHubPagesCertificateState DestroyPending = new("destroy_pending");
    public static readonly GitHubPagesCertificateState DnsChanged = new("dns_changed");
}