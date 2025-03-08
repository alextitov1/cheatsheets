# BGP

* Exterior routing protocol
* Network routes (prefixes) are shared between mutually-configured peers
* No prefixes are automatically shared
* Select the "best" of multiple paths to the same destination
* TCP 179

Interior Gateway Protocol (IGP) - e.g. OSPF

eBGP - exterior 
iBGP - interior; prefix learned from from iBGP not advertised further

## BGP Prefix

BGP Prefix Preference Sequence (Abridged):
* Highest **Weight** (Default for local 32768 (max 16 bit)) "Cisco feature, applied to the prefix on the router, not advertised to peers"
* Highest **Local Preference** (Default is 100) "Like Weight, but advertised to iBGP peers"
* Shortest **AS Path** (Example: 65413 65412 i (i for iBGP)) "AS Path prepending used to set preferred route on VGW side, passed to beyond peers"
* eBGP over iBGP
* Lowest **Metric** (Example: 0) "Not passed to beyond peers"

VGW - alway automatically share all prefixes (unlike real routers)

# ASN - autonomous system numbers

16-bit and 32 bit
* 0 - 65535
* 65536 - 4294967295

Public and private ASNs
* Public ASNs are controlled by the IANA
* 16-bit private range: 64512-65534
* 32-bit private range: 420000000+