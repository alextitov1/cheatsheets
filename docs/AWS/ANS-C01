Availability Zone ID

Public Services - AWS IAM; AMAZON SQS; AMAZON S3

Private Services - VPC, VPC Endpoints


HA (Highly available) - your system will almost maintain uptime; guarantees essential services uptime, NOT full functionality

FT (Fault Tolerant) - your system can continue to operate regardless of disruption


# VPC

Virtual Private Cloud (VPC) - lets you provision a logically isolated section of the AWS Cloud:
  * Soft limit: 5 VPC in single region in a single account
  * Best Practice is a multi-account strategy. (not VPC)
  * Don't use default VPC for production workloads

## VPC Router
VPC Routers are highly available devices and it occupies the .1 addressing space on every subnet associated with our VPC.

5 reserved IPs in each subnet:
* 10.0.64.0 - network address
* 10.0.64.1 - VPC router
* 10.0.64.2 - DNS Server
* 10.0.64.3 - Reserved by AWS for future use.
* 10.0.71.255/21 - Network broadcast address (AWS doesn't support broadcast)

## Route Tables
You can influence the routing for your VPC by editing the main route table or creating custom route tables for each of your subnets.



## Internet Gateway(IGW)
- public to private IP address mapping 
  * Resource must have a public IP.
  * There must be a router entry for the IGW.
### Egress-Only Internet Gateway
- acts like a NAT gateway for IPv6 compute

## Nat Instance (legacy)
Lives in a public subnet;

Non-public subnets use it as a default rule

Disable check source/destination flag

## NAT Gateway
up to 45 GBit/s
Zone-independent architectures
Need one per AZ

### Private NAT Gateway
* No elastic IPs
* Private traffic is routed from a private NAT gateway through a VGW or TGW

Use case: Non-routable IP Ranges (Overlapping)

## Transit gateway (TGW)
## Virtual Private Gateway(VGW)
## ENI (Elastic Network Interface)
## EIP (Elastic IP)
  * 5 IPs limit


## Classless Inter-Domain Routing (CIDR)

How to cal the number of available IPs e.g.: 
  * /27 subnet = 2^(32-27)-5(reserved IPs) = 27
  * /24 subnet = 2^(32-24)-5 = 2^8-5 = 256-5 = 251

## IPv4 va IPv6

IPv4:
  * required for all VPCs.
  * You have a choice between a size of /16 to /28 CIDR block.
  * You can choose the private CIDR block.
  * Public and private addresses are a thing.

IPv6:
  * Fixed size of /56 CIDR blocks (when using AWS-assigned ranges).
  * Using AWS-owned ranges means you cannot select the assigned CIDR block.
  * You associate a /64 block to each subnet.
  * No difference in public and private addresses. Security is controlled with routing and security.

> Address spaces are binary!

## Subnets
>Public, Private or VPN only

Private ranges:
* 192.168.0.0 - 192.168.255.255 (offers 1 /16 range)
* 172.16.0.0 - 172.31.255.255   (offers 2 /16 ranges)
* 10.0.0.0 - 10.255.255.255     (offers 256 /16 ranges)

Ephemeral ports:
* Linux 32768-61000
* Windows 49152-65535
* AWS NAT Gateway 1024-65535

### Network Access Control Lists(NACLs)
Applied at the subnet level;

Stateless;

Can specify both allow and deny rules;

Traffic is processed before it enters or leaves the subnet.


### Security Groups
> also works like an IP list
Applied at the resource level (ENI)

Stateful;

Can specify allow rules, but not deny rules;

Scoped to VPC;

Can be applied to:
* EC2 instances
* RDS instances
* Elastic load balancers
* etc

Supports `self-referencing` feature

## VPC Endpoints (VPCE)
VPC-EID: identifier of the endpoint (vpce-xyz)
pl-id s3 (prefix list) ????

limits:
* Endpoints are a reginal service
* Endpoints are not extendable across VPC boundaries
* DNS resolution is Required
* Default VPC Endpoint **Policy** is unrestricted


### Interface Endpoints
* ENI with a private IP address.
* Powered by AWS PrivateLink.

Services: API Gateway, Athena, Kinesis, etc.

### Gateway Endpoints
* Gateway specify as a target in a route table

Gateway endpoints do NOT support hybrid connectivity!
Leverage interface endpoints for this.

Services: S3, DynamoDB

Free??

## VPC Peering
pcx-abc

limits:
* no transitive peering allowed
* You can reference security group IDs across peering connections only if the VPCs are in the same AWS Region!

## VPC Flow Logs

- Flow logs may be defined for:
  * VPCs
  * Subnets
  * ENIs
- Flow log definitions apply to all ENIs within scope.
- Traffic will be logged separately for each definition.

- Flow log data may be sent to:
  * CloudWatch log group
    * 1 log stream per ENI
  * S3 bucket
    * 1 log file object per-publication
  
limitations:
  * Does not capture all IP traffic
    * EC2 DNS requests to Route 53
    * Amazon Windows license activation
    * Instance metadata
    * Amazon Time Sync Service
    * DHCP traffic
    * Default VPC router (only source and destination ENI)
    * Endpoint services created by AWS customers
  * Does not capture application data (operates at l3 and l4 of OSI)

### Flow logs formats

  - version 2:
    * version
    * account-id
    * interface-id
    * srcaddr
    * dstaddr
    * srcport
    * dstport
    * protocol
    * packets
    * bytes
    * start
    * end
    * action
    * log-status
  - version 3:
    * vpc-id
    * subnet-id
    * instance-id
    * tcp-flags
    * type
    * pkt-srcaddr
    * pkt-dstaddr
  - version 4:
    * region
    * az-id
    * sublocation-type
    * sublocation-id
  - version 5:
    * pkt-src-aws-service
    * pkt-dst-aws-service
    * flow-direction
    * traffic-path

## VPC Traffic Mirroring

## Reachability Analyzer (AWS Network Manager)

VPC tool for performing connectivity testing between a source and destination involving your AWS VPC resources. Create paths for analysis.

## BYOIP

Import your IP space into AWS and then grant AWS the ability to advertise via BGP using their ASNs of 16509 and 14618.
Use cases:
* Hardcoded Dependencies
* Allow List
* Compliance Requirements
* On-Premises IPv6 Policy
* IP Reputations

limits:
* the most specific IPv4 address range that you can bring is a /24
* the most specific **publicly advertised** IPv6 range that you can bring is /48. **Non-publicly advertised** IPv6 range can be /56.
* Each address range can only belong to one Region at a time.
* You are allowed five BYOIP ranges per Region per AWS account.
* No support for Local Zones, Wavelength Zone, AWS Outposts.

# Bastion host (Jump Server)
* Server running at the **edge of a network**
* Bastion and their firewalls can be leveraged to perform **port forwarding**
* Bastion hosts should be locked down to a small set of allowed users.


# AWS Systems Manager - Session Manager
* Agent-based (SSM agent) management of all managed instances, edge devices, and managed on-premises VM.
* No more SSH or RDP required, port forwarding still supported.
* Centralized access control via IAM policies.


# HPC (high performance connectivity)

* Enhanced networking uses single root I/O virtualization
* Clustering placement groups packs instances close together
* Enabling Enhanced Networking - jumbo frames

Instance Types:
* Elastic Network Adapter (ENA) - up to 100 Gbps
* Intel 82599 Virtual Function (VF) interface - up to 10 Gbps

# AWS Cloud WAN
Helps centrally build, manage, and monitor global networks.

* Core network policy: Declarative document applied to core network capturing intent. Defines all segments, regional routing, and attachments.
* Attachments: Any connection or resource added to your core network. VPCs, VPNs, and TGW attachments.
* Core network edge: Regional connection point managed by AWS in each of your Regions. AWS Transit Gateway behind scenes.
* Network segments: Dedicated routing domains.
* Segment actions: Define how routing works between segments.

## Global Network
Single, private network serving as high-level container for network objects

## Core Network
Part of it is manged by AWS, including regional connections (VPNs, VPC, TGWs)

# GuardDuty
GuardDuty is a security service that continuously monitors your AWS accounts for malicious activity. It uses threat intelligence and machine learning to analyze various data sources like logs and network traffic. GuardDuty helps you identify and respond to potential threats in your AWS environment.

# AWS Shield
AWS Shield is a managed Distributed Denial of Service (DDoS) protection service that safeguards applications running on AWS.

## AWS Shield Standard
AWS Shield Standard primarily mitigates attacks that occur at Layer 3 of the OSI model.


# AWS Web Application Firewall (WAF)
AWS Web Application Firewall mitigates attacks that primarily occur at Layer 7 (the Application Layer) of the OSI model.

# AWS Config
AWS Config is a service that enables you to assess, audit, and evaluate the configurations of your AWS resources. Config continuously monitors and records your AWS resource configurations and allows you to automate the evaluation of recorded configurations against desired configurations.

# AWS Firewall Manager
AWS Firewall Manager enforces deployment of Web Application Firewall ACLs,

