# Core ELB Concepts (non-GWLB)
 
* Each ELB works with a single VPC.
* ELBs must be configured to work in at least one AZ.
  - Use at least two AZ to support HA.

* Requests are sent to AWS-assigned FQDN
  - Public if ELB **scheme** is internet-facing
  - Private if ELB **scheme** is internal


* Listener:
  - Processes that check for connection requests to specific protocols and ports.
  - Matching traffic forwarded to targets.
  - Settings and options vary by ELB type.

* Targe groups:
  * Types(cannot be changed):
    - EC2 Instances
    - IP addresses
    - A single Lambda function
  * Protocols:
    * ALB
      - HTTP
      - HTTPS
    * NLB
      - TCP
      - TLS
      - UDP
      - TCP_UDP
    * GWLB
      - GENEVE

* Worker nodes created in each configured **subnet**.
  * Each node accessed by IP address. (private IPs for internal, public for internet-facing)

* Requests to ELB will be evenly distributed across all nodes.
* Nodes determine which targets receive requests.
  * Routing algorithms:
    - Round robin
    - Least outstanding requests
    - Hash (NLB)
  
* Cross-Zone Load Balancing
  * if disabled: ELB nodes only forward to targets in the same AZ. (disabled by default for: NLB, GWLB, CLB created using GLI/API)
  * if enabled: ELB nodes may forward to targets in any AZ.
  * NO data transfer charges for ALB and CLB

* ELB Access Logging
  * Disabled by default
  * Captures information about requests
  * Records stored in S3 bucket
  * Supported for:
    * ALB
    * CLB
    * NLB for TLS protocol only

## Network load balancer
