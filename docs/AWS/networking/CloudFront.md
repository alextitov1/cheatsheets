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

## Cache behaviors settings
* Precedence - the order of precedence for evaluating behaviors (which cache behavior preferred over another)
* Path Pattern - request path pattern the cache behavior will apply to. Example: *.gif
* Origin/Origin Groups - which origin/origin group the request are routed to
* Viewer Protocol Policy - which protocol policy you want to use for edge locations
* Restrict Viewer Access - require use of signed URLs or signed cookies

# TLS/HTTP implementation
* supports CNAMEs
* supports SNI
* Native ACM integration. Certs MUST be issued in ua-east-1

**Viewer protocol** - protocol user uses

**Origin protocol** - cloudfront uses to connection to origins

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

# Private viewer

Signed URLs (take precedence)

Signed Cookies

# CloudFront Field-Level Encryption

Additional layer of security for protecting data throughout a process/request within CloudFront.

* help to protect sensitive data within CloudFront
* Information is encrypted at the edge and remains encrypted throughout
* completely separate from the actual HTTP/S tunnels
* Uses a public and private key pair for all encryption/decryption

## Configuration steps

* Cet your public and private key pair
* Create field-level encryption config
* Create field-level encryption profile
* Link to a cache behavior 

# CloudFront Geo Blocking

## CloudFront Built-it Feature

Restricts all access to files associated with a distribution. Restricts at a **country** level.

- allow list
- deny list
- returns 403.
- Third-party database leveraged that offers 99.8% accuracy

## Third-Party Service

Restricts access to a subset of files. Usually allows for finer granularity than country-level restrictions.

- Restriction requirements that do not require entire countries

# Invalidating and Expiring Files within Amazon CloudFront

## Control Caching Durations

- By default(24 hours), CloudFront servers a cached file until the specified cache duration.
- After expiration, **origin fetch** occurs to update cached data.
- Cache hit (returns 304 Not Modified): CloudFront has the lates version for immediate return.
- Cache miss (returns 200 Ok): CloudFront retrieves lates version from origin.

## Cache TTL Header Examples

12-Hours TTL Using Cache-Control
```
Key: Cache Control
Value: maxage:43200
```

Specific Data Using Expires
```
Key: Expires
Value: Mon, 1 Jan 2024 06:00:00 GMT
```

## Invalidate Files
Remove cached files to force origin fetch before specified object TTL.

Two options:
 - Invalidation: Specify the path you want to invalidate (URL/files/*.png)
 - Versioning: Provide version names in files for best control (acloudguru_v3.png)

# CloudFront Lambdas

## Lambda at Edge
- lives within lambdas
- an extension of the AWS Lambda service
- must be in us-east-1
- executes at edge locations - precess request closer to viewers for reduced latency
- allows for interception of request and responses for customizations
- node.js or python
- scale automatically up to thousand request per sec

## CloudFront Functions Overview
- native functions that live entirely within CloudFront
- Can only be written in JavaScript
- Extremely **similar use cases** to Lambda@Edge
- Leverage CloudFront Functions and Lambda@Edge if desired
- Best latency - sub-millisecond startup and millions of request per second