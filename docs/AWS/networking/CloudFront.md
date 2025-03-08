# CloudFront

CDN, operates on Level4

# Key Concepts

**Origin Server**: Location of stored content for distributions to use. (S3, EC2, ALB, Lambda, MediaStore, CloudFront Origin Group)

**Distribution**: Configuration telling CloudFront which origin server to use.

**Domain Name**: CloudFront-assigned DNS for use in web requests.

**Edge Location** (aka Point of presents): Geographically-dispersed servers that cache your files.

# Cache
## Missed Cache flow

i.Edge Location Checked, ii. Regional Edge Checked iii. Origin Fetch

## Cache behaviors

**Default cache behavior** - required for all distributions.

Additional cache behaviors to **define responses based on requests**. (Example: Match for specific path pattern, like *.png, and send to S3 origin) Cache behaviors use **one specific origin** based on settings. If you want to use **multiple origins**, you must have a **matching number of cache behaviors**.

# Status codes

**Always cached**: 404, 414: Request-URL too large, 500, 501: Not Implemented, 502: Bad Gateway, 503: Service Unavailable, 504: Gateway Timeout

**Conditionally Cached**: 400: Bad Request, 403, 405: Method Not Allowed, 412: Precondition Failed, 415: Unsupported Media Type


# Origins
S3, EC2, ALB, Lambda, MediaStore, CloudFront Origin Group

Origin access control (OAC) is the successor to an origin access identity (OAI)

OAC supports actions: Using all S3 buckets in all AWS Regions, AWS KMS (SSE-KMS), Dynamic requests (PUT and DELETE) to S3

OAC: 
* Requires an Amazon S3 bucket origin that is NOT a website endpoint. 
* Grant OAC access to bucket via the Amazon S3 bucket policy.
* Must grant access to OAC manually for distribution.
* OAC is a type of identity that is **NOT** a role or user.